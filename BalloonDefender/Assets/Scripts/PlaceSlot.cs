using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceSlot : MonoBehaviour
{
    [HideInInspector] public bool isOccupied;
    [HideInInspector] public bool isUnlocked;
    public bool onLeft;

    public void PlacePrefab(TurretScriptable turret)
    {
        if (turret.Price <= MoneyManager.money)
        {
            var turretGun = turret.Turret;
            var instanceTurret = Instantiate(turretGun, transform);
            instanceTurret.isOnLeft = onLeft;
            instanceTurret.transform.localPosition = new Vector3(0f, 0f, -1f);
            isOccupied = true;
            MoneyManager.money -= turret.Price;
            CurrentMoneyShow.UpdateMoneyText();
        }
    }
}
