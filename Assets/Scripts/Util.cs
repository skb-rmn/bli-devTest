using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Util
{
    readonly string FILE_DIR = string.Format("{0}/PlayerData.dat", Application.persistentDataPath);
    private static Util _instance;
    public static Util Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Util();
            }
            return _instance;
        }
    }
    public void SaveData(List<PlayerData> data)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(FILE_DIR);
        bf.Serialize(file, data);
        file.Close();
    }
    public List<PlayerData> LoadData()
    {
        List<PlayerData> data = new List<PlayerData>();
        if (File.Exists(FILE_DIR))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(FILE_DIR, FileMode.Open);
            data = (List<PlayerData>)bf.Deserialize(file);
            file.Close();
        }
        return data;
    }
    public void DeleteData()
    {
        if (File.Exists(FILE_DIR))
        {
            File.Delete(FILE_DIR);
        }
    }
}
