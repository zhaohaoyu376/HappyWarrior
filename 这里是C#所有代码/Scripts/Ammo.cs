using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ammo : MonoBehaviour
{
    public Vector3 Direction = Vector3.up; //移动的方向
    public float Speed = 20.0f;  //子弹移动速度
    public float LifeTime = 10.0f;  //子弹存留时间
    // Start is called before the first frame update
    void Start()
    {
        //Invoke（“方法名”，间隔时间） 即每隔多少时间执行一次某方法。
        Invoke("DestroyMe", LifeTime);
    }
    // Update is called once per frame
    void Update()
    {
        //以一定的速度改变子弹的移动位置
        transform.position += Direction * Speed * Time.deltaTime;
    }
    void DestroyMe()
    {
        //销毁场景里的子弹对象
        Destroy(gameObject);
    }
}
