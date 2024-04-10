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

            // 检查物体是否超出屏幕范围
            Vector3 screenPosition = mainCamera.WorldToViewportPoint(transform.position);
            Debug.Log("screenPosition: " + screenPosition);
            if (screenPosition.x < 0 || screenPosition.x > 1 || screenPosition.y < 0 || screenPosition.y > 1)
            {
                Debug.Log("物体超出屏幕范围，即将销毁");
                Destroy(gameObject); // 销毁物体
            }
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
