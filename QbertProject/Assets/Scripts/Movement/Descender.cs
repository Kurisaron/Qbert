using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Descender : MonoBehaviour
{
    // VARIABLES
    protected Vector3 gravityDirection;
    protected bool canMove;
    protected Vector3 leftDescendDirection, rightDescendDirection;

    protected Action<RaycastHit> doDescendAction;
    protected Action<Side> dontDescendAction;

    // FUNCTIONS
    public virtual void Awake()
    {
        canMove = true;
    }

    public void Descend(Side side)
    {
        Vector3 rayOrigin = gameObject.transform.position + (side == Side.Left ? leftDescendDirection : rightDescendDirection);

        if (Physics.Raycast(rayOrigin, gravityDirection, out RaycastHit hit))
        {
            // TO-DO: Move
            Debug.Log("Descend!");
            doDescendAction(hit);
        }
        else
        {
            Debug.Log("Cannot descend!");
            dontDescendAction(side);
        }
    }
}
