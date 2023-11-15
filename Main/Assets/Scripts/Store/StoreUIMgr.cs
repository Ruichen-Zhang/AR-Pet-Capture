using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoreUIMgr : MonoBehaviour
{
    public Text[] Tx_PetNm;
    public Text[] Tx_PetType;
    //存储显示宝可梦信息的Text组件
    public static StoreUIMgr Instance;

    void Awake()
    {
        Instance = this;
    }

    //刷新仓库显示中的宝可梦的名称
    public void UpdatePetNm(int index, string strNm)
    {
        Tx_PetNm[index].text = strNm;

    }

    // 跳转到地图场景的按钮
     public void Btn_ToMap()
    {
        Store_Au.Instance.BtnAudioPlay();
        SceneManager.LoadScene("Map_Scn");
    }

    //刷新仓库显示中的宝可梦的种类
    public void UpdatePetType(int index, string strType)
    {
        Tx_PetType[index].text = strType;
    }
}
