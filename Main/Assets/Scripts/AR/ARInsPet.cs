using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARInsPet : MonoBehaviour
{
    public Transform[] traPos;
    //存储预制体生成的位置

    private GameObject[] pets;
    //存储宝可梦预制体

    public Transform CameraTra;
    //存储AR摄像机的位置

    // Start is called before the first frame update
    void Start()
    {
        pets = Resources.LoadAll<GameObject>("Pets");
        //加载宝可梦预制体
        InsPet();
        //生成要捕捉的宝可梦
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //生成宝可梦
    public void InsPet()
    {
        int _index = Random.Range(0, traPos.Length);
        //从预制位置中随机选择一个位置

        Transform _tra = traPos[_index];
        //得到随机位置

        GameObject _pet = Instantiate(pets[StaticData.CatchingPetIndex], _tra.position, _tra.rotation);
        //在随机位置生成宝可梦，宝可梦的生成序号为地图场景传递来的正要捕捉的宝可梦的序号

        _pet.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        //把生成的宝可梦的预制体缩小到0.5倍

        _pet.transform.LookAt(new Vector3(CameraTra.position.x,
            _pet.transform.position.y, CameraTra.position.z));
        //让生成的宝可梦面向玩家
    }

    //检查生成宝可梦的预制点到摄像机的距离
    private void checkDis()
    {
        foreach (Transform pos in traPos)
        {
            float _dis = Vector3.Distance(pos.position, CameraTra.position);
            Debug.Log(_dis);
        }
    }

}
