using System.Collections.Generic;
using UnityEngine;
using System.Data.SqlClient;
using System;
using System.Data;
using System.IO;

public static class DBconnection
{
    public static List<Lokal> lokali;
    public static List<Brand> brandovi;
    public static List<BrandLokal> brand_lokal;
    public static List<Reklama> reklame;
    public static List<User> users;
    public static AllDatabaseClasses allDatabase;
    public static Action<AllDatabaseClasses> OnEndDatabaseConnection;

    public static void GetData()
    {
        DBconnection.OnEndDatabaseConnection += JsonManager.SaveJson;
        lokali = new List<Lokal>();
        brandovi = new List<Brand>();
        brand_lokal = new List<BrandLokal>();
        reklame = new List<Reklama>();
        users = new List<User>();
        // using(SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-TRKR9Q\SQLEXPRESS,1433;User ID=MyLogin;Password=12345; Initial Catalog=ParkIndjija;"))
        using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-RI6AJAR\SQLEXPRESS,1433;User ID=test;Password=test; Initial Catalog=ParkIndjija;"))
        {
            try
            {
                connection.Open();
                SqlCommand com = connection.CreateCommand();

                com.CommandText = "Select * from Lokali";
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lokali.Add(new Lokal(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), (byte[])rdr.GetValue(3), (byte[])rdr.GetValue(4), rdr.GetString(5)));
                }
                rdr.Close();

                com = connection.CreateCommand();
                com.CommandText = "Select * from Brandovi";
                rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    brandovi.Add(new Brand(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2)));
                }
                rdr.Close();

                com = connection.CreateCommand();
                com.CommandText = "Select * from Brand_Lokal";
                rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    brand_lokal.Add(new BrandLokal(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetInt32(2)));
                }
                rdr.Close();

                com = connection.CreateCommand();
                com.CommandText = "Select * from Reklame";
                rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    reklame.Add(new Reklama(rdr.GetInt32(0), rdr.GetString(1), (byte[])rdr.GetValue(2), Convert.ToSingle(rdr.GetValue(3)), rdr.GetString(4), rdr.GetString(5)));
                }
                rdr.Close();

                com = connection.CreateCommand();
                com.CommandText = "Select * from Users";
                rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    users.Add(new User(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3)));
                }
                rdr.Close();
                connection.Close();
                CreateLocalDatabase();
            }
            catch(Exception e)
            {
                Debug.Log("----------- GRESKA! ----------- \n " + e.Message);

                JsonManager.LoadJson();
            }
        }
    }

    private static void CreateLocalDatabase()
    {
        if (lokali.Count > 0)
        {
            allDatabase = new AllDatabaseClasses(lokali, brandovi, brand_lokal, reklame, users);
        }
        OnEndDatabaseConnection?.Invoke(allDatabase);
        Debug.Log(Application.persistentDataPath);
    }

    public static UnityEngine.Object ByteToTexture(byte[] data)
    {
        Texture2D texture = new Texture2D(100, 100);
        texture.LoadImage(data);
        //Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),new Vector3());
        //return sprite;
        return texture;
    }
    public static UnityEngine.Object ByteToVideo(byte[] data)
    {
        File.WriteAllBytes(Application.persistentDataPath + "temp.mp4", data);
        UnityEngine.Object temp = Resources.Load("temp.mp4");
        File.Delete(Application.persistentDataPath + "temp.mp4");
        return temp;
    }

    /*               KOD ZA UPLOAD SLIKE U BAZU 

        byte[] imageData = File.ReadAllBytes(@"C:\Users\nikol\Desktop\baza\adidas.png");
        com = connection.CreateCommand();
        com.CommandText = "UPDATE Lokali SET lokalLogo= @Param";
        SqlParameter param = com.Parameters.Add("@Param", SqlDbType.VarBinary, imageData.Length);
        param.Value = imageData;
        int test = com.ExecuteNonQuery();

    */
}
