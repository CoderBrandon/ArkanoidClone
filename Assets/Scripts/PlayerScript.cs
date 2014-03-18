using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public Vector2 speed = new Vector2(50,50);

	private Vector2 movement;

	//called once when object is created (AKA constructor)
	// void Awake(){}

	// called after Awake(), but not called if script is not enabled
	// void Start () {	}
	
	// Update is called once per frame
	void Update () {

		//clamp to camera bounds
		var dist = (transform.position - Camera.main.transform.position).z;
		var leftBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, dist)).x;
		var rightBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, dist)).x;
		var topBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, dist)).y;
		var bottomBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, dist)).y;

		transform.position = new Vector3 (
			Mathf.Clamp (transform.position.x, leftBorder + 26, rightBorder - 23), 
			Mathf.Clamp (transform.position.y, topBorder, bottomBorder), 
			transform.position.z
		);

		//move based on input
		float inputX = Input.GetAxis ("Horizontal");
		movement = new Vector2(speed.x * inputX, 0);
	}

	// called at each fixed framerate frame. Used for physics.
	void FixedUpdate() { 
		rigidbody2D.velocity = movement;
	}

	// invoked when object is destroyed.
	// void Destroy(){}

	// invoked when another collider is touching this object collider
	// void OnCollisionEnter2D(CollisionInfo2D info) {}

	// invoked when another collider is stops touching this object collider
	// void OnCollisionExit2D(CollisionInfo2D info) {}

	// invoked when another collider marked as "Trigger" is touching this object collider
	// void OnTriggerEnter2D(CollisionInfo2D info) {}

	// invoked when another collider marked as "Trigger"stops touching this object collider
	// void OnTriggerExit2D(CollisionInfo2D info) {}
}
