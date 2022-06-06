using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    string collisionName;
    string collisionTag;


    void OnTriggerEnter2D(Collider2D collision)
    {
        collisionName=collision.name;
        collisionTag=collision.tag;
        if (collision.gameObject.tag == "Grass"|| collision.gameObject.tag == "HorstBorder")
        {
            return;
        }

        if (collision.gameObject.tag == collisionTag)
        {
            SceneManager.LoadScene(collisionName);
        }
        
    
        Debug.Log(collisionName);
        Debug.Log(collisionTag);
    }
}
