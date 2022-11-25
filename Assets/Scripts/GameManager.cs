using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Key;

public class GameManager : MonoBehaviour
{
    // SINGLETON
    public static GameManager Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Multiple GMs in the scene!");
        }
    }

    [SerializeField] int time = 60;
    bool gamePaused;
    bool gameOver;

    int diamonds = 0;
    int redKeys = 0;
    int greenKeys = 0;
    int goldenKeys = 0;

    //Unity Callbacks
    private void Start()
    {
        InvokeRepeating( nameof(TimerTick), 3, 1 );
    }
    private void Update()
    {
        if(Input.GetButtonDown("Cancel") && !gameOver)
        {
            if(gamePaused)
            {
                Unpause();
            }
            else
            {
                Pause();
            }
        }
    }

    //Game Flow Functions
    void Pause()
    {
        Time.timeScale = 0;
        gamePaused = true;
    }
    void Unpause()
    {
        Time.timeScale = 1;
        gamePaused = false;
    }
    void TimerTick()
    {
        time--;
        //Debug.Log("Time: " + time);

        if(time <= 0)
        {
            time = 0;
            GameOver();
        }
    }
    void GameOver()
    {
        gameOver = true;
        CancelInvoke(nameof(TimerTick));
        Time.timeScale = 0;
    }

    //Pickups Interactions
    public void AddDiamond()
    {
        diamonds++;
    }
    public void AddKey(KeyColor keyColor)
    {
        switch(keyColor)
        {
            case KeyColor.Red:
                redKeys++;
                break;

            case KeyColor.Green:
                greenKeys++;
                break;

            case KeyColor.Gold:
                goldenKeys++;
                break;
        }
    }
    public void FreezeTime(int time)
    {
        CancelInvoke(nameof(TimerTick));
        InvokeRepeating(nameof(TimerTick), time, 1);
    }
    public void AddTime(int time)
    {
        this.time += time; 
    }

    //Other Interactions
    internal bool CheckTheKey(KeyColor keyColor)
    {
        switch(keyColor)
        {
            case KeyColor.Red:
                return redKeys > 0;

            case KeyColor.Green:
                return greenKeys > 0;

            case KeyColor.Gold:
                return goldenKeys > 0;
        }
        return false;
    }
}
