using SojaExiles;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerVRController : MonoBehaviour
{
    public float speed = 3.5f;
    private float gravity = 10f;
    private CharacterController controller;

    void Start ()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        PlayerMovement(); 
    }

    private void PlayerMovement ()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal,0,vertical);
        Vector3 velocity = direction * speed;
        velocity = Camera.main.transform.TransformDirection(velocity);
        velocity.y -= gravity;
        controller.Move(velocity*Time.deltaTime);
    }
}
