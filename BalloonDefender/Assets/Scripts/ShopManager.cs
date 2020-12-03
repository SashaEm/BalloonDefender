using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopManager : MonoSingleton<ShopManager>
{
    private Dictionary<string, TurretScriptable> turretDescDict;
    private const string turretPath = @"Turrets";
    private bool Initialized => turretDescDict != null;

    private void Awake() => Initialize();

    private void Initialize()
    {
        var turretDescList = Resources.LoadAll<TurretScriptable>(turretPath).ToList();
        turretDescDict = new Dictionary<string, TurretScriptable>();
        foreach (var turretDesc in turretDescList)
        {
            turretDescDict.Add(turretDesc.Id, turretDesc);
        }
    }
    public List<TurretScriptable> GetAllTurrets()
    {
        if (!Initialized)
            Initialize();

        return turretDescDict.Values.ToList();
    }
}
