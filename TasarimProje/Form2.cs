using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MathNet;

namespace TasarimProje
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void islemler(DataGridView dty,DataGridView dtc,DataGridView dtTahmini,DataGridView dtAnaliz,Chart chart1 ,int modelno)
        {
         
            double[,] x;
            double[,] y;
            double[,] Cmodel;
            double[,] YussuModel;
            if (modelno != 7)
            {

                x = Form1.matris.ModelMatrix(modelno, 0);
                y = Form1.matris.ModelMatrix(modelno, 1);
      
                Cmodel = Form1.matris.HesaplaModel(x, y);
                YussuModel = Form1.matris.MatrisCarpim(x, Cmodel);
                Form1.matris.Sonuc(dty, y, 1);
                Form1.matris.Sonuc(dty, YussuModel, 2);
                Form1.matris.Sonuc(dtc, Cmodel, 0);
                dtTahmini.ColumnCount = 1;
                dtTahmini.Rows.Add(7);
                for (int i = 0; i < 7; i++)
                    dtTahmini.Rows[i].Cells[0].Value = Form1.matris.TahminiDegerler[i];

                Form1.matris.IstatistikiSonuclar(dtAnaliz, x, y, YussuModel);
                for (int i = 0; i < Cmodel.Length; i++)
                {
                    chart1.Series["Y"].Points.DataBindY(y);
                    chart1.Series["Y'"].Points.DataBindY(YussuModel);


                }
            }
            else {
                double[,] xmodel = Form1.matris.mtrxX;
                y = Form1.matris.mtrxY;
                Cmodel = Form1.matris.HesaplaModel(xmodel, y);
                YussuModel = Form1.matris.MatrisCarpim(xmodel, Cmodel);
                Form1.matris.Sonuc(dty, y, 1);
                Form1.matris.Sonuc(dty, YussuModel, 2);
                Form1.matris.Sonuc(dtc, Cmodel, 0);
                dtTahmini.ColumnCount = 1;
                dtTahmini.Rows.Add(7);
                for (int i = 0; i < 7; i++)
                    dtTahmini.Rows[i].Cells[0].Value = Form1.matris.TahminiDegerler[i];

                Form1.matris.IstatistikiSonuclar(dtAnaliz, xmodel, y, YussuModel);
                for (int i = 0; i < Cmodel.Length; i++)
                {
                    chart1.Series["Y"].Points.DataBindY(y);
                    chart1.Series["Y'"].Points.DataBindY(YussuModel);


                }
            }


        }
        private void Form2_Load(object sender, EventArgs e)
        {

            
            islemler(dataGridView2,dataGridView3,dataGridView22,dataGridView1,chart1,1);
            islemler(dataGridView5, dataGridView4, dataGridView23, dataGridView16, chart2, 2);
            islemler(dataGridView7, dataGridView6, dataGridView24, dataGridView17,chart3, 3);
            islemler(dataGridView9, dataGridView8, dataGridView25, dataGridView18, chart4, 4);
            islemler(dataGridView11, dataGridView10, dataGridView26, dataGridView19, chart5, 5);
            islemler(dataGridView13, dataGridView12, dataGridView27, dataGridView20, chart6, 6);
            islemler(dataGridView15, dataGridView14, dataGridView28,dataGridView21, chart7, 7);
           
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
