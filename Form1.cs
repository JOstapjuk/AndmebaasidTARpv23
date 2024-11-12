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

        //private void Uuenda_btn_Click(object sender, EventArgs e)
        //{
        //    if (Nimetus_txt.Text.Trim() != string.Empty || Kogus_txt.Text.Trim() != string.Empty || Hind_txt.Text.Trim() != string.Empty)
        //    {
        //        try
        //        {
        //            conn.Open();
        //            cmd = new SqlCommand("update Tooded set Nimetus = @nimetus, Kogus = @kogus, Hind = @hind where Id = @ID", conn);
        //            cmd.Parameters.AddWithValue("@nimetus", Nimetus_txt.Text);
        //            cmd.Parameters.AddWithValue("@ID", Id_txt.Text);
        //            cmd.Parameters.AddWithValue("@kogus", Kogus_txt.Text);
        //            cmd.Parameters.AddWithValue("@hind", Hind_txt.Text);
        //            cmd.ExecuteNonQuery();
        //            conn.Close();
        //            NaitaAndmed();
        //        }
        //        catch
        //        {
        //            MessageBox.Show("Admebaasiga viga!");
        //        }
        //    }
        //    else 
        //    {
        //        MessageBox.Show("Sisesta andmed mille tahate uuenda");
        //    }
        //}

        private void Uuenda_btn_Click()
        {
            if (Id_txt.Text.Trim() != string.Empty)
            {
                try
                {
                    conn.Open();

                    string paring = "update Tooded set ";
                    bool esimine = true;

                    if (Nimetus_txt.Text.Trim() != string.Empty)
                    {
                        paring += "Nimetus = @nimetus";
                        cmd.Parameters.AddWithValue("@nimetus", Nimetus_txt.Text);
                        esimine = false;
                    }
                    else if (Kogus_txt.Text.Trim() != string.Empty)
                    {
                        if (!esimine) paring += ", "; 
                        paring += "Kogus = @kogus";
                        cmd.Parameters.AddWithValue("@kogus", Kogus_txt.Text);
                        esimine = false;
                    }
                    else (Hind_txt.Text.Trim() != string.Empty)
                    {
                        if (!esimine) paring += ", ";
                        paring += "Hind = @hind";
                        cmd.Parameters.AddWithValue("@hind", Hind_txt.Text);
                    }

                    paring += " where Id = @ID";
                    cmd = new SqlCommand(paring, conn);
                    cmd.Parameters.AddWithValue("@ID", Id_txt.Text);

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
                MessageBox.Show("Sisesta Id");
            }
        }
    }
}
