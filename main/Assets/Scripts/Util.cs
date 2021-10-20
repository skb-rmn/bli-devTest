using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Util
{
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
        FileStream file = File.Create(Application.persistentDataPath + "/PlayerData.dat");
        bf.Serialize(file, data);
        file.Close();
    }
    public List<PlayerData> LoadData()
    {
        List<PlayerData> data = new List<PlayerData>();
        if (File.Exists(Application.persistentDataPath + "/PlayerData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/PlayerData.dat", FileMode.Open);
            data = (List<PlayerData>)bf.Deserialize(file);
            file.Close();
        }
        return data;
    }
    public void ResetData()
    {
        if (File.Exists(Application.persistentDataPath + "/PlayerData.dat"))
        {
            File.Delete(Application.persistentDataPath + "/PlayerData.dat");
        }
    }
}
