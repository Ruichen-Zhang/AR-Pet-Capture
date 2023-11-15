using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARShootBall : MonoBehaviour
{
    public float FwdForce = 500f;
    //设置给小球向前的力的大小
    public Vector3 StanTra = new Vector3(0, 1f, 0);
    //设置一个夹角的参照数值

    private bool blTouched = false;
    //判断手指是否碰触到了精灵球的位置
    private bool blShooted = false;
    //判断精灵球是否发射
    private Vector3 startPosition;
    //手指滑动的起始点
    private Vector3 endPosition;
    //手指滑动的终点
    private float disFick;
    //记录手指滑动的距离
    private Vector3 offset;
    //记录手指滑动的偏移向量
    private int timeFlick;
    //用帧数来记录手指滑动的时间
    private float speedFlick;
    //记录滑动的速度
    private Camera camera;
    //记录主摄像机

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        //赋值为主摄像机
    }

    // Update is called once per frame
    void Update()
    {
        if(blTouched)//如果按在小球上 允许计算手指滑动
        {
            slip();

        }
    }

    //重置参数
    private void resetVari()
    {
        startPosition = Input.mousePosition;
        //起始位置设置为手指按下的位置
        endPosition = Input.mousePosition;
        //终止位置设置为手指按下的位置
    }

    //鼠标（手指）按下（是否触碰到脚本挂载物体）
    void OnMouseDown()
    {
        if(blShooted == false)//精灵球尚未发射
        {
            blTouched = true; //允许检测手指滑动
        }
    }

    //计算手指的滑动
    private void slip()
    {
        timeFlick += 25;    //时间每帧增加25

        if(Input.GetMouseButtonDown(0)) //当手指按下的时候
        {
            resetVari();//重置参数
        }
        if(Input.GetMouseButton(0)) //当手指一直按在屏幕上的时候
        {
            endPosition = Input.mousePosition;
            //把手指的终点位置变量 赋值刷新为当前手指所处的位置
            offset = camera.transform.rotation * (endPosition - startPosition);
            //获取手指在世界坐标上的偏移向量
            disFick = Vector3.Distance(startPosition, endPosition);
            //计算手指滑动的距离
        }
        if(Input.GetMouseButtonUp(0))
        {
            speedFlick = disFick / timeFlick;
            //计算滑动的速度
            blTouched = false;
            //手指是否触碰到精灵球 设置为否
            timeFlick = 0;
            //时间记录归零 
            if(disFick > 20 && endPosition.y - startPosition.y > 0) //如果手指移动距离大于20 方向向上滑动
            {
                shootBall();
                //发射精灵球
            }
        }
    }

    //发射精灵球
    private void shootBall()
    {
        transform.gameObject.AddComponent<Rigidbody>();
        //给精灵球添加刚体组件
        Rigidbody _rigBall = transform.GetComponent<Rigidbody>();
        //用局部变量获取刚体组件
        _rigBall.velocity = offset.normalized * speedFlick;
        //给精灵球一个初始速度 这个速度等于方向（单位向量）乘以速度
        _rigBall.AddForce(camera.transform.forward * FwdForce);
        //给精灵球一个向着屏幕前方的力
        _rigBall.AddTorque(transform.right);
        //让精灵球旋转起来
        _rigBall.drag = 0.5f;
        //设置精灵球的阻力
        blShooted = true;
        //这个精灵球已经发射出去了
        transform.parent = null;
        //让这个发射出去的精灵球脱离父级物体

        StaticData.BallNum--;
        //发射后减少精灵球的数量
        ARUI_Mgr.Instance.UpdateUIBallNum();
        //更新精灵球数量在UI中的显示

        StartCoroutine(LateInsBall());
        //调用延迟函数
    }

    //延迟生成精灵球的函数
    IEnumerator LateInsBall()
    {
        yield return new WaitForSeconds(0.2f);
        //延迟0.2秒向下执行
        ARBallCtrl.Instance.InsNewBall();
    }
}
