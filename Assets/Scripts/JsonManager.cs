using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonManager : MonoBehaviour
{

    AllDatabaseClasses localDatabase;
    public string fileName = "TextDatabase.txt";


    private void Awake()
    {
        DBconnection.OnEndDatabaseConnection += SaveJson;
    }

    public void SaveJson(AllDatabaseClasses allDatabase)
    {

        string json = JsonConvert.SerializeObject(allDatabase);
        WriteToFile(fileName, json);

    }

    public void LoadJson()
    {
        string json = ReadFromFile(fileName);
        localDatabase = JsonConvert.DeserializeObject<AllDatabaseClasses>(json);
    }

    private void WriteToFile(string fileName, string json)
    {
        string path = GetFilePath(fileName);
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }
    }

    private string ReadFromFile(string fileName)
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

    private string GetFilePath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName;
    }
}
