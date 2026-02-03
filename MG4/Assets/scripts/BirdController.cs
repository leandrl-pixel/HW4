using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public static event Action OnFlap;
    public static event Action OnDied;
    public static event Action OnPassedPipe;

    // Movement 
    [SerializeField] private float flapVelocity = 5.5f;

    private Rigidbody2D rb;
    private bool isAlive = true; 
    public bool IsAlive => isAlive;

  
   private void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
   private void Update()
    {
        if (!isAlive) return; 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //this is where the real movement activates and brings flappy bird 
            rb.velocity = new Vector2(rb.velocity.x, flapVelocity);
            OnFlap?.Invoke();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isAlive) return;
        //pipe has to be a non trigger collider 
        if (collision.collider.CompareTag("Pipe"))
        {
            isAlive = true;
            OnDied?.Invoke();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isAlive) return;
        //ScoreZone gameobject 
        if (other.CompareTag("ScoreZone"))
        {
            OnPassedPipe?.Invoke();
        }
    }
}
