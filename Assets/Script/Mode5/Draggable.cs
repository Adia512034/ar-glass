using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Camera mainCamera;
    private bool isDragging = false;
    private Vector3 offset;

    void Awake()
    {
        mainCamera = Camera.main; // 获取主摄像机
    }

    void OnMouseDown()
    {
        Debug.Log("OnMouseDown " + isDragging);
        isDragging = true;
        // 计算物体的偏移量 = 物体世界坐标 - 鼠标点击位置的世界坐标
        offset = transform.position - GetMouseWorldPos();
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void Update()
    {
        // Debug.Log("isDragging" + isDragging);
        if (isDragging)
        {
            // 更新物体位置到新的鼠标世界坐标位置，加上初始偏移量
            transform.position = GetMouseWorldPos() + offset;
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Debug.Log("get item");
        // 获取鼠标在屏幕上的位置
        Vector3 mousePoint = Input.mousePosition;

        // 获取鼠标在世界的位置，假设物体在地面上，即y坐标为0
        mousePoint.z = Mathf.Abs(mainCamera.transform.position.y - transform.position.y);
        return mainCamera.ScreenToWorldPoint(mousePoint);
    }
}
