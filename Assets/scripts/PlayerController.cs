using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	public Animator Anim;
	public Rigidbody2D	playerRigidbody;
	public int 	forceJump;


	//verifica o chao
	public Transform GroundCheck;
	public bool grounded;
	public LayerMask whatIsGround;

	// Use this for initialization
	void Start () {

			
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButtonDown("Jump") && grounded ){
			playerRigidbody.AddForce (new Vector2(0,forceJump));


	}
		grounded = Physics2D.OverlapCircle (GroundCheck.position, 0.2f, whatIsGround);
			
		Anim.SetBool ("jump", !grounded);
	}
}