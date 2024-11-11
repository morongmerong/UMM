using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnKeyPress_ChangeAnime : MonoBehaviour
{
    public string rightAnime = "";
    public string leftAnime = "";

    private string nowMode = "";
    // Start is called before the first frame update
    void Start()
    {
        // nowMode = rightAnime;
    }

    // Update is called once per frame
    void Update()
    {
        nowMode = "";
        if (Input.GetKey("d"))
        {
            nowMode = rightAnime;
        }
        if (Input.GetKey("a"))
        {
            nowMode = leftAnime;
        }
        
    }

    private void FixedUpdate()
    {
        if (nowMode != string.Empty)
        {
            this.GetComponent<Animator>().enabled = true;
            this.GetComponent<Animator>().Play(nowMode);
        }
        else
        {
            this.GetComponent<Animator>().enabled = false;
        }
    }
}
