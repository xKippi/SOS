﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{

    // Use this for initialization
    public AudioSource Doing;
    public float Speed = 1F;
    public float JumpHeight = 1F;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.position += new Vector3(-Speed, 0) * Time.deltaTime;
        if (Input.GetKey(KeyCode.RightArrow))
            transform.position += new Vector3(Speed, 0) * Time.deltaTime;
        if (Input.GetKey(KeyCode.UpArrow))
            transform.position += new Vector3(0, JumpHeight)*Time.deltaTime;
        /*if (Input.GetKey(KeyCode.S))
            transform.position += new Vector3(Speed, 0);*/
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!Doing.isPlaying)
            Doing.Play();
    }
}
