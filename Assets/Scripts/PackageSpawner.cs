using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;


public class PackageSpawner : MonoBehaviour
{
    public GameObject greenSquarePrefab;
    public Transform[] spawnPoints;
    private System.Random random = new System.Random();
    private List<Transform> randomSpawnPoints = new List<Transform>();
    private int maxSpawnPointCount = 5;
    void Start()
    {
        GetRandomPoints();
        SpawnGreenSquares();
    }

    void SpawnGreenSquares()
    {
        foreach (Transform spawnPoint in randomSpawnPoints)
        {
            Instantiate(greenSquarePrefab, spawnPoint.position, Quaternion.identity);
        }
    }
    private void GetRandomPoints()
    {
        ShuffleTransformPoints();
        randomSpawnPoints = spawnPoints.Take(maxSpawnPointCount).ToList();

    }
    private void ShuffleTransformPoints()
    {
        int n = spawnPoints.Length;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            Transform value = spawnPoints[k];
            spawnPoints[k] = spawnPoints[n];
            spawnPoints[n] = value;
        }
    }
}
