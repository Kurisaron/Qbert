using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscherDescender : Descender, IPurpleEnemy
{
    [SerializeField]
    private Side sideWalking;

    // FUNCTIONS
    public override void Awake()
    {
        base.Awake();

        gravityDirection = sideWalking == Side.Left ? Vector3.left : Vector3.back;
        leftDescendDirection = sideWalking == Side.Left ? Vector3.up : Vector3.right;
        rightDescendDirection = sideWalking == Side.Left ? Vector3.forward : Vector3.up;

        dontDescendAction = FallOff;
    }

    public void OnTriggerEnter(Collider other)
    {
        
    }

    private void FallOff(Side side)
    {

    }
}
