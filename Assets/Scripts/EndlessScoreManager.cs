using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndlessScoreManager : MonoBehaviour
{
    public int totalScore = 0;
    public TextMeshProUGUI scoreLabel;
    public float zoomInEffect = 0.2f;
    float czoomInEffect = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // reset the text scale if the zoom effect is on
        if (czoomInEffect > 0.0f)
        {
            scoreLabel.transform.localScale = Vector3.one * Mathf.Lerp(1, 2, czoomInEffect / zoomInEffect);
            czoomInEffect -= Time.deltaTime;
            if (czoomInEffect <= 0.0f)
            {
                czoomInEffect = 0.0f;
            }
        }
    }

    public void addScore(int newScore)
    {
        totalScore += newScore;
        scoreLabel.text = Convert.ToString(totalScore);
        czoomInEffect = zoomInEffect;
        scoreLabel.transform.localScale = Vector3.one * 2;
    }
}
