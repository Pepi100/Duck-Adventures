using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer(){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.data";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = PlayerData.instance;
        DTOPlayerData dpd = new DTOPlayerData();
        formatter.Serialize(stream, dpd);
        stream.Close();
        Debug.Log("saved file at location " + path);
    }

    public static void LoadPlayer(){
        string path = Application.persistentDataPath + "/player.data";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            DTOPlayerData dpd = formatter.Deserialize(stream) as DTOPlayerData;
            dpd.createSingleton();
            stream.Close();

        }else{
            Debug.LogError("Save file not fount in " + path);
        }
    }
}
