using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AndmebaasidTARpv23
{
    public partial class ShopForm : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\Source\Repos\AndmebaasidTARpv23\Toode.mdf;Integrated Security=True");

        public ShopForm(string username)
        {
            InitializeComponent();
        }
    }
}