using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AndmebaasidTARpv23
{
    public partial class LoginForm : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\Source\Repos\AndmebaasidTARpv23\Toode.mdf;Integrated Security=True");

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Palun täitke kõik väljad!");
                return;
            }

            try
            {
                conn.Open();
                string Parool = txtPassword.Text;

                string roll = rbAdmin.Checked ? "Omanik" : "Müüja";

                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Kasutajad (Kasutajanimi, Parool, Roll) VALUES (@username, @password, @role)",
                    conn);
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@password", Parool);
                cmd.Parameters.AddWithValue("@role", roll);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Registreerimine õnnestus!");
                }
                else
                {
                    MessageBox.Show("Registreerimine ebaõnnestus.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Viga: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Palun täitke kõik väljad!");
                return;
            }

            try
            {
                conn.Open();
                string Parool = txtPassword.Text;

                SqlCommand cmd = new SqlCommand(
                    "SELECT Roll FROM Kasutajad WHERE Kasutajanimi = @username AND Parool = @password",
                    conn);
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@password", Parool);

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    string roll = result.ToString();

                    this.Hide();

                    if (roll == "Omanik")
                    {
                        Form1 omanikForm = new Form1();
                        omanikForm.FormClosed += (s, args) => this.Show();
                        omanikForm.Show();
                    }
                    else if (roll == "Müüja")
                    {
                        ShopForm muujaForm = new ShopForm(txtUsername.Text);
                        muujaForm.FormClosed += (s, args) => this.Show();
                        muujaForm.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Vale kasutajanimi või parool!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Viga: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
