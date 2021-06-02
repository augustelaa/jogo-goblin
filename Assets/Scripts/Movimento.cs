using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    CharacterController controller;
    Animator anim;

    public float speed = 6.0f;
    public float jumpSpeed = 2.0f;
    public float gravity = 20.0f;
    private Quaternion lookLeft;
	private Quaternion lookRight;

    public Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();

        lookRight = transform.rotation;
		lookLeft = lookRight * Quaternion.Euler(0, 180, 0); 
    }

    void Update()
    {
        anim.SetBool ("andando", false);
		if (Input.GetButton("Jump"))
			moveDirection.y = jumpSpeed;

		if (Input.GetKey(KeyCode.A)){
			transform.rotation = lookLeft;
			anim.SetBool ("andando", true);
		}

		if (Input.GetKey(KeyCode.D)){
			transform.rotation = lookRight;
			anim.SetBool ("andando", true);
		}

		moveDirection.x = Input.GetAxis("Horizontal") * speed;

        if (Input.GetKey(KeyCode.LeftShift))
            moveDirection.x *= 1.5f;

        moveDirection.y -= gravity * Time.deltaTime;
        if (controller.isGrounded) moveDirection.y = 0;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
