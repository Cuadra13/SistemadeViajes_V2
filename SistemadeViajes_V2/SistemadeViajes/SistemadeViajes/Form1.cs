using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemadeViajes
{
    public partial class Form1 : Form
    {
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnIngresar;

        private const string apiUrl = "https://localhost:7034/api/Login/Get";

        public Form1()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            Label lblLogin = new Label();
            lblLogin.Text = "Login";
            lblLogin.Location = new Point(50, 20);
            lblLogin.Size = new Size(200, 20);

            txtUsername = new TextBox();
            txtUsername.Location = new Point(50, 50);
            txtUsername.Size = new Size(200, 20);

            txtPassword = new TextBox();
            txtPassword.Location = new Point(50, 80);
            txtPassword.Size = new Size(200, 20);
            txtPassword.PasswordChar = '*';

            btnIngresar = new Button();
            btnIngresar.Location = new Point(50, 110);
            btnIngresar.Size = new Size(200, 30);
            btnIngresar.Text = "Ingresar";
            btnIngresar.Click += btnIngresar_Click;

            Controls.Add(lblLogin);
            Controls.Add(txtUsername);
            Controls.Add(txtPassword);
            Controls.Add(btnIngresar);
        }

        private async void btnIngresar_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Realizar la llamada a la API para validar las credenciales
            bool isValidUser = await ValidateUserAsync(username, password);

            if (isValidUser)
            {
                // Ocultar el formulario de login
                this.Hide();

                // Mostrar el formulario de RegistroViajesForm
                RegistroViajesForm registroViajesForm = new RegistroViajesForm();
                registroViajesForm.ShowDialog();

                // Cerrar la aplicación después de cerrar el formulario de RegistroViajesForm
                this.Close();
            }
            else
            {
                MessageBox.Show("Credenciales inválidas");
            }
        }

        private async Task<bool> ValidateUserAsync(string username, string password)
        {
            using (HttpClient client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("username", username),
                    new KeyValuePair<string, string>("password", password)
                });

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    // Obtener la respuesta de la API
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Analizar la respuesta y determinar si las credenciales son válidas
                    bool isValidUser = bool.Parse(responseBody);
                    return isValidUser;
                }
                else
                {
                    MessageBox.Show("Error en la petición: " + response.StatusCode);
                    return false;
                }
            }
        }
    }
}
