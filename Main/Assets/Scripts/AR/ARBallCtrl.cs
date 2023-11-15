using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARBallCtrl : MonoBehaviour
{
    public static ARBallCtrl Instance;

    public Transform PosInsBall;
    //储存生成精灵球的位置

    private GameObject[] balls;
    //储存精灵球预制体

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        balls = Resources.LoadAll<GameObject>("Balls");
        //加载所有路径在“Resources/Balls”中的预制体

        ARUI_Mgr.Instance.UpdateUIBallNum();
        //刷新精灵球的数量

        InsNewBall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //生成精灵球
    public void InsNewBall()
    {
        if(StaticData.BallNum > 0)
        {
            GameObject _ball = Instantiate(balls[0], PosInsBall.position, PosInsBall.rotation);
            //生成精灵球
            _ball.transform.SetParent(PosInsBall);
            //设置精灵球的父级物体 为了保证发射前始终在屏幕的固定位置
            _ball.gameObject.AddComponent<SphereCollider>();
            //给精灵球增加球形碰撞器
            _ball.gameObject.AddComponent<ARShootBall>();
            _ball.transform.localScale = new Vector3(25f, 25f, 25f);
            //把精灵球的大小设置为25倍（预制体是250倍，所以这里等于是缩小）
            _ball.GetComponent<SphereCollider>().radius = 0.01f;
            //更改球形碰撞器的大小 使碰撞器与模型大小保持匹配
        }  
    }
}
