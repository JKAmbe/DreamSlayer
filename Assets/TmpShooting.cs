using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TmpShooting : MonoBehaviour
{
    public GameObject pew;
    public Transform spawn;
    // Start is called before the first frame update
    float beamSize = 0;
    public int duration = 1;

    public float maxBeamSize = 10;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
        {
            ChargeBeam();
        }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Mouse0))
        {
            Debug.Log(beamSize);
            FireBeam();
        }
    }

    private void FireBeam()
    {
        float tmp = Mathf.Pow(3, beamSize);
        GameObject pewTmp = Instantiate(pew, spawn.position, Quaternion.identity, transform.parent);
        pewTmp.transform.localScale = pewTmp.transform.localScale * tmp;
        pewTmp.GetComponent<Rigidbody>().AddForce(transform.forward);
        Destroy(pewTmp, duration);
        beamSize = 0;
    }

    private void ChargeBeam()
    {
        beamSize += Time.deltaTime;
        beamSize = Mathf.Clamp(beamSize, 0, maxBeamSize);
    }
}
