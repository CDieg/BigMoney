using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;

    private bool isGrounded;

    [SerializeField]
    private bool isDashActive;
    [SerializeField]
    private bool isDashReloaded = true;
    private bool crouching;
    private bool lerpCrouch;

    [SerializeField]
    private float speedValue = 5f;
    private float speed;
    [SerializeField]
    private float playerGravity = -30f;
    [SerializeField]
    private float jumpHeight = 3f;
    [SerializeField]
    private float crouchTimer = 0f;
    [SerializeField]
    private float dashTimer = 0.2f;
    [SerializeField]
    private float dashAcceleration = 15f;
    [SerializeField]
    private float dashReloadTime = 2f;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        speed = speedValue;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;

        if (lerpCrouch)
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;
            if (crouching)
                controller.height = Mathf.Lerp(controller.height, 1, p);
            else controller.height = Mathf.Lerp(controller.height, 2, p);

            if (p > 1)
            {
                lerpCrouch = false;
                crouchTimer = 0f;
            }
        }
    }
    // Receive the inputs from the InputManager.cs and apply in character controller
    public void ProcessMove (Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += playerGravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;
        controller.Move(playerVelocity * Time.deltaTime);
        Debug.Log(playerVelocity.y);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * playerGravity);
        }
    }

    public void Crouch()
    {
        crouching = !crouching;
        crouchTimer = 0f;
        lerpCrouch = true;
    }

    public void Dash()
    {
        isDashActive = !isDashActive;
        

        if (isDashActive && isDashReloaded)
        {
            isDashReloaded = false;
            speed = speedValue * dashAcceleration;
            StartCoroutine(DashTimerRoutine());
            StartCoroutine(DashingReload());
        } 
        else
        {
            speed = speedValue;
        }        
    }

    IEnumerator DashTimerRoutine()
    {
        yield return new WaitForSeconds(dashTimer);
        isDashActive = false;
        speed = speedValue;
    }

    IEnumerator DashingReload()
    {
        yield return new WaitForSeconds(dashReloadTime);
        isDashReloaded = true;
    }
}
