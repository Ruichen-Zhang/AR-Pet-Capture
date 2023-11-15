using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticData 
{
    public static int BallNum = 5;
    //静态定义宝可梦精灵球的数量

    public static int CatchingPetIndex;
    //正在捕捉的宝可梦在预制体中的序号

    public static List<PetSave> PetList = new List<PetSave>();
    //申请列表存储捕捉到的宝可梦

    /// <summary>
	/// 添加宝可梦
	/// </summary>
	/// <param name="petSave">宝可梦的属性类</param>
    public static void AddPet(PetSave petSave)
    {
        PetList.Add(petSave);
    }

    //获取宝可梦的种类
    public static string GetType(int index)
    {
        if(index == 0)
        {
            return "熊";
        }
        else if(index == 1)
        {
            return "牛";
        }
        else if (index == 2)
        {
            return "兔子";
        }
        else if (index == 3)
        {
            return "鸡";
        }
        else if (index == 4)
        {
            return "蛋";
        }
        else if (index == 5)
        {
            return "老虎";
        }
        else if (index == 6)
        {
            return "猴子";
        }
        else if (index == 7)
        {
            return "猫";
        }
        else if (index == 8)
        {
            return "狮子";
        }
        else if (index == 9)
        {
            return "企鹅";
        }
        else if (index == 10)
        {
            return "企鹅";
        }
        else if (index == 11)
        {
            return "北极熊";
        }
        else if (index == 12)
        {
            return "狗";
        }
        else if (index == 13)
        {
            return "犀牛";
        }
        else
        {
            return "雪人";
        }
    }
}
