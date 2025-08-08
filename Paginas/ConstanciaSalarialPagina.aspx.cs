using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.X509.SigI;
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
    public partial class ConstanciaSalarialPagina : System.Web.UI.Page
    {
        ConstanciaSalarialDAO constanciaSalarialDAO = new ConstanciaSalarialDAO();
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

                }
                else
                {
                    stListaEmpleados.Visible = false;
                }
            }
        }
        public void btnGenerarConstanciaClick(object sender, EventArgs e)
        {
            var listaRoles = Session["ListaRoles"] as List<ListaRoles>;
            if (listaRoles.Any(r => r.nombreRol.Equals("Administrador", StringComparison.OrdinalIgnoreCase)))
            {
                int empleadoId = Convert.ToInt32(Session["EmpleadoIDSeleccionado"]);
                ConstanciaSalarial constanciaSalarial = constanciaSalarialDAO.CrearSolicitud(empleadoId);
                if (constanciaSalarial != null)
                {
                    txtIdentificacion.Text = constanciaSalarial.identificacion.ToString();
                    txtNombreCompleto.Text = constanciaSalarial.nombreCompleto.ToString();
                    txtSalario.Text = constanciaSalarial.salarioBruto.ToString();
                    DateTime fechaC = Convert.ToDateTime(constanciaSalarial.fechaContratacion);
                    string fechaContratacion = fechaC.ToString("dd/MM/yyyy");
                    txtFechaContrato.Text = fechaContratacion;
                    txtDepartamento.Text = constanciaSalarial.departamento.ToString();
                    txtPuesto.Text = constanciaSalarial.puesto.ToString();
                    string constancia = "Constancia Salarial para " + constanciaSalarial.nombreCompleto +
                        " con identificación " + constanciaSalarial.identificacion +
                        " quien ocupa el puesto de " + constanciaSalarial.puesto + " en el departamento de " +
                        constanciaSalarial.departamento + ". Su salario bruto es de " +
                        +constanciaSalarial.salarioBruto + " y fue contratado el " + fechaContratacion + ", " +
                        "con tipo de Contrato " + constanciaSalarial.tipoContrato + ".";
                    txtConstancia.Text = constancia;
                }

            }
            else
            {
                ConstanciaSalarial constanciaSalarial = new ConstanciaSalarial();
                constanciaSalarial = constanciaSalarialDAO.CrearSolicitud(Convert.ToInt32(Session["EmpleadoID"]));
                if (constanciaSalarial != null)
                {
                    txtIdentificacion.Text = constanciaSalarial.identificacion.ToString();
                    txtNombreCompleto.Text = constanciaSalarial.nombreCompleto.ToString();
                    txtSalario.Text = constanciaSalarial.salarioBruto.ToString();
                    DateTime fechaC = Convert.ToDateTime(constanciaSalarial.fechaContratacion);
                    string fechaContratacion = fechaC.ToString("dd/MM/yyyy");
                    txtFechaContrato.Text = fechaContratacion;
                    txtDepartamento.Text = constanciaSalarial.departamento.ToString();
                    txtPuesto.Text = constanciaSalarial.puesto.ToString();
                    string constancia = "Constancia Salarial para " + constanciaSalarial.nombreCompleto +
                        " con identificación " + constanciaSalarial.identificacion +
                        " quien ocupa el puesto de " + constanciaSalarial.puesto + " en el departamento de " +
                        constanciaSalarial.departamento + ". Su salario bruto es de " +
                        +constanciaSalarial.salarioBruto + " y fue contratado el " + fechaContratacion + ", " +
                        "con tipo de Contrato " + constanciaSalarial.tipoContrato + ".";
                    txtConstancia.Text = constancia;
                }
            }
        }
        public void btnDescargarClick(object sender, EventArgs e)
        {
            var listaRoles = Session["ListaRoles"] as List<ListaRoles>;
            string constancia = "";
            ConstanciaSalarial constanciaSalarial = new ConstanciaSalarial();
            if (listaRoles.Any(r => r.nombreRol.Equals("Administrador", StringComparison.OrdinalIgnoreCase)))
            {
                constanciaSalarial = constanciaSalarialDAO.CrearSolicitud(Convert.ToInt32(Session["EmpleadoIDSeleccionado"]));
            }
            else
            {
                constanciaSalarial = constanciaSalarialDAO.CrearSolicitud(Convert.ToInt32(Session["EmpleadoID"]));
            }

            if (constanciaSalarial != null)
            {
                DateTime fechaC = Convert.ToDateTime(constanciaSalarial.fechaContratacion);
                string fechaContratacion = fechaC.ToString("dd/MM/yyyy");
                txtFechaContrato.Text = fechaContratacion;
                constancia = "Constancia Salarial para " + constanciaSalarial.nombreCompleto +
                    " con identificación " + constanciaSalarial.identificacion +
                    " quien ocupa el puesto de " + constanciaSalarial.puesto + " en el departamento de " +
                    constanciaSalarial.departamento + ". Su salario bruto es de " +
                    +constanciaSalarial.salarioBruto + " y fue contratado el " + fechaContratacion + ", " +
                    "con tipo de Contrato " + constanciaSalarial.tipoContrato + ".";
            }
            string dirreccion = Server.MapPath("~/Archivos/ConstanciaSalarial.pdf");
            using (var witter = new PdfWriter(dirreccion))
            {
                using (var pdf = new PdfDocument(witter))
                {
                    var documento = new Document(pdf);
                    documento.Add(new Paragraph("Constancia Salarial"));
                    documento.Add(new Paragraph(constancia));
                    documento.Close();
                }
            }
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Reporte.pdf");
            Response.TransmitFile(dirreccion);
            Response.End();
        }

        public void gvEmpleadosSelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvEmpleados.SelectedRow;
            if (row != null)
            {
                int empleadoId = Convert.ToInt32(gvEmpleados.DataKeys[row.RowIndex].Value);
                Session["EmpleadoIDSeleccionado"] = empleadoId;
            }
            txtConstancia.Text = "";
            txtIdentificacion.Text = "";
            txtNombreCompleto.Text = "";
            txtSalario.Text = "";
            txtFechaContrato.Text = "";
            txtDepartamento.Text = "";
            txtPuesto.Text = "";
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
    }
}