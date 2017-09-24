using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement_Prot : MonoBehaviour {

	public int playerSpeed = 10;
	public bool facingRight = true;
	public int playerJumpPower = 1250;
	public float moveX;
	
	// Update is called once per frame
	void Update () {
		PlayerMove ();
	}

	void PlayerMove() {
		moveX = Input.GetAxis("Horizontal");
		if (Input.GetButtonDown("Jump")) {
			Jump();
		}
		if (moveX < 0.0f && facingRight == true) {
			FlipPlayer();
		} else if (moveX > 0.0f && facingRight == false) {
			FlipPlayer();
		}

		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}

	void Jump() {
		gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
	}

	void FlipPlayer() {
		facingRight = !facingRight;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}
}
