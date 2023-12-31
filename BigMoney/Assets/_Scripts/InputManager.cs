using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public PlayerInput.OnFootActions onFoot;

    [SerializeField]
    private GameObject weapon;
    private PlayerInput playerInput;
    private PlayerMotor motor;
    private PlayerLook look;
    private WeaponManager shooting;


    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        shooting = weapon.GetComponent<WeaponManager>();
        
        onFoot.Jump.performed += ctx => motor.Jump();
        onFoot.Crouch.performed += ctx => motor.Crouch();
        onFoot.Dash.performed += ctx => motor.Dash();
        onFoot.Fire1.started += ctx => shooting.StartShot();
        onFoot.Fire1.canceled += ctx => shooting.EndShot();
        onFoot.Reload.performed += ctx => shooting.Reload();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Tell the player motor to move using the value from our movement action
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}
