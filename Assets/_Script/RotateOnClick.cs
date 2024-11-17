using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RotateOnClick : MonoBehaviour
{
    public float rotationSpeed = 1.0f;
    private bool isRotated = false; // Biến lưu trữ trạng thái xoay
    private Quaternion originalRotation; // Lưu trữ góc quay ban đầu
    private Quaternion rotatedRotation; // Lưu trữ góc quay sau khi xoay
    private bool isRotating = false; // Biến lưu trữ trạng thái đang xoay
    public float angle = 90;

    void Awake()
    {
        originalRotation = transform.rotation;
        rotatedRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, angle, 0));
    }
    void OnMouseDown()
    {
        if (!isRotating)
        {
            StartCoroutine(RotateObject());
        }
    }
    IEnumerator RotateObject()
    {
        isRotating = true;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = isRotated ? originalRotation : rotatedRotation;
        float elapsedTime = 0f;

        while (elapsedTime < 1f / rotationSpeed)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime * rotationSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = endRotation;
        isRotated = !isRotated;
        isRotating = false;
    }
}







