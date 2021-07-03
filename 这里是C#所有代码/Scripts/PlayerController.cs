using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    //[SerializeField]
    private Rigidbody2D player;
    private Animator animate;
    public LayerMask ground;
    public Collider2D coll;
    public GameObject gameOverDialog;
    public float speed=450;
    public float jumpforce=450; 
    public int cherrynum;
    public Text cherryNum;
    public int gemnum;
    public Text gemNum;
    private bool isHurt;
    public int grassnum,mushroomnum,woodnum;
    private int meatnum;
    public bool isDig;
    public int stone, copper, silver, gold;
    public int remainDigNumber;
    public Text stoneNumber, copperNumber, silverNumber, goldNumber;
    public Text finalStoneNumber, finalCopperNumber, finalSilverNumber, finalGoldNumber;
    public Text remainDigTimes;

    // Start is called before the first frame update
    void Start()
    {
        player=GetComponent<Rigidbody2D>();
        animate = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!isHurt)
        {
        Movement();
        }
        SwitchAnim();
        Judge();

    }

    void Movement(){
        float horizontalMove= Input.GetAxis("Horizontal");
        float faceDirection=Input.GetAxisRaw("Horizontal");
        //角色移动
        if(horizontalMove!=0)
        {
            player.velocity=new Vector2(horizontalMove*speed*Time.deltaTime,player.velocity.y);

            animate.SetFloat("running",Mathf.Abs(faceDirection));
        }

        //角色方向变换
        if(faceDirection!=0)
        {
            transform.localScale=new Vector3(faceDirection,1,1);
        }

        //角色跳跃
        if(Input.GetButtonDown("Jump")&&coll.IsTouchingLayers(ground)){
            player.velocity=new Vector2(player.velocity.x,jumpforce*Time.deltaTime);
            animate.SetBool("jumping",true);
        }

       // if(Input.GetButton("Submit")){
       //    Physics2D.gravity=new Vector2(0,9.8f );
        //  
      //  }



    }


    //切换动画效果
    void SwitchAnim()
    {

        animate.SetBool("idle",false);
        if(player.velocity.y<0.1&&!coll.IsTouchingLayers(ground)){
            animate.SetBool("falling",true);
        }
        if(animate.GetBool("jumping")){
            if(player.velocity.y<0){
                animate.SetBool("jumping",false);
                animate.SetBool("falling",true);
            }
        }else if(isHurt){
             animate.SetBool("hurt",true);
             animate.SetFloat("running",0);
            if(Mathf.Abs(player.velocity.x)<0.1f){
                animate.SetBool("hurt",false);
                animate.SetBool("idle",true);
                isHurt=false;
            }
        }
        else if(coll.IsTouchingLayers(ground))
        {
            animate.SetBool("falling",false);
            animate.SetBool("idle",true);
        }
    }


    //玩家是否选择挖掘
    void Judge()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            isDig = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
         //收集
        if(collision.tag=="Cherry")
        {
            Destroy(collision.gameObject);
            cherrynum+=1;
            cherryNum.text=cherrynum.ToString();
        }
        if(collision.tag=="Gem")
        {
            Destroy(collision.gameObject);
            gemnum+=1;
            gemNum.text=gemnum.ToString();
        }
 	    if(collision.tag=="Grass")
        {
            Destroy(collision.gameObject);
            grassnum+=1;
           
        }
        if(collision.tag=="Mushroom")
        {
            Destroy(collision.gameObject);
            mushroomnum+=1;
           
        }
        if(collision.tag=="Wood")
        {
            Destroy(collision.gameObject);
            woodnum+=1;
           
        }
        //触发死亡效果
        if(collision.tag=="Deadline")
        {
         Invoke("Restart",2f);
           
        }
      
    }

    //用脚踩消灭敌人
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag=="Frog")
        {
            Frog frog =collision.gameObject.GetComponent<Frog>();
            var point=frog.rb;
            var delta=player.velocity.y-point.velocity.y;
            if(animate.GetBool("falling")&&(delta>=0))
            {
                frog.JumpOn();
                meatnum++;
      
                player.velocity=new Vector2(player.velocity.x,jumpforce*0.5f*Time.deltaTime);
                animate.SetBool("jumping",true);
            }
          
            else if(transform.position.x<collision.gameObject.transform.position.x)
            {
                player.velocity=new Vector2(-5,player.velocity.y);
                isHurt=true;

            }
            else if(transform.position.x>collision.gameObject.transform.position.x)
            {
                isHurt=true;
                player.velocity=new Vector2(5,player.velocity.y);
            
            }
        }
        if(collision.gameObject.tag=="Eagle")
        {
            Eagle eagle =collision.gameObject.GetComponent<Eagle>();
            if(animate.GetBool("falling"))
            {
                eagle.JumpOn();
                meatnum++;
                player.velocity=new Vector2(player.velocity.x,jumpforce*0.5f*Time.deltaTime);
                animate.SetBool("jumping",true);
            }
          
            else if(transform.position.x<collision.gameObject.transform.position.x)
            {
                player.velocity=new Vector2(-5,player.velocity.y);
                isHurt=true;

            }
            else if(transform.position.x>collision.gameObject.transform.position.x)
            {
                isHurt=true;
                player.velocity=new Vector2(5,player.velocity.y);
            
            }
        }
        if(collision.gameObject.tag=="Jumper")
        {
            Jumper jumper =collision.gameObject.GetComponent<Jumper>();
            if(animate.GetBool("falling"))
            {
                jumper.JumpOn();
                meatnum++;
                player.velocity=new Vector2(player.velocity.x,jumpforce*0.5f*Time.deltaTime);
                animate.SetBool("jumping",true);
            }
          
            else if(transform.position.x<collision.gameObject.transform.position.x)
            {
                player.velocity=new Vector2(-5,player.velocity.y);
                isHurt=true;

            }
            else if(transform.position.x>collision.gameObject.transform.position.x)
            {
                isHurt=true;
                player.velocity=new Vector2(5,player.velocity.y);
            
            }
        }
        if(collision.gameObject.tag=="Oct")
        {
            Octopus oct =collision.gameObject.GetComponent<Octopus>();
            if(animate.GetBool("falling"))
            {
                oct.JumpOn();
                meatnum++;
                player.velocity=new Vector2(player.velocity.x,jumpforce*0.5f*Time.deltaTime);
                animate.SetBool("jumping",true);
            }
          
            else if(transform.position.x<collision.gameObject.transform.position.x)
            {
                player.velocity=new Vector2(-5,player.velocity.y);
                isHurt=true;

            }
            else if(transform.position.x>collision.gameObject.transform.position.x)
            {
                isHurt=true;
                player.velocity=new Vector2(5,player.velocity.y);
            
            }
        }
        if(collision.gameObject.tag=="Crab")
        {
            Crab crab =collision.gameObject.GetComponent<Crab>();
            if(animate.GetBool("falling"))
            {
                crab.JumpOn();
                meatnum++;
                player.velocity=new Vector2(player.velocity.x,jumpforce*0.5f*Time.deltaTime);
                animate.SetBool("jumping",true);
            }
          
            else if(transform.position.x<collision.gameObject.transform.position.x)
            {
                player.velocity=new Vector2(-5,player.velocity.y);
                isHurt=true;

            }
            else if(transform.position.x>collision.gameObject.transform.position.x)
            {
                isHurt=true;
                player.velocity=new Vector2(5,player.velocity.y);
            
            }
        }
    }

    //挖矿
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (remainDigNumber > 0)
        {
            gameOverDialog.SetActive(false);
            if (isDig)
            {
                isDig = false;
                //石头
                if (collision.gameObject.tag == "Stone")
                {
                    Destroy(collision.gameObject);
                    isDig = false;
                    stone += 1;
                    remainDigNumber -= 1;
                    stoneNumber.text = stone.ToString();
                    remainDigTimes.text = remainDigNumber.ToString();
                    finalStoneNumber.text = stoneNumber.text;

                }
                //铜矿
                else if (collision.gameObject.tag == "Copper")
                {
                    Destroy(collision.gameObject);
                    isDig = false;
                    copper += 1;
                    remainDigNumber -= 1;
                    copperNumber.text = copper.ToString();
                    remainDigTimes.text = remainDigNumber.ToString();
                    finalCopperNumber.text = copperNumber.text;
                }
                //银矿
                else if (collision.gameObject.tag == "Silver")
                {
                    Destroy(collision.gameObject);
                    isDig = false;
                    silver += 1;
                    remainDigNumber -= 1;
                    silverNumber.text = silver.ToString();
                    remainDigTimes.text = remainDigNumber.ToString();
                    finalSilverNumber.text = silverNumber.text;
                }
                //金矿
                else if (collision.gameObject.tag == "Gold")
                {
                    Destroy(collision.gameObject);
                    isDig = false;
                    gold += 1;
                    remainDigNumber -= 1;
                    goldNumber.text = gold.ToString();
                    remainDigTimes.text = remainDigNumber.ToString();
                    finalGoldNumber.text = goldNumber.text;
                }

            }
        }
        else if (remainDigNumber <= 0)
        {
            //挖掘次数用完，显示结束对话框
            gameOverDialog.SetActive(true);
            Invoke("Exit", 5f);
        }

    }

    //重新开始
    private void Restart()
    {
          SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Exit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }


}
