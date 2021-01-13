using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class JsonManager
{

    public static AllDatabaseClasses localDatabase;
    public static string fileName = "TextDatabase.txt";

    public static void SaveJson(AllDatabaseClasses allDatabase)
    {

        string json = JsonConvert.SerializeObject(allDatabase);
        WriteToFile(fileName, json);

    }
    public static void LoadJson()
    {
        string json = ReadFromFile(fileName);
        localDatabase = JsonConvert.DeserializeObject<AllDatabaseClasses>(json);
        if (localDatabase.lokali.Count > 0)
        {
            DBconnection.lokali = localDatabase.lokali;
            DBconnection.reklame = localDatabase.reklame;
            DBconnection.brandovi = localDatabase.brandovi;
            DBconnection.brand_lokal = localDatabase.brand_lokal;
            DBconnection.users = localDatabase.users;
        }
    }
    private static void WriteToFile(string fileName, string json)
    {
        string path = GetFilePath(fileName);
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }
    }
    private static string ReadFromFile(string fileName)
    {
        string path = GetFilePath(fileName);
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                return json;
            }
        }
        else
        {
            Debug.Log("Local database not found");
            return "";
        }
    }
    private static string GetFilePath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName;
    }
}
