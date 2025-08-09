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
    public partial class LiquidacionPagina : System.Web.UI.Page
    {
        LiquidacionDAO liquidacionDAO = new LiquidacionDAO();
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
            }
        }
        public void btnCalcularClick(object sender, EventArgs e)
        {
            Liquidacion liquidacion = new Liquidacion();
            liquidacion = liquidacionDAO.CrearLiquidacion(Convert.ToInt32(Session["EmpleadoIDSeleccionado"]), Convert.ToDateTime(calFecha.SelectedDate));
            float cesantia = liquidacion.montoCesantia;
            float preaviso = liquidacion.montoPreaviso;
            float aguinaldo = liquidacion.aguinaldoProporcional;
            float vacaciones = liquidacion.vacacionesProporcionales;
            float aniosTrabajados = liquidacion.aniosTrabajados;
            float salarioDiario = liquidacion.salarioDiario;
            float salarioMensual = liquidacion.salarioMensual;
            float totalLiquidacion = liquidacion.totalLiquidacion;
            txtResCesantia.Text = cesantia.ToString("N0");
            txtResPreaviso.Text = preaviso.ToString("N0");
            txtResAguinaldo.Text = aguinaldo.ToString("N0");
            txtResVacaciones.Text = vacaciones.ToString("N0");
            txtResAnnios.Text = aniosTrabajados.ToString();
            txtResSalarioDiario.Text = salarioDiario.ToString("N0");
            txtResSalarioMensual.Text = salarioMensual.ToString("N0");
            txtTotalLiquidacion.Text = totalLiquidacion.ToString("N0");
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
        public async void btnCargarEmpleadosClick(object sender, EventArgs e)
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
    }
}
