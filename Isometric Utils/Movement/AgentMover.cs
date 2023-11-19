using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMover : MonoBehaviour
{
    [SerializeField] float MovementForce;

    Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 input) {
        if (input != Vector3.zero) {

            Vector3 movement = input;

            // Apply force to the ball in the calculated direction
            //rb.AddForce(movement * MovementForce);
            rb.velocity += input*MovementForce*Time.deltaTime;
        }
    }
}