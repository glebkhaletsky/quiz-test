using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cell cellPrefab;


    public void SpawnCell(Vector2 position)
    {
         Instantiate(cellPrefab, position, Quaternion.identity, transform.parent);
    }
}
