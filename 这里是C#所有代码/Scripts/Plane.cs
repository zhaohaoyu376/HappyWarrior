using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{

    //飞船生命值
    public int Health = 100;
    //两发子弹间隔时间
    public float ReloadDelay = 0.2f;
    //这里是方便传入两个所需的游戏对象，一个是预设对象，一个是开火位置
    public GameObject PrefabAmmo = null;
    public GameObject GunPosition = null;
    //true时说明可以开火，flase时不能开火
    private bool WeaponsActivated = true;


    //飞船每秒移动的单元的个数
    public float Speed;
    //保证飞船在上下左右移动 
    public Vector3 MinMaxX = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        transform.position =
            new Vector2(
                Mathf.Clamp(              //Mathf.Clamp限制x移动范围,Input.GetAxis("Horizontal")获取键盘左右移动
                    transform.position.x + Input.GetAxis("Horizontal") * Speed * Time.deltaTime,
                    -7,
                    7),
                //transform.position.y,
                Mathf.Clamp(              //Mathf.Clamp限制y移动范围，Input.GetAxis("Vertical")获取键盘上下移动
                    transform.position.y + Input.GetAxis("Vertical") * Speed * Time.deltaTime,
                    -4,
                    4)
                );

    }



    void LateUpdate() //用于实现子弹发射
    {
        //当按下发射按钮时,让鼠标按下的时候一直执行  需要使用Input.GetButton("Fire1")
        if (Input.GetButton("Fire1") && WeaponsActivated)
        {
            //创建一个新子弹
            //参数一：是预设（在预设中已设定好子弹的属性） 参数二：实例化预设的坐标  参数三：实例化预设的旋转角度
            Instantiate(PrefabAmmo, GunPosition.transform.position,
                PrefabAmmo.transform.rotation);
            WeaponsActivated = false;
            Invoke("ActivateWeapons", ReloadDelay);
        }
    }
    //允许发射子弹
    void ActivateWeapons()
    {
        WeaponsActivated = true;
    }

}
