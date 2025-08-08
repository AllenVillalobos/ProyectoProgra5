using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.Paginas
{
    public partial class Liquidacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioID"] == null)
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
                if (listaRoles.Any(r => r.nombreRol.Equals("Administrador", StringComparison.OrdinalIgnoreCase)))
                {
                    gvEmpleados.Visible = true;

                }
                else
                {
                    gvEmpleados.Visible = false;
                }

            }
        }
    }
}