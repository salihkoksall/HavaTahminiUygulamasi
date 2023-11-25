using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using MySql.Data.MySqlClient;


namespace TasarimProje
{


    
    
    public partial class Form1 : Form
    {



        public int Sutun = 0;



        
        public int Satir = 0;
        public String DosyaIsmi;
        void SatirSutunHesapla()
        {

            for (int j = 0; j < dataGridView1.ColumnCount; j++)
            {
                if (dataGridView1.Rows[0].Cells[j].Value.ToString() != "")
                    Sutun++;
                else
                    break;

            }

            Satir = dataGridView1.RowCount-8;


        }
        public Form1()
        {
            InitializeComponent();
            textBox1.Hide();
        }
        public static MatrisIslem matris = new MatrisIslem();

      
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_Click(object sender, EventArgs e)
        {
            Satir = 0;
            Sutun = 0;
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            comboBox2.Items.Clear();
            string MyConString = "SERVER=;" +
"DATABASE=;" +
"UID=;" +
"PASSWORD=;";
            string Komut = "select * from WeatherDB";
            MySqlConnection connection = new MySqlConnection(MyConString);
            try
            {
   
                MySqlCommand command = connection.CreateCommand();
                MySqlDataAdapter da = new MySqlDataAdapter(Komut, MyConString);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                throw;
            }
           
           
            comboBox2.Items.Add("Hafta");
            comboBox2.Items.Add("Ay");
            comboBox2.Items.Add("Yıl");
            comboBox2.Items.Add("Diğer");

            

            /* for(int i=0;i<dataGridView1.Rows.Count;i++)
                 for(int j=0;j<dataGridView1.Columns.Count;j++)
                 {
                     if (dataGridView1.Rows[i].Cells[j].DataGridView.)
                         dataGridView1.Rows[i].Cells[j].Value = 1;
                     else
                         dataGridView1.Rows[i].Cells[j].Value =0 ;


                 }*/
            SatirSutunHesapla();
            dataGridView2 = matris.MatrisXYSecim(dataGridView1, Satir, Sutun, dataGridView2);
            dataGridView3 = matris.MatrisXYSecim(dataGridView1, Satir, Sutun, dataGridView3);
            button1.Visible = true;
            connection.Close();





        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sayacX = 0;
            int sayacY = 0;

            for (int i = 0; i < dataGridView2.RowCount; i++)
            {

                if (dataGridView2.Rows[i].Selected == false)
                {
                    sayacX++;
                }
                if (dataGridView3.Rows[i].Selected == false)
                {
                    sayacY++;
                }
            }
            if(sayacX==dataGridView2.RowCount)
            {
                MessageBox.Show("Lütfen Bağımlı Değişkenleri Belirleyiniz.....!!!!!!");
            }
            else if(sayacY== dataGridView3.RowCount)
            {
                MessageBox.Show("Lütfen Bağımsız Değişkeni Belirleyiniz.....!!!!!!");

            }
            else
            {
                try
                {
                    matris.MatrisDoldur(dataGridView1, Satir, Sutun, dataGridView2, dataGridView3);


                    Form2 goster = new Form2();

                    goster.Show();
                }
                catch (Exception )
                {
             
                    throw;
                }
            }
            
           
            
           
                
        }
        
     

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


       

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            
            
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            

         

            
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

        /*private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Satir = 0;
            Sutun = 0;
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();

            Baglanti baglanti=new Baglanti();
            string komut = "";
            OleDbCommand cmd = new OleDbCommand(komut, baglanti.baglanti);
            OleDbDataAdapter da = new OleDbDataAdapter(komut, baglanti.baglanti);
            OleDbDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt.DefaultView;

            SatirSutunHesapla();
            dataGridView2 = matris.MatrisXYSecim(dataGridView1, Satir, Sutun, dataGridView2);
            dataGridView3 = matris.MatrisXYSecim(dataGridView1, Satir, Sutun, dataGridView3);
            baglanti.baglanti.Close();
            
            button1.Visible = true;
            
            
        }*/

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() == "Hafta")
            {
                
                matris.sezon = 7;
                textBox1.Hide();

            }
              
            else if (comboBox2.SelectedItem.ToString() == "Ay")
            {
                
                matris.sezon = 30;
                textBox1.Hide();
            }
              
            else if (comboBox2.SelectedItem.ToString() == "Yıl")
            {
                
                matris.sezon = 360;
                textBox1.Hide();
            }
               
            else if (comboBox2.SelectedItem.ToString() == "Diğer")
            {
                textBox1.Show();
                MessageBox.Show("Lütfen Sezon Belirleyiniz!!!!!!");
             

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            matris.sezon = Convert.ToInt32(textBox1.Text);
    
        }
    }
}
