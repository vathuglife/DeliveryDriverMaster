using System.Collections;
using System.Collections.Generic;
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
        SpawnGreenSquares();
    }   
   
    void SpawnGreenSquares()
    {
        GetRandomPoints();
        foreach (Transform spawnPoint in randomSpawnPoints)
        {
            Instantiate(greenSquarePrefab, spawnPoint.position, Quaternion.identity);

        }
    }
    private void GetRandomPoints()
    {
        ShuffleTransformPoints();
        for (int count = 1; count <= maxSpawnPointCount; count++)
        {
            // Add the element to the selected elements list
            randomSpawnPoints.Add(spawnPoints[count]);
            
        }
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
