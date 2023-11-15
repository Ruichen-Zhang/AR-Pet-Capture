using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARShootBall : MonoBehaviour
{
    public float FwdForce = 500f;
    //���ø�С����ǰ�����Ĵ�С
    public Vector3 StanTra = new Vector3(0, 1f, 0);
    //����һ���нǵĲ�����ֵ

    private bool blTouched = false;
    //�ж���ָ�Ƿ��������˾������λ��
    private bool blShooted = false;
    //�жϾ������Ƿ���
    private Vector3 startPosition;
    //��ָ��������ʼ��
    private Vector3 endPosition;
    //��ָ�������յ�
    private float disFick;
    //��¼��ָ�����ľ���
    private Vector3 offset;
    //��¼��ָ������ƫ������
    private int timeFlick;
    //��֡������¼��ָ������ʱ��
    private float speedFlick;
    //��¼�������ٶ�
    private Camera camera;
    //��¼�������

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        //��ֵΪ�������
    }

    // Update is called once per frame
    void Update()
    {
        if(blTouched)//�������С���� ���������ָ����
        {
            slip();

        }
    }

    //���ò���
    private void resetVari()
    {
        startPosition = Input.mousePosition;
        //��ʼλ������Ϊ��ָ���µ�λ��
        endPosition = Input.mousePosition;
        //��ֹλ������Ϊ��ָ���µ�λ��
    }

    //��꣨��ָ�����£��Ƿ������ű��������壩
    void OnMouseDown()
    {
        if(blShooted == false)//��������δ����
        {
            blTouched = true; //��������ָ����
        }
    }

    //������ָ�Ļ���
    private void slip()
    {
        timeFlick += 25;    //ʱ��ÿ֡����25

        if(Input.GetMouseButtonDown(0)) //����ָ���µ�ʱ��
        {
            resetVari();//���ò���
        }
        if(Input.GetMouseButton(0)) //����ָһֱ������Ļ�ϵ�ʱ��
        {
            endPosition = Input.mousePosition;
            //����ָ���յ�λ�ñ��� ��ֵˢ��Ϊ��ǰ��ָ������λ��
            offset = camera.transform.rotation * (endPosition - startPosition);
            //��ȡ��ָ�����������ϵ�ƫ������
            disFick = Vector3.Distance(startPosition, endPosition);
            //������ָ�����ľ���
        }
        if(Input.GetMouseButtonUp(0))
        {
            speedFlick = disFick / timeFlick;
            //���㻬�����ٶ�
            blTouched = false;
            //��ָ�Ƿ����������� ����Ϊ��
            timeFlick = 0;
            //ʱ���¼���� 
            if(disFick > 20 && endPosition.y - startPosition.y > 0) //�����ָ�ƶ��������20 �������ϻ���
            {
                shootBall();
                //���侫����
            }
        }
    }

    //���侫����
    private void shootBall()
    {
        transform.gameObject.AddComponent<Rigidbody>();
        //����������Ӹ������
        Rigidbody _rigBall = transform.GetComponent<Rigidbody>();
        //�þֲ�������ȡ�������
        _rigBall.velocity = offset.normalized * speedFlick;
        //��������һ����ʼ�ٶ� ����ٶȵ��ڷ��򣨵�λ�����������ٶ�
        _rigBall.AddForce(camera.transform.forward * FwdForce);
        //��������һ��������Ļǰ������
        _rigBall.AddTorque(transform.right);
        //�þ�������ת����
        _rigBall.drag = 0.5f;
        //���þ����������
        blShooted = true;
        //����������Ѿ������ȥ��
        transform.parent = null;
        //����������ȥ�ľ��������븸������

        StaticData.BallNum--;
        //�������پ����������
        ARUI_Mgr.Instance.UpdateUIBallNum();
        //���¾�����������UI�е���ʾ

        StartCoroutine(LateInsBall());
        //�����ӳٺ���
    }

    //�ӳ����ɾ�����ĺ���
    IEnumerator LateInsBall()
    {
        yield return new WaitForSeconds(0.2f);
        //�ӳ�0.2������ִ��
        ARBallCtrl.Instance.InsNewBall();
    }
}
