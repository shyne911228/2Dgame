using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eaglemove : enemy
{
    private Rigidbody2D rb;
    //private Collider2D co;
    public Transform top,button;
    public float tope,buttone;
    public float Speed;
    private bool isup;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();//得到enemy的comonent
        rb=GetComponent<Rigidbody2D>();
        //co=GetComponent<Collider2D>();

        transform.DetachChildren();
        tope=top.position.y;
        buttone=button.position.y;
        Destroy(top.gameObject);
        Destroy(button.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    void move()
    {          
        if(transform.position.y<buttone)
        {
            rb.velocity=new Vector2(transform.position.x,Speed);
            
        }
        else if(transform.position.y>tope)
        {
            rb.velocity=new Vector2(transform.position.x,-Speed);
        }
        
        
           
        
    }
}
