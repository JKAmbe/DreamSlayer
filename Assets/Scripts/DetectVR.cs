using UnityEngine.XR.Management;
using UnityEngine;

public class DetectVR : MonoBehaviour
{
    public GameObject xrOrigin;
    public GameObject desktop;
    public bool startInVR;
    // Start is called before the first frame update
    void Start()
    {
        if (startInVR)
        {
            var xrSettings = XRGeneralSettings.Instance;
            if (xrSettings == null || xrSettings.Manager == null || xrSettings.Manager.activeLoader == null)
            {
                Debug.Log("Problem Starting VR Headset, either not plugged in or missing component in scene");
                Debug.Log("Starting in desktop...");
                xrOrigin.SetActive(false);
                desktop.SetActive(true);
                return;
            }

            Debug.Log("XR detected, starting in VR...");
            xrOrigin.SetActive(true);
            desktop.SetActive(false);
        }
        else
        {
            Debug.Log("Desktop selected");
            xrOrigin.SetActive(false);
            desktop.SetActive(true);
        }


    }

}
