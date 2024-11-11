using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnCollision_SwitchScene : MonoBehaviour
{
    public string targetObjectName;

    public string sceneName;
    
    // Start is called before the first frame update
    // void OncollsionEnter2D(Collider2D collision)
    // {
    //     if (collision.gameObject.name == targetObjectName)
    //     {
    //         SceneManager.LoadScene(sceneName);
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == targetObjectName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
