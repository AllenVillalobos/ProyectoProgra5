using Newtonsoft.Json;
using Proyecto.DAO;
using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.Paginas
{
    public partial class SolicitudVacacionesPagina : System.Web.UI.Page
    {
        SolicitudVacacionesDAO solicitudVacacionesDAO = new SolicitudVacacionesDAO();
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
                    stListaEmpleados.Visible = true;
                    stListaSolicitudes.Visible = true;
                    stModificar.Visible = true;
                    CargarSolicitudes();
                }
                else
                {
                    stListaEmpleados.Visible = false;
                    stListaSolicitudes.Visible = false;
                    stModificar.Visible = false;
                }

            }

        }
        protected async void btnCargarEmpleadosClick(object sender, EventArgs e)
        {
            await CargarEmpleados();
        }

        public void gvEmpleadosSelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvEmpleados.SelectedRow;
            if (row != null)
            {
                int empleadoId = Convert.ToInt32(gvEmpleados.DataKeys[row.RowIndex].Value);
                Session["EmpleadoIDSeleccionado"] = empleadoId;
            }
        }
        protected void btnEnviarSolicitudClick(object sender, EventArgs e)
        {
            SolicitudVacaciones solicitudVacaciones = new SolicitudVacaciones();
            var listaRoles = Session["ListaRoles"] as List<ListaRoles>;
            if (listaRoles == null)
            {
                Response.Redirect("~/Paginas/Login.aspx");
                return;
            }


            if (listaRoles.Any(r => r.nombreRol.Equals("Administrador", StringComparison.OrdinalIgnoreCase)))
            {
                if (Session["EmpleadoIDSeleccionado"] == null)
                {
                    lblMensaje.Text = "Debes seleccionar un empleado.";
                }else if (String.IsNullOrEmpty(txtDetalle.Text))
                {
                    lblMensaje.Text = "Debes rellenar el campo de Detalle para enviar la solicitud";
                }
                else {
                    solicitudVacaciones = new SolicitudVacaciones()
                    {
                        detalle = txtDetalle.Text,
                        idEmpleado = Convert.ToInt32(Session["EmpleadoIDSeleccionado"]),
                        adicionadoPor = Convert.ToString(Session["nombreEmpleado"])
                    };
                    CargarSolicitudes();
                }
            }
            else
            {
                solicitudVacaciones = new SolicitudVacaciones()
                {
                    detalle = txtDetalle.Text,
                    idEmpleado = Convert.ToInt32(Session["EmpleadoID"]),
                    adicionadoPor = Convert.ToString(Session["nombreEmpleado"])
                };
            }
            solicitudVacacionesDAO.CrearSolicitudVacaciones(solicitudVacaciones);
            CargarSolicitudes();
        }

        public void CargarSolicitudes()
        {
            List<SolicitudVacaciones> solicitudes = solicitudVacacionesDAO.ObtenerSolicitudes();
            if (solicitudes != null && solicitudes.Count > 0)
            {
                gvSolicitudes.DataSource = solicitudes;
                gvSolicitudes.DataBind();
            }
            else
            {
                gvSolicitudes.DataSource = null;
                gvSolicitudes.DataBind();
            }
        }
        public void gvSolicitudesSelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvSolicitudes.SelectedRow;
            if (row != null)
            {
                int solicitudId = Convert.ToInt32(gvSolicitudes.DataKeys[row.RowIndex].Values["idSolicitudVacaciones"]);
                txtSolID.Text = solicitudId.ToString();
                txtSolDet.Text = Convert.ToString(gvSolicitudes.DataKeys[row.RowIndex].Values["detalle"]);
                txtSolEstado.Text = Convert.ToString(gvSolicitudes.DataKeys[row.RowIndex].Values["estado"]);
                DateTime fechaRevision =Convert.ToDateTime(gvSolicitudes.DataKeys[row.RowIndex].Values["fechaAdicion"]);
                string fechaRevisionStr = fechaRevision.ToString("dd/MM/yyyy");
                txtSolFecha.Text = fechaRevisionStr;
                txtSolEmpleado.Text = Convert.ToString(gvSolicitudes.DataKeys[row.RowIndex].Values["empleadoNombre"]);
                txtSolRevisor.Text = Convert.ToString(Session["nombreEmpleado"]);
            }
        }
        public void btnModificarSolicitudClick(object sender, EventArgs e)
        {
            SolicitudVacaciones solicitudVacaciones = new SolicitudVacaciones()
            {
                idSolicitudVacaciones = Convert.ToInt32(txtSolID.Text),
                detalle = txtSolDet.Text,
                estado = txtSolRes.Text,
                revisadoPor = txtSolRevisor.Text,
            };
            solicitudVacacionesDAO.ModificarSolicitudVacaciones(solicitudVacaciones);
            CargarSolicitudes();
            txtSolID.Text = "";
            txtSolDet.Text = "";
            txtSolEstado.Text = "";
            txtSolFecha.Text = "";
            txtSolEmpleado.Text = "";
            txtSolRevisor.Text = "";
            txtSolRes.Text = "";
        }

        public async Task CargarEmpleados()
        {
            List<Empleado> empleados = new List<Empleado>();
            String URLbase = ConfigurationManager.AppSettings["URLbase"];
            using (HttpClient cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(URLbase);
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync("proyecto/Empleado");
                    if (respuesta.IsSuccessStatusCode)
                    {
                        string json = await respuesta.Content.ReadAsStringAsync();
                        empleados = JsonConvert.DeserializeObject<List<Empleado>>(json);
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Error al consumir el servicio: " + ex.Message, ex);
                }
            }
            gvEmpleados.DataSource = empleados;
            gvEmpleados.DataBind();
        }
    }
}