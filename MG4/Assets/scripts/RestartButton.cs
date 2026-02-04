using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
    
public class RestartButton : MonoBehaviour
{
    [SerializeField] private GameObject restartButton; 
    // Start is called before the first frame update
  private  void Awake()
    {
        restartButton.SetActive(false);
        
    }

    // Update is called once per frame
  private  void OnEnable()
    {
        BirdController.OnDied += ShowButton; 
    }

    private void OnDisable()
    {
        BirdController.OnDied -= ShowButton;
    }
    private void ShowButton()
    {
        restartButton.SetActive(true); 
    }
    //this is when i add a button to on click 
    // public void RestartGame()
    // {
    // Debug.Log("Restart clicked"); 
    // Time.timeScale = 1.0f;
    // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);



    // }
    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
        );
    }
    }
