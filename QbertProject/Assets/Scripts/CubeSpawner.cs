using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject cubePrefab;

    private GameObject[] cubes = new GameObject[28];
    private int cubeIndex = 0;

    public void SetupPyramid(int level)
    {
        cubeIndex = 0;

        for (int row = 1; row <= 7; ++row)
        {
            SetupRow(level, row);
        }
    }

    private void SetupRow(int level, int row)
    {
        for (int cube = 0; cube < row; ++cube)
        {
            cubes[cubeIndex] = Instantiate(cubePrefab, new Vector3(7.0f - row, row - cube, cube), Quaternion.identity);

            cubeIndex++;
        }
    }

    public void DemolishPyramid()
    {
        for (int i = 0; i < cubes.Length; ++i)
        {
            Destroy(cubes[i]);
            cubes[i] = null;
        }
    }
}
