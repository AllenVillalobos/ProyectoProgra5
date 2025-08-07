using Proyecto.DAO;
using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.Paginas
{
    public partial class Login : System.Web.UI.Page
    {
        UsuarioDAO usuarioDAO = new UsuarioDAO();
        ListaRolesDAO listaRolesDAO = new ListaRolesDAO(); 
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void btnLoginClick(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            if (String.IsNullOrEmpty(txtUsuario.Text) || String.IsNullOrEmpty(txtPassword.Text))
            {
                lblMensaje.Text = "Debes de Compleatar los campos del Inicio de Seccion";
            }
            try
            {
                usuario = usuarioDAO.Login(txtUsuario.Text, txtPassword.Text);
                if (usuario != null)
                {
                    Session["UsuarioID"] = usuario.idUsuario;
                    Session["UsuarioEmail"] = usuario.nombreUsuario;
                    Session["EmpleadoID"] = usuario.idEmpleado;
                    Session["nombreEmpleado"] = usuario.nombreEmpleado;
                    OptenerListaRoles(usuario.idUsuario);
                    Response.Redirect("~/Paginas/MenuPrincipal.aspx");
                }
                else
                {
                    lblMensaje.Text = "Usuario o contraseña incorrectos.";

                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al iniciar sesión: " + ex.Message;
            }
        }
        public void OptenerListaRoles(int idUsuario) { 
            List<ListaRoles> listaRoles = new List<ListaRoles>();
            try
            {
                listaRoles = listaRolesDAO.ObtenerListaRolesPorUsuario(idUsuario);
                if (listaRoles.Count() > 0)
                {
                    Session["ListaRoles"] = listaRoles;
                }
                else
                {
                    Session["ListaRoles"] = null;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al obtener los roles: " + ex.Message;
            }
        }
    }
}