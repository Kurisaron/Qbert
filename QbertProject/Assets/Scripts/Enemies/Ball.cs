using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : NormalMover, ICollisionInteractable
{
    private bool isRed;

    protected override void Awake()
    {
        base.Awake();

        isPlayer = false;
        fallOff = Ball_FallOff;
        fallOffEnd = new Action(() => Debug.Log("A ball has fallen off"));
        cubeLanding = Ball_CubeLanding;
        warpPlatformLanding = Ball_WarpPlatformLanding;
        canMove = true;

        StartCoroutine(RegularMoveRoutine());
    }

    public void SetBallColor(bool isRed)
    {
        this.isRed = isRed;

        transform.Find("Body").gameObject.GetComponent<Renderer>().material.color = isRed ? Color.red : Color.green;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent != null && other.transform.parent.gameObject.name.Contains("Qbert"))
        {
            if (isRed) RedPlayerCollisionEvent();
            else GreenPlayerCollisionEvent();
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

    private void Ball_FallOff(MovementDirection movementDirection)
    {
        StartCoroutine(FallOffRoutine(movementDirection));
    }

    private void Ball_CubeLanding(Cube cube)
    {
        
    }

    private void Ball_WarpPlatformLanding(WarpPlatform warpPlatform)
    {
        warpPlatform.ErrorLanding();
    }

    private void RedPlayerCollisionEvent()
    {
        GameManager.Instance.KillPlayer();
    }

    private void GreenPlayerCollisionEvent()
    {
        GameManager.Instance.FreezeAllEnemies();
        Destroy(gameObject);
    }
}
