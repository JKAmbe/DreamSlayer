using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;

public class AimingReticle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject farReticle;
    public GameObject nearReticle;
    Canvas canvas;
    public GameObject player;

    void Start()
    {
        canvas = gameObject.GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 playerPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, canvas.worldCamera.WorldToScreenPoint(player.transform.position), canvas.worldCamera, out playerPos);

        switch (player.GetComponent<PlayerBase>().aimingMode)
        {
            case aimingType.Mouse:
                Vector2 mousePos;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out mousePos);
                farReticle.transform.position = canvas.transform.TransformPoint(mousePos);
                nearReticle.transform.position = canvas.transform.TransformPoint((playerPos + mousePos) / 2);
                break;
            case aimingType.PitchYaw:
                Vector2 playerFrontDirection;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, canvas.worldCamera.WorldToScreenPoint(player.transform.forward * 1000 + player.transform.position), canvas.worldCamera, out playerFrontDirection);
                farReticle.transform.position = canvas.transform.TransformPoint(playerFrontDirection);
                nearReticle.transform.position = canvas.transform.TransformPoint((playerPos + playerFrontDirection) / 2);
                break;
            case aimingType.AutoLock:
                //both reticle should auto lock into the closest target 
                break;
        }
        

        
    }
}
