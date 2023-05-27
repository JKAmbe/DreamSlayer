using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TornadoBossBehaviour : MonoBehaviour
{
    public GameoverUI gameoverUI;
    int currentAttack = 0;
    float attackDuration = 3;
    Animator anim;
    //TornadoHealthBar health;
    public GameObject EnemySpawnPrefab;
    public GameObject TornadoSpawnPrefab;
    public Transform[] SpawnLocation;
    public AudioSource suckAudio;
    public AudioSource swooshAudio;

    List<GameObject> minions = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //health = GetComponent<TornadoHealthBar>();
        anim = GetComponentInChildren<Animator>();
        anim.SetTrigger("SpawnMinion");
    }

    // Update is called once per frame
    void Update()
    {
        if (attackDuration > 0)
        {
            Debug.Log(attackDuration);
            attackDuration -= Time.deltaTime;
            suckAudio.Play();
        }
        else
            ResetAttack();
    }

    void ResetAttack()
    {
        anim.SetTrigger("Reset");
        int oldAttack = currentAttack;
        while (currentAttack == oldAttack)
            currentAttack = Random.Range(0, 3);
            //suckAudio.Play();
        switch (currentAttack)
        {
            case 0:
                anim.SetTrigger("Suck");
                attackDuration = 5;
                break;
            case 1:
                anim.SetTrigger("SpawnMinion");
                attackDuration = 3;
                break;
            case 2:
                anim.SetTrigger("SpawnTornado");
                attackDuration = 10;
                break;
        }
        
    }

    public void SpawnEnemy()
    {
        minions.Add(Instantiate(EnemySpawnPrefab, SpawnLocation[Random.Range(0, SpawnLocation.Length)].position, Quaternion.identity, null));
    }

    public void SpawnTornado()
    {
        Instantiate(TornadoSpawnPrefab, SpawnLocation[Random.Range(0, SpawnLocation.Length)].position, Quaternion.Euler(0,0,Random.Range(0.0f,360.0f)), null);
        swooshAudio.Play();
    }
    private void OnDestroy()
    {
        gameoverUI.showGameoverUI(true);
        //foreach (GameObject e in minions)
        //{
        //    if (e) { e.GetComponent<Enemyhealthbar>().TakeDamage(1000.0f); }
        //}
        Destroy(gameObject);
    }

    //public void DestroyBoss()
    //{
    //    gameoverUI.showGameoverUI(true);
    //    //foreach (GameObject e in minions)
    //    //{
    //    //    if (e) { e.GetComponent<Enemyhealthbar>().TakeDamage(1000.0f); }
    //    //}
    //    Destroy(gameObject);
    //}
}
