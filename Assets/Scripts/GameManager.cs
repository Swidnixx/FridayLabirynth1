using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    int keys = 0;

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
    public void AddKey()
    {
        keys++;
    }
    public void FreezeTime(int time)
    {
        CancelInvoke(nameof(TimerTick));
        InvokeRepeating(nameof(TimerTick), time, 1);
    }
}
