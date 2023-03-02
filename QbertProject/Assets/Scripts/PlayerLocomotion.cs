using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : NormalMover
{



    public override void Ascend(Side side)
    {
        Vector3 rayDirection = side == Side.Left ? new Vector3(0, 0, -1) : new Vector3(-1, 0, 0);

        if (PlayerController.Instance.canMove && Physics.Raycast(gameObject.transform.position, rayDirection, out RaycastHit hit))
        {
            // TO-DO: Move Qbert
            Debug.Log("Ascend!");
        }
        else
        {
            Debug.Log("Cannot ascend!");
        }
    }

    public override void Descend(Side side)
    {
        Vector3 rayOrigin = gameObject.transform.position + (side == Side.Left ? new Vector3(1, 0, 0) : new Vector3(0, 0, 1));

        if (PlayerController.Instance.canMove && Physics.Raycast(rayOrigin, Vector3.down, out RaycastHit hit))
        {
            // TO-DO: Move Qbert
            Debug.Log("Descend!");
        }
        else
        {
            Debug.Log("Cannot descend!");
        }
    }
}
