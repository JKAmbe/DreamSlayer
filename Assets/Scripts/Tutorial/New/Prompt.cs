using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prompt : MonoBehaviour
{
    private string[] stringArray =
    {
        " ", //1
        "Welcome to Nightmare Slayers!\nThis tutorial will help you understand this game and its mechanics.", //2
        "Let's start with movement!", //3
        "You can move in the X and Y axes.\nW/S - Up/Down Direction\nA/D - Left/Right Direction", //4
        "Try it yourself!", //5
        " ", //6
        "Now that we have mastered basic movement,\nLet's move onto shooting", //7
        "Shoot your weapon by holding Left-Click", //8
        "Aim for the target!", //9
        " ", //10
        "Great Job!\nLet's dive into the other characters", //11
        "Different characters have their own weapons and special abilities.", //12
        "Currently, we are using Blue.", //13
        "Press Right-Click and change to Red.", //14
        " ", //15
        "Hold Left-click to charge and release on the target!", //16
        " ", //17
        "Let's try White, press right-click", //18
        " ", //19
        "White can't aim with the mouse, but there is more than one way to aim...", //20
        "Defeat the target!", //21
        " ", //22
        "Not only do each character have their own unique style...", //23
        "Each character also has their own special ability!", //24
        "Press the Space-Bar to use the special ability.", //25
        "Let's go through each one.", //26
        "Go back to blue with right-click", //27
        " ", //28
        "Blue's ability is a bomb that damages enemies and erases projectiles.\nTry it with space-bar", //29
        " ", //30
        "Let's switch over to Red.", //31
        " ", //32
        "Red's ability is a shield that blocks projectiles.\nUse it to help you beat the enemy", //33
        " ", //34
        "The shield has a limit, so keep that in mind", //35
        "Now let's switch over to White.", //36
        " ", //37
        "White's ability can parry enemy projectiles.\nSee if you can time it with enemy attacks.", //38
        " ", //39
        "The green bar is your character's health.", //40
        "You will lose if this bar goes down to 0!", //41
        "Let's take a closer look at enemies", //42
        "Enemies will fire various projeciles at you.", //43
        "Make sure to avoid their attacks!", //44
        "Wipe out the enemies!", //45
        " ", //46
        "Let's go over the different enemy types.", //47
        "You came across the basic Shooters...", //48
        "But now we have two new types!", //49
        "The Laser and the Shield", //50
        "Hopefully you'll be able to figure out\nhow they work and how to defeat them", //51
        "There are special powerups in the level.", //52
        "There are two notable drops", //53
        "The Blue item gives you temporary bonus damage.", //54
        "The Red item recovers your health.", //55
        "Move into them to pick them up!", //56
        "Now, let's go into obstacles", //57
        "There are Destrucible (Right) and \nNon-Destrictible (Left) obstacles.", //58
        "They have different colours\nTry to remember this distinction", //59
        "There are moving obstacles, too", //60
        "They're Non-Destructive, so move around them!", //61
        "Break the destructible obstacle!", //62
        "Well done!", //63
        "This is the end of the tutorial\nHopefully you have learnt how to play Nightmare Slayers...", //64
        "...because this game is not easy" //65
    };
    public TextMeshProUGUI textMesh;
    public float updateInterval = 1f;
    public float timeSinceLastUpdate = 0f;
    
    public int currentIndex = 0;
    private bool shouldContinueUpdating = true;
    

    public GameObject arrows;
    public CountMovement cm;

    public GameObject target;
    public EnemyHealthBarTut enemyHealthBarTut;

    public CharacterSwitchController CSC;
    
    public GameObject target1;
    public EnemyHealthBarTut enemyHealthBarTut1;
    
    public GameObject target2;
    public EnemyHealthBarTut enemyHealthBarTut2;
    
    public GameObject target3;
    public EnemyHealthBarTut enemyHealthBarTut3a;
    public EnemyHealthBarTut enemyHealthBarTut3b;
    public EnemyHealthBarTut enemyHealthBarTut3c;
    
    public GameObject target4;
    public EnemyHealthBarTut enemyHealthBarTut4;

    public GameObject target5;
    public EnemyHealthBarTut enemyHealthBarTut5;

    public GameObject target6;
    public EnemyHealthBarTut enemyHealthBarTut6a;
    public EnemyHealthBarTut enemyHealthBarTut6b;
    public EnemyHealthBarTut enemyHealthBarTut6c;

    public GameObject laser;
    public GameObject shield;
    
    public GameObject power;
    public GameObject hp;

    public GameObject dest;
    public GameObject nDest;
    public GameObject moving;
    public GameObject testObstacle;
    public GameObject fakeObstacle;

    public ObstacleCollision OC;
    public void StopUpdating()
    {
        shouldContinueUpdating = false;
    }

    public void ResumeUpdating()
    {
        if (currentIndex == 5)
        {
            arrows.SetActive(true);
            if (cm.total)
            {
                arrows.SetActive(false);
                shouldContinueUpdating = true;
                UpdateTextMesh();
            }
        }
        else if (currentIndex == 9)
        {
            target.SetActive(true);
            if (enemyHealthBarTut.targetCheck)
            {
                target.SetActive(false);
                shouldContinueUpdating = true;
                UpdateTextMesh();
            }
        }
        else if (currentIndex == 14)
        {
            if (CSC.index == 0 && Input.GetMouseButtonDown(1))
            {
                shouldContinueUpdating = true;
                UpdateTextMesh();
            }
            
        }
        else if (currentIndex == 16)
        {
            target1.SetActive(true);
            if (enemyHealthBarTut1.targetCheck)
            {
                target1.SetActive(false);
                shouldContinueUpdating = true;
                UpdateTextMesh();
            }
        }
        else if (currentIndex == 18)
        {
            if (CSC.index == 1 && Input.GetMouseButtonDown(1))
            {
                shouldContinueUpdating = true;
                UpdateTextMesh();
            }
        }
        else if (currentIndex == 21)
        {
            target2.SetActive(true);
            if (enemyHealthBarTut2.targetCheck)
            {
                target2.SetActive(false);
                shouldContinueUpdating = true;
                UpdateTextMesh();
            }
        }
        else if (currentIndex == 27)
        {
            if (CSC.index == 2 && Input.GetMouseButtonDown(1))
            {
                shouldContinueUpdating = true;
                UpdateTextMesh();
            }
        }
        else if (currentIndex == 29)
        {
            target3.SetActive(true);
            if (enemyHealthBarTut3a.targetCheck && enemyHealthBarTut3b.targetCheck && enemyHealthBarTut3c.targetCheck)
            {
                target3.SetActive(false);
                shouldContinueUpdating = true;
                UpdateTextMesh();
            }
        }
        else if (currentIndex == 31)
        {
            if (CSC.index == 0 && Input.GetMouseButtonDown(1))
            {
                shouldContinueUpdating = true;
                UpdateTextMesh();
            }
        }
        else if (currentIndex == 33)
        {
            target4.SetActive(true);
            if (enemyHealthBarTut4.targetCheck)
            {
                target4.SetActive(false);
                shouldContinueUpdating = true;
                UpdateTextMesh();
            }
        }
        else if (currentIndex == 36)
        {
            if (CSC.index == 1 && Input.GetMouseButtonDown(1))
            {
                shouldContinueUpdating = true;
                UpdateTextMesh();
            }
        }
        else if (currentIndex == 38)
        {
            target5.SetActive(true);
            if (enemyHealthBarTut5.targetCheck)
            {
                target5.SetActive(false);
                shouldContinueUpdating = true;
                UpdateTextMesh();
            }
        }
        else if (currentIndex == 46)
        {
            target6.SetActive(true);
            if (enemyHealthBarTut6a.targetCheck && enemyHealthBarTut6b.targetCheck && enemyHealthBarTut6c.targetCheck)
            {
                target6.SetActive(false);
                shouldContinueUpdating = true;
                UpdateTextMesh();
            }
        }
        else if (currentIndex == 62)
        {
            moving.SetActive(false);
            testObstacle.SetActive(true);
            fakeObstacle.SetActive(true);
            if (OC.destroyed)
            {
                testObstacle.SetActive(false);
                fakeObstacle.SetActive(false);
                shouldContinueUpdating = true;
                UpdateTextMesh();
            }
        }
        
    }

    private void UpdateTextMesh()
    {
        if (currentIndex < stringArray.Length && shouldContinueUpdating)
        {
            textMesh.text = stringArray[currentIndex];
            currentIndex++;
            timeSinceLastUpdate = 0f;

            if (currentIndex == 5 || currentIndex == 9 || currentIndex == 14 || currentIndex == 16 || currentIndex == 18 ||
                currentIndex == 21 || currentIndex == 27 || currentIndex == 29 || currentIndex == 31 || currentIndex == 33 ||
                currentIndex == 36 || currentIndex == 38 || currentIndex == 46 || currentIndex == 62)
            {
                StopUpdating();
            }
        }
    }
    void Start()
    {
        arrows.SetActive(false);
        target.SetActive(false);
        target1.SetActive(false);
        target2.SetActive(false);
        target3.SetActive(false);
        target4.SetActive(false);
        target5.SetActive(false);
        target6.SetActive(false);
        laser.SetActive(false);
        shield.SetActive(false);
        power.SetActive(false);
        hp.SetActive(false);
        dest.SetActive(false);
        nDest.SetActive(false);
        moving.SetActive(false);
        testObstacle.SetActive(false);
        fakeObstacle.SetActive(false);
        UpdateTextMesh();
    }

    void Update()
    {
        
        if (shouldContinueUpdating)
        {
            timeSinceLastUpdate += Time.deltaTime;
            if (timeSinceLastUpdate >= updateInterval)
            {
                if (currentIndex == 50)
                {
                    laser.SetActive(true);
                    shield.SetActive(true);
                }

                if (currentIndex == 51)
                {
                    laser.SetActive(false);
                    shield.SetActive(false);
                }
                if (currentIndex == 52)
                {
                    power.SetActive(true);
                    hp.SetActive(true);
                    UpdateTextMesh();
                }
                else if (currentIndex == 53)
                {
                    hp.SetActive(false);
                    UpdateTextMesh();
                }
                else if (currentIndex == 54)
                {
                    power.SetActive(false);
                    hp.SetActive(true);
                    UpdateTextMesh();
                }
                else if (currentIndex == 55)
                {
                    power.SetActive(true);
                    hp.SetActive(true);
                    UpdateTextMesh();
                }
                else if (currentIndex == 57 || currentIndex == 58)
                {
                    dest.SetActive(true);
                    nDest.SetActive(true);
                    UpdateTextMesh();
                }
                else if (currentIndex == 59 || currentIndex == 60)
                {
                    dest.SetActive(false);
                    nDest.SetActive(false);
                    moving.SetActive(true);
                    UpdateTextMesh();
                }
                // else if (currentIndex == 57)
                // {
                //     moving.SetActive(false);
                // }
                else if (currentIndex == 65)
                {
                    SceneManager.LoadScene("MainMenu2");
                }
                else
                {
                    moving.SetActive(false);
                    power.SetActive(false);
                    hp.SetActive(false);
                    UpdateTextMesh();    
                }
            }
        }
        else if (!shouldContinueUpdating)
        {
            ResumeUpdating();
        }
    }
}

