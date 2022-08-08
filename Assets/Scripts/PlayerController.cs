using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float speed;
    Animator animator;
    Rigidbody m_rb;
    public float rotationSpeed;
    

    private void Start()
    {
        animator = GetComponent<Animator>();
        m_rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
       
        float horizontalMov = Input.GetAxisRaw("Horizontal");
        float verticalMov = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(horizontalMov, 0, verticalMov);
        move.Normalize();
        transform.Translate(move * speed * Time.deltaTime, Space.World);

        if (move != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(move, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        var vel = m_rb.velocity;
        float currentSpeed = vel.magnitude;

        if(currentSpeed > 0)
        {
            animator.SetBool("walking", true);
           
        }
        if (currentSpeed == 0)
        {
            animator.SetBool("walking", false);
        }

    }
}
