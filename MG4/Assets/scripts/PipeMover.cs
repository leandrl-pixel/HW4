using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMover : MonoBehaviour
{
    [SerializeField] private float speed = 2.5f;
    [SerializeField] private float destoryX = -10f;

    private bool moving = true; 

    // Start is called before the first frame update
    private void OnEnable()
    {
        BirdController.OnDied += StopMoving; 
    }

    private void OnDisable()
    {
        BirdController.OnDied -= StopMoving;
    }

    private void Update()
    {
        if (!moving) return;
        transform.position += Vector3.left * speed * Time.deltaTime; 

        if (transform.position.x  < destoryX)
            Destroy(gameObject);
    }
    



    // Update is called once per frame
    private void StopMoving()
    {
        moving = false;
    }

}
