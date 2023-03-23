using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UggWrongway : Mover, ICollisionInteractable
{
    private bool isUgg;

    protected override void Awake()
    {
        
        isPlayer = false;
        fallOff = UggWrongway_FallOff;
        fallOffEnd = new Action(() => Debug.Log("Ugg or Wrongway has fallen off"));
        cubeLanding = UggWrongway_CubeLanding;
        warpPlatformLanding = UggWrongway_WarpPlatformLanding;
        canMove = true;

        StartCoroutine(RegularMoveRoutine());
    }

    private void Update()
    {
        if (canMove) GetComponent<Rigidbody>().AddForce(gravityDirection);
    }

    public void SetupDirections(bool isUgg)
    {
        this.isUgg = isUgg;
        gravityDirection = isUgg ? Vector3.left : Vector3.back;
        forwardDirection = Vector3.up;
        backDirection = Vector3.down;
        leftDirection = isUgg ? Vector3.back : Vector3.right;
        rightDirection = isUgg ? Vector3.forward : Vector3.left;
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent != null && other.transform.parent.gameObject.name.Contains("Qbert"))
        {
            
        }
    }

    private IEnumerator RegularMoveRoutine()
    {
        yield return new WaitForSeconds(1.5f);

        Tuple<MovementDirection, MovementDirection> leftRightMoveDirections;

        while (true)
        {
            Side moveDirection = (Side)UnityEngine.Random.Range(0, 2);
            Move(moveDirection == Side.Left ? (isUgg ? MovementDirection.Forward : MovementDirection.Left) : (MovementDirection.Right));
            yield return new WaitUntil(() => canMove);
            yield return new WaitForSeconds(1.0f);
        }
    }

    private void UggWrongway_FallOff(MovementDirection movementDirection)
    {
        StartCoroutine(FallOffRoutine(movementDirection));
    }

    private void UggWrongway_CubeLanding(Cube cube)
    {
        
    }

    private void UggWrongway_WarpPlatformLanding(WarpPlatform warpPlatform)
    {
        warpPlatform.ErrorLanding();
    }

}
