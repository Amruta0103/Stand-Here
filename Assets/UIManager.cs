using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject endGamePanel;
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI timerText;
    public AudioSource audioSource;
    public AudioClip pepSound;
    public AudioClip looseSound;
    public AudioClip winSound;
    public AudioSource backgroundMusic;
    public GameObject tryAgainButton;
    public void Start()
    {
      endGamePanel.SetActive(false);
      tryAgainButton.SetActive(false);
    }
    public void UpdateTimer(float time)
    {
      timerText.text = "TIME: " + time.ToString("F1");
      if (time > 2f)
      {
        timerText.color = Color.white;
      }
      else if (time > 1f)
      {
        timerText.color = Color.yellow;
      }
      else
      {
        timerText.color = Color.red;
      }
    }
    public void ShowWin()
    { 
      backgroundMusic.Stop();
      endGamePanel.SetActive(true);
      resultText.text = "YOU WON!";
      tryAgainButton.SetActive(true);
      audioSource.PlayOneShot(winSound);
    }

    public void ShowLoss()
    {
      backgroundMusic.Stop();
      endGamePanel.SetActive(true);
      resultText.text = "OH NO! YOU LOST!";
      tryAgainButton.SetActive(true);
      audioSource.PlayOneShot(looseSound);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}