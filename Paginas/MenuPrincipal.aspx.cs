using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.Paginas
{
    public partial class MenuPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioID"]==null)
            {
                Response.Redirect("~/Paginas/Login.aspx");
            }
            if (!IsPostBack)
            {
                var listaRoles = Session["ListaRoles"] as List<ListaRoles>;
                if (listaRoles == null)
                {
                    Response.Redirect("~/Paginas/Login.aspx");
                }
                if (listaRoles.Any(r =>r.nombreRol.Equals("Administrador", StringComparison.OrdinalIgnoreCase)))
                {
                    btnLiquidacion.Visible = true;
                    btnEmpleados.Visible = true;
                }
                else
                {
                    btnLiquidacion.Visible = false;
                    btnEmpleados.Visible = false;
                }
            }

        }
        public void btnSalirClick(object sender, EventArgs e)
        {
            Session["UsuarioID"] = null;
            Session["UsuarioEmail"] = null;
            Session["EmpleadoID"] = null;
            Session["nombreEmpleado"] = null;
            Session["ListaRoles"] = null;
        }
    }
}