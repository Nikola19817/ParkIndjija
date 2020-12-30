using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data.Sql;
using System.Data.SqlClient;

public static class DBconnection
{
    public static List<Lokal> lokali;
    public static List<Brand> brandovi;
    public static List<BrandLokal> brand_lokal;
    public static List<Reklama> reklame;
    public static List<User> users;

    public static void GetData()
    {
        lokali = new List<Lokal>();
        brandovi = new List<Brand>();
        brand_lokal = new List<BrandLokal>();
        reklame = new List<Reklama>();
        users = new List<User>();

        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-RI6AJAR\SQLEXPRESS,1433;User ID=test;Password=test; Initial Catalog=ParkIndjija;");
        connection.Open();
        SqlCommand com = connection.CreateCommand();
        
        com.CommandText = "Select * from Lokali";
        SqlDataReader rdr = com.ExecuteReader();
        while (rdr.Read())
        {
            lokali.Add(new Lokal(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5)));
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
            reklame.Add(new Reklama(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetFloat(3), rdr.GetString(4)));
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
    }
}
