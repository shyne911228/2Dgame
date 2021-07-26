using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class area : MonoBehaviour
{
   public Transform cam;
   public float moveR;
   private float startX,startY;
   public bool lockY;
    void Start()
    {
        startX=transform.position.x;
        startY=transform.position.y;
    
    }

    void Update()
    {
        if(lockY)
        {
            transform.position=new Vector2(startX+cam.position.x*moveR,transform.position.y);
        }
        else
        {
            transform.position=new Vector2(startX+cam.position.x*moveR,startY+cam.position.y*moveR);
        }
       
    }
}
