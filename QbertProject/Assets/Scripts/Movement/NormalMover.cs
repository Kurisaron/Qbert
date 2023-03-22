using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMover : Mover
{
    protected override void Awake()
    {
        gravityDirection = Vector3.down;
        forwardDirection = Vector3.left;
        backDirection = Vector3.right;
        leftDirection = Vector3.back;
        rightDirection = Vector3.forward;

    }
}
