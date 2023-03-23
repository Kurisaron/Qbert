using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlickSam : NormalMover, ICollisionInteractable
{
    
    protected override void Awake()
    {
        base.Awake();

        isPlayer = false;
        fallOff = SlickSam_FallOff;
        cubeLanding = SlickSam_CubeLanding;
        warpPlatformLanding = SlickSam_WarpPlatformLanding;
        canMove = true;

        StartCoroutine(RegularMoveRoutine());
    }

    public void OnTriggerEnter(Collider other)
    {

    }

    private IEnumerator RegularMoveRoutine()
    {
        while(true)
        {
            Side moveDirection = (Side)Random.Range(0, 2);
            Move(moveDirection == Side.Left ? MovementDirection.Backward : MovementDirection.Right);
            yield return new WaitUntil(() => canMove);
        }
    }

    private void SlickSam_FallOff(MovementDirection movementDirection)
    {
        StartCoroutine(FallOffRoutine(movementDirection));
    }

    private void SlickSam_CubeLanding(Cube cube)
    {
        cube.SlickSamLanding();
    }

    private void SlickSam_WarpPlatformLanding(WarpPlatform warpPlatform)
    {
        warpPlatform.ErrorLanding();
    }
}
