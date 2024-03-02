using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class PackageToDeliver:MonoBehaviour
    {
        private GameObject packageCollectedCount;
        void Start()
        {
            FindPackageCollectedCountObject();
        }
        void OnCollisionEnter2D(Collision2D collision)
        {
            UnityEngine.Debug.Log($"Current collision tag: {collision.gameObject.tag}");
            if (IsCollisionWithCar(collision)) HandleCollisionWithCar();
        }
        bool IsCollisionWithCar(Collision2D collision)
        {
            if (collision.gameObject.tag.Equals("Player"))
                return true;
            return false;
        }
        void HandleCollisionWithCar()
        {            
            this.gameObject.SetActive(false);
            IncrementPackageCollectedCount();
        }
        void IncrementPackageCollectedCount()
        {
            TextMeshProUGUI countTxt = packageCollectedCount.gameObject.GetComponent<TextMeshProUGUI>();
            countTxt.text = GetIncrementedCount(countTxt.text);            
        }
        string GetIncrementedCount(string count)
        {
            int temp = Int32.Parse(count);
            temp++;
            return temp.ToString();
        }
        void FindPackageCollectedCountObject()
        {
            packageCollectedCount = GameObject.Find("Packages Collected Count");
        }

    }
}
