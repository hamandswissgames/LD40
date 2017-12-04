using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {

	public Vector2 size = new Vector2();
	public Transform boardParent;
	public GameObject tilePrefab;
	public Sprite grassSprite;
	public Dictionary<Vector2, GameObject> tiles = new Dictionary<Vector2, GameObject>();
	// Use this for initialization

	public void BuildBoard(){
		for (int i = 0; i < size.x; i++) {
			for (int j = 0; j < size.y; j++) {
				Vector2 v = new Vector2 (i, j);
				if (!tiles.ContainsKey (v)) {
					GameObject tile = Instantiate (tilePrefab, boardParent);
					tile.transform.localPosition = v;
					tile.GetComponent<SpriteRenderer> ().sprite = grassSprite;
					tiles.Add (tile.transform.localPosition, tile);
				}
			}
		}
		boardParent.transform.position = new Vector2 (-size.x / 2 + .5f, -size.y / 2 + .5f);	
	}

	public void IncreaseBoardSize(){

		size.x += 2;
		size.y += 2;
		Camera.main.orthographicSize += 1;
		BuildBoard ();


	}

	public void Reset (){
		for (int i = boardParent.childCount - 1; i >= 0; i--) {
			Destroy (boardParent.GetChild (i).gameObject);
		}
		tiles.Clear ();
	}
}
