using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using static PlayerWeapon;

public class AimingReticle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject farReticle;
    public GameObject nearReticle;
    Canvas canvas;
    public GameObject player;
    public Sprite ReticleSprite;

    void Start()
    {
        canvas = gameObject.GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 playerPos;

        if (player)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, canvas.worldCamera.WorldToScreenPoint(player.transform.position), canvas.worldCamera, out playerPos);

            switch (player.GetComponent<PlayerBase>().CharacterWeapon.WeaponAimingMode)
            {
                case EAimMode.Freelook:
                    Vector2 mousePos;
                    RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out mousePos);
                    farReticle.transform.position = canvas.transform.TransformPoint(mousePos);
                    nearReticle.transform.position = canvas.transform.TransformPoint((playerPos + mousePos) / 2);
                    break;
                case EAimMode.PitchYaw:
                    Vector2 playerFrontDirection;
                    RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, canvas.worldCamera.WorldToScreenPoint(player.transform.forward * 50 + player.transform.position), canvas.worldCamera, out playerFrontDirection);
                    farReticle.transform.position = canvas.transform.TransformPoint(playerFrontDirection);
                    nearReticle.transform.position = canvas.transform.TransformPoint((playerPos + playerFrontDirection) / 2);
                    break;
                case EAimMode.Autolock:
                    //both reticle should auto lock into the closest target 
                    break;
            }
        }
    }

    public void ChangeCrosshairSprite(Sprite newCrosshairSprite, Color newColor)
    {
        farReticle.GetComponent<Image>().sprite = newCrosshairSprite;
        farReticle.GetComponent<Image>().color = newColor;
        nearReticle.GetComponent<Image>().sprite = newCrosshairSprite;
        nearReticle.GetComponent<Image>().color = newColor;
    }

    public void PlayCrosshairAnimation()
    {
        GetComponent<Animator>().SetTrigger("Shoot");
    }
}
