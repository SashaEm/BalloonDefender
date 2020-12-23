using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public static Text textShower;
    public static GameObject endScreen;
    public static GameObject shopCanvas;

    private void Start()
    {
        endScreen.SetActive(false);
    }

    public static void ScoreAdd(int scoreValue)
    {
        score += scoreValue;
    }

    public static void ShowEndScreen()
    {
        shopCanvas.SetActive(false);
        endScreen.SetActive(true);
        textShower.text = score.ToString();
    }
}
