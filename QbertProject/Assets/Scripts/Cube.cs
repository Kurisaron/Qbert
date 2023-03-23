using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private GameObject topPlane;

    private int currentLandings;
    private int landingsNeeded;
    private bool playerCanReset;

    public void SetupCube(int level)
    {
        topPlane = transform.Find("TopPlane").gameObject;

        currentLandings = 0;
        SetTopColor();
        landingsNeeded = (level <= 1 || level == 3) ? 1 : 2;
        playerCanReset = level > 2;
    }

    public void QbertLanding()
    {
        if (HaveNeededLandings())
        {
            if (!playerCanReset) return;

            ResetLandings();
        }
        else
        {
            AddLanding();
        }
    }

    private void AddLanding()
    {
        currentLandings += 1;
        SetTopColor();

        if (HaveNeededLandings())
        {
            GameManager.Instance.CheckCubesComplete();
        }
    }

    private void ResetLandings()
    {
        currentLandings = 0;
        SetTopColor();
    }

    public void SlickSamLanding()
    {
        ResetLandings();
    }

    private void SetTopColor()
    {
        Color color;
        switch(currentLandings)
        {
            case 0:
                color = Color.blue;
                break;
            case 1:
                color = Color.yellow;
                break;
            case 2:
                color = Color.green;
                break;
            default:
                Debug.Log("Landing number invalid");
                color = Color.red;
                break;
        }
        
        topPlane.GetComponent<Renderer>().material.color = color;
    }

    public bool HaveNeededLandings()
    {
        return currentLandings >= landingsNeeded;
    }
}
