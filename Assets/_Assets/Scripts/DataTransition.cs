// Script which save some data in the file inside the folder of game
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class DataTransition
{
    public static void MapNameToFile(GameData hs)//saving level name from special data format(In the choosing level window) to file for next loading
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/BallPath.Heller";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
        GameData GameData = new GameData(hs);
        formatter.Serialize(stream, GameData);
        stream.Close();
    }
    public static GameData MapNameFromFile() //load level name and level data from file into the GameData variable
    {
        string path = Application.persistentDataPath + "/BallPath.Heller";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            GameData GameData = formatter.Deserialize(stream) as GameData;
            stream.Close();

            return GameData;
        }
        else // check for safety
        {
            Debug.LogError("file doesnt exist");
            return null;
        }   
    }
}