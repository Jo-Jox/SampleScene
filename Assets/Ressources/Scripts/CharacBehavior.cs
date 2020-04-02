using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacBehavior : MonoBehaviour {

	public Rigidbody2D rb;
	public float vitesse;
	public float maxJump;
	public bool isGrounded = false;
	public Animator animator;
	private bool isMoving = false;
	private bool isMovingBack = false;
	public bool isAlive = true;
	public bool isAllowedToMove =true;


	// Use this for initialization
	void Start () {
		SetVelocity(0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space") && isGrounded == true && isAllowedToMove ==true){
			Jump();
		}
// right Movement
	if(Input.GetKey("right") && isAlive == true && isAllowedToMove ==true){
			vitesse = 7;		
			SetVelocity(vitesse, 0);
			animator.SetBool("isMoving", true);
			animator.SetBool("isMovingBack", false);
	}
	if(Input.GetKeyUp("right")  && isAlive == true && isAllowedToMove ==true && isGrounded==true){
			vitesse = 0;		
			SetVelocity(vitesse, 0);
			animator.SetBool("isMoving", false);
			animator.SetBool("isMovingBack", false);
	}
//Sert à arrêter l'animation de course en vol
	if(Input.GetKeyUp("right")  && isAlive == true && isAllowedToMove ==true && isGrounded==false){
			animator.SetBool("isMoving", false);
			animator.SetBool("isMovingBack", false);
	}

// left Movement
	if(Input.GetKey("left")  && isAlive == true && isAllowedToMove ==true){
			vitesse = -7;		
			SetVelocity(vitesse, 0);
			animator.SetBool("isMovingBack", true);
			animator.SetBool("isMoving", false);
	}
	if(Input.GetKeyUp("left")  && isAlive == true && isAllowedToMove ==true && isGrounded==true){
			vitesse = 0;		
			SetVelocity(vitesse, 0);
			animator.SetBool("isMovingBack", false);
			animator.SetBool("isMoving", false);
		}
//Sert à arrêter l'animation de course en vol
	if(Input.GetKeyUp("left")  && isAlive == true && isAllowedToMove ==true && isGrounded==false){
		animator.SetBool("isMovingBack", false);
		animator.SetBool("isMoving", false);
		}

}


//jump Movement
void Jump(){
		rb.velocity += new Vector2(0, maxJump);
	}

//Définition Setvelocity
void SetVelocity(float xVelocity, float yVelocity){
	rb.velocity = new Vector2(0, rb.velocity.y);
	rb.velocity += new Vector2(xVelocity, yVelocity);
}


}	
