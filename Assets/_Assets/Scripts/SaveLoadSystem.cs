using UnityEngine;
using System.IO;
using TMPro;

public class SaveLoadSystem : MonoBehaviour
{
    public GameData CurrentData;
    [SerializeField] TextMeshProUGUI text;
    void Awake()
    {
        if (File.Exists(Application.persistentDataPath + "/BallPath.Heller"))
        {
            TransitDataToCurrent();
        }
        else
        {
            NewData();
            SaveDataIntoFile();
        }
        text.text = "Level: " + CurrentData.levelNumber;
    }
    public void NewData()
    {
        CurrentData = new GameData();
    }
    public GameData TransitDataToCurrent()
    {
        CurrentData = new GameData(DataTransition.MapNameFromFile());
        return CurrentData;
    }
    public void SaveDataIntoFile()
    {
        DataTransition.MapNameToFile(CurrentData);
    }
}