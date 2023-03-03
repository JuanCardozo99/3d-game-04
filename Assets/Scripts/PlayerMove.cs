using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float inputX;
    float inputZ;
    public float speed;
    public float rotSpeed;
    Rigidbody rb;
    Animator anim;
    public bool canJump;
    public float jumpForce;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(inputX, 0.0f, inputZ)*speed*Time.deltaTime);
        transform.Rotate(new Vector3(0.0f, inputX * rotSpeed,0.0f)*Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            Jump();
        }
        else
        {
            anim.SetBool("jump", false);
        }

        if(Input.GetKeyDown(KeyCode.J))
        {
            //if()
        }
    }

    private void FixedUpdate() 
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");

        anim.SetFloat("speedX", inputX);
        anim.SetFloat("speedZ", inputZ);
    }

    void Jump()
    {
        anim.SetBool("jump", true);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
