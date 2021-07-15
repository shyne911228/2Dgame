using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    protected Animator an;
    protected AudioSource AS;

    protected virtual void Start()
    {
        an=GetComponent<Animator>();
        AS=GetComponent<AudioSource>();
    }
    public void dead()
    {
        Destroy(gameObject);
        
    }
    public void jumpon()
    {
        an.SetTrigger("dead");
        AS.Play();
    }
    
}
