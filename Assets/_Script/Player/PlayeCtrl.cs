using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayeCtrl : MonoBehaviour
{
    public Rigidbody rb;
    public float pressVertical;
    public float pressHorizontal;
    public float speedPlayer = 5f;
    public float speedPlayerRotate = 5f;
    public Vector3 moveDirection;
    public GameObject playerCamera;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        PlayerMove();
    }
    private void Update()
    {
        PcMoveInput();
        //JoystickMoveInput();
    }
    public void PcMoveInput()
    {
        this.pressVertical = Input.GetAxis("Vertical");
        this.pressHorizontal = Input.GetAxis("Horizontal");
    }
    public void JoystickMoveInput()
    {
        this.pressVertical = Joystick.instance.Vertical();
        this.pressHorizontal = Joystick.instance.Horizontal();
    }

    public void PlayerMove()
    {
        Vector3 movement1 = playerCamera.transform.forward * pressVertical;
        Vector3 movement2 = playerCamera.transform.right * pressHorizontal;
        moveDirection = movement1 + movement2;
        moveDirection.y = 0;
        rb.MovePosition(rb.position + this.speedPlayer * moveDirection * Time.deltaTime);
        if (moveDirection != Vector3.zero)
        {
            PlayerAnimation.instance.SetIsRunTrue();
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speedPlayerRotate);
        }
        else
        {
            PlayerAnimation.instance.SetIsRunFalse();
        }
    }    
}
