using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Speedup : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //UnityEngine.Debug.Log($"SPEEDUP - Current collision tag: {collision.gameObject.tag}");
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
    }    
}
