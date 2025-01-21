using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float movementSpeed = 10f;

    private float _directionMove;
    private Rigidbody2D _playerRb;

    
    public int jewelCount;
    public Text jewelText;
    public GameObject gameOverPanel;
    public Text gameScore;
    private Camera mainCamera;
    public float shiftDistanceDestroy = 10f;
    public float deadZone = 10f;
    

    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        _directionMove = Input.GetAxis("Horizontal") * movementSpeed;
        if (transform.position.y < mainCamera.transform.position.y - deadZone) 
        {
            gameOverPanel.SetActive(true);
            //SceneManager.LoadScene(0);
            gameScore.text = Convert.ToString(jewelCount);
        }
    }

    private void FixedUpdate()
    {
        Vector2 velocity = _playerRb.velocity;
        velocity.x = _directionMove;
        _playerRb.velocity = velocity;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Jewel"))
        {
            jewelCount++;
            jewelText.text = Convert.ToString(jewelCount);
        }
    }
}
