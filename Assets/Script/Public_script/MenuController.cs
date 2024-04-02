using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuController : MonoBehaviour
{
    public GameObject menuPanel; // 設置一個公共變量來參考你的選單Panel
    public GameObject subMenu1; // 設置一個公共變量來參考你的子選單1
    public GameObject subMenu2; // 設置一個公共變量來參考你的子選單2
    public GameObject SwishMode1; // 設置一個公共變量來參考你的SwishMode1
    public GameObject SwishMode2; // 設置一個公共變量來參考你的SwishMode2
    public GameObject SwishMode3; // 設置一個公共變量來參考你的SwishMode3
    public GameObject SwishMode4; // 設置一個公共變量來參考你的SwishMode4
    public GameObject SwishMode5; // 設置一個公共變量來參考你的SwishMode5
    public GameObject SwishMode6; // 設置一個公共變量來參考你的SwishMode6
    private bool isShowing= false; // 設置一個私有變量來檢查選單是否正在顯示
    private int SwitchMode = 0;
    public void MenuControll()
    {
        if (isShowing)
        {
            // 如果選單正在顯示，則隱藏它
            if (menuPanel != null)
            {
                menuPanel.SetActive(false); // 使選單Panel可見
            }
        }
        else
        {
            // 如果選單沒有顯示，則顯示它
            if (menuPanel != null)
            {
                menuPanel.SetActive(true); // 使選單Panel隱藏
            }
        }
        isShowing = !isShowing; // 切換選單顯示狀態
    }
    //2個子選單的控制
    public void SubMenu1Controll()
    {
        if (subMenu1 != null)
        {
            subMenu1.SetActive(true); // 使子選單1可見
            subMenu2.SetActive(false); // 使子選單2隱藏
        }
    }
    public void SubMenu2Controll()
    {
        if (subMenu2 != null)
        {
            subMenu2.SetActive(true); // 使子選單2可見
            subMenu1.SetActive(false); // 使子選單1隱藏
        }
    }
    // 子選單內的按鈕點擊後要做的事情
    public void SubMenuButton(string num)
    {
        switch (num)
        {
            case "1":
                SwitchMode = 1;
                break;
            case "2":
                SwitchMode = 2;
                break;
            case "3":
                SwitchMode = 3;
                break;
            case "4":
                SwitchMode = 4;
                SwishMode4.SetActive(true);
                break;
            case "5":
                SwitchMode = 5;
                SwishMode5.SetActive(true);
                break;
            case "6":
                SwitchMode = 6;
                SwishMode6.SetActive(true);
                break;
            default:
                SwitchMode = 0;
                break;
        }
        MenuControll(); // 隱藏選單
    }

}
