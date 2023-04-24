using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum aimingType 
{
    PitchYaw,
    Mouse,
    AutoLock
};

public enum firingType
{
    ChargeShot,
    RapidFire,
};

public class PlayerBase : MonoBehaviour
{
    Camera cam;
    float damageMultiplier = 1;

    [Header("Firing System")]
    public float planeDistance;
    public aimingType aimingMode;
    public firingType firingMode;
    public float ChargingSpeed = 10.0f;
    public float maxRateOfFire = 0.5f;
    public GameObject pew;
    public Transform spawn;
    public float pewForce = 4f;
    public int duration = 1;
    public float maxBeamSize = 10;
    private float beamSize = 0;
    private float ROFTimer = 0;
    [Header("Special Ability")]
    public SpecialAbility CharacterSpecialAbility;


    [Header("Reticle")]
    public Sprite Reticle;
    public Color ReticleColor;

    [Header("Movement System")]
    public int playerSpeed;
    public Vector2 AxisDamping;
    public Vector3 directionRange;
    public float RotationSpeed = 4;
    CharacterController controller;

    public CharacterSwitchController switchController;

    [Header("Visual/Audio Effects")]
    public GameObject PlayerMesh;
    public ParticleSystem TakeDamageParticle;
    public Animator animator;
    public AudioSource audioSource;

    [Header("iFrame/Health")]
    public HealthBar healthBar;
    public float iFrameTime = 1.0f;
    float iframeCounter;

    private void Start()
    {
        cam = Camera.main;
        controller = GetComponent<CharacterController>();
        if (CharacterSpecialAbility)
        {
            CharacterSpecialAbility.parent = this;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal") * AxisDamping.x, Input.GetAxis("Vertical") * AxisDamping.y, 0);
        controller.Move(move * Time.deltaTime * playerSpeed);

        Quaternion rotation = Quaternion.Euler(new Vector3(-move.y * directionRange.x, move.x * directionRange.y, -move.x * directionRange.z));
        Quaternion SmoothedRotation = Quaternion.Slerp(transform.rotation, rotation, RotationSpeed * Time.deltaTime);
        transform.rotation = SmoothedRotation;
    }
    void Update()
    {

        if (Time.time - ROFTimer >= maxRateOfFire)
        {
            
            if (firingMode == firingType.RapidFire)
            {
                if (Input.GetButton("Fire1"))
                {
                    ROFTimer = Time.time;
                    FireBeam();
                }
            }
            if (firingMode == firingType.ChargeShot)
            {
                if (Input.GetButtonUp("Fire1"))
                {
                    ROFTimer = Time.time;
                    FireBeam();
                }
                if (Input.GetButton("Fire1"))
                {
                    ChargeBeam();
                }
            }
        }
        if (CharacterSpecialAbility && Input.GetButton("Fire3"))
        {
            CharacterSpecialAbility.useSpecialAbility();
        }
        if (CharacterSpecialAbility && Input.GetButtonUp("Fire3"))
        {
            CharacterSpecialAbility.unuseSpecialAbility();
        }
    }

    private void FireBeam()
    {

        //Debug.Log(beamSize);
        Vector3 Direction = Vector3.forward;
        switch (aimingMode)
        {
            case aimingType.Mouse:
                Direction = (cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, planeDistance)) - transform.position).normalized;
                break;
            case aimingType.PitchYaw:
                Direction = transform.forward;
                break;
            case aimingType.AutoLock:
                //placeholder, direction should be whatever the target location is
                break;
        }
        float tmp = Mathf.Pow(ChargingSpeed, beamSize);
        GameObject pewTmp = Instantiate(pew, spawn.position, Quaternion.identity, transform.parent);
        pewTmp.GetComponent<AudioSource>().pitch = 1 / (beamSize+1);
        pewTmp.transform.localScale = pewTmp.transform.localScale * tmp;
        pewTmp.GetComponent<Rigidbody>().AddForce(Direction* pewForce);
        pewTmp.GetComponent<Projectile>().damage *= damageMultiplier;
        Destroy(pewTmp, duration);
        beamSize = 0;

        // call the reticle shooting animation from the parent PlayerManager
        switchController.Reticle.GetComponent<Animator>().SetTrigger("Shoot");
    }

    private void ChargeBeam()
    {
        beamSize += Time.deltaTime;
        beamSize = Mathf.Clamp(beamSize, 0, maxBeamSize);
    }
    public void BuffDamage(float multiplier, float buffDuration)
    {
        damageMultiplier = multiplier;
        Invoke("revertBuff", buffDuration);
    }

    private void revertBuff()
    {
        damageMultiplier = 1;
    }

    public void TakeDamageEffects()
    {
        TakeDamageParticle.Play();
        audioSource.Play();
        // start iframe
        Debug.Log("Start iframe");
        animator.SetBool("bTakeDamage", true);
        StartCoroutine(useiFrame());
    }

    IEnumerator useiFrame()
    {
        healthBar.binvulnerable = true;
        yield return new WaitForSeconds(iFrameTime);
        healthBar.binvulnerable = false;
        animator.SetBool("bTakeDamage", false);
        yield return null;
    }

}
