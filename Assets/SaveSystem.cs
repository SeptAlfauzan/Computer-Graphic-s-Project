using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public static void SaveData(int level, string name)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.dataPath + "/SaveData/save.fun";
        FileStream stream = File.Create(path);

        PlayerSaveData data = new PlayerSaveData(level, name);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static bool CheckLoadSaveData()
    {
        string path = Application.dataPath + "/SaveData/save.fun";
        if (File.Exists(path)) return true;
        return false;
    }

    public static bool DeleteSaveFile()
    {
        string path = Application.dataPath + "/SaveData/save.fun";
        try
            {
                File.Delete(path);
                return true;
            }
            catch (System.Exception e)
            {
                Debug.Log(e);
                return false;
            }
    }

    public static PlayerSaveData LoadSaveData()
    {
        string path = Application.dataPath + "/SaveData/save.fun";
        if (File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerSaveData data = formatter.Deserialize(stream) as PlayerSaveData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }

}
