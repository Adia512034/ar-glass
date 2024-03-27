using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User_moving : MonoBehaviour
{
    public float movementSpeed = 500.0f;
    public float mouseSensitivity = 2000.0f;
    private float xRotation = 0f;
    private Rigidbody rb;
    public static bool moving_on = false;

    void Start()
    {
        // 獲取Rigidbody組件
        rb = GetComponent<Rigidbody>();
        // 鎖定游標，隱藏游標
        // Cursor.lockState = CursorLockMode.Locked;

        // 鎖定Rigidbody的旋轉軸，防止它在移動時翻滾或傾斜
        // rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionY;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void Update()
    {
        // // 獲取陀螺儀的角速度讀數
        // Vector3 gyroRotationRate = new Vector3(SensorExample.GYROX, SensorExample.GYROY, SensorExample.GYROZ);

        // // 計算這一幀的旋轉量。Time.deltaTime 是上一幀完成的時間
        // Vector3 gyroRotationAmount = gyroRotationRate * Time.deltaTime * Mathf.Rad2Deg; // 將弧度轉換為角度

        // // 旋轉攝影機
        // transform.Rotate(gyroRotationAmount, Space.World);
        ////////////////////////////////////////////////////////////////////////////////////////
        // if (moving_on)
        // {
        //     Vector3 gyroRotationRate = new Vector3(SensorExample.GYROX, SensorExample.GYROY, SensorExample.GYROZ);
        //     // 增加一个缩放系数，例如 10.0f，您可以根据需要调整这个值
        //     float scale = 100.0f;
        //     Quaternion targetRotation = Quaternion.Euler(gyroRotationRate * scale * Time.deltaTime * Mathf.Rad2Deg);
        //     transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5); // 使用Slerp平滑旋


        //     float speed = 100.0f;
        //     // 將加速度轉換為移動向量，這裡乘以Time.deltaTime是為了使移動速度獨立於幀率
        //     Vector3 move = new Vector3(SensorExample.accx , 0, SensorExample.accy) * speed * Time.deltaTime;

        //     // 更新Camera的位置
        //     transform.Translate(move, Space.World);
        // }
        ////////////////////////////////////////////////////////////////////////////////////////
        // 處理攝像機的旋轉
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            // 旋轉攝像機而不是Rigidbody，以免影響物理計算
            transform.localRotation = Quaternion.Euler(xRotation, transform.localEulerAngles.y + mouseX, 0f);
            transform.localRotation = Quaternion.Euler(Mathf.Clamp(-SensorExample.GYROY, -90f, 90f), transform.localEulerAngles.y + SensorExample.GYROX, 0f);
        }

    }


    void FixedUpdate()
    {
        // 處理攝像機的移動
        float xInput = Input.GetAxis("Horizontal") * movementSpeed;
        float zInput = Input.GetAxis("Vertical") * movementSpeed;

        // 計算基於攝像機方向的移動向量
        Vector3 move = transform.right * xInput + transform.forward * zInput;
        // 使用Rigidbody.MovePosition進行移動
        rb.MovePosition(rb.position + move * Time.fixedDeltaTime);
    }
}
