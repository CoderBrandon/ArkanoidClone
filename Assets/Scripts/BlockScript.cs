using UnityEngine;
using System.Collections;

public class BlockScript : MonoBehaviour {
	
	public int hp = 1;

	public void Damage(int damageCount) {
		hp -= damageCount;

		if (hp <= 0) {
			Destroy(gameObject);
			GameObject.Find ("Blocks").GetComponent<BlockSpawnerScript>().checkWin();
		}
	}
}
