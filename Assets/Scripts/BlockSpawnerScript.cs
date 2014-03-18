using UnityEngine;
using System.Collections;

public class BlockSpawnerScript : MonoBehaviour {

	public GameObject[] blockPrefabs;
	public Sprite[] blockSprites;
	public Vector2 tileSize = new Vector2 (5, 5);
	//public Vector2 topLeft = new Vector2(-3, 3);

	// Use this for initialization
	void Start () {
		GameObject parent = GameObject.Find ("Blocks");

		BoxCollider2D blockCollider = blockPrefabs[0].GetComponent<BoxCollider2D> ();
		Vector2 blockSize = blockCollider.size;
		Vector2 topLeft = new Vector2 (parent.transform.position.x, parent.transform.position.y);

		int[,] blockMap = new int[,]{
			{-1,1,1,1,1,1,1,1,1,1,-1},
			{1,9,9,9,1,1,1,9,9,9,1},
			{1,0,0,0,1,1,1,0,0,0,1},
			{1,0,3,0,1,1,1,0,3,0,1},
			{1,1,1,1,1,4,1,1,1,1,1},
			{1,0,1,1,1,4,1,1,1,0,1},
			{1,0,0,1,1,1,1,1,0,0,1},
			{1,1,0,0,0,0,0,0,0,1,1},
			{-1,1,1,1,1,1,1,1,1,1,-1}
		};

		for (int y = 0; y < tileSize.y; y++) {
			for(int x = 0; x < tileSize.x; x++) {
				//int blockIndex = blockMap[(int)tileSize.x - x - 1,(int)tileSize.y - y - 1];
				int blockIndex = blockMap[y,x];
				if(blockIndex < 0) continue;

				var blockPrefab = blockPrefabs[0];

				var xPos = topLeft.x + (x * blockSize.x * blockPrefab.transform.localScale.x);
				var yPos = topLeft.y - (y * blockSize.y * blockPrefab.transform.localScale.y);
				var block = Instantiate (blockPrefab, new Vector3 (xPos, yPos, 0), Quaternion.identity) as GameObject;

				//change sprite graphic
				SpriteRenderer spriteRenderer = block.GetComponent<SpriteRenderer>();
				spriteRenderer.sprite = blockSprites[blockIndex];
				
				//attach to parent
				block.transform.parent = parent.transform;
			}
		}
	}

	//check if all blocks have been destroyed (called by BlockScript)
	public void checkWin() {
		var blocks = GameObject.FindGameObjectsWithTag ("Block");
		if (blocks.Length <= 1) {
			transform.parent.gameObject.AddComponent<WinScript>();
		}
	}
	
	// Update is called once per frame
	//void Update () {}
}
