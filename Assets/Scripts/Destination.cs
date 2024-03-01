using Assets.Scripts;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using Utils;


public class Destination : MonoBehaviour
{

    [SerializeField] GameObject packagesCollected;
    [SerializeField] GameObject victoryCanvas;
    [SerializeField] GameObject destinationsRemaining;
    [SerializeField] TextMeshProUGUI packagesDeliveredTxt;
    [SerializeField] TextMeshProUGUI destinationsRemainingTxt;
    [SerializeField] string rawPackagesDeliveredTxt;
    [SerializeField] string rawDestinationsRemaining;

    void Start()
    {
        ReloadCanvasItems();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Package retrieved!");
        UpdatePoints();
    }
    void UpdatePoints()
    {
        packagesDeliveredTxt = packagesCollected.GetComponent<TextMeshProUGUI>();
        destinationsRemainingTxt = destinationsRemaining.GetComponent<TextMeshProUGUI>();   
        rawPackagesDeliveredTxt = packagesDeliveredTxt.text;
        rawDestinationsRemaining = destinationsRemainingTxt.text;
        
        if (rawPackagesDeliveredTxt.Equals("0"))
        {
            HandleNoPackagesCollected();
            return;
        }
        HandlePackagesCollected();

    }
    void HandleNoPackagesCollected()
    {
        this.gameObject.SetActive(true);
    }
    void HandlePackagesCollected()
    {        
        string rawDecrementedPoint = StringUtils.DecrementPoints(rawPackagesDeliveredTxt);
        string rawDecrementedDestinationsRemaining = StringUtils.DecrementPoints(rawDestinationsRemaining);
        packagesDeliveredTxt.text = rawDecrementedPoint;
        destinationsRemainingTxt.text = rawDecrementedDestinationsRemaining;
        if (GetRemainingDestinations() == 0)
        {
            CanvasUtils.EnableCanvas(victoryCanvas);
            Time.timeScale = 0;
        }
            
        
        this.gameObject.SetActive(false);
    }
    int GetRemainingDestinations()
    {
        GameObject[] destinationsRemaining = GameObject.FindGameObjectsWithTag("Destinations");
        int count = destinationsRemaining.Length;
        Debug.Log($"Destinations remaining: {count}");
        return count-1;
    }
    void ReloadCanvasItems()
    {
        packagesCollected = GameObject.Find("Follow Camera/Canvas/Packages");
        victoryCanvas = GameObject.Find("Follow Camera/VictoryCanvas");
        destinationsRemaining = GameObject.Find("Follow Camera/Canvas/DestinationRemaining");
        CanvasUtils.DisableCanvas(victoryCanvas);
    }
  
}
