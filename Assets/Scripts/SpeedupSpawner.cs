using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class SpeedupSpawner:MonoBehaviour
    {
        public GameObject speedUpPrefab;
        public Transform[] spawnPoints;
        private System.Random random = new System.Random();
        private List<Transform> randomSpawnPoints = new List<Transform>();
        private int maxSpawnPointCount = 8;
        void Start()
        {
            SpawnSpeedups();
        }

        void SpawnSpeedups()
        {
            GetRandomPoints();
            int count = 1;
            foreach (Transform spawnPoint in randomSpawnPoints)
            {
                Instantiate(speedUpPrefab, spawnPoint.position, Quaternion.identity);
                Debug.Log($"Speedup Spawn point {count}: {spawnPoint.position}");
                count++;
            }
        }
        private void GetRandomPoints()
        {
            ShuffleTransformPoints();
            for (int count = 1; count <= maxSpawnPointCount; count++)
            {                
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
}
