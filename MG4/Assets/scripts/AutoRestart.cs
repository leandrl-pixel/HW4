using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoRestart : MonoBehaviour
{
    // restart setting 
    [SerializeField] private float restartDelay = 5f;

    //[Header("Optional UI")]
    [SerializeField] private TMP_Text countdownText; // can be left empty

    private bool restarting = false;

    private void Awake()
    {
        if (countdownText != null)
            countdownText.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        BirdController.OnDied += BeginRestart;
    }

    private void OnDisable()
    {
        BirdController.OnDied -= BeginRestart;
    }

    private void BeginRestart()
    {
        if (restarting) return;
        restarting = true;

        StartCoroutine(RestartRoutine());
    }

    private IEnumerator RestartRoutine()
    {
        if (countdownText != null)
            countdownText.gameObject.SetActive(true);

        float t = restartDelay;

        while (t > 0f)
        {
            if (countdownText != null)
                countdownText.text = $"Restarting in {Mathf.CeilToInt(t)}...";

            t -= Time.deltaTime;
            yield return null;
        }

        Time.timeScale = 1f; // safety
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}