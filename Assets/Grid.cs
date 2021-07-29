using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    
    [SerializeField] private float cellSize;

    private Spawner spawner;

    private List<Vector2> cellsPositions = new List<Vector2>();
    private Vector2 align;

    public void GenerateGrid(int numberCell, int rows)
    {
        spawner = FindObjectOfType<Spawner>();
        int cols = numberCell / rows;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                float posX = col * cellSize;
                float posY = row * -cellSize;
                cellsPositions.Add(new Vector2(posX, posY));
            }
        }
        AlignGrid(cols,rows);
        StartCoroutine(FillingGrig());
    }

    private void AlignGrid(int cols, int rows)
    {
        float gridWidht = cols * cellSize;
        float gridHight = rows * cellSize;
        align = new Vector2(-gridWidht / 2 + cellSize / 2, gridHight / 2 - cellSize / 2);
        transform.position = align;
    }

   

    IEnumerator FillingGrig()
    {
        yield return null;
        int randomIndex = Random.Range(0, cellsPositions.Count);
        for (int i = 0; i < cellsPositions.Count; i++)
        {
            spawner.SpawnCell(cellsPositions[randomIndex] + align);
            cellsPositions.Remove(cellsPositions[randomIndex]);
            break;
        }
        StartCoroutine(FillingGrig());
    }


}
