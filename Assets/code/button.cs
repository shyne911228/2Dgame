using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class button : MonoBehaviour
{
    public AudioSource au;


    void OnMouseDown() 
    {
        /*if(gameObject.tag=="press")
        {
            au.Play();
        }*/
        au.Play();
    }

    
}
