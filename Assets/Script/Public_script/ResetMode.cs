using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetMode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // // 重置mode1
    // public void ResetMode1()
    // {
    //     GameObject.Find("SwishMode1").GetComponent<SwishMode1>().ResetMode1();
    // }
    // // 重置mode2
    // public void ResetMode2()
    // {
    //     GameObject.Find("SwishMode2").GetComponent<SwishMode2>().ResetMode2();
    // }
    // // 重置mode3
    // public void ResetMode3()
    // {
    //     GameObject.Find("SwishMode3").GetComponent<SwishMode3>().ResetMode3();
    // }
    // 重置mode4
    public void ResetMode4()
    {
        GameObject.Find("Mode4").SetActive(false);
    }
    // 重置mode5
    public void ResetMode5()
    {
        GameObject Mode5ShowRawImage = GameObject.Find("Mode5ShowRawImage");
        if (Mode5ShowRawImage != null) // 检查是否找到了对象
        {
            Mode5ShowRawImage.SetActive(false);
        }
        GameObject.Find("Mode5").SetActive(false);
        User_moving.moving_on = false;
        GetRange.RangeX = 0;
        GetRange.RangeY = 0;
        GetRange.RangeZ = 0;

        // getcomponent<GetRange>().RangeX = 0;
        // getcomponent<GetRange>().RangeY = 0;
        // getcomponent<GetRange>().RangeZ = 0;
    }
    // 重置mode6
    public void ResetMode6()
    {
        GameObject.Find("Mode6").SetActive(false);
    }

}
