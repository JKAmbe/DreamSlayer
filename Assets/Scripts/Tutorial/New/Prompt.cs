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
        "Welcome to Nightmare Slayers!\nThis tutorial is built to help you understand how this game works and it's mechanics", //2
        "Let's start into movement!", //3
        "Movement in this game is based on the X and Y axes\nW - Up Direction\nA - Left Direction\nS - Down Direction\nD - Right Direction", //4
        "Try it yourself!", //5
        " ", //6
        "Now that we have mastered basic movement,\nLet's move onto shooting", //7
        "Shooting can be achieved by pressing/holding left-click", //8
        "Aim for the target!", //9
        " ", //10
        "Great Job!\nLet's dive into the other characters that are available to us", //11
        "Different characters enable us to use different play-styles through shooting mechanics and abilities", //12
        "Currently, we are using the default blue.", //13
        "To change characters on the fly, press right-click", //14
        " ", //15
        "Try holding left-click and release on the target!", //16
        " ", //17
        "Lets try the white, press right-click", //18
        " ", //19
        "White can't aim with the mouse, but there is more than one way to aim...", //20
        "Defeat the enemy", //21
        " ", //22
        "Not only do each character have their own unique style...", //23
        "Each character also has their own special ability!", //24
        "We can access this ability by pressing space-bar", //25
        "Let's go through them starting with blue", //26
        "Go back to blue with right-click", //27
        " ", //28
        "Blue ability is a bomb that can you help you eradicate your enemies\nTry it with space-bar", //29
        " ", //30
        "Lets switch over to red and see their ability!", //31
        " ", //32
        "Red ability is a shield, try timing it with enemy projectiles\nUse it to help you beat the enemies", //33
        " ", //34
        "The shield has a time limit, so keep that in mind", //35
        "Now lets check out white's ability\nChange to white with right-click", //36
        " ", //37
        "White has the ability to parry enemy bullets\nSee if you can time the enemy bullets", //38
        " ", //39
        "The player has a health bar that we can see on the bottom right hand corner", //40
        "If this bar goes down to zero, you will lose", //41
        "Let's take a closer look at enemies", //42
        "Each enemy will have a health-bar and will shoot at the player", //43
        "These bullets will hurt the player, so make sure you avoid being hit", //44
        "Wipe out the enemies to progress further!", //45
        " ", //46
        "Now let's go over the buffs/drops you may encounter in your playthrough", //47
        "There are two notable drops", //48
        "First is a power buff that allows the player's projectile to deal more damage", //49
        "Second is a health drop\nThis lets you recover any lost health points", //50
        "Move into them to obtain these boosts!", //51
        "Now lets go into obstacles", //52
        "There are two types of obstacles\nDestructible and Non-Destructible", //53
        "As you can see, they both have different colours\nTry to remember this distinction", //54
        "Another distinction is that moving obstacles,\nsuch as these", //55
        "...are non-destructible, so try to maneuver around them!", //56
        "Let's test your memory and eliminate the destructible obstacle!", //57
        "Well done!", //58
        "This is the end of the tutorial\nHopefully you have learnt how to play Nightmare Slayers...", //59
        "...because this game is not easy" //60
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
    public EnemyHealthBarTut enemyHealthBarTut4a;
    public EnemyHealthBarTut enemyHealthBarTut4b;
    public EnemyHealthBarTut enemyHealthBarTut4c;
    
    public GameObject target5;
    public EnemyHealthBarTut enemyHealthBarTut5a;
    public EnemyHealthBarTut enemyHealthBarTut5b;
    public EnemyHealthBarTut enemyHealthBarTut5c;
    
    public GameObject target6;
    public EnemyHealthBarTut enemyHealthBarTut6a;
    public EnemyHealthBarTut enemyHealthBarTut6b;
    public EnemyHealthBarTut enemyHealthBarTut6c;
    
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
            if (enemyHealthBarTut4a.targetCheck && enemyHealthBarTut4b.targetCheck && enemyHealthBarTut4c.targetCheck)
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
            if (enemyHealthBarTut5a.targetCheck && enemyHealthBarTut5b.targetCheck && enemyHealthBarTut5c.targetCheck)
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
        else if (currentIndex == 57)
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
                currentIndex == 36 || currentIndex == 38 || currentIndex == 46 || currentIndex == 57)
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
                if (currentIndex == 47)
                {
                    power.SetActive(true);
                    hp.SetActive(true);
                    UpdateTextMesh();
                }
                else if (currentIndex == 48)
                {
                    hp.SetActive(false);
                    UpdateTextMesh();
                }
                else if (currentIndex == 49)
                {
                    power.SetActive(false);
                    hp.SetActive(true);
                    UpdateTextMesh();
                }
                else if (currentIndex == 50)
                {
                    power.SetActive(true);
                    hp.SetActive(true);
                    UpdateTextMesh();
                }
                else if (currentIndex == 52 || currentIndex == 53)
                {
                    dest.SetActive(true);
                    nDest.SetActive(true);
                    UpdateTextMesh();
                }
                else if (currentIndex == 54 || currentIndex == 55)
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
                else if (currentIndex == 60)
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

