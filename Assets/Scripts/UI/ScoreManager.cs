using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    public int scoreCounter;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = scoreCounter.ToString();
    }
    public void AddPoint()
    {
        scoreCounter += 1;
        scoreText.text = scoreCounter.ToString();
    }

}
