using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Destination : MonoBehaviour
{
    public GameObject victoryScreen;
    private GameObject packageCollectedCount;
    private GameObject packageDeliveredCount;
    private GameObject TimeElapsed;
    private GameObject TotalTime;
    
    void Start()
    {
        FindGameObjects();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        UnityEngine.Debug.Log($"DESTINATION - Current collision tag: {collision.gameObject.tag}");
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
        if (IsPackageCollectedCountEqualsZero()) return;
        this.gameObject.SetActive(false);
        DecrementPackageCollectedCount();
        DecrementPackageDeliveredCount();
        if (IsNoPackageLeft())
        {
            ShowVictoryScreen();
            return;
        }
    }
    void DecrementPackageCollectedCount()
    {
        TextMeshProUGUI countTxt = packageCollectedCount.gameObject.GetComponent<TextMeshProUGUI>();
        countTxt.text = GetDecrementedCount(countTxt.text);
    }
    void DecrementPackageDeliveredCount()
    {
        TextMeshProUGUI countTxt = packageDeliveredCount.gameObject.GetComponent<TextMeshProUGUI>();
        countTxt.text = GetDecrementedCount(countTxt.text);
    }
    string GetDecrementedCount(string count)
    {
        int temp = Int32.Parse(count);
        temp--;
        return temp.ToString();
    }
    bool IsPackageCollectedCountEqualsZero()
    {
        TextMeshProUGUI countTxt = packageCollectedCount.gameObject.GetComponent<TextMeshProUGUI>();
        if (countTxt.text.Equals("0")) return true;
        return false;
    }
    bool IsNoPackageLeft()
    {
        TextMeshProUGUI packageCollectedCountTxt =
            packageCollectedCount.gameObject.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI packageDeliveredCountTxt =
            packageDeliveredCount.gameObject.GetComponent<TextMeshProUGUI>();
        if (packageCollectedCountTxt.text == "0" && packageDeliveredCountTxt.text == "0")
        {
            return true;
        }
        return false;
    }
    void FindGameObjects()
    {        
        packageCollectedCount = GameObject.Find("Packages Collected Count");
        packageDeliveredCount = GameObject.Find("Packages Delivered Count");
        TotalTime = GameObject.Find("TotalTime");
        TimeElapsed = GameObject.Find("Time Elapsed");
    }
    void ShowVictoryScreen()
    {
        Time.timeScale = 0;
        victoryScreen.gameObject.SetActive(true);
        UpdateTotalTimeText();
    }
    void UpdateTotalTimeText()
    {
        TextMeshProUGUI totalTimeTxt = TotalTime.GetComponent<TextMeshProUGUI>();
        totalTimeTxt.text = TimeElapsed.GetComponent<TextMeshProUGUI>().text!;
    }
}
