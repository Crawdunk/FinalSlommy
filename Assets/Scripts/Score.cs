using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI scoreCounter;
    public int scoreValue;
    
    private GameManager gm;

    void Awake()
    {
        scoreCounter = GetComponent<TextMeshProUGUI>(); //Grabs the TMPro component
    }

    void Start()
    {
        gm = GameObject.FindWithTag("GM").GetComponent<GameManager>();
        scoreValue = gm.score; //Sets the scoreValue to the game manager float score.
    }

    void Update()
    {
        scoreCounter.text = "Your Score: " + scoreValue.ToString(); //Sets the text string to Your Score: *insert score*
    }


}
