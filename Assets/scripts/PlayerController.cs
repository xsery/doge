﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	public Animator Anim;
	public Rigidbody2D	playerRigidbody;
	public int 	forceJump;

    public bool slide; 

	//verifica o chao
	public Transform GroundCheck;
	public bool grounded;
	public LayerMask whatIsGround;

    //Slide
    public float slideTemp;
    public float timeTemp;

    //Collider
    public Transform colisor;

	// Use this for initialization
	void Start () {

			
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButtonDown("Jump") && grounded ){
			playerRigidbody.AddForce (new Vector2(0,forceJump));
            if (slide == true)
            {
                colisor.position = new Vector3(colisor.position.x, colisor.position.y + 0.8f, colisor.position.z);
            }
            slide = false;

	}

        if (Input.GetButtonDown("Slide") && grounded){
            colisor.position = new Vector3(colisor.position.x, colisor.position.y - 0.8f, colisor.position.z);
            slide = true;
            timeTemp = 0;
        }


		grounded = Physics2D.OverlapCircle (GroundCheck.position, 0.2f, whatIsGround);
			
        if (slide == true)
        {
            timeTemp += Time.deltaTime;
            if (timeTemp >= slideTemp){
                colisor.position = new Vector3(colisor.position.x, colisor.position.y + 0.8f, colisor.position.z);
                slide = false;
            }

        }

		Anim.SetBool ("jump", !grounded);
        Anim.SetBool("slide", slide);
    }

    void OnTriggerEnter2D()
    {
        Debug.Log("bateu");
    }
}