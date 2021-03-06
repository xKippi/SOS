﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour {

    private static int _leftScore;
    private static int _rightScore;
    private float oldY;
    private int _goalMode;
    public Text ScoreBox;
    public Component Player1;
    public Component Player2;

	// Use this for initialization
	void Start ()
    {
        UpdateScore();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.y - oldY == 0)
            transform.position += new Vector3(0, 0.005F);
        oldY = transform.position.y;

        switch (_goalMode)
        {

            case 1: return;
            case 2: _reset(); break;
            case 3:
                {
                    ScoreBox.text += "\n" + (_leftScore < _rightScore ? "Player 1" : "Player 2") + " won!";
                    _goalMode = 1;
                }
                return;
        }

        if (transform.position.y < -1)
        {
            if (transform.position.x < -8.5)
            {
                // Goal left
                _goal(ref _rightScore);
            }
            else if (transform.position.x > 8.5)
            {
                // Goal right
                _goal(ref _leftScore);
            }
        }
    }

    void UpdateScore()
    {
        ScoreBox.text = _leftScore + ":" + _rightScore;
    }

    void _reset()
    {
        /*transform.position = new Vector3(0, -1.9F, -2);
        transform.rotation = new Quaternion(0, 0, 0, 0);

        Player1.transform.position = new Vector3(-7.24F, -3.76F);
        Player1.transform.rotation = new Quaternion(0, 0, 0, 0);
        Player2.transform.position = new Vector3(7.24F, -3.76F);
        Player2.transform.rotation = new Quaternion(0, 0, 0, 0);

        _goalMode = 0;*/

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void _goal(ref int score)
    {
        score++;
        UpdateScore();
        if (score < 10)
        {
            new Thread(() =>
            {
                _goalMode = 1;
                Thread.Sleep(2500);
                _goalMode = 2;
            }).Start();
        }
        else
        {
            _goalMode = 3;
        }
    }

    void EndGame()
    {

    }
}
