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
}
