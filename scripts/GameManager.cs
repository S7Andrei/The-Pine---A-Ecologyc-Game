using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;
    public bool startPlaying;
    public BeatScroler theBS;
    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 1;
    public int scorePerGoodNote = 3;
    public int scorePerPerfectNote = 5;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multilplierThresholds;

    public Text scoreText;
    public Text multiText;
    
    void Start()
    {
        instance = this;
        scoreText.text = "Score: 0";
        currentMultiplier = 1;
    }
    
    void Update()
    {
        if(!startPlaying){
            if(Input.anyKeyDown){
                startPlaying = true;
                theBS.hasStarted = true;

                theMusic.Play();
            }
        }
    }

    public void NoteHit(){
        Debug.Log("hit On Time");

        if(currentMultiplier - 1 < multilplierThresholds.Length){
            multiplierTracker++;

            if(multilplierThresholds[currentMultiplier - 1] <= multiplierTracker){
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        multiText.text = "Multiplier: x" + currentMultiplier;

        //currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;

    }

    public void NormalHit(){
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();
    }

    public void GoodHit(){
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();
    }

    public void PerfectHit(){
        currentScore += scorePerPerfectNote * currentMultiplier;
        NoteHit();
    }


    public void NoteMissed(){
    //    Debug.Log("Missed Note");

        currentMultiplier = 1;
        multiplierTracker = 0;

        multiText.text = "Multiplier: x" + currentMultiplier;
    }
}
