using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIfrog : enemy
{
    private Rigidbody2D rb;
    private Collider2D co;
    public Transform left,right;
    public float leftf,rightf;
    public float Speed,jumpforce;
    public LayerMask ground;
    private bool face=true;
    



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

    
    void Update()
    {
        swichan();
    }
    
    void move()
    {
        if(face)
        {
            if(co.IsTouchingLayers(ground))
            {
                rb.velocity=new Vector2(-Speed,jumpforce);
                an.SetBool("jump",true);
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
                rb.velocity=new Vector2(Speed,jumpforce);
                an.SetBool("jump",true);
            }
            
            if(transform.position.x>rightf)
            {
                transform.localScale=new Vector3(1,1,1);
                face=true;
            }
        }
    }
    void swichan()
    {
        if(an.GetBool("jump"))
        {
            if(rb.velocity.y<0.1)
            {
                an.SetBool("jump",false);
                an.SetBool("down",true);
            }
        }
        if(co.IsTouchingLayers(ground)&&an.GetBool("down"))
        {
            an.SetBool("down",false);
        }
    }
    


}
