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
        int ID = 0;
        public Form1()
        {
            InitializeComponent();
            NaitaAndmed();
            LoadLaduComboBox();
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

        public void LoadLaduComboBox()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Id, LaoNimetus FROM Ladu", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                LaduComboBox.Items.Clear();

                while (reader.Read())
                {
                    LaduComboBox.Items.Add(new KeyValuePair<int, string>(
                        (int)reader["Id"],
                        reader["LaoNimetus"].ToString()
                    ));
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void Btn_lisa_Click(object sender, EventArgs e)
        {
            if (Nimetus_txt.Text.Trim() != string.Empty && Kogus_txt.Text.Trim() != string.Empty && Hind_txt.Text.Trim() != string.Empty)
            {
                try
                {
                    conn.Open();
                    int laduId;

                    if (LaduComboBox.SelectedItem != null)
                    {
                        laduId = ((KeyValuePair<int, string>)LaduComboBox.SelectedItem).Key;
                    }
                    else
                    {
                        MessageBox.Show("Palun vali või lisa Ladu enne toote lisamist!");
                        conn.Close();
                        return;
                    }

                    cmd = new SqlCommand("INSERT INTO Toode (Nimetus, Kogus, Hind, Pilt, PiltFus,LaoID) VALUES (@nimetus, @kogus, @hind, @pilt, @fpilt,@laduid)", conn);
                    cmd.Parameters.AddWithValue("@nimetus", Nimetus_txt.Text);
                    cmd.Parameters.AddWithValue("@kogus", Kogus_txt.Text);
                    cmd.Parameters.AddWithValue("@hind", Hind_txt.Text);
                    cmd.Parameters.AddWithValue("@pilt", Nimetus_txt.Text + extension);

                    byte[] imageData = File.ReadAllBytes(open.FileName);
                    cmd.Parameters.AddWithValue("@fpilt", imageData);

                    cmd.Parameters.AddWithValue("@laduid", laduId);

                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Emalda();
                    NaitaAndmed();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"error: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Sisesta kõik andmed enne toote lisamist!");
            }
        }

        private void Emalda()
        {
            MessageBox.Show("Andmed elukalt uuendatud", "Uuendamine");
            Nimetus_txt.Text = "";
            Kogus_txt.Text = "";
            Hind_txt.Text = "";
            pictureBox1.Image = Image.FromFile(Path.Combine(Path.GetFullPath(@"..\..\pildid"), "error.png"));
            LaduComboBox.SelectedIndex = -1;
        }

        public void Btn_kustuta_Click(object sender, EventArgs e)
        {
            if (Id_txt.Text.Trim() != string.Empty)
            {
                try
                {
                    conn.Open();


                    cmd = new SqlCommand("delete from Toode where Id = @ID", conn);
                    cmd.Parameters.AddWithValue("@ID", Id_txt.Text);
                    cmd.ExecuteNonQuery(); 

                    conn.Close();

                    string file = dataGridView1.SelectedRows[0].Cells["Pilt"].Value.ToString();

                    Emalda();
                    System.Threading.Thread.Sleep(1000);
                    Kustuta_Faili(file);
                    NaitaAndmed();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Admebaasiga viga! {ex}");
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
                    System.Threading.Thread.Sleep(1000);
                    Kustuta_Faili(file);
                    NaitaAndmed();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Admebaasiga viga! {ex}");
                }
            }
            else
            {
                MessageBox.Show("Sisesta nimetus või ID");
            }
        }

        private void Kustuta_Faili(string file)
        {
            try
            {
                string fullPath = Path.Combine(Path.GetFullPath(@"..\..\pildid"), file);

                if (File.Exists(fullPath))
                {
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                        pictureBox1.Image = null;
                    }

                    // GC.Collect() sunnib .NET prügikogujat kohe käivitama.
                    // See aitab tagada, et kõik viitamata objektid puhastatakse.
                    GC.Collect();

                    // WaitForPendingFinalizers() blokeerib praeguse lõime, kuni 
                    // kõik järjekorras olevad finaliseerijad on töödeldud.
                    // See tagab, et failikäepidemed ja muud ressursid on täielikult vabastatud.
                    GC.WaitForPendingFinalizers();

                    try
                    {
                        File.Delete(fullPath);
                    }
                    catch
                    {
                        File.SetAttributes(fullPath, FileAttributes.Normal);
                        File.Delete(fullPath);
                    }

                    MessageBox.Show($"Faili kustutamine õnnestus!");
                }
                else
                {
                    MessageBox.Show($"Faili ei leitud: {fullPath}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Faili kustutamisel tekkis viga: {ex.Message}");
            }
        }

        private void Uuenda_btn_Click(object sender, EventArgs e)
        {
            if (Nimetus_txt.Text.Trim() != string.Empty && Kogus_txt.Text.Trim() != string.Empty && Hind_txt.Text.Trim() != string.Empty)
            {
                try
                {
                    conn.Open();

                    cmd = new SqlCommand("UPDATE Toode SET Nimetus = @nimetus, Kogus = @kogus, Hind = @hind, Pilt = @pilt, LaoID = @laduid WHERE Id = @ID", conn);
                    cmd.Parameters.AddWithValue("@nimetus", Nimetus_txt.Text);
                    cmd.Parameters.AddWithValue("@ID", Id_txt.Text);
                    cmd.Parameters.AddWithValue("@kogus", Kogus_txt.Text);
                    cmd.Parameters.AddWithValue("@hind", Hind_txt.Text);
                    cmd.Parameters.AddWithValue("@pilt", Nimetus_txt.Text + extension);

                    int laduId;

                    laduId = ((KeyValuePair<int, string>)LaduComboBox.SelectedItem).Key;
                    
                    cmd.Parameters.AddWithValue("@laduid", laduId);

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



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells["Id"].Value != null)
                {
                    ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                    Id_txt.Text = ID.ToString();

                    Nimetus_txt.Text = dataGridView1.Rows[e.RowIndex].Cells["Nimetus"].Value.ToString();
                    Kogus_txt.Text = dataGridView1.Rows[e.RowIndex].Cells["Kogus"].Value.ToString();
                    Hind_txt.Text = dataGridView1.Rows[e.RowIndex].Cells["Hind"].Value.ToString();

                    int selectedLaduId = (int)dataGridView1.Rows[e.RowIndex].Cells["LaoID"].Value;

                    for (int i = 0; i < LaduComboBox.Items.Count; i++)
                    {
                        var item = (KeyValuePair<int, string>)LaduComboBox.Items[i];
                        if (item.Key == selectedLaduId)
                        {
                            LaduComboBox.SelectedItem = item;
                            break;
                        }
                    }

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
                else
                {
                    MessageBox.Show("ei ole id");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
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

        private void Ladu_add_Click(object sender, EventArgs e)
        {
            Form2 addLaduForm = new Form2();

            addLaduForm.OnLaduAdded += LoadLaduComboBox;

            addLaduForm.ShowDialog();
        }
    }
}