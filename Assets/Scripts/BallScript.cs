using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {
	
	public Vector2 speed = new Vector2(5000,5000);

	public Vector2 direction = new Vector2 (0, 0);
	
	private Vector2 movement;
	
	//called once when object is created (AKA constructor)
	// void Awake(){}
	
	// called after Awake(), but not called if script is not enabled
	// void Start () {	}
	
	// Update is called once per frame
	void Update () {
		//clamp to camera bounds and bounce off edges
		var dist = (transform.position - Camera.main.transform.position).z;
		var leftBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, dist)).x;
		var rightBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, dist)).x;
		var topBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, dist)).y;
		var bottomBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, dist)).y;

		if (transform.position.x < leftBorder + 5) {
			direction.x = Mathf.Abs(direction.x);
		}

		if (transform.position.x > rightBorder) {
			direction.x = -Mathf.Abs(direction.x);
		}

		if (transform.position.y > topBorder - 5) {
			direction.y = -Mathf.Abs(direction.y);
		}

		if (transform.position.y < bottomBorder) {
			transform.parent.gameObject.AddComponent<GameOverScript>();
		}

		movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
	}
	
	// called at each fixed framerate frame. Used for physics.
	void FixedUpdate() { 
		rigidbody2D.velocity = movement;
	}
	
	// invoked when object is destroyed.
	// void Destroy(){}
	
	// invoked when another collider is touching this object collider
	void OnCollisionEnter2D(Collision2D coll) {
		BoxCollider2D box = coll.gameObject.GetComponent<BoxCollider2D>();

		//bounce off player
		if (coll.gameObject.tag == "Player") {
			//reflect Y direction
			direction.y = -direction.y;
			
			//adjust angle of X based on position from center of paddle
			float diffX = this.gameObject.transform.position.x - coll.gameObject.transform.position.x;
			float offsetFromCenter = diffX/box.size.x;
			direction.x += offsetFromCenter * 2;
		}

		//bounce off a block
		if (coll.gameObject.tag == "Block") {
			BlockScript blockScript = coll.gameObject.GetComponent<BlockScript>();
			blockScript.Damage(1);

			var blockPos = coll.gameObject.transform.position;
			var ballPos = transform.position;

			//Debug.Log ("(" + coll.gameObject.transform.position.x + ", " + coll.gameObject.transform.position.y + ") vs. (" + transform.position.x + ", " + transform.position.y + ")");
		
			//left or right collision
			if(Mathf.Abs (blockPos.y - ballPos.y) < 3.8) {
				direction.x *= -1;
			} else {
				direction.y = -direction.y;
			}
		}
	}
	
	// invoked when another collider is stops touching this object collider
	// void OnCollisionExit2D(CollisionInfo2D info) {}
	
	// invoked when another collider marked as "Trigger" is touching this object collider
	/*void OnTriggerEnter2D(Collider2D otherCollider) {
		PlayerScript playerScript = otherCollider.gameObject.GetComponent<PlayerScript> ();
		BoxCollider2D box = otherCollider.gameObject.GetComponent<BoxCollider2D>();

		if(playerScript != null) {
			//reflect Y direction
			direction.y = -direction.y;

			//adjust angle of X based on position from center of paddle
			float diffX = this.gameObject.transform.position.x - otherCollider.gameObject.transform.position.x;
			float offsetFromCenter = diffX/box.size.x;
			direction.x += offsetFromCenter * 2;
		}

		BlockScript blockScript = otherCollider.gameObject.GetComponent<BlockScript> ();
		if (blockScript != null) {
			blockScript.Damage(1);





			direction.y = -direction.y;
		}
	}*/
	
	// invoked when another collider marked as "Trigger"stops touching this object collider
	// void OnTriggerExit2D(Collider2D otherCollider) {}
}
