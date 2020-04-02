using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacBehavior : MonoBehaviour
{

	public Rigidbody2D rb;
	public float vitesse;
	public float maxJump;
	public Animator animator;

	public ContactFilter2D GroundedBelowFilter;
	public ContactFilter2D GroundedLeftFilter;
	public ContactFilter2D GroundedRightFilter;
	public bool IsGroundedBelow;
	public bool IsGroundedLeft;
	public bool IsGroundedRight;

	private bool isMoving = false;
	private bool isMovingBack = false;
	public bool isAlive = true;
	public bool isAllowedToMove = true;

	// Use this for initialization
	void Start()
	{
		SetVelocity(0, 0);
	}


	// Update is called once per frame
	void Update()
	{
		if (!isAllowedToMove)
			return;

		IsGroundedBelow = rb.IsTouching(GroundedBelowFilter);
		IsGroundedLeft = rb.IsTouching(GroundedLeftFilter);
		IsGroundedRight = rb.IsTouching(GroundedRightFilter);

		if (IsGroundedBelow && Input.GetKeyDown("space"))
		{
			Jump();
		}

		if (isAlive)
		{
			// right Movement
			if (!IsGroundedRight && Input.GetKey("right"))
			{
				vitesse = 7;
				SetVelocity(vitesse, 0);
				animator.SetBool("isMoving", true);
				animator.SetBool("isMovingBack", false);
			}
			else if (Input.GetKeyUp("right"))
			{
				if (IsGroundedBelow)
				{
					vitesse = 0;
					SetVelocity(vitesse, 0);
				}

				animator.SetBool("isMoving", false);
				animator.SetBool("isMovingBack", false);
			}

			// left Movement
			if (!IsGroundedLeft && Input.GetKey("left"))
			{
				vitesse = -7;
				SetVelocity(vitesse, 0);
				animator.SetBool("isMovingBack", true);
				animator.SetBool("isMoving", false);
			}
			else if (Input.GetKeyUp("left"))
			{
				if (IsGroundedBelow)
				{
					vitesse = 0;
					SetVelocity(vitesse, 0);
				}

				animator.SetBool("isMovingBack", false);
				animator.SetBool("isMoving", false);
			}
		}
	}

	//jump Movement
	void Jump()
	{
		rb.velocity += new Vector2(0, maxJump);
	}

	//Définition Setvelocity
	void SetVelocity(float xVelocity, float yVelocity)
	{
		rb.velocity = new Vector2(xVelocity, yVelocity + rb.velocity.y);
	}
}