using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
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
            GameObject newCube = Instantiate(cubePrefab, new Vector3(6.0f - row, row - cube, cube), Quaternion.identity);
            newCube.AddComponent<Cube>().SetupCube(level);
            cubes[row][cube] = newCube;
        }
    }

    public void CheckCubesComplete()
    {
        bool cubesComplete = true;
        foreach (GameObject[] row in cubes)
        {
            foreach (GameObject cube in row)
            {
                if (cube.GetComponent<Cube>() == null || !cube.GetComponent<Cube>().HaveNeededLandings()) cubesComplete = false;
            }
        }

        if (cubesComplete) GameManager.Instance.LevelWin();
    }

    public void DemolishPyramid()
    {
        foreach (GameObject[] row in cubes)
        {
            foreach (GameObject cube in row)
            {
                Destroy(cube);
            }
        }
    }
    
}
