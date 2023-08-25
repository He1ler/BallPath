// Data for game variables
[System.Serializable]
public class GameData
{
    public int levelNumber;
    public GameData()// saving starting variables for new game
    {
        levelNumber = 1;
    }
    public GameData(GameData hs)// saving variables for loading level
    {
        levelNumber = hs.levelNumber;
    }
}