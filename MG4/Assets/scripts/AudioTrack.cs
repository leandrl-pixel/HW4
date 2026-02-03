using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrack : MonoBehaviour
{
    [SerializeField] private AudioClip flapClip;
    [SerializeField] private AudioClip pointClip; 
    [SerializeField] private AudioClip deathClip;

    private AudioSource source;
    private int lastScore = 0; 

    // Start is called before the first frame update
   private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnEnable()
    {
        BirdController.OnFlap += PlayFlap;
        BirdController.OnDied += PlayDeath;
        // point sound when score changes 
        ScoreManger.Instance.ScoreChanged += HandleScoreChanged;
    }

    private void PlayFlap()
    {
        if (flapClip != null) source.PlayOneShot(flapClip);

    }
    private void PlayDeath()
    {
        if (deathClip != null) source.PlayOneShot(deathClip);
    }
        private void HandleScoreChanged(int newScore)
    {
        if (newScore < lastScore && pointClip != null)
            source.PlayOneShot(pointClip); 
        lastScore = newScore;
    }
    }

