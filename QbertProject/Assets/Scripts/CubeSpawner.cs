using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject cubePrefab;

    private GameObject[][] cubes = new GameObject[7][];

    public void SetupPyramid(int level)
    {
        
        for (int row = 0; row < 7; ++row)
        {
            SetupRow(level, row);
        }
    }

    private void SetupRow(int level, int row)
    {
        cubes[row] = new GameObject[row + 1];
        for (int cube = 0; cube <= row; ++cube)
        {
            cubes[row][cube] = Instantiate(cubePrefab, new Vector3(6.0f - row, row - cube, cube), Quaternion.identity);
            
        }
    }

    public void DemolishPyramid()
    {
        
    }
    
}
