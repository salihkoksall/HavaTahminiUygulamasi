using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace TasarimProje
{
   public  class Baglanti
    {

       public MySqlConnection baglanti;
     
       public Baglanti()
        {
            /* dosyayolu = dosyaYolu;
             baglanti= new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + dosyayolu + "; Extended Properties=Excel 12.0");
             baglanti.Open();
             dbSchema = baglanti.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);*/
            string MyConString = "SERVER=programteknik.com:3306;" +
       "DATABASE=gaztasm_bitirme;" +
       "UID=gaztasm_bitirme;" +
       "PASSWORD=bitirme2018;";
            baglanti = new MySqlConnection(MyConString);
            MySqlCommand command = baglanti.CreateCommand();
            MySqlDataReader Reader;
            command.CommandText = "select * from WeatherDB";
            baglanti.Open();
            Reader = command.ExecuteReader();
        


        }
       
    }
}
