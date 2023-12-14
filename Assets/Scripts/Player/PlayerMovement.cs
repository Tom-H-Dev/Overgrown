using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float _speed = 5;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (GameManager.instance.canMovePlayer)
        {
            rb.velocity = new Vector3(Input.GetAxis("Horizontal") * _speed , rb.velocity.y , Input.GetAxis("Vertical") * _speed);


            if (Input.GetKeyDown(InputManager.instance.keyBinds.CheckKey("sprint")))
            {
                _speed = 7;
            }
            else if (Input.GetKeyUp(InputManager.instance.keyBinds.CheckKey("sprint")))
            {
                _speed = 5;
            }
        }
    }
}
