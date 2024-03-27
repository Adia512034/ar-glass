using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureClickManager : MonoBehaviour
{
    public Camera renderCamera; // 用于Render Texture的摄像机
    public RectTransform renderTextureUI; // Render Texture在UI上的RectTransform
    public LayerMask draggableLayer; // 你想要拖拽的物体所在的层
    private bool isDragging = false;
    private GameObject selectedObject; // 当前选中的可拖拽物体
    private Vector3 offset;
    private float originalY;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TrySelectObject(Input.mousePosition);
        }

        if (isDragging)
        {
            DragObject(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;
            selectedObject = null;
        }
    }

    private void TrySelectObject(Vector2 screenPosition)
{
    // 确定Canvas的渲染模式并获取正确的Camera引用
    Camera canvasCamera = renderTextureUI.GetComponentInParent<Canvas>().worldCamera;

    if (RectTransformUtility.ScreenPointToLocalPointInRectangle(renderTextureUI, screenPosition, canvasCamera, out Vector2 localPoint))
    {
        // 确保localPoint在Render Texture的范围内
        if (localPoint.x < -renderTextureUI.rect.width * 0.5f || localPoint.x > renderTextureUI.rect.width * 0.5f || localPoint.y < -renderTextureUI.rect.height * 0.5f || localPoint.y > renderTextureUI.rect.height * 0.5f)
            return;

        Vector2 renderTextureSize = renderTextureUI.sizeDelta;
        Vector2 normalizedPoint = new Vector2(
            (localPoint.x / renderTextureSize.x) + 0.5f,
            (localPoint.y / renderTextureSize.y) + 0.5f);

        Ray ray = renderCamera.ViewportPointToRay(normalizedPoint);
        RaycastHit hit;
        Debug.DrawLine(ray.origin, ray.origin + ray.direction * 1000, Color.yellow);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, draggableLayer))
        {
            Debug.Log("hit " + hit.collider.name);
            isDragging = true;
            selectedObject = hit.collider.gameObject;
            offset = selectedObject.transform.position - hit.point;
            originalY = hit.collider.gameObject.transform.position.y;
        }
    }
}


    private void DragObject(Vector2 screenPosition)
    {
        Camera canvasCamera = renderTextureUI.GetComponentInParent<Canvas>().worldCamera;
        // Debug.Log("in  DragObject");
        // Debug.Log("renderCamera " + renderCamera) ;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(renderTextureUI, screenPosition, canvasCamera, out Vector2 localPoint))
        {
            // Debug.Log("in  DragObject2");
            Vector2 renderTextureSize = renderTextureUI.sizeDelta;
            Vector2 normalizedPoint = new Vector2((localPoint.x / renderTextureSize.x) + 0.5f, (localPoint.y / renderTextureSize.y) + 0.5f);

            Ray ray = renderCamera.ViewportPointToRay(normalizedPoint);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, draggableLayer))
            {
                Vector3 newPosition = hit.point + offset;
                newPosition.y = originalY;
                selectedObject.transform.position = newPosition;
            }
        }
    }
}