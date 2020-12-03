using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTurret", menuName = "ScriptableObjects/Turrets")]
public class TurretScriptable : ScriptableObject
{
    [SerializeField] private string turretName;
    [SerializeField] private Sprite icon;
    [SerializeField] private int price;
    [SerializeField] private Turret turret;
    [SerializeField] private bool isUnlockedByDefault;

    public bool IsUnlocked() => isUnlockedByDefault;

    public string Id => turretName;

    public Sprite Icon => icon;

    public int Price => price;

    public Turret Turret => turret;
}
