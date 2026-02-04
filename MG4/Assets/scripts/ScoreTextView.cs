using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTextView : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText; 
    // Start is called before the first frame update
   private void Start()
    {
        // begin display 
        scoreText.text = "0";

        ScoreManager.Instance.ScoreChanged += UpdateScoreText; 
    }

    private void OnDestroy()
    {
        if (ScoreManager.Instance != null)
            ScoreManager.Instance.ScoreChanged -= UpdateScoreText;
    }


    // Update is called once per frame
    private void UpdateScoreText(int newScore)
    {
        scoreText.text = newScore.ToString();
    }
}
