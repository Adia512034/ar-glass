using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetRange : MonoBehaviour
{
    public Text RangetextX;
    public Text RangetextY;
    public Text RangetextZ;
    private string Xrange;
    public static float RangeX;
    public static float RangeY;
    public static float RangeZ;
    // 取得鏡頭位置
    public Transform cameraTransform;
    // 取得door位置
    public Transform doorTransform;
    // Start is called before the first frame update
    void Start()
    {
        RangetextX.text = "X：";
        RangetextY.text = "Y：";
        RangetextZ.text = "Z：";   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //設定X參數
    public void GetrangeX()
    {
        RangeX = 200;
        //轉成float型別
        // RangeX = float.Parse(TofExample.valueRange2)/10;
        RangetextX.text = "X：" + $"{RangeX}" + "cm";
    }

    //設定Y參數
    public void GetrangeY()
    {
        RangeY = 300;
        //轉成float型別
        // RangeY = float.Parse(TofExample.valueRange2)/10;
        RangetextY.text = "Y：" + $"{RangeY}" + "cm";
    }

    //設定Z參數
    public void GetrangeZ()
    {
        RangeZ = 200;
        //轉成float型別
        // RangeZ = float.Parse(TofExample.valueRange2)/10;
        RangetextZ.text = "Z：" + $"{RangeZ}" + "cm";
    }


    public GameObject obj;
    public RawImage ShowrawImage;
    //點擊按鈕縮放物件scale

    public void Change3DScale()
    {
        if(RangeX == 0)
        {
            RangetextX.text = "請輸入此數值";
        }
        if(RangeY == 0)
        {
            RangetextY.text = "請輸入此數值";
        }
        if(RangeZ == 0)
        {
            RangetextZ.text = "請輸入此數值";
        }
        if(RangeX == 0 || RangeY == 0 || RangeZ == 0)
        {
            return;
        }
        

        ShowrawImage.gameObject.SetActive(true);
        User_moving.moving_on = true;

        float RangetextTempX = (RangeX)/200.0f;
        float RangetextTempY = (RangeY)/300.0f;
        float RangetextTempZ = (RangeZ)/200.0f;
        Debug.Log("RangetextTempX :" + RangetextTempX);
        Debug.Log("RangetextTempY :" + RangetextTempY);
        Debug.Log("RangetextTempZ :" + RangetextTempZ);
        obj.transform.localScale = new Vector3(9.2f * RangetextTempX, 9.2f * RangetextTempY, 9.2f * RangetextTempZ);

        // Debug.Log("doorTransform.transform.position :" + doorTransform.transform.position);
        cameraTransform.position = doorTransform.transform.position + new Vector3(100*RangetextTempX, 100, 100*RangetextTempZ);
        // Debug.Log("doorTransform.transform.position :" + doorTransform.transform.position);
        // cameraTransform.LookAt(doorTransform);
        cameraTransform.Rotate(0, -90, 0);
    }
}
