using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AndmebaasidTARpv23
{
    public partial class Form2 : Form
    {
        public event Action OnLaduAdded;  // Üritus vormi1 teavitamiseks

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jeliz\source\repos\AndmebaasidTARpv23\Toode.mdf;Integrated Security=True");
        SqlCommand cmd;

        public Form2()
        {
            InitializeComponent();
        }

        private void btnAddLadu_Click_1(object sender, EventArgs e)
        {
            string laoNimetus = txtLaoNimetus.Text.Trim();
            string suurus = txtSuurus.Text.Trim();
            string kirjeldus = txtKirjeldus.Text.Trim();

            if (string.IsNullOrEmpty(laoNimetus) || string.IsNullOrEmpty(suurus) || string.IsNullOrEmpty(kirjeldus))
            {
                MessageBox.Show("Kõik väljad peavad olema täidetud!");
                return;
            }

            try
            {
                conn.Open();
                cmd = new SqlCommand("INSERT INTO Ladu (LaoNimetus, Suurus, Kirjeldus) VALUES (@nimetus, @suurus, @kirjeldus)", conn);
                cmd.Parameters.AddWithValue("@nimetus", laoNimetus);
                cmd.Parameters.AddWithValue("@suurus", suurus);
                cmd.Parameters.AddWithValue("@kirjeldus", kirjeldus);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Ladu lisatud edukalt!");

                // Trigger sündmus teavitada vormi1 värskendada ComboBox
                OnLaduAdded?.Invoke();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Tekkis viga ladu lisamisel: {ex.Message}");
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
