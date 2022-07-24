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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            label3.Text = "";
            data();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sayi = Convert.ToInt32(textBox1.Text);
            int kalan = 0;

            for(int i = 1; i <= 10; i++)
            {
                kalan = sayi % i;
                listBox1.Items.Add(sayi + " % " + i + " = " + kalan);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e){}
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ay = Convert.ToInt32(textBox2.Text);

                switch (ay)
                {
                    case 1:
                        label3.Text = "Ocak";
                        label3.ForeColor = Color.Blue;
                        break;
                    case 2:
                        label3.Text = "Şubat";
                        label3.ForeColor = Color.Blue;
                        break;
                    case 3:
                        label3.Text = "Mart";
                        label3.ForeColor = Color.DeepPink;
                        break;
                    case 4:
                        label3.Text = "Nisan";
                        label3.ForeColor = Color.DeepPink;
                        break;
                    case 5:
                        label3.Text = "Mayıs";
                        label3.ForeColor = Color.DeepPink;
                        break;
                    case 6:
                        label3.Text = "Haziran";
                        label3.ForeColor = Color.Orange;
                        break;
                    case 7:
                        label3.Text = "Temmuz";
                        label3.ForeColor = Color.Orange;
                        break;
                    case 8:
                        label3.Text = "Ağustos";
                        label3.ForeColor = Color.Orange;
                        break;
                    case 9:
                        label3.Text = "Eylül";
                        label3.ForeColor = Color.Brown;
                        break;
                    case 10:
                        label3.Text = "Ekim";
                        label3.ForeColor = Color.Brown;
                        break;
                    case 11:
                        label3.Text = "Kasım";
                        label3.ForeColor = Color.Brown;
                        break;
                    case 12:
                        label3.Text = "Aralık";
                        label3.ForeColor = Color.Blue;
                        break;
                    default:
                        MessageBox.Show("1 ile 12 arasi deger giriniz!");
                        break;
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e){}

        private void button3_Click(object sender, EventArgs e)
        {
            double negatif = Convert.ToInt32(textBox3.Text);
            double mutlak = Math.Abs(negatif);
            double karekok = Math.Sqrt(mutlak);
            double kare = Math.Pow(mutlak, 2);

            if(negatif >= 0)
            {
                MessageBox.Show("Negatif deger giriniz.");
            }
            else
            {
                listBox2.Items.Add(negatif + " mutlak degeri = " + mutlak);
                listBox2.Items.Add(mutlak + " karekoku = " + karekok);
                listBox2.Items.Add(negatif + " karesi = " + kare);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox3.Items.Add(textBox4.Text);
            textBox4.Clear();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        SqlConnection conn = new SqlConnection("server=.; Initial Catalog=login; Integrated Security=True");
        private void data()
        {
            conn.Open();
            string bring = "SELECT * FROM kayit";
            SqlDataAdapter adapter = new SqlDataAdapter(bring, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void label8_Click(object sender, EventArgs e){}
        private void label7_Click(object sender, EventArgs e){}

        private void button5_Click(object sender, EventArgs e)
        {
            string ss = "INSERT INTO kayit (id, name, surname ,telephone, address) VALUES (@id, @name, @surname, @telephone, @address)";
            SqlCommand add = new SqlCommand(ss, conn);
            add.Parameters.AddWithValue("@id", textBox5.Text);
            add.Parameters.AddWithValue("@name", textBox6.Text);
            add.Parameters.AddWithValue("@surname", textBox7.Text);
            add.Parameters.AddWithValue("@telephone", textBox8.Text);
            add.Parameters.AddWithValue("@address", textBox9.Text);
            conn.Open();
            add.ExecuteNonQuery();
            conn.Close();
            data();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            conn.Open();
            string deleting = "DELETE FROM kayit WHERE id = @id";
            SqlCommand delete = new SqlCommand(deleting, conn);
            delete.Parameters.AddWithValue("@id", textBox5.Text);
            delete.ExecuteNonQuery();
            conn.Close();
            data();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            conn.Open();
            string updating = "UPDATE kayit SET id = @id, name = @name, surname = @surname, telephone = @telephone, address = @address WHERE id = @id";
            SqlCommand update = new SqlCommand(updating, conn);
            update.Parameters.AddWithValue("@id", textBox5.Text);
            update.Parameters.AddWithValue("@name", textBox6.Text);
            update.Parameters.AddWithValue("@surname", textBox7.Text);
            update.Parameters.AddWithValue("@telephone", textBox8.Text);
            update.Parameters.AddWithValue("@address", textBox9.Text);
            update.ExecuteNonQuery();
            conn.Close();
            data();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            conn.Open();
            DataTable dtt = new DataTable();
            SqlDataAdapter adapterr = new SqlDataAdapter("SELECT name FROM kayit WHERE name LIKE '%" + textBox10.Text + "%'", conn);
            adapterr.Fill(dtt);
            dataGridView2.DataSource = dtt;
            conn.Close();
        }

        private void label10_Click(object sender, EventArgs e){}
    }
}
