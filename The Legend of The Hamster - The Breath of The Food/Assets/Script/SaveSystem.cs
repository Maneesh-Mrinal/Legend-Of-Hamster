using UnityEngine;
using UnityEngine.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveSystem 
{
    public static void SavePlayer (PlayerMovement player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.madeyoulaugh";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data =  new PlayerData(player);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static void SavePlayer(GameManager gm)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playergm.madeyoulaugh";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(gm);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.madeyoulaugh";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter ();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("Save File not Found" + path);
            return null;
        }
    }
}
