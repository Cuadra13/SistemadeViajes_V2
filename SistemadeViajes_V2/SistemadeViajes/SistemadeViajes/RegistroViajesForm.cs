using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemadeViajes
{
    public partial class RegistroViajesForm : Form
    {
        private ComboBox cmbSucursal;
        private ComboBox cmbColaborador;
        private DateTimePicker dtpFechaViaje;
        private TextBox txtTransportista;
        private Button btnRegistrarViaje;

        private const string apiUrl = "https://localhost:7034/api/Viajes-Get";

        public RegistroViajesForm()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            Label lblSucursal = new Label();
            lblSucursal.Text = "Sucursal:";
            lblSucursal.Location = new Point(50, 20);
            lblSucursal.Size = new Size(100, 20);

            cmbSucursal = new ComboBox();
            cmbSucursal.Location = new Point(150, 20);
            cmbSucursal.Size = new Size(200, 20);

            Label lblColaborador = new Label();
            lblColaborador.Text = "Colaborador:";
            lblColaborador.Location = new Point(50, 50);
            lblColaborador.Size = new Size(100, 20);

            cmbColaborador = new ComboBox();
            cmbColaborador.Location = new Point(150, 50);
            cmbColaborador.Size = new Size(200, 20);

            Label lblFechaViaje = new Label();
            lblFechaViaje.Text = "Fecha de Viaje:";
            lblFechaViaje.Location = new Point(50, 80);
            lblFechaViaje.Size = new Size(100, 20);

            dtpFechaViaje = new DateTimePicker();
            dtpFechaViaje.Location = new Point(150, 80);
            dtpFechaViaje.Size = new Size(200, 20);

            Label lblTransportista = new Label();
            lblTransportista.Text = "Transportista:";
            lblTransportista.Location = new Point(50, 110);
            lblTransportista.Size = new Size(100, 20);

            txtTransportista = new TextBox();
            txtTransportista.Location = new Point(150, 110);
            txtTransportista.Size = new Size(200, 20);

            btnRegistrarViaje = new Button();
            btnRegistrarViaje.Location = new Point(150, 140);
            btnRegistrarViaje.Size = new Size(100, 30);
            btnRegistrarViaje.Text = "Registrar Viaje";
            btnRegistrarViaje.Click += btnRegistrarViaje_Click;

            Controls.Add(lblSucursal);
            Controls.Add(cmbSucursal);
            Controls.Add(lblColaborador);
            Controls.Add(cmbColaborador);
            Controls.Add(lblFechaViaje);
            Controls.Add(dtpFechaViaje);
            Controls.Add(lblTransportista);
            Controls.Add(txtTransportista);
            Controls.Add(btnRegistrarViaje);
        }

        private async void btnRegistrarViaje_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los valores de los controles
                int sucursalId = Convert.ToInt32(cmbSucursal.SelectedValue);
                int colaboradorId = Convert.ToInt32(cmbColaborador.SelectedValue);
                DateTime fechaViaje = dtpFechaViaje.Value;
                string transportista = txtTransportista.Text;

                // Crear el objeto Viaje con los datos del formulario
                var viaje = new
                {
                    SucursalId = sucursalId,
                    ColaboradorId = colaboradorId,
                    FechaViaje = fechaViaje,
                    Transportista = transportista
                };

                // Enviar la petición POST a la API para registrar el viaje
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.PostAsJsonAsync(apiUrl, viaje);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Viaje registrado exitosamente");
                        // Realizar otras operaciones después del registro exitoso
                    }
                    else
                    {
                        MessageBox.Show("Error en la petición: " + response.StatusCode);
                        // Mostrar mensaje de error o realizar otras acciones en caso de error
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el registro del viaje: " + ex.Message);
                // Mostrar mensaje de error o realizar otras acciones en caso de error
            }
        }
    }
}
