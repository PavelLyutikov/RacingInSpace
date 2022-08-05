using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public PlayerMovement movement;
    //public float levelRestartDelay = 1f;
    [SerializeField] private Score scoreScript;
    [SerializeField] private GameObject losePanel;
    [SerializeField] Text recordText;

    public void EndGame()
    {
        SaveRecord();

        int lastRunScore = int.Parse(scoreScript.scoreText.text.ToString());
        PlayerPrefs.SetInt("lastRunScore", lastRunScore);

        StopGame();
    }

    public void StopGame()
    {
        movement.enabled = true;

        losePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void SaveRecord()
    {
        int lastRunScore = PlayerPrefs.GetInt("lastRunScore");
        int recordScore = PlayerPrefs.GetInt("recordScore");

        if (lastRunScore > recordScore)
        {
            recordScore = lastRunScore;
            PlayerPrefs.SetInt("recordScore", recordScore);
            recordText.text = recordScore.ToString();
        }
        else
        {
            recordText.text = recordScore.ToString();
        }
    }


    //public void EndGameRotate()
    //{
    //    losePanel.SetActive(true);
    //    Time.timeScale = 0;
    //}
}