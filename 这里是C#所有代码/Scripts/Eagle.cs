using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{
    private Rigidbody2D rb;
   public float Speed=6;
   private float upy,downy;
   public Transform uppoint,downpoint;
   private bool Faceup=true;
    void Start()
    { 
        rb=GetComponent<Rigidbody2D>();
        transform.DetachChildren();
        upy=uppoint.position.y;
        downy=downpoint.position.y;
        Destroy(uppoint.gameObject);
        Destroy(downpoint.gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
     void Move(){
            if(Faceup){
                rb.velocity=new Vector2(rb.velocity.x,Speed);
                if(transform.position.y>upy){
                    
                    Faceup=false;
                }
            }else{
                rb.velocity=new Vector2(rb.velocity.x,-Speed);
                if(transform.position.y<downy){
            
                    Faceup=true;
                }
            }
    }
     public void JumpOn(){
        Destroy(gameObject);
        
    }
}
