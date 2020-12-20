using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour
{
    private Player _player;

    private CharacterController _controller;

    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<Player>();
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        direction.y -= _player.gravity;

        direction = transform.transform.TransformDirection(direction);

        _controller.Move(direction * _player.speed * Time.deltaTime);
    }
}
