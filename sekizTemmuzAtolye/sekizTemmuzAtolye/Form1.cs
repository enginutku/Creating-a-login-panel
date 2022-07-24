using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sekizTemmuzAtolye
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            textBox2.PasswordChar = '*';
            
        }

        SqlDataReader get;
        SqlConnection conn = new SqlConnection("server=.; Initial Catalog=login; Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            string ss = "SELECT * FROM giris WHERE kullanici = @kullanici AND sifre = @sifre";
            SqlCommand check = new SqlCommand(ss, conn);
            check.Parameters.AddWithValue("@kullanici", textBox1.Text);
            check.Parameters.AddWithValue("@sifre", textBox2.Text);
            conn.Open();
            get = check.ExecuteReader();

            if (get.Read())
            {
                MessageBox.Show("Giriş Başarılı");
                Form f2 = new Form2();
                f2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatali kullanici adi ya da sifre");
            }
            conn.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }
    }
}
