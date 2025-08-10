using Org.BouncyCastle.Asn1.Mozilla;
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
    public partial class GestionEmpleados : System.Web.UI.Page
    {
        JornadaDAO jornadaDAO = new JornadaDAO();
        PuestoDAO puestoDAO = new PuestoDAO();
        DepartamentoDAO departamentoDAO = new DepartamentoDAO();
        EmpleadoDAO empleadoDAO = new EmpleadoDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioID"] == null)
            {
                Response.Redirect("~/Paginas/Login.aspx");
            }
            if (!IsPostBack)
            {
                CargarEmpleados();
                CargarDepartamentos();
                CargarJornadas();
                CargarPuestos();
            }
        }
        public void gvEmpleadosSelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvEmpleados.SelectedRow;
            if (row != null)
            {
                int empleadoId = Convert.ToInt32(gvEmpleados.DataKeys[row.RowIndex].Values["idEmpleado"]);
                txtIdEmpleado.Text = empleadoId.ToString();
                txtNombreE1.Text = Convert.ToString(gvEmpleados.DataKeys[row.RowIndex].Values["primerNombre"]);
                txtNombreE2.Text = Convert.ToString(gvEmpleados.DataKeys[row.RowIndex].Values["segundoNombre"]);
                txtApellidoE1.Text = Convert.ToString(gvEmpleados.DataKeys[row.RowIndex].Values["primerApellido"]);
                txtApellidoE2.Text = Convert.ToString(gvEmpleados.DataKeys[row.RowIndex].Values["segundoApellido"]);
                txtIdentificacionE.Text = Convert.ToString(gvEmpleados.DataKeys[row.RowIndex].Values["identificacion"]);
                txtSalarioEd.Text = Convert.ToString(gvEmpleados.DataKeys[row.RowIndex].Values["salarioBruto"]);

            }
        }
        public void btnModificarClick(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIdEmpleado.Text) || string.IsNullOrEmpty(txtIdentificacionE.Text) ||
                    string.IsNullOrEmpty(txtNombreE1.Text) || string.IsNullOrEmpty(txtApellidoE1.Text) ||
                    string.IsNullOrEmpty(txtSalarioEd.Text) || ddlDepartamentoE.SelectedValue == "" ||
                    ddlJornadaE.SelectedValue == "" || ddlPuestoE.SelectedValue == "")
                {
                    lblMensaje.Text = "Por favor, complete todos los campos requeridos.";
                    return;
                }
                if (string.IsNullOrEmpty(txtApellidoE2.Text))
                {
                    txtApellidoE2.Text = "";
                }
                if (string.IsNullOrEmpty(txtNombreE2.Text))
                {
                    txtNombreE2.Text = "";
                }
                int idDepartamento = Convert.ToInt32(ddlDepartamentoE.SelectedValue);
                int idJornada = Convert.ToInt32(ddlJornadaE.SelectedValue);
                int idPuesto = Convert.ToInt32(ddlPuestoE.SelectedValue);
                Empleado empleado = new Empleado
                {
                    idEmpleado = Convert.ToInt32(txtIdEmpleado.Text),
                    identificacion = txtIdentificacionE.Text,
                    primerNombre = txtNombreE1.Text,
                    segundoNombre = txtNombreE2.Text,
                    primerApellido = txtApellidoE1.Text,
                    segundoApellido = txtApellidoE2.Text,
                    salarioBruto = float.Parse(txtSalarioEd.Text),
                    usuarioModificacion = Convert.ToString(Session["nombreEmpleado"])
                };
                empleadoDAO.ModificarEmpleado(empleado, idDepartamento, idJornada, idPuesto);
                CargarEmpleados();
            }
            catch (Exception ex)
            {
                // Manejo de errores, por ejemplo, mostrar un mensaje al usuario
                lblMensaje.Text = "Error al modificar el empleado: " + ex.Message;
            }
        }

        public void btnEliminarClick(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIdEmpleado.Text))
                {
                    lblMensaje.Text = "Por favor, seleccione un empleado para eliminar.";
                    return;
                }
                Empleado empleado = new Empleado
                {
                    idEmpleado = Convert.ToInt32(txtIdEmpleado.Text),
                    usuarioModificacion = Convert.ToString(Session["nombreEmpleado"])
                };
                empleadoDAO.EliminarEmpleado(empleado);
                CargarEmpleados();
            }
            catch (Exception ex)
            {
                // Manejo de errores, por ejemplo, mostrar un mensaje al usuario
                lblMensaje.Text = "Error al eliminar el empleado: " + ex.Message;
            }
        }


        public void btnCrearEmpleadoClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdentificacionC.Text) || string.IsNullOrEmpty(txtNombreC1.Text) ||
                string.IsNullOrEmpty(txtApellidoC1.Text) || string.IsNullOrEmpty(txtSalarioCr.Text) ||
                ddlDepartamentoC.SelectedValue == "" || ddlJornadaC.SelectedValue == "" || ddlPuestoC.SelectedValue == "")
            {
                lblMensaje.Text = "Por favor, complete todos los campos requeridos.";
                return;
            }
            if (string.IsNullOrEmpty(txtApellidoC2.Text))
            {
                txtApellidoC2.Text = "";
            }
            if (string.IsNullOrEmpty(txtNombreC2.Text))
            {
                txtNombreC2.Text = "";
            }
            int idDepartamento = Convert.ToInt32(ddlDepartamentoC.SelectedValue);
            int idJornada = Convert.ToInt32(ddlJornadaC.SelectedValue);
            int idPuesto = Convert.ToInt32(ddlPuestoC.SelectedValue);
            Empleado empleado = new Empleado
            {
                identificacion = txtIdentificacionC.Text,
                primerNombre = txtNombreC1.Text,
                segundoNombre = txtNombreC2.Text,
                primerApellido = txtApellidoC1.Text,
                segundoApellido = txtApellidoC2.Text,
                fechaContratacion = Convert.ToDateTime(calFecha.SelectedDate),
                salarioBruto = float.Parse(txtSalarioCr.Text),
                adicionadoPor = Convert.ToString(Session["nombreEmpleado"])
            };
            try
            {
                empleadoDAO.CrearEmpleado(empleado, idDepartamento, idJornada, idPuesto);
                CargarEmpleados();
            }
            catch (Exception ex)
            {
                // Manejo de errores, por ejemplo, mostrar un mensaje al usuario
                lblMensaje.Text = "Error al crear el empleado: " + ex.Message;

            }
        }

        public void CargarDepartamentos()
        {
            List<Departamento> departamentos = departamentoDAO.ListarDepartamentos();
            ddlDepartamentoE.Items.Clear();
            ddlDepartamentoC.Items.Clear();
            ddlDepartamentoE.Items.Add(new ListItem("Seleccione un departamento", ""));
            ddlDepartamentoC.Items.Add(new ListItem("Seleccione un departamento", ""));
            for (int i = 0; i < departamentos.Count(); i++)
            {
                ddlDepartamentoC.Items.Add(new ListItem(departamentos[i].nombre, departamentos[i].idDepartamento.ToString()));
                ddlDepartamentoE.Items.Add(new ListItem(departamentos[i].nombre, departamentos[i].idDepartamento.ToString()));
            }
            ddlDepartamentoC.DataBind();
            ddlDepartamentoE.DataBind();
        }
        public void CargarJornadas()
        {
            List<Jornada> jornadas = jornadaDAO.ListarJornadas();
            ddlJornadaC.Items.Clear();
            ddlJornadaE.Items.Clear();
            ddlJornadaC.Items.Add(new ListItem("Seleccione una jornada", ""));
            ddlJornadaE.Items.Add(new ListItem("Seleccione una jornada", ""));
            for (int i = 0; i < jornadas.Count(); i++)
            {
                ddlJornadaC.Items.Add(new ListItem(jornadas[i].nombre, jornadas[i].idJornada.ToString()));
                ddlJornadaE.Items.Add(new ListItem(jornadas[i].nombre, jornadas[i].idJornada.ToString()));
            }
            ddlJornadaC.DataBind();
            ddlJornadaE.DataBind();
        }
        public void CargarPuestos()
        {
            List<Puesto> puestos = puestoDAO.ListarPuestos();
            ddlPuestoC.Items.Clear();
            ddlPuestoE.Items.Clear();
            ddlPuestoC.Items.Add(new ListItem("Seleccione un puesto", ""));
            ddlPuestoE.Items.Add(new ListItem("Seleccione un puesto", ""));
            for (int i = 0; i < puestos.Count(); i++)
            {
                ddlPuestoC.Items.Add(new ListItem(puestos[i].nombre, puestos[i].idPuesto.ToString()));
                ddlPuestoE.Items.Add(new ListItem(puestos[i].nombre, puestos[i].idPuesto.ToString()));
            }
            ddlPuestoC.DataBind();
            ddlPuestoE.DataBind();
        }

        public void CargarEmpleados()
        {
            try
            {
                List<Empleado> empleados = empleadoDAO.ObtenerEmpleados();
                gvEmpleados.DataSource = empleados;
                gvEmpleados.DataBind();
            }
            catch (Exception ex)
            {
                // Manejo de errores, por ejemplo, mostrar un mensaje al usuario
                lblMensaje.Text = "Error al cargar los empleados: " + ex.Message;
            }
        }
    }
}