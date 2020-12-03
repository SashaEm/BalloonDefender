using System.Collections.Generic;
using UnityEngine;

public class ShopScreen : MonoBehaviour
{
    [SerializeField] private ShopEntry turretEntryPrefab;
    [SerializeField] private Transform turretEntryParent;

    [SerializeField] GameObject confirmPurchaseOverlay;
    [SerializeField] private GameObject lockedOverlay;

    private List<TurretScriptable> AllTurrets => ShopManager.Instance.GetAllTurrets();

    private void OnEnable()
    {
        confirmPurchaseOverlay.SetActive(false);
        lockedOverlay.SetActive(false);
        UpdateTurretOptions();
    }

    private void UpdateTurretOptions()
    {
        var oldTurretEntries = new List<GameObject>();
        for (var i = 0;i  < turretEntryParent.childCount; i++)
        {
            var child = turretEntryParent.GetChild(i);
            if (child != null && child.gameObject != null)
                oldTurretEntries.Add(child.gameObject);
        }
        foreach(var oldSkinEntry in oldTurretEntries)
        {
            Destroy(oldSkinEntry.gameObject);
        }

        var turretOptions = AllTurrets;
        foreach(var turretDesc in turretOptions)
        {
            var newEntry = Instantiate(turretEntryPrefab, turretEntryParent);
            newEntry.Initialize(turretDesc, this);
        }
    }

    public void OpenLockedOverlay()
    {
        lockedOverlay.SetActive(true);
    }
}
