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
        DOTPlayerData dpd = new DOTPlayerData();
        formatter.Serialize(stream, dpd);
        stream.Close();
        Debug.Log("saved file at location " + path);
    }

    public static void LoadPlayer(){
        string path = Application.persistentDataPath + "/player.data";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            DOTPlayerData dpd = formatter.Deserialize(stream) as DOTPlayerData;
            dpd.createSingleton();
            stream.Close();

        }else{
            Debug.LogError("Save file not fount in " + path);
        }
    }
}
