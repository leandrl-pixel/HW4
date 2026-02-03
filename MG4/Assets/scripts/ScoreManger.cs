using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManger : MonoBehaviour
{
    public static ScoreManger Instance { get; private set; }
    public event Action<int> ScoreChanged; 
    public int Score { get; private set; }

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        // hmm might add 
        // optional: DontDestoryOnLoad(gameObject); 
    }

    // Update is called once per frame
    private void OnEnable()
    {
        BirdController.OnPassedPipe += HandlePassedPipe;
        BirdController.OnDied += HandleDied;   
    }

    private void OnDisable()
    {
        BirdController.OnPassedPipe -= HandlePassedPipe;
        BirdController.OnDied -= HandleDied;
    }


    private void HandlePassedPipe()
    {
        Score++; 
        ScoreChanged?.Invoke(Score);
    }
    private void HandleDied()
    {
        Score = 0;
        ScoreChanged?.Invoke(Score);
    }


}
