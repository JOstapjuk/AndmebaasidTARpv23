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
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\Source\Repos\AndmebaasidTARpv23\Toode.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapter;
        OpenFileDialog open;
        SaveFileDialog save;
        string extension;
        public Form1()
        {
            InitializeComponent();
            NaitaAndmed();
        }

        public void NaitaAndmed()
        {
            conn.Open();
            DataTable dt = new DataTable();
            cmd = new SqlCommand("SELECT * FROM Toode", conn);
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
                    cmd = new SqlCommand("insert into Toode(Nimetus,Kogus,Hind,Pilt) values (@nimetus,@kogus,@hind,@pilt)", conn); 
                    cmd.Parameters.AddWithValue("@nimetus",Nimetus_txt.Text);
                    cmd.Parameters.AddWithValue("@kogus", Kogus_txt.Text);
                    cmd.Parameters.AddWithValue("@hind", Hind_txt.Text);
                    cmd.Parameters.AddWithValue("@pilt", Nimetus_txt.Text + extension);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    NaitaAndmed();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Admebaasiga viga! \n\n{ex.Message}");
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
                    cmd = new SqlCommand("delete from Toode where Id = @ID", conn);
                    cmd.Parameters.AddWithValue("@ID",Id_txt.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    string file = dataGridView1.SelectedRows[0].Cells["Pilt"].Value.ToString();

                    Emalda();
                    NaitaAndmed();
                    System.Threading.Thread.Sleep(1000);
                    //Kustuta_Faili(Nimetus_txt.Text + extension);
                    Kustuta_Faili(file);
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
                    cmd = new SqlCommand("delete Toode where Nimetus = @nimetus", conn);
                    cmd.Parameters.AddWithValue("@nimetus", Nimetus_txt.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    string file = dataGridView1.SelectedRows[0].Cells["Pilt"].Value.ToString();

                    Emalda();
                    NaitaAndmed();
                    System.Threading.Thread.Sleep(1000);
                    //Kustuta_Faili(Nimetus_txt.Text + extension);
                    Kustuta_Faili(file);

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

        private void Kustuta_Faili(string file)
        {
            System.Threading.Thread.Sleep(1000);
            bool fail_kustutatud = false;
            while (!fail_kustutatud) 
            {
                try
                {
                    System.Threading.Thread.Sleep(1000);
                    string fullPath = Path.Combine(Path.GetFullPath(@"..\..\pildid"), file);

                    if (File.Exists(fullPath))
                    {
                        File.SetAttributes(fullPath, FileAttributes.Normal);

                        try
                        {
                            File.Delete(fullPath);
                            MessageBox.Show($"Faili kustutamine õnnestus!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Valesti kustutamisel: {ex.Message}");
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Faili ei leitud: {fullPath}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Tekkis vea faili kustutamisel! {ex.Message}");
                }
                fail_kustutatud = true;
            }         
        }

        //private async Kustuta_Faili(string file)
        //{
        //    try
        //    {
        //        string fullPath = Path.Combine(Environment.CurrentDirectory, @"pildid", file);

        //        if (File.Exists(fullPath))
        //        {
        //            using (FileStream stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.None))
        //            {
        //                await stream.ReadAsync(new byte[1024], 0, 0);

        //                stream.Close();
        //            }

        //            File.Delete(fullPath);
        //            MessageBox.Show($"Faili kustutamine õnnestus!");
        //        }
        //        else
        //        {
        //            MessageBox.Show($"Faili ei leitud: {fullPath}");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Tekkis vea faili kustutamisel! {ex.Message}");
        //    }
        //}

        private void Uuenda_btn_Click(object sender, EventArgs e)
        {
            if (Nimetus_txt.Text.Trim() != string.Empty && Kogus_txt.Text.Trim() != string.Empty && Hind_txt.Text.Trim() != string.Empty)
            {
                try
                {
                    conn.Open();
                    cmd = new SqlCommand("update Toode SET Nimetus = @nimetus, Kogus = @kogus, Hind = @hind, Pilt = @pilt WHERE Id = @ID", conn);
                    cmd.Parameters.AddWithValue("@nimetus", Nimetus_txt.Text);
                    cmd.Parameters.AddWithValue("@ID", Id_txt.Text);
                    cmd.Parameters.AddWithValue("@kogus", Kogus_txt.Text);
                    cmd.Parameters.AddWithValue("@hind", Hind_txt.Text);
                    cmd.Parameters.AddWithValue("@pilt", Nimetus_txt.Text + extension);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    NaitaAndmed();
                    Emalda();
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

        private void Emalda()
        {
            MessageBox.Show("Andmed elukalt uuendatud", "Uuendamine");
            Nimetus_txt.Text = "";
            Kogus_txt.Text = "";
            Hind_txt.Text = "";
            pictureBox1.Image = Image.FromFile(Path.Combine(Path.GetFullPath(@"..\..\pildid"), "error.png"));
        }



        int ID = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = (int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;
            Nimetus_txt.Text = dataGridView1.Rows[e.RowIndex].Cells["Nimetus"].Value.ToString();
            Kogus_txt.Text = dataGridView1.Rows[e.RowIndex].Cells["Kogus"].Value.ToString();
            Hind_txt.Text = dataGridView1.Rows[e.RowIndex].Cells["Hind"].Value.ToString();
            try
            {
                pictureBox1.Image = Image.FromFile(Path.Combine(Path.GetFullPath(@"..\..\pildid"),
                    dataGridView1.Rows[e.RowIndex].Cells["Pilt"].Value.ToString()));
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch (Exception)
            {
                pictureBox1.Image = Image.FromFile(Path.Combine(Path.GetFullPath(@"..\..\pildid"), "error.png"));
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            open = new OpenFileDialog();
            open.InitialDirectory = @"C:\Users\opilane\Pictures\";
            open.Multiselect = false;
            open.Filter = "Image Files(*.jpeg;*.png;*.bmp;*.jpg)|*.jpeg;*.png;*.bmp;*.jpg";

            if (open.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(Nimetus_txt.Text))
            {
                save = new SaveFileDialog();
                save.InitialDirectory = Path.GetFullPath(@"..\..\pildid");
                extension = Path.GetExtension(open.FileName);
                save.FileName = Nimetus_txt.Text + extension;
                save.Filter = "Images Files(*.jpeg;*.png;*.bmp;*.jpg)|*.jpeg;*.png;*.bmp;*.jpg";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    File.Copy(open.FileName, save.FileName, true);  
                    pictureBox1.Image = Image.FromFile(save.FileName); 
                }
            }
            else
            {
                MessageBox.Show("Puudub toode nimetus või ole Cancel vajutatud");
            }
        }
    }
}
