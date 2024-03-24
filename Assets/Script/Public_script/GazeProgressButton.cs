using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GazeProgressButton : MonoBehaviour
{
    public float gazeTime = 2f; // 注視觸發時間
    public Image gazeProgressBar; // 注視進度條的UI Image

    private float gazeTimer;
    private Vector2 currentGazePosition;
    private GameObject currentGazeObject;

    private void Update()
    {
        UpdateGaze();
        CheckGazeButton();
    }

    // 模擬眼動儀的注視點，實際應用中需要替換為眼動儀數據
    private void UpdateGaze()
    {
        // currentGazePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y); // 用鼠標位置模擬
        currentGazePosition = Ganzin2DScreenPosCtrl.CurrentGazePosition; // 用眼動儀數據模擬
        Debug.Log("currentGazePosition :" + currentGazePosition);
    }

    private void CheckGazeButton()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = currentGazePosition
        };

        RaycastResult result = RaycastUI(pointerData);
        // Debug.Log("result.gameObject:"+result.gameObject+"。result.gameObject.tag:"+ result.gameObject.tag+"。result.gameObject.name:"+ result.gameObject.name);
        if (result.gameObject != null && result.gameObject.tag == "GazeButton")
        {
            if (currentGazeObject != result.gameObject)
            {
                gazeTimer = 0f;
                currentGazeObject = result.gameObject;
                gazeProgressBar.fillAmount = 0f;
            }

            gazeTimer += Time.deltaTime;
            gazeProgressBar.fillAmount = gazeTimer / gazeTime;

            if (gazeTimer >= gazeTime)
            {
                gazeTimer = 0f;
                gazeProgressBar.fillAmount = 0f;
                currentGazeObject.GetComponent<Button>().onClick.Invoke();
                currentGazeObject = null;
            }
        }
        else
        {
            gazeTimer = 0f;
            currentGazeObject = null;
            gazeProgressBar.fillAmount = 0f;
        }
    }

    private RaycastResult RaycastUI(PointerEventData pointerData)
    {
        var results = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);
        return results.Count > 0 ? results[0] : new RaycastResult();
    }
}
