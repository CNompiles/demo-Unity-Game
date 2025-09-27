﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;   // Ταχύτητα κίνησης
    public float gravity = -9.81f; // βαρυτητα 
    private CharacterController controller;
    private Vector3 velocity; 

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal"); // A/D ή ← →
        float z = Input.GetAxis("Vertical");   // W/S ή ↑ ↓
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * moveSpeed * Time.deltaTime);
        if (controller.isGrounded && velocity.y <0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
