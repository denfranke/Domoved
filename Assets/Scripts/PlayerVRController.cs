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
        //controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        test();
        //PlayerMovement(); 
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

    private void test ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        if(moveHorizontal!=0 && moveVertical!=0)
        Debug.Log(moveHorizontal+"______"+ moveVertical);
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
