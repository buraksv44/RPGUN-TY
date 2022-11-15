using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseScript : MonoBehaviour
{
    public Texture2D cursorTextureNormal;
    public Texture2D cursorTextureEnemy;
    private CursorMode mode = CursorMode.ForceSoftware;
    private Vector2 hotSpot = Vector2.zero;

    public  GameObject mousePoint;

   
    // Update is called once per frame
    void Update()
    {
        CursorChanger();

        if (Input.GetMouseButtonUp(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit))
            {
                if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                {
                    Vector3 LastPos = hit.point;
                    LastPos.y = 0.35f;

                    Instantiate(mousePoint, LastPos, Quaternion.identity);
                }
            }
        }
    }
    void CursorChanger()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Target"))
            {
                Cursor.SetCursor(cursorTextureEnemy, hotSpot, mode);
            }
            else
            {
                Cursor.SetCursor(cursorTextureNormal, hotSpot, mode);
            }
        }
    }
}
