using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] LevelManager levelManager;
    [SerializeField] SaveLoadSystem saveLoadSystem;
    [SerializeField] PlayerScript playerScript;
    [Header("UI")]
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject losePanel;
    [SerializeField] GameObject startImage;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject pauseBtn;
    bool isStart = true;
    bool isEnd = false;
    private void Awake()
    {
        Time.timeScale = 1f;
        Application.targetFrameRate = 60;
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        levelManager.GenerateLevel(saveLoadSystem.CurrentData.levelNumber);
    }
    private void Update()
    {
        StartingFunc();
    }
    void StartingFunc()
    {
        if(Input.GetMouseButtonDown(0) && isStart)
        {
            isStart = false;
            startImage.SetActive(false);
            playerScript.gameObject.SetActive(true);
        }
    }
    public void WinGame()
    {
        if(isEnd)
        {
            return;
        }
        playerScript.WinGame();
        isEnd = true;
    }
    public void LoseGame()
    {
        if (isEnd)
        {
            return;
        }
        ShowLoseGameUI();
        isEnd = true;
    }
    public void PauseGame()
    {
        pausePanel.SetActive(true);
        pauseBtn.SetActive(false);
        Time.timeScale = 0;
    }
    public void UnPauseGame()
    {
        pausePanel.SetActive(false);
        pauseBtn.SetActive(true);
        Time.timeScale = 1;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void ShowWinGameUI()
    {
        winPanel.SetActive(true);
        pauseBtn.SetActive(false);
    }
    public void ShowLoseGameUI()
    {
        losePanel.SetActive(true);
        pauseBtn.SetActive(false);
    }
    public void WinGameUI()
    {
        saveLoadSystem.CurrentData.levelNumber += 1;
        saveLoadSystem.SaveDataIntoFile();
        RestartGame();
    }
    public void LoseGameUI()
    {
        RestartGame();
    }
}