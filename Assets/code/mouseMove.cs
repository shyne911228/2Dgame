using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseMove : enemy
{
    private Rigidbody2D rb;
    private Collider2D co;
    public Transform left,right;
    public float leftf,rightf;
    public float Speed;
    
    private bool face=true;
    public LayerMask ground;
   
    protected override void Start()
    {
        //an=GetComponent<Animator>();
        base.Start();
        rb=GetComponent<Rigidbody2D>();
        co=GetComponent<Collider2D>();

        transform.DetachChildren();
        leftf=left.position.x;
        rightf=right.position.x;
        Destroy(left.gameObject);
        Destroy(right.gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    void move()
    {
        if(face)
        {
            if(co.IsTouchingLayers(ground))
            {
                rb.velocity=new Vector2(-Speed,transform.position.y);
                
            }
            
            if(transform.position.x<leftf)
            {
                transform.localScale=new Vector3(-1,1,1);
                face=false;
            }
        }
        else
        {
            if(co.IsTouchingLayers(ground))
            {
                rb.velocity=new Vector2(Speed,transform.position.y);
                
            }
            
            if(transform.position.x>rightf)
            {
                transform.localScale=new Vector3(1,1,1);
                face=true;
            }
        }
    }
    /*void faceforward()
    {
        if(face)
        {
            if(transform.position.x<leftf)
            {
                transform.localScale=new Vector3(-1,1,1);
                face=false;
            }
        }
        else
        {
            if(transform.position.x>rightf)
            {
                transform.localScale=new Vector3(1,1,1);
                face=true;
            }
        }
    }

    */
}
