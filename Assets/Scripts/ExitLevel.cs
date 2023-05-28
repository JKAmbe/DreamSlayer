using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    public GameoverUI gameoverUI;

    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                if (enemy.GetComponentInChildren<Detection>().target != null)
                    return;
                else
                    continue;
            }
            if (!gameoverUI.bGameover)
            {
                gameoverUI.showGameoverUI(true);
            }
        }
    }
}
