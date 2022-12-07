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

namespace sql_veri_silmee
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=ERCANMONSTER\\ERCANSERVER;Initial Catalog=KÜTÜPHANE;Integrated Security=True");
        private void ShowData()
        {
            baglan.Open();
            SqlCommand command = new SqlCommand("Select * From KİTAPLAR", baglan);
            SqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                ListViewItem  ekle = new ListViewItem();
                ekle.Text = read["KİTAPID"].ToString();
                ekle.SubItems.Add(read["KİTAPADI"].ToString());
                ekle.SubItems.Add(read["KİTAPYAZAR"].ToString());
                ekle.SubItems.Add(read["KİTAPYAYINEVİ"].ToString());
                ekle.SubItems.Add(read["KİTAPSAYFA"].ToString());

                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
          ShowData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand command = new SqlCommand(" insert into KİTAPLAR(KİTAPID,KİTAPADI,KİTAPYAZAR,KİTAPYAYINEVİ,KİTAPSAYFA) values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString()+"' )", baglan);
            command.ExecuteNonQuery();
            ShowData();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
        int ıD = 0;

        private void button4_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand commmand = new SqlCommand("delete from KİTAPLAR where KİTAPID =(" + ıD + ")", baglan);
            commmand.ExecuteNonQuery();
            baglan.Close();
            ShowData();

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ıD = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text =( listView1.SelectedItems[0].SubItems[0].Text);
            textBox2.Text = (listView1.SelectedItems[0].SubItems[1].Text);
            textBox3.Text = (listView1.SelectedItems[0].SubItems[2].Text);
            textBox4.Text = (listView1.SelectedItems[0].SubItems[3].Text);
            textBox5.Text = (listView1.SelectedItems[0].SubItems[4].Text);
            
        }
    }
}
