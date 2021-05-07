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

namespace Arkadaş_Takip_Sistemi
{
    public partial class Form1 : Form
    {
        SqlConnection bgl = new SqlConnection("Data Source=DESKTOP-PKO8JLN\\SQLEXPRESS;Initial Catalog=DBArkadaş;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        void listele()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from TblArkadaş",bgl);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
           
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bgl.Open();
                listBox1.Items.Clear();
                SqlCommand k = new SqlCommand("Select Ad,Soyad from TblArkadaş where Ad like'" + textBox1.Text + "%'", bgl);
                SqlDataReader dr = k.ExecuteReader();
                while (dr.Read())
                {
                    listBox1.Items.Add(dr[0].ToString() + " " + dr[1].ToString());

                    if (textBox1.Text == "")
                    {
                        listBox1.Items.Clear();
                    }
                   
                }
               
            }
                                      
            catch (Exception)
            {

                
            }
            bgl.Close();
        }
        int sayac = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" && textBox3.Text=="")
            {
                MessageBox.Show("Eksik Bilgiler Mevcut", "Arkadaş Kayıt Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                              
                FrmP f = new FrmP();
                f.Show();              
                bgl.Open();
                SqlCommand d = new SqlCommand("insert into TblArkadaş (Ad,Soyad,Telefon,Cinsiyet,Doğum,Adres) values (@p1,@p2,@p3,@p4,@p5,@p6)", bgl);
                d.Parameters.AddWithValue("@p1", textBox2.Text);
                d.Parameters.AddWithValue("@p2", textBox3.Text);
                d.Parameters.AddWithValue("@p3", maskedTextBox1.Text);
                d.Parameters.AddWithValue("@p4", textBox4.Text);
                d.Parameters.AddWithValue("@p5", textBox5.Text);
                d.Parameters.AddWithValue("@p6", richTextBox1.Text);
                d.ExecuteNonQuery();
                bgl.Close();
                listele();
            }

        }

        private void maskedTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" && textBox3.Text == "")
            {
                MessageBox.Show("Eksik Bilgiler Mevcut", "Arkadaş Kayıt Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
              
                FrmP f = new FrmP();
                f.Show();
                bgl.Open();
                SqlCommand d = new SqlCommand("delete from TblArkadaş where Ad=@p1 and Soyad=@p2", bgl);
                d.Parameters.AddWithValue("@p1",textBox2.Text);
                d.Parameters.AddWithValue("@p2",textBox3.Text);
                d.ExecuteNonQuery();
                bgl.Close();
                listele();

            }
           


        }

        private void button3_Click(object sender, EventArgs e)
        {
     
            if (textBox2.Text == "" && textBox3.Text == "")
            {
                MessageBox.Show("Eksik Bilgiler Mevcut", "Arkadaş Kayıt Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                FrmP f = new FrmP();
                f.Show();
                bgl.Open();
                SqlCommand x = new SqlCommand("update TblArkadaş set Ad=@p1,Soyad=@p2,Telefon=@p3,Cinsiyet=@p4,Doğum=@p5,Adres=@p6 where Ad=@p1 and Soyad=@p2", bgl);
                x.Parameters.AddWithValue("@p1", textBox2.Text);
                x.Parameters.AddWithValue("@p2", textBox3.Text);
                x.Parameters.AddWithValue("@p3", maskedTextBox1.Text);
                x.Parameters.AddWithValue("@p4", textBox4.Text);
                x.Parameters.AddWithValue("@p5", textBox5.Text);
                x.Parameters.AddWithValue("@p6", richTextBox1.Text);
                x.ExecuteNonQuery();
                bgl.Close();
                listele();

            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            richTextBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[5].ToString();

        }
    }
}
