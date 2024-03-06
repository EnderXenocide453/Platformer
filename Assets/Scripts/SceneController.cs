using ScoreManagement;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    private static SceneController _instance;
    private static int _nextID = 1;

    [SerializeField] Transform diePanel;
    [SerializeField] Transform winPanel;
    [SerializeField] Text scoreField;

    private void Awake()
    {
        if (_instance != null) {
            Destroy(this);
            return;
        }

        Time.timeScale = 1;
        Storytelling.CameraCapture.ResetActive();

        _instance = this;
    }

    public static void ShowDiePanel()
    {
        _instance.diePanel.gameObject.SetActive(true);
    }

    public static void FinishLevel(int nextID)
    {
        _nextID = nextID;

        _instance.winPanel.gameObject.SetActive(true);
        _instance.scoreField.text = LevelScore.CurrentScorePoints.ToString();

        Time.timeScale = 0;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        LevelScore.Reset();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(_nextID);
        LevelScore.Reset();
    }
}
