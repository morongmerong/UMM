using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class OnUpKeyPress_Throw : MonoBehaviour
{
    public GameObject newPrefab;

    public int maxCount = 20;

    public float throwX = 4;

    public float throwY = 8;

    public float offsetY = 1;

    private bool pushFlag = false;

    private bool leftFlag = false;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d"))
        {
            leftFlag = false;
        }

        if (Input.GetKey("a"))
        {
            leftFlag = true;
        }

        if (Input.GetKey("space"))
        {
            if (pushFlag == false)
            {
                pushFlag = true;
                Vector3 area = this.GetComponent<SpriteRenderer>().bounds.size;
                Vector3 newPos = this.transform.position;
                newPos.y += offsetY;
                GameObject newGameObject = Instantiate(newPrefab) as GameObject;
                newPos.z = -5;
                newGameObject.transform.position = newPos;

                Rigidbody2D rbody = newGameObject.GetComponent<Rigidbody2D>();
                if (leftFlag)
                {
                    rbody.AddForce(new Vector2(-throwX, throwY), ForceMode2D.Impulse);
                }
                else
                {
                    rbody.AddForce(new Vector2(throwY, throwY), ForceMode2D.Impulse);
                }
            }
        }
        else
        {
            pushFlag = false;
        }
    }
}
