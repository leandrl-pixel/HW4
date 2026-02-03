using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    [SerializeField] private GameObject pipePairPrefab;
    [SerializeField] private float spawnInterval = 1.5f; 
    [SerializeField] private float spawnX = 8.5f;
    [SerializeField] private float minY = -2.0f;
    [SerializeField] private float maxY = 2.0f;

    private float timer = 0f;
    private bool spawning = true; 
   
    // Start is called before the first frame update

   private void OnEnable()
    {
        BirdController.OnDied += StopSpawning;
    }
    private void OnDisable()
    {
        BirdController.OnDied -= StopSpawning;
    }

    private void Update()
    {
        if (!spawning) return;
        timer += Time.deltaTime;
        if (timer > spawnInterval)
        {
            timer = 0f; 
            float y = Random.Range(minY, maxY);
            Instantiate(pipePairPrefab, new Vector3(spawnX,y, 0f), Quaternion.identity);
        }
    }

    // Update is called once per frame
    private void StopSpawning()
    {
        spawning = false;
    }
}
