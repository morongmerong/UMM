using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OnKeyPress_MoveGravity : MonoBehaviour
{
    public float speed = 3;
    public float jumppower = 8;
    
    float vx = 0;
    bool leftFlag = false;
    bool pushFlag = false;
    bool jumpFlag = false;
    bool groundFlag = false;

    private Rigidbody2D rbody;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        //rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        vx = 0;
        if (Input.GetKey(KeyCode.D))
        {
            vx = speed;
            leftFlag = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            vx = -speed;
            leftFlag = true;
        }
        if (Input.GetKey(KeyCode.W) && groundFlag)
        {
            this.transform.rotation =  new Quaternion(0f,0f,0f,0);
            if (pushFlag == false)
            {
                jumpFlag = true;
                pushFlag = true;
            }
        }
        else
        {
            pushFlag = false;
        }
    }

    private void FixedUpdate()
    {
        rbody.velocity = new Vector2(vx, rbody.velocity.y);
        this.GetComponent<SpriteRenderer>().flipX = leftFlag;
        if (jumpFlag)
        {
            jumpFlag = false;
            rbody.AddForce(new Vector2(0, jumppower), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        groundFlag = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        groundFlag = false;
    }
}
