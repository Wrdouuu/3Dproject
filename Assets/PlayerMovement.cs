using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Joystick joystick;
    public FixedButton fixedbutton;
    private Rigidbody rb;
    public float movespeed;

    public float jumpforce;
    public bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask LayerIsGround;


    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        fixedbutton = FindObjectOfType<FixedButton>();

        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, LayerIsGround);

        rb.velocity = new Vector3(joystick.Horizontal * movespeed, rb.velocity.y, joystick.Vertical * movespeed);

        if (isGrounded && fixedbutton.Pressed)
        {
            rb.velocity += Vector3.up * jumpforce;
        }
    }
}
