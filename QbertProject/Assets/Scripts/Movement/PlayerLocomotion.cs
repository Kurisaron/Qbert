using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : NormalMover, ICollisionInteractable
{
    // FUNCTIONS
    protected override void Awake()
    {
        base.Awake();

        isPlayer = true;
        fallOff = Player_FallOff;
        cubeLanding = Player_CubeLanding;
        warpPlatformLanding = Player_WarpPlatformLanding;
        canMove = true;
    }


    public void OnTriggerEnter(Collider other)
    {
        
    }

    private void Player_FallOff()
    {
        Debug.Log("You cannot go that way! You don't want to fall off");
    }

    private void Player_CubeLanding(Cube currentCube)
    {
        GameManager.Instance.AddScore(25);
        currentCube.QbertLanding();
    }

    private void Player_WarpPlatformLanding(WarpPlatform warpPlatform)
    {
        warpPlatform.QbertLanding();
    }
}
