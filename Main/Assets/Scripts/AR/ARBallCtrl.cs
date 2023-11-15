using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARBallCtrl : MonoBehaviour
{
    public static ARBallCtrl Instance;

    public Transform PosInsBall;
    //�������ɾ������λ��

    private GameObject[] balls;
    //���澫����Ԥ����

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        balls = Resources.LoadAll<GameObject>("Balls");
        //��������·���ڡ�Resources/Balls���е�Ԥ����

        ARUI_Mgr.Instance.UpdateUIBallNum();
        //ˢ�¾����������

        InsNewBall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //���ɾ�����
    public void InsNewBall()
    {
        if(StaticData.BallNum > 0)
        {
            GameObject _ball = Instantiate(balls[0], PosInsBall.position, PosInsBall.rotation);
            //���ɾ�����
            _ball.transform.SetParent(PosInsBall);
            //���þ�����ĸ������� Ϊ�˱�֤����ǰʼ������Ļ�Ĺ̶�λ��
            _ball.gameObject.AddComponent<SphereCollider>();
            //������������������ײ��
            _ball.gameObject.AddComponent<ARShootBall>();
            _ball.transform.localScale = new Vector3(25f, 25f, 25f);
            //�Ѿ�����Ĵ�С����Ϊ25����Ԥ������250�������������������С��
            _ball.GetComponent<SphereCollider>().radius = 0.01f;
            //����������ײ���Ĵ�С ʹ��ײ����ģ�ʹ�С����ƥ��
        }  
    }
}
