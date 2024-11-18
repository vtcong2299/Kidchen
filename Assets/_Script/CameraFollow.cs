using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float Yaxis;
    public float Xaxis;
    public float rotateSencitivity = 3f;
    public Transform target;
    public float rotateMax = 50;
    public float rotateMin = -10;
    public float smoothTime = 0.12f;
    public Vector3 targetRotation;
    public Vector3 currentVel;
    private void Update()
    {
        CameraMove();
    }

    public void CameraMove()
    {
        //InputScrollByTouch();
        InputScrollByMouse();
        Xaxis = Mathf.Clamp(Xaxis, rotateMin, rotateMax);

        targetRotation = Vector3.SmoothDamp(targetRotation, new Vector3(Xaxis, Yaxis), ref currentVel , smoothTime  ); 
        transform.eulerAngles = targetRotation;
        //transform.position = target.position - transform.forward * 1.5f + transform.up *0.5f;
    }
    public void InputScrollByTouch()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                if (touch.position.x > Screen.width / 3)
                {
                    Yaxis += touch.deltaPosition.x * rotateSencitivity/30;
                    Xaxis -= touch.deltaPosition.y * rotateSencitivity/30;
                }
            }
        }
    }
    public void InputScrollByMouse()
    {
        if (Input.mousePosition.x > Screen.width / 3)
        {
            Yaxis += Input.GetAxis("Mouse X") * rotateSencitivity;
            Xaxis -= Input.GetAxis("Mouse Y") * rotateSencitivity;
        }
    }
}
