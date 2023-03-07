using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Singleton<PlayerController>
{
    public bool canMove;
    public PlayerLocomotion playerLocomotion;

    public override void Awake()
    {
        base.Awake();
        canMove = true;
    }

    public void AscendLeft(InputAction.CallbackContext context)
    {
        if (context.performed && canMove) Ascend(Side.Left);
    }

    public void AscendRight(InputAction.CallbackContext context)
    {
        if (context.performed && canMove) Ascend(Side.Right);
    }

    public void DescendLeft(InputAction.CallbackContext context)
    {
        if (context.performed && canMove) Descend(Side.Left);
    }

    public void DescendRight(InputAction.CallbackContext context)
    {
        if (context.performed && canMove) Descend(Side.Right);
    }

    private void Ascend(Side side)
    {
        playerLocomotion.Ascend(side);
    }

    private void Descend(Side side)
    {
        playerLocomotion.Descend(side);
    }
}
