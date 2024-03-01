using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Utils;

public class Collision : MonoBehaviour
{
    [SerializeField] GameObject lives;
    [SerializeField] TextMeshProUGUI livesTxt;
    [SerializeField] GameObject gameOverCanvas;    
    public AudioSource audioSource;    
    void Start()
    {        
        RefreshGameObjects();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.Play();                
        //UpdatePoints();
    }
    void UpdatePoints()
    {
        livesTxt = lives.GetComponent<TextMeshProUGUI>();
        string decrementedLives = StringUtils.DecrementPoints(livesTxt.text);
        if (decrementedLives.Equals("0"))
        {
            EndGame();  
        }
        
        livesTxt.text = decrementedLives;        
    }
    
    void EndGame()
    {
        Time.timeScale = 0;
        CanvasUtils.EnableCanvas(gameOverCanvas);
    }
    void RefreshGameObjects()
    {
        lives = GameObject.Find("Follow Camera/Canvas/Lives");
        gameOverCanvas = GameObject.Find("Follow Camera/GameOverCanvas");
        CanvasUtils.DisableCanvas(gameOverCanvas);        
    }
    
}
