using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopEntry : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private GameObject locked;
    [SerializeField] private Text priceText;
    private TurretScriptable turretScriptable;
    private ShopScreen shopScreen;

    public void Initialize(TurretScriptable turretScriptable, ShopScreen shopScreen)
    {
        this.turretScriptable = turretScriptable;
        this.shopScreen = shopScreen;
        UpdateVisuals();
    }

    private void UpdateVisuals()
    {
        var isUnlocked = turretScriptable.IsUnlocked();
        if(turretScriptable == null)
        {
            Debug.LogError("Missing ref to turretScriptable");
            return;
        }

        if(iconImage != null)
        {
            iconImage.sprite = turretScriptable.Icon;
            iconImage.color = new Color(1, 1, 1, isUnlocked ? 1 : 0.5f);
        }

        if(locked != null)
        {
            locked.SetActive(!isUnlocked);
            priceText.text = turretScriptable.Price.ToString();
        }
    }

    public void OnClick()
    {
        if(turretScriptable == null)
        {
            Debug.LogError("Missing ref to turretScriptable");
            return;
        }

        var isUnlocked = turretScriptable.IsUnlocked();

        if (!isUnlocked)
        {
            shopScreen.OpenLockedOverlay();
        }
        else
        {
            PlaceManager.selectedTurret = turretScriptable;
        }
    }
}
