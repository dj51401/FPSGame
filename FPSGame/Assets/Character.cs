using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed = 5f;
    public float gravity = 8f;

    private CharacterController _controller;
    Vector3 _velocity = Vector3.zero;


    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _controller.Move(move * speed * Time.deltaTime);
        if(move != Vector3.zero)
        {
            transform.forward = move;
        }

        
        _velocity.y += gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }
}
