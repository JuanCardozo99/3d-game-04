using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public bool grounded;
    public float distance;
    Vector3 dir;
    PlayerMove playermove_script;
    void Start()
    {
        dir = new Vector3(0f,-1f,0f);
        playermove_script = FindObjectOfType<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, dir, out hit, distance))
        {
            grounded = true;
            playermove_script.canJump = true;
        }
        else
        {
            grounded = false;
            playermove_script.canJump = false;
        }
    }
}
