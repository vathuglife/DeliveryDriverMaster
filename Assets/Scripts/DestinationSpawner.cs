using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationSpawner : MonoBehaviour
{
    public GameObject destinationPrefab;
    public Transform[] spawnPoints;
    private System.Random random = new System.Random();
    private List<Transform> randomSpawnPoints = new List<Transform>();
    private int maxSpawnPointCount = 5;
    void Start()
    {
        SpawnDestinations();
    }

    void SpawnDestinations()
    {
        GetRandomPoints();
        foreach (Transform spawnPoint in randomSpawnPoints)
        {
            Instantiate(destinationPrefab, spawnPoint.position, Quaternion.identity);

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
