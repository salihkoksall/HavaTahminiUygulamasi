using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Drawing2D;
using MathNet.Numerics.LinearRegression;
namespace TasarimProje
{
    public class MatrisIslem
    {
        public double[,] mtrxX;
        public double[,] mtrxY;
        public double[,] Yussu;
        public double[,] C;
        public double[,] TahminiDegerlerIslenmemis;
        public double[] TahminiDegerler = new double[7];
        public int sezon;

        
        public MatrisIslem()
        {

        }
         ~MatrisIslem()
        {

        }

        #region Matris Transpoze İşlemi

        public double[,] Transpoze(double[,] matrisA)
        {
            double[,] matris = new double[matrisA.GetUpperBound(1) + 1, matrisA.GetUpperBound(0) + 1];
            for (int i = 0; i <= matrisA.GetUpperBound(1); i++)
                for (int j = 0; j <= matrisA.GetUpperBound(0); j++)
                    matris[i, j] = matrisA[j, i];


            return matris;
        }
        #endregion
        public double[,] Cevir(double[,] matrisA)
        {
            double[,] matris = new double[matrisA.GetUpperBound(0), matrisA.GetUpperBound(1)];
            for (int i = 0; i < matrisA.GetUpperBound(0); i++)
                for (int j = 0; j < matrisA.GetUpperBound(1); j++)
                    matris[i, j] = matrisA[i, j];


            return matris;
        }
        public double[,] MatrisCarpim(double[,] Tmatris, double[,] Nmatris)
        {
            double[,] Carpim = new double[Tmatris.GetUpperBound(0) + 1, Nmatris.GetUpperBound(1) + 1];
            for (int i = 0; i < Carpim.GetUpperBound(0) + 1; i++)
                for (int k = 0; k < Carpim.GetUpperBound(1) + 1; k++)
                    for (int j = 0; j < Tmatris.GetUpperBound(1) + 1; j++)
                        Carpim[i, k] += Tmatris[i, j] * Nmatris[j, k];
            return Carpim;
        }
        public double[,] MatrisCarpim2(double[][] Tmatris)
        {
            int deneme = Tmatris.GetLength(0);
            double[,] Carpim = new double[Tmatris.GetLength(0), Tmatris.GetLength(0)];
            for (int i = 0; i <= Carpim.GetUpperBound(1); i++)
                for (int k = 0; k <= Carpim.GetUpperBound(1); k++)

                    Carpim[i, k] = Tmatris[i][k];

            return Carpim;
        }
        public double[][] MatrisTers(double[,] matrixA)
        {
            double ratio, a;
            int n = matrixA.GetUpperBound(0) + 1;

            double[][] matrixB = new double[n][];
            for (int i = 0; i < n; i++)
                matrixB[i] = new double[n];

            double[][] matrix2 = new double[n][];
            for (int i = 0; i < n; i++)
                matrix2[i] = new double[2 * n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix2[i][j] = matrixA[i, j];
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = n; j < 2 * n; j++)
                {
                    if (i == (j - n))
                        matrix2[i][j] = 1.0;
                    else
                        matrix2[i][j] = 0.0;
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        if (matrix2[i][i] == 0)
                            ratio = 1;
                        else
                        ratio = matrix2[j][i] / matrix2[i][i];
                        for (int k = 0; k < 2 * n; k++)
                        {
                            matrix2[j][k] -= ratio * matrix2[i][k];
                        }
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                a = matrix2[i][i];
                for (int j = 0; j < 2 * n; j++)
                {
                    matrix2[i][j] /= a;
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrixB[i][j] = matrix2[i][n + j];
                }
            }

            return matrixB;
           

        }
        public double[,] Hesapla()
        {
            try
            {

                C = MatrisCarpim(MatrisCarpim(MatrisCarpim2(MatrisTers(MatrisCarpim(Transpoze(mtrxX), mtrxX))), Transpoze(mtrxX)), mtrxY);
                return C;
            }
            catch (Exception)
            {
                MessageBox.Show("Bu matrisin tersi Alınamaz!!!!!!!");
                throw;
            }
            
        }
        public void MatrisYazdir(DataGridView dataGridView, DataGridView dataGridView2)
        {
            dataGridView.ColumnCount = mtrxX.GetUpperBound(1) + 1;
            dataGridView.Rows.Add(mtrxX.GetUpperBound(0) + 1);
            dataGridView2.ColumnCount = mtrxY.GetUpperBound(1) + 1;
            dataGridView2.Rows.Add(mtrxY.GetUpperBound(0) + 1);
            for (int i = 0; i <= mtrxX.GetUpperBound(0); i++)
                for (int j = 0; j <= mtrxX.GetUpperBound(1); j++)
                {

                    dataGridView.Rows[i].Cells[j].Value = mtrxX[i, j];

                }
            for (int i = 0; i <= mtrxY.GetUpperBound(0); i++)
                for (int j = 0; j <= mtrxY.GetLowerBound(1); j++)
                {

                    dataGridView2.Rows[i].Cells[j].Value = mtrxY[i, j];
                }
        }
        public void MatrisDoldur(DataGridView dataGridView1,int Satir,int Sutun,DataGridView dataGridView,DataGridView dataGridView2)
        {
            mtrxX = new double[Satir ,dataGridView.SelectedRows.Count+1];
            mtrxY = new double[Satir , 1];
            TahminiDegerlerIslenmemis = new double[7, dataGridView.SelectedRows.Count ];
           
                   
                    for (int i = 0; i < Satir; i++)
            {
                
                int sayi = 1;

                for (int j = 0; j <Sutun; j++)
                {

                
                    if(j==0)
                        mtrxX[i, 0] = 1;
                   if (dataGridView.Rows[j].Selected == true)


                    {
                       

                        mtrxX[i, sayi] = Convert.ToDouble(dataGridView1[j, i].Value);

                        sayi++;
                    }
                    
                       
                }
                
            }

            for (int i = 0; i < mtrxY.GetUpperBound(0) + 1; i++)
            {
               

                for (int j = 0; j < Sutun; j++)
                {


                   
                    if (dataGridView2.Rows[j].Selected == true)


                    {


                        mtrxY[i, 0] = Convert.ToDouble(dataGridView1[j, i].Value);

                        
                    }
                    

                }

            }
            for(int i=0;i<7;i++)
            { int sayi = 0;
                for (int j = 0; j < Sutun; j++)
                    if (dataGridView.Rows[j].Selected == true)
                    {
                        TahminiDegerlerIslenmemis[i, sayi] = Convert.ToDouble(dataGridView1[j, 397+i].Value);
                        sayi++;
                    }
            }
            int deneme = 0;
                


        }
        public DataGridView Sonuc(DataGridView dataGridView2,double[,] Dizi,int  a)
        {
            dataGridView2.ColumnCount = 3;
            dataGridView2.Rows.Add(Dizi.GetUpperBound(0) + 1);


            for (int i = 0; i <=
                Dizi.GetUpperBound(0); i++)
                dataGridView2.Rows[i].Cells[0].Value =i+1;
            for (int i = 0; i <= Dizi.GetUpperBound(0); i++)
                for (int j = 0; j <=Dizi.GetLowerBound(1); j++)
                {
                    dataGridView2.Rows[i].Cells[a].Value =Dizi[i, j];
                }
            return dataGridView2;
        }
        public DataGridView MatrisXYSecim(DataGridView dataGridView,int Satir,int Sutun,DataGridView dataGridView1)
        {
            dataGridView1.ColumnCount =1;
            dataGridView1.Rows.Add(Sutun);


            for (int j = 0; j < Sutun; j++)
            {
               
                dataGridView1.Rows[j].Cells[0].Value = dataGridView.Columns[j].HeaderText.ToString ();

                }
            return dataGridView1;
        }
        public DataGridView IstatistikiSonuclar(DataGridView data,double[,]x,double[,] y,double[,] yussu)
        {
            data.ColumnCount = 4;
            data.Rows.Add(1);
            for(int i=0;i<4;i++)
                switch (i)
                {
                    case 0:
                        {
                            double Toplam = 0;
                            for (int k = 0; k < y.Length ; k++)
                                for (int j = 0; j < 1; j++)
                                    Toplam += Math.Pow(y[k, j] - yussu[k, j],2);
                            data.Rows[0].Cells[0].Value = Toplam / y.Length;

                            break;
                        }
                    case 1:
                        {
                            double Toplam = 0;
                            for (int k = 0; k < y.Length; k++)
                                for (int j = 0; j < 1; j++)
                                    Toplam += Math.Abs((y[k, j] - yussu[k, j])) / y[k, j];
                            data.Rows[0].Cells[1].Value = Toplam / y.Length;
                            break;
                        }
                    case 2:
                        {
                            double Toplam1 = 0;
                            double Toplam = 0;
                            double AnaToplam = 0;
                            double ortalama = 0;
                            for (int k = 0; k < y.Length; k++)
                                for (int j = 0; j < 1; j++)
                                    Toplam += y[k, j];
                            ortalama = Toplam / y.Length;
                            Toplam = 0;
                            for (int k = 0; k < y.Length; k++)
                                for (int j = 0; j < 1; j++)
                                    Toplam1 += Math.Pow(y[k, j] - ortalama, 2);

                            for (int k = 0; k < y.Length; k++)
                                for (int j = 0; j < 1; j++)
                                    Toplam += Math.Pow(y[k, j] -yussu[k,j], 2);
                            AnaToplam = (1 - (Toplam / Toplam1));
                            data.Rows[0].Cells[2].Value = AnaToplam;
                          

                            break;
                        }
                    case 3:
                        {
                            double Toplam1 = 0;
                            for (int k = 0; k < y.Length ; k++)
                                for (int j = 0; j < 1; j++)
                                    Toplam1 += Math.Pow(mtrxY[k, j] - yussu[k,j], 2);
                            data.Rows[0].Cells[3].Value = Toplam1;
                            break;
                        }
                }

            return data;
        }
      /*  public void VirgulAyarla()
        {
            for (int i = 0; i <Yussu.Length; i++)
                for (int j = 0; j <1; j++)
                {
                    string sonuc;
                    sonuc =Yussu[i, j].ToString("0.######");
                    Yussu[i, j] =Convert.ToDouble(sonuc);
                }


        }*/
        public double[,] ModelMatrix(int Modelno,int Matrisno)
        {


           
            int DataSayi = mtrxX.GetUpperBound(0);
            int KolonSayi = mtrxX.GetUpperBound(1)+1;
            int KolondakiSifirSayisi = 0;
            int SilinenKolonSayisi = 0;
            int[] index=new int[35];
            



            for (int l = 0; l < KolonSayi; l++)
            {
                int tmp = DataSayi;
                for (int u = 0; u < Modelno * sezon; u++)
                {
                    if (mtrxX[tmp, l] == 0)
                    {
                        KolondakiSifirSayisi++;

                        if (KolondakiSifirSayisi == Modelno * sezon)
                        {
                            
                            index[SilinenKolonSayisi] = l;
                            SilinenKolonSayisi++;



                        }

                    }
                    tmp--;
                }

                KolondakiSifirSayisi = 0;
                

            }
            double[,] x = new double[Modelno * sezon, KolonSayi-SilinenKolonSayisi];
            double[,] y = new double[Modelno * sezon, 1];



            for (int i = 0; i<Modelno*sezon; i++)
            {
                int deneme = 0;
                int temp=999;
                for (int j = 0; j < KolonSayi; j++)
                    {
                
                    if (j == 0)
                        y[i, j] = mtrxY[DataSayi, j];

                    for (int m = 0; m <= j; m++)
                        if (j == 0)
                            break;
                        else if (j == index[m])
                        {

                            temp = j;
                            deneme++;
                            break;
                          
                            
                        }
                    if (temp == j)
                        continue;
                    else
                        x[i, j - deneme] = mtrxX[DataSayi, j];






                }

                    DataSayi--;

                             
               
            }
            double[,] Cmodel = HesaplaModel(x, y);
          

           
            for (int i=0;i<7;i++)
            {
                int sayac = 0;
                for (int j = 0; j < KolonSayi-1; j++)
                {
                    int kontrol = 0;
                    for (int k = 0; k <SilinenKolonSayisi; k++)
                        if (j == (index[k] - 1))
                            kontrol++;
                        if (sayac == 0&&kontrol==0)
                    {
                        TahminiDegerler[i] = Cmodel[sayac, 0];
                        sayac++;
                        TahminiDegerler[i] = TahminiDegerler[i] + TahminiDegerlerIslenmemis[i, j] * Cmodel[sayac, 0];
                    }
                        
                        else if(kontrol==0)
                        {
                        sayac++;
                        TahminiDegerler[i] = TahminiDegerler[i] + TahminiDegerlerIslenmemis[i, j] * Cmodel[sayac, 0];
                        
                    }
                  
                    
                    continue;
                }
             
            }
                

            if (Matrisno == 0)
                return x;
            else
                return y;
         
        }
        public double[,] HesaplaModel(double[,] x,double[,] y)
        {
            double[,] c= MatrisCarpim(MatrisCarpim(MatrisCarpim2(MatrisTers(MatrisCarpim(Transpoze(x), x))), Transpoze(x)), y);
            return c;
        }
       /* public double[,] SifirSutunTemizle(double[,] x)
        {
            int DataSayi = x.GetUpperBound(0);
            int KolonSayi = x.GetUpperBound(1) + 1;
            int sayac = 0;
            for (int j = 0; j <KolonSayi; j++)
                for (int i = 0; i < DataSayi; i++)
                {
                    if (x[i, j] == 0)
                    {
                        sayac++;
                        if(sayac==DataSayi)
                        {
                            for (int k = 0; k < DataSayi; k++)
                            {
                                if (j + 1 != KolonSayi)
                                {
                                    
                                    x[k, j] = x[k, j + 1];
                                    x[k, j + 1] = x[k,j];

                                }
                                else
                                {

                                }
                                    
                            }
                            sayac = 0;
                               
                        }

                    }
                      

                }
                    


                    return x;
        }*/

    }
     
}
