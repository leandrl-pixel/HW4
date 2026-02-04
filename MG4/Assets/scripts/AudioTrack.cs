using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioTrack : MonoBehaviour
{
    [SerializeField] private AudioClip flapClip;
    [SerializeField] private AudioClip pointClip;
    [SerializeField] private AudioClip deathClip;

    private AudioSource source;
    private int lastScore = 0;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        BirdController.OnFlap += PlayFlap;
        BirdController.OnDied += PlayDeath;
    }

    private void Start()
    {
        if (ScoreManager.Instance != null)
            ScoreManager.Instance.ScoreChanged += HandleScoreChanged;
    }

    private void OnDisable()
    {
        BirdController.OnFlap -= PlayFlap;
        BirdController.OnDied -= PlayDeath;

        if (ScoreManager.Instance != null)
            ScoreManager.Instance.ScoreChanged -= HandleScoreChanged;
    }

    private void PlayFlap()
    {
        if (flapClip != null)
            source.PlayOneShot(flapClip);
    }

    private void PlayDeath()
    {
        if (deathClip != null)
            source.PlayOneShot(deathClip);
    }

    private void HandleScoreChanged(int newScore)
    {
        if (newScore > lastScore && pointClip != null)
            source.PlayOneShot(pointClip);

        lastScore = newScore;
    }
}