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

    //[Header("Firing System")]
    public float planeDistance;
    //public aimingType aimingMode;
    //public firingType firingMode;
    //public float damage = 10.0f;
    //public float aimSpread = 0.0f;
    //public float ChargingSpeed = 10.0f;
    //public float maxRateOfFire = 0.5f;
    //public GameObject pew;
    //public Transform spawn;
    //public float pewForce = 4f;
    //public int duration = 1;
    //public float maxBeamSize = 10;
    //private float beamSize = 0;
    //private float ROFTimer = 0;

    [Header("Weapon")]
    public PlayerWeapon CharacterWeapon;

    [Header("Special Ability")]
    public SpecialAbility CharacterSpecialAbility;


    [Header("Reticle")]
    public Sprite Reticle;
    public Color ReticleColor;

    [Header("Movement System")]
    public float playerSpeed;
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
    public bool bIframeOn = false;
    public float iFrameTime = 1.0f;
    float iframeCounter;

    private void Start()
    {
        cam = Camera.main;
        controller = GetComponent<CharacterController>();
        if (CharacterSpecialAbility)
        {
            CharacterSpecialAbility.Init(this);
        }
        if (CharacterWeapon)
        {
            CharacterWeapon.Init(this);
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
        if (CharacterWeapon && Input.GetButton("Fire1"))
        {
            CharacterWeapon.WeaponFire();
        }
        if (CharacterWeapon && Input.GetButtonUp("Fire1"))
        {
            CharacterWeapon.WeaponRelease();
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

    public Vector3 GetPlayerToMouseAim()
    {
        return (cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, planeDistance)) - transform.position).normalized;
    }

    // Deprecated
    //private void FireBeam()
    //{

    //    //Debug.Log(beamSize);
    //    Vector3 Direction = Vector3.forward;
    //    switch (aimingMode)
    //    {
    //        case aimingType.Mouse:
    //            Direction = (cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, planeDistance)) - transform.position).normalized;
    //            break;
    //        case aimingType.PitchYaw:
    //            Direction = transform.forward;
    //            break;
    //        case aimingType.AutoLock:
    //            //placeholder, direction should be whatever the target location is
    //            break;
    //    }
    //    // add spread to direction (simulating weapon spread)
    //    Direction.x += Random.Range(-aimSpread / 100, aimSpread / 100);
    //    Direction.y += Random.Range(-aimSpread / 100, aimSpread / 100);
    //    float tmp = Mathf.Pow(ChargingSpeed, beamSize);
    //    GameObject pewTmp = Instantiate(pew, spawn.position, Quaternion.identity, transform.parent);
    //    pewTmp.GetComponent<Projectile>().damage = this.damage;
    //    pewTmp.GetComponent<AudioSource>().pitch = 1 / (beamSize+1);
    //    pewTmp.transform.localScale = pewTmp.transform.localScale * tmp;
    //    pewTmp.GetComponent<Rigidbody>().AddForce(Direction* pewForce);
    //    pewTmp.GetComponent<Projectile>().damage *= damageMultiplier;
    //    Destroy(pewTmp, duration);
    //    beamSize = 0;

    //}

    //private void ChargeBeam()
    //{
    //    beamSize += Time.deltaTime;
    //    beamSize = Mathf.Clamp(beamSize, 0, maxBeamSize);
    //}
    public void BuffDamage(float multiplier, float buffDuration)
    {
        CharacterWeapon.MultiplyDamage(multiplier);
        Invoke("revertBuff", buffDuration);
    }

    private void revertBuff()
    {
        CharacterWeapon.MultiplyDamage();
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
        bIframeOn = true;
        healthBar.binvulnerable = true;
        Debug.Log("test");
        //PlayerMesh.GetComponent<Renderer>().material.SetFloat("_bTakeDamage", 1.0f);
        yield return new WaitForSeconds(iFrameTime);
        bIframeOn = false;
        healthBar.binvulnerable = false;
        //PlayerMesh.GetComponent<Renderer>().material.SetFloat("_bTakeDamage", 0.0f);
        animator.SetBool("bTakeDamage", false);
        yield return null;
    }

}
