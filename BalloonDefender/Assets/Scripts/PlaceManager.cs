using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceManager : MonoBehaviour
{
    public static TurretScriptable selectedTurret;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (!hit)
                return;
            var objectHit = hit.collider.gameObject.GetComponent<PlaceSlot>();
            if (objectHit != null && objectHit.onLeft && !objectHit.isOccupied)
            {
                objectHit.PlacePrefab(selectedTurret);
            }else if(objectHit != null && !objectHit.onLeft && !objectHit.isOccupied)
            {
                objectHit.PlacePrefab(selectedTurret);
            }
        }
    }
}
