﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float screenWidth = 16f;
    [SerializeField] private float minX = 1f;
    [SerializeField] private float maxX = 15f;

    Ball ball;
    GameSession gameSession;

    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<Ball>();
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);

        paddlePosition.x = Mathf.Clamp(GetXPos(), minX, maxX);

        transform.position = paddlePosition;
    }

    private float GetXPos()
    {
        if(gameSession.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidth;
        }
    }
}
    