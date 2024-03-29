using System;
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
        fallOffEnd = new Action(() => Debug.Log("Slick or Sam has fallen off"));
        cubeLanding = SlickSam_CubeLanding;
        warpPlatformLanding = SlickSam_WarpPlatformLanding;
        canMove = true;

        StartCoroutine(RegularMoveRoutine());
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent != null && other.transform.parent.gameObject.name.Contains("Qbert"))
        {
            KillSelf();
        }
    }

    private IEnumerator RegularMoveRoutine()
    {
        yield return new WaitForSeconds(1.5f);

        while (true)
        {
            Side moveDirection = (Side)UnityEngine.Random.Range(0, 2);
            Move(moveDirection == Side.Left ? MovementDirection.Backward : MovementDirection.Right);
            yield return new WaitUntil(() => canMove);
            yield return new WaitForSeconds(1.0f);
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

    private void KillSelf()
    {
        GameManager.Instance.AddScore(300);
        Destroy(gameObject);
    }
}
