using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPlatform : MonoBehaviour
{
    public void QbertLanding()
    {
        GameManager.Instance.TeleportPlayer();
        Destroy(gameObject);
    }

    public void ErrorLanding()
    {
        Debug.LogError("A character that should not be able to land on the warp platform has landed on one.");
    }
}
