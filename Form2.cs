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

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\Source\Repos\AndmebaasidTARpv23\Toode.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapter;

        public Form2()
        {
            InitializeComponent();
            NaitaAndmed()
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
            OnLaduAdded?.Invoke();
            this.Close();
        }

        private void Kustuta_btn_Click(object sender, EventArgs e)
        {
            if (txtLaoNimetus.Text.Trim() != string.Empty)
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Ladu WHERE LaoNimetus = @LaoNimetus", conn);
                    cmd.Parameters.AddWithValue("@LaoNimetus", txtLaoNimetus.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Ladu kustutatud edukalt!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Viga ladu kustutamisel: {ex.Message}");
                }
                OnLaduAdded?.Invoke();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sisesta ladu nimetus!");
            }
        }

        private void Uuenda_btn_Click(object sender, EventArgs e)
        {
            if (txtLaoNimetus.Text.Trim() != string.Empty)
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Ladu SET Suurus = @Suurus, Kirjeldus = @Kirjeldus WHERE LaoNimetus = @LaoNimetus", conn);
                    cmd.Parameters.AddWithValue("@LaoNimetus", txtLaoNimetus.Text);
                    cmd.Parameters.AddWithValue("@Suurus", txtSuurus.Text);
                    cmd.Parameters.AddWithValue("@Kirjeldus", txtKirjeldus.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Ladu uuendatud edukalt!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Viga ladu uuendamisel: {ex.Message}");
                }
                OnLaduAdded?.Invoke();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sisesta ladu nimetus!");
            }
        }

        public void NaitaAndmed()
        {
            conn.Open();
            DataTable dt = new DataTable();
            cmd = new SqlCommand("SELECT * FROM Ladu", conn);
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
            conn.Close();
        }
    }
}
