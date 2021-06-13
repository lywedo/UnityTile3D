using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 摄像机控制器
/// </summary>
public class CameraControler : MonoBehaviour
{
    // 限制摄像机角度范围
    private const float Y_ANGLE_MIN = 10f;
    private const float Y_ANGLE_MAX = 50.0f;

    // 摄像机看向的物体
    public Transform lookAt;
    // 摄像机Transform
    public Transform camTransform;
    // 摄像机距离目标物体的距离
    public float distance = 1.2f;
    // 原始距离
    private float originalDistance;
    // 旋转速度
    public float rotateSpeed = 0.01f;

    private float currentX = 0.0f;
    private float currentY = 20.0f;


    private bool rotating;
    private Vector2 rotateDelta;

    private void Start()
    {
        camTransform = transform;
        originalDistance = distance;

    }

    private void Update()
    {
        if (rotating)
        {
            currentX += rotateDelta.x;
            currentY += rotateDelta.y;
            currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        }
    }

    public void RotateCam(Vector2 delta)
    {
        rotateDelta = delta * rotateSpeed;
        rotating = true;
    }

    public void StopRotate()
    {
        rotating = false;
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }

}
