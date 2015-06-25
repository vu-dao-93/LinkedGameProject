using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TopPlayerControl : MonoBehaviour {

	float moveSpeed = 200f;
	float jumpForce = 250f;
	public Transform topGroundCheck;
	public GameObject topInventory;
	bool grounded = false;
	bool jump = false;
	
	void Awake ()
	{
		topGroundCheck = transform.Find("TopGroundCheck");
	}
	
	void Update ()
	{
		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		grounded = Physics2D.Linecast (transform.position, topGroundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));
		
		// If the jump button is pressed and the player is grounded then the player should jump.
		if (Input.GetKeyDown(KeyCode.W) && grounded)
			jump = true;
	}
	
	void FixedUpdate()
	{
		if (Input.GetKey (KeyCode.D))
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed * Time.deltaTime, GetComponent<Rigidbody2D> ().velocity.y);
		if (Input.GetKey (KeyCode.A))
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed * Time.deltaTime, GetComponent<Rigidbody2D> ().velocity.y);

		/*
		if (move == 0)
			GetComponent<Rigidbody2D>().velocity = new Vector2 (0f, GetComponent<Rigidbody2D>().velocity.y);
		*/

		if (jump)
		{
			// Add a vertical force to the player.
			GetComponent<Rigidbody2D>().AddForce (new Vector2 (0f, jumpForce));
				
			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			jump = false;
		}
	}

	void OnTriggerEnter2D (Collider2D item)
	{
		topInventory.GetComponent<Inventory> ().AddToInventory (item);
		Destroy (item.gameObject);
	}
}
