using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreenManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject endScreenPanel;
    private void Start()
    {
        ScoreManager.textShower = scoreText;
        ScoreManager.endScreen = endScreenPanel;
    }

    public void RestartGame()
    {
        ScoreManager.score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
