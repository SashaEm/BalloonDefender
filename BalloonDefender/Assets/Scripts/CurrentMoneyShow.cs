using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentMoneyShow : MonoBehaviour
{
    public static Text moneyText;

    private void Start()
    {
        moneyText = GetComponent<Text>();
        UpdateMoneyText();
    }

    public static void UpdateMoneyText()
    {
        moneyText.text = MoneyManager.money.ToString();
    }
}
