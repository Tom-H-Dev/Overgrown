using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private float _speed = 5;

    private Animator _animator;
    private GameObject _playerSprite;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();

        _playerSprite = GameObject.Find("Herman");
    }

    private void FixedUpdate()
    {
        if (GameManager.instance.canMovePlayer)
        {
            _rb.velocity = new Vector3(Input.GetAxis("Horizontal") * _speed, _rb.velocity.y, Input.GetAxis("Vertical") * _speed);

            if (Input.GetKeyDown(InputManager.instance.keyBinds.CheckKey("sprint")))
            {
                _speed = 7;
            }
            else if (Input.GetKeyUp(InputManager.instance.keyBinds.CheckKey("sprint")))
            {
                _speed = 5;
            }

            bool l_move = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) ? true : false;

            if (Input.GetKey(KeyCode.D))
            {
                _playerSprite.transform.rotation = new Quaternion(transform.rotation.x, (transform.rotation.y + 180), transform.rotation.z, 0);
            }
            if (Input.GetKey(KeyCode.A))
            {
                _playerSprite.transform.rotation = new Quaternion(transform.rotation.x, (transform.rotation.y), transform.rotation.z, 0);
            }

            _animator.SetBool("isMoving", l_move ? true : false);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Finish"))
        {
            MainMenu.instance.ToScene("LoadingScreen");
        }
    }

}
