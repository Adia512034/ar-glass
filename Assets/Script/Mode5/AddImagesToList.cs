using UnityEngine;
using UnityEngine.UI;

public class AddImagesToList : MonoBehaviour
{
    public GameObject Item_list;

    public void control_item_list()
    {
        if (Item_list.activeInHierarchy)
        {
            Item_list.SetActive(false);
        }
        else
        {
            Item_list.SetActive(true);
        }
    }

    
    public GameObject objectPrefab; // 在Inspector中设置想要移动的物体
    public Camera mainCamera;       // 也可以在Start()中使用Camera.main赋值
    public float distanceFromCamera = 10.0f; // 物体离相机的距离

    public void add_item_to_scense()
    {
            Vector3 creationPoint = mainCamera.transform.position + mainCamera.transform.forward * distanceFromCamera; // 
            creationPoint.y = creationPoint.y - 100;
            Instantiate(objectPrefab, creationPoint, Quaternion.identity);

    }
}
