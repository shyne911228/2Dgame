using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class enemyai : MonoBehaviour
{
    public Transform ta;
    public Transform enemy;
    public float speed=200f;
    public float next=3f;
    int current=0;
    bool reach = false;
    Path path;
    Seeker seeker;
    Rigidbody2D rb;

    void Start()
    {
        seeker=GetComponent<Seeker>();
        rb=GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath",0f,.5f);
        seeker.StartPath(rb.position,ta.position,OnPathComplete);
    }
    void UpdatePath()
    {
        if(seeker.IsDone())
            seeker.StartPath(rb.position,ta.position,OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path=p;
            current=0;
        }
    }
    void FixedUpdate()
    {
        if(path==null)
            return;
        if(current>=path.vectorPath.Count)
        {
            reach=true;
            return;
        }
        else
        {
            reach=false;
        }
        Vector2 direction=((Vector2)path.vectorPath[current]-rb.position).normalized;
        Vector2 force= direction*speed*Time.deltaTime;
        rb.AddForce(force);
        float distance=Vector2.Distance(rb.position,path.vectorPath[current]);
        if(distance<next)
        {
            current++;
        }
        if(force.x>=0.01f)
        {
            enemy.localScale=new Vector3(-1f,1f,1f);
        }
        else if(force.x<=-0.01f)
        {
            enemy.localScale=new Vector3(1f,1f,1f);
        }
    }
}
