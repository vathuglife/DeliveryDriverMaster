using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Driver : MonoBehaviour
{

    public AudioSource audioPlayer;
    public float moveSpeed = 0.03f;
    private float rotationSpeed = 1f;
    private List<string> excludedCollisionTags = new List<string>() {
        "Bridge","Package","SpeedUp"
    };
    public Vector3 startingPosition;
    public SpriteRenderer carSpriteRenderer;

    void Start()
    {
        carSpriteRenderer = GetComponent<SpriteRenderer>();
        startingPosition = transform.position;
        UnityEngine.Debug.Log($"Initial Start position: {startingPosition}");
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            GoVertical();
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            Rotate();
        }

    }
    private void GoVertical()
    {
        float verticalMove = Input.GetAxis("Vertical") * moveSpeed;
        transform.Translate(0, verticalMove, 0);

    }
    private void Rotate()
    {
        float rotateMove = Input.GetAxis("Horizontal") * rotationSpeed;
        if (Input.GetKey(KeyCode.DownArrow))
            transform.Rotate(0, 0, rotateMove);
        else
            transform.Rotate(0, 0, -rotateMove);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        UnityEngine.Debug.Log($"PLAYER - Current collision tag: {collision.gameObject.tag}");
        if (IsCollisionWithSpeedup(collision)) { HandleSpeedupCollision();  return; };
        if (IsCollisionWithinExceptions(collision)) return; 
        audioPlayer.Play();
        transform.position = startingPosition;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bridge"))
        {
            carSpriteRenderer.sortingOrder = 1;
        }
    }
    bool IsCollisionWithinExceptions(Collision2D collision)
    {
        if (excludedCollisionTags.Any(excludedCollisionTag
                => excludedCollisionTag.Equals(collision.gameObject.tag)))
            return true;
        return false;
    }

    bool IsCollisionWithSpeedup(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("SpeedUp")) return true;
        return false;
    }
    void HandleSpeedupCollision()
    {
        moveSpeed = (float)(moveSpeed + 0.02);
        UnityEngine.Debug.Log($"PLAYER - Current car speed: {moveSpeed}");
    }



}
