using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class eaglemove : enemy
{
    
    
    private Rigidbody2D rb;
    //private Collider2D co;
    //public Transform top,button;
    //public float tope,buttone;
    //public float Speed;
    private bool isup;
    public AIPath AI;
    
    protected override void Start()
    {
        base.Start();//得到enemy的comonent
        rb=GetComponent<Rigidbody2D>();
    //   co=GetComponent<Collider2D>();

    //  transform.DetachChildren();
    //    tope=top.position.y;
    //     buttone=button.position.y;
    //     Destroy(top.gameObject);
    //    Destroy(button.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
        aimove();
    }

    void aimove()
    {
        if(AI.desiredVelocity.x>=0.01f)
        {
            transform.localScale=new Vector3(-1f,1f,1f);
        }
        else if(AI.desiredVelocity.x<=-0.01f)
        {
            transform.localScale=new Vector3(1f,1f,1f);
        }
    }

}
