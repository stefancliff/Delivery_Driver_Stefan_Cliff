using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    
    [SerializeField] float steerSpeed = 0.01f;  // check Unity for new values
    [SerializeField] float moveSpeed = 20f;     // check Unity for new values
    [SerializeField] float slowSpeed = 5f;
    [SerializeField] float boostSpeed = 30f;

    void Start()
    {
        
    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;  // this is to ensure that a fast and a slow computer see and effect things at the same rate 
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;      // because otherwise a faster computer would move faster than a slower one. This also means they are Frame independant
        transform.Rotate(0, 0, -steerAmount);                                           // putting a - here beacause otherwise it goes the wrong way around 
        transform.Translate(0, moveAmount, 0);
    }

    void OnCollisionEnter2D(Collision2D other) {
       
        moveSpeed = slowSpeed;
        Debug.Log("Slow down!");
    }

    void OnTriggerEnter2D(Collider2D other) {

        if(other.tag == "slowSpeed"){
            moveSpeed = slowSpeed;
            Debug.Log("Slow down!");
        }

        else if(other.tag == "boostSpeed"){
            moveSpeed = boostSpeed;
            Debug.Log("Boost!");
        }
         
    }
}
