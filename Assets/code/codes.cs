using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class codes : MonoBehaviour  //public class = 檔案名
{
    private Rigidbody2D rb;//鋼體(me)
    private Animator an;//動畫(me)
    public Collider2D co;//碰撞體(腳)
    public Collider2D cco;//碰撞體(頭)
    public Transform celling;//天花板
    public LayerMask ground;//地板(tilemap)
    public LayerMask spike;
    public float speed; //跑步速度(me)
    public float jumpforce;//跳躍力(me)
    public int cherry=0;
    public int diamond=0;
    public int damage;
    public int Health;
    public int score;
    public int blinks;
    public float time;
    public Text scorenum;
    public AudioSource au,auh,auc;
    private bool ishurt;//默認為false
    private Renderer render;
    
    



    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        an=GetComponent<Animator>();
        render=GetComponent<Renderer>();
        health.healthmax=Health;
        health.healthnow=Health;
        InvokeRepeating("spiketouch",0.01f,1f);

    }

    // Update is called once per frame
    private void Update() 
    {
        Crouch();
        jump();
        scorenum.text=score.ToString();
        

    }
    void FixedUpdate()
    {
        if(!ishurt)
        {
            
            Movement();//移動
        }
        swichan();//動畫運作
    }
    void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Crouch()
    {
        if(!Physics2D.OverlapCircle(celling.position,0.2f,ground))
        {
            if (Input.GetButton("Crouch"))
            {
            an.SetBool("crouch",true);
            cco.enabled=false;
            }
            else
            {
            an.SetBool("crouch",false);
            cco.enabled=true;
            }
        }
       

    }
    void jump()
    {
        if (Input.GetButton("Jump"))//角色跳躍
        {
            if (co.IsTouchingLayers(ground)  ||  co.IsTouchingLayers(spike))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpforce * Time.fixedDeltaTime);
                au.Play();
                an.SetBool("jumping", true);
            }
            
        }
    }
    void Movement()//移動製作
    {
        float move = Input.GetAxis("Horizontal");//左右移動速率
        float directionX = Input.GetAxisRaw("Horizontal");//左右移動的面向

        
        rb.velocity = new Vector2(move * speed * Time.fixedDeltaTime, rb.velocity.y); //velocity=速率   rb.velocity=鋼體的速率
        
        an.SetFloat("running", Mathf.Abs(directionX));
        
        if (directionX != 0)//角色面向
        {
            transform.localScale = new Vector3(directionX, 1, 1);
        }
    }
    void swichan()//動畫製作
    {
        //an.SetBool("idle", false);    //先將站立定義為否
        if( rb.velocity.y <0.1f && !co.IsTouchingLayers(ground))
        {
            an.SetBool("downing",true);//自由落體
        }
        if (an.GetBool("jumping"))    //是否在跳躍
        {
            if (rb.velocity.y < 0)    //是否上升速率小於0
            {
                an.SetBool("jumping", false);//將跳躍定義為否
                an.SetBool("downing", true);//將落下定義為是
            }
        }
        else if(ishurt)
        {
            an.SetBool("hurt",true);
            blinkplayer(blinks,time);
            an.SetFloat("running",0);

            if(Mathf.Abs(rb.velocity.x)<0.1f)
            {
                an.SetBool("hurt",false);
            //    an.SetBool("idle",true);
                ishurt=false;
            }
        }
        else if (co.IsTouchingLayers(ground)||co.IsTouchingLayers(spike))//是否碰觸到指定物ground
        {
            an.SetBool("downing", false);//將落下定義為否
         //    an.SetBool("idle", true);//將站立定義為是
        }
    }
    void spiketouch()
    {
       
        if (co.IsTouchingLayers(spike))//是否碰觸到指定物spike
        {
           Health-=2;
           blinkplayer(2,time);
           auh.Play();
           if (Health<0)
            {
                Health=0;
            }
           health.healthnow=Health; 
        }
    }
    void blinkplayer(int blinksNum,float sec)
    {
        StartCoroutine( Doblink (blinksNum ,sec));
    }
    IEnumerator Doblink(int blinksNum,float sec)
    {
        for(int i=0;i<blinksNum*2;i++)
        {
            render.enabled=!render.enabled;
            yield return new WaitForSeconds(sec);
        }
        render.enabled=true;
    }
    private void OnTriggerEnter2D(Collider2D other) //碰觸器
    {
        if(other.tag=="die")
        {
            Health=Health-health.healthnow;
            blinkplayer(blinks,time);
            health.healthnow=Health;
            GetComponent<AudioSource>().enabled=false;
            Invoke( "restart",2f);
        }
        else 
        {
            if(other.tag=="cherry")
            {
                auc.Play();
                other.GetComponent<Animator>().Play("gotten");
                
            }else if(other.tag=="diamond") 
            {
                auc.Play();
                other.GetComponent<Animator>().Play("gotten");   
            } 
            
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other) //消滅敵人
    {
        if(other.gameObject.tag=="enemy")
        {
            enemy enemy=other.gameObject.GetComponent<enemy>();
            if(an.GetBool("downing"))
            {
                enemy.jumpon();
                rb.velocity = new Vector2(rb.velocity.x, jumpforce * Time.deltaTime);
                an.SetBool("jumping", true);
            }
            
            else if(transform.position.x < other.gameObject.transform.position.x)
            {
                rb.velocity=new Vector2(-12,rb.velocity.y);
                ishurt=true;
                Health-=damage;
                if (Health<0)
                {
                    Health=0;
                }
                health.healthnow=Health;
                auh.Play();
            }
            else if(transform.position.x > other.gameObject.transform.position.x)
            {
                rb.velocity=new Vector2(12,rb.velocity.y);
                ishurt=true;
                Health-=damage;
                if (Health<0)
                {
                    Health=0;
                }
                health.healthnow=Health;
                auh.Play();
            }
            
        }
    }
    

    
    
    public void cherrycount()
    {
        cherry+=1;
        score+=120;
    }
    public void diamondcount()
    {
        diamond+=1;
        score+=500;
    }

}