using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AndmebaasidTARpv23
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Andmebaas;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapter;
        public Form1()
        {
            InitializeComponent();
            NaitaAndmed();
        }

        public void NaitaAndmed()
        {
            conn.Open();
            DataTable dt = new DataTable();
            cmd = new SqlCommand("SELECT * FROM Tooded", conn);
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        public void Btn_lisa_Click(object sender, EventArgs e)
        {
            if (Nimetus_txt.Text.Trim() != string.Empty && Kogus_txt.Text.Trim() != string.Empty && Hind_txt.Text.Trim() != string.Empty) 
            {
                try 
                {
                    conn.Open();
                    cmd = new SqlCommand("insert into Tooded(Nimetus,Kogus,Hind) values (@toode,@kogus,@hind)",conn);
                    cmd.Parameters.AddWithValue("@toode",Nimetus_txt.Text);
                    cmd.Parameters.AddWithValue("@kogus", Kogus_txt.Text);
                    cmd.Parameters.AddWithValue("@hind", Hind_txt.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    NaitaAndmed();
                }
                catch 
                {
                    MessageBox.Show("Admebaasiga viga!");
                }
            }
            else
            {
                MessageBox.Show("Sisesta andmed!");
            }
        }

        public void Btn_kustuta_Click(object sender, EventArgs e)
        {
            if (Id_txt.Text.Trim() != string.Empty)
            {
                try
                {
                    conn.Open();
                    cmd = new SqlCommand("delete from Tooded where Id = @ID", conn);
                    cmd.Parameters.AddWithValue("@ID",Id_txt.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    NaitaAndmed();
                }
                catch
                {
                    MessageBox.Show("Admebaasiga viga!");
                }
            }
            else if (Nimetus_txt.Text.Trim() != string.Empty)
            {
                try
                {
                    conn.Open();
                    cmd = new SqlCommand("delete Tooded where Nimetus = @nimetus", conn);
                    cmd.Parameters.AddWithValue("@nimetus", Nimetus_txt.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    NaitaAndmed();
                }
                catch
                {
                    MessageBox.Show("Admebaasiga viga!");
                }
            }
            else
            {
                MessageBox.Show("Sisesta nimetus või ID");
            }
        }

        private void Uuenda_btn_Click(object sender, EventArgs e)
        {
            if (Nimetus_txt.Text.Trim() != string.Empty || Kogus_txt.Text.Trim() != string.Empty || Hind_txt.Text.Trim() != string.Empty)
            {
                try
                {
                    conn.Open();
                    cmd = new SqlCommand("update Tooded set Nimetus = @nimetus, Kogus = @kogus, Hind = @hind where Id = @ID", conn);
                    cmd.Parameters.AddWithValue("@nimetus", Nimetus_txt.Text);
                    cmd.Parameters.AddWithValue("@ID", Id_txt.Text);
                    cmd.Parameters.AddWithValue("@kogus", Kogus_txt.Text);
                    cmd.Parameters.AddWithValue("@hind", Hind_txt.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    NaitaAndmed();
                }
                catch
                {
                    MessageBox.Show("Admebaasiga viga!");
                }
            }
            else
            {
                MessageBox.Show("Sisesta andmed mille tahate uuenda");
            }
        }

        int ID = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ID = (int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;
                Nimetus_txt.Text = dataGridView1.Rows[e.RowIndex].Cells["Nimetus"].Value.ToString();
                Kogus_txt.Text = dataGridView1.Rows[e.RowIndex].Cells["Kogus"].Value.ToString();
                Hind_txt.Text = dataGridView1.Rows[e.RowIndex].Cells["Hind"].Value.ToString();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog
            {
                InitialDirectory = @"C:\Users\opilane\Pictures\",
                Multiselect = false,
                Filter = "Image Files(*.jpeg;*.png;*.bmp;*.jpg)|*.jpeg;*.png;*.bmp;*.jpg"
            };

            if (open.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(Nimetus_txt.Text))
            {
                SaveFileDialog save = new SaveFileDialog
                {
                    InitialDirectory = Path.GetFullPath(@"..\..\..\pildid"),
                    FileName = Nimetus_txt.Text + Path.GetExtension(open.FileName),
                    Filter = "Images|*" + Path.GetExtension(open.FileName)
                };

                if (save.ShowDialog() == DialogResult.OK)
                {
                    File.Copy(open.FileName, save.FileName, true);
                    pictureBox1.Image = Image.FromFile(save.FileName);
                }
            }
            else
            {
                MessageBox.Show("Puudub toote nimetus või Cancel vajutatud", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
