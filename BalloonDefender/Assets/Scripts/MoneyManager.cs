using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static int money = 0;
    [SerializeField] private int startMoney = 20;
    private void Awake()
    {
        money += startMoney;
    }
}
