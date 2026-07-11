using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject endGamePanel;
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI timerText;

    public void Start()
    {
      endGamePanel.SetActive(false);
    }
    public void UpdateTimer(float time)
    {
        timerText.text = time.ToString("F1");
    }
    public void ShowWin()
    {
        endGamePanel.SetActive(true);
        resultText.text = "YOU WON!";
    }

    public void ShowLoss()
    {
        endGamePanel.SetActive(true);
        resultText.text = "OH NO! YOU LOST!";
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}