using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 10;

    CharacterController controller;

    public Transform groundSensor;
    public LayerMask groundLayer;

    bool grounded;
    float velocity = 0;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Movement();
        GroundSensor();
        Gravity();
    }

    void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = (x * transform.right + z * transform.forward) * speed * Time.deltaTime;
        controller.Move(movement);
    }
    void GroundSensor()
    {
        RaycastHit hit;

        bool didHit = Physics.Raycast(groundSensor.position, Vector3.down, out hit, 0.4f, groundLayer);
        if(didHit)
        {
            grounded = true;
            switch( hit.collider.tag )
            {
                case "SlowFloor":
                    speed = 4;
                    break;

                case "FastFloor":
                    speed = 16;
                    break;

                default:
                    speed = 10;
                    break;
            }
        }
        else
        {
            grounded = false;
        }
    }
    void Gravity()
    {
        if (grounded)
        {
            return;
        }

        if( velocity < 55 )
        {
            velocity += Time.deltaTime * 10;
        }

        controller.Move(Vector3.down * velocity * Time.deltaTime);
    }
}
