using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreInsPet : MonoBehaviour
{
    public Transform[] Pos;
    //存储宠物栏中宝可梦的生成点

    private GameObject[] Pets;
    //存储所有宝可梦的预制体



    private GameObject[] PetsShow = new GameObject[3];

    void Awake()
    {
        Pets = Resources.LoadAll<GameObject>("Pets");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InsPet()
    {
        int _petNum = StaticData.PetList.Count;
        // 存储已经捕捉到的宝可梦的数量
        
        if(_petNum > 0)
        {
            // 判断是否还有宝可梦没有放入宠物栏
            // 3为宠物栏的数量，可以后期进行更改
            for (int i = 0; i < 3; i++)
            {
                if((_petNum - 1) < i)
                {
                    return;
                }
                PetSave _petInfo = StaticData.PetList[i];
                // 从全局变量中获取对应序号的宝可梦属性列

                Instantiate(Pets[_petInfo.PetIndex], Pos[i].position, Pos[i].rotation);
                // 通过宝可梦预制体中的预制体序号来生成对应宝可梦的预制体
                // 生成位置为宠物栏对应位置

                string _petNm = _petInfo.PetName;
                // 获取宝可梦的名称

                StoreUIMgr.Instance.UpdatePetNm(i, _petNm);
                // 刷新宝可梦名称

                string _pettype = StaticData.GetType(_petInfo.PetIndex);
                //获取宝可梦的种类
                StoreUIMgr.Instance.UpdatePetType(i, _pettype);
                // 刷新宝可梦种类
            }
        }

    }
}
