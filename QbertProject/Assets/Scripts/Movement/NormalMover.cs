using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMover : NormalDescender
{
    // FUNCTIONS
    public void Ascend(Side side)
    {
        Vector3 rayDirection = side == Side.Left ? new Vector3(0, 0, -1) : new Vector3(-1, 0, 0);

        if (Physics.Raycast(gameObject.transform.position, rayDirection, out RaycastHit hit))
        {
            // TO-DO: Move
            Debug.Log("Ascend!");
        }
        else
        {
            Debug.Log("Cannot ascend!");
        }
    }

}
