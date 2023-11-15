using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ARUI_Mgr : MonoBehaviour
{
    public static ARUI_Mgr Instance;

    public Text Tx_BallNum;
    //������ʾ������������Text���

    public GameObject PnCatched;
    //存储捕捉成功面板信息

    public Text InputPetName;
    //宝可梦起名字的Text组件

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //��ת����ͼ�����İ�ť
    public void Btn_GoMapScn()
    {
        AR_Au.Instance.BtnAudioPlay();
        SceneManager.LoadScene("Map_Scn");
    }

    //ˢ�¾�����UI�����ĺ���
    public void UpdateUIBallNum()
    {
        Tx_BallNum.text = StaticData.BallNum.ToString();
        //�Ѿ�����������ȫ��������ʾ��UI��
    }

    //显示小精灵捕捉成功的面板
    public void Show_PnCatched()
    {
        PnCatched.SetActive(true);
    }

    //捕捉小精灵确认保存按钮的函数
    public void Btn_OK()
    {
        AR_Au.Instance.BtnAudioPlay();
        string _name = InputPetName.text;
        int _index = StaticData.CatchingPetIndex;

        StaticData.AddPet(new PetSave(_name, _index));
        SceneManager.LoadScene("Store_Scn");
    }

    // 放生按钮返回地图
    public void Btn_GiveUp()
    {
        AR_Au.Instance.BtnAudioPlay();
        SceneManager.LoadScene("Map_Scn");
    }

    //跳转仓库场景的按钮函数
    public void Btn_ToStore()
    {
        AR_Au.Instance.BtnAudioPlay();
        SceneManager.LoadScene("Store_Scn");
    }
}
