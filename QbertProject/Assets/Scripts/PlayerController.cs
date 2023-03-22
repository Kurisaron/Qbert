using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Singleton<PlayerController>
{
    // VARIABLES
    [HideInInspector]
    public PlayerLocomotion playerLocomotion;

    // FUNCTIONS
    public override void Awake()
    {
        base.Awake();


    }

    public void MoveForward(InputAction.CallbackContext context)
    {
        if (context.performed && playerLocomotion != null) playerLocomotion.Move(MovementDirection.Forward);
    }

    public void MoveBackward(InputAction.CallbackContext context)
    {
        if (context.performed && playerLocomotion != null) playerLocomotion.Move(MovementDirection.Backward);
    }

    public void MoveLeft(InputAction.CallbackContext context)
    {
        if (context.performed && playerLocomotion != null) playerLocomotion.Move(MovementDirection.Left);
    }

    public void MoveRight(InputAction.CallbackContext context)
    {
        if (context.performed && playerLocomotion != null) playerLocomotion.Move(MovementDirection.Right);
    }

}
