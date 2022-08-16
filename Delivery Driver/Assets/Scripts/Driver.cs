using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float turnSpeed = 200f;
    [SerializeField] float moveSpeed = 15f;

    [SerializeField] float slowSpeed = 10f;
    [SerializeField] float boostSpeed = 20f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Boost"){
            moveSpeed = boostSpeed;
        }

        if(other.tag == "Slow"){
            moveSpeed = slowSpeed;
        }
    }

    // Update is called once per frame
    void Update() // Callback
    {
        float turnAmount = Input.GetAxis("Horizontal"); // Left and right input [-1, 1]
        float moveAmount = Input.GetAxis("Vertical"); // Up and Down input [-1, 1]

        transform.Translate(0, moveSpeed * moveAmount * Time.deltaTime, 0);
        transform.Rotate(0, 0, turnAmount * -turnSpeed * Time.deltaTime);
    }
}
