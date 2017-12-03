using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inhabitant : MonoBehaviour {

	public InhabitantData data;
	SpriteRenderer spriteRenderer;
	public AnimalManager manager;
	private int moveInterval = 1;
	float moveTimer = 0;
	public Vector2 tileLoc = new Vector2();

	// Use this for initialization
	void Awake () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		spriteRenderer.sprite = data.sprite;
		InhabitantData d = ScriptableObject.CreateInstance<InhabitantData> ();
		d.init (data);
		data = d;
	}
	void Start () {
		tileLoc = transform.parent.localPosition;
		moveTimer = Random.value * moveInterval;
	}
	public virtual void Clicked() {Kill ();}
	public virtual void Kill(){
		Destroy (gameObject);
		if (manager != null) {
			manager.animals.Remove (gameObject);
		}
	}

	// Use this for initialization


	// Update is called once per frame
	void Update () {
		DoMove ();
	}

	protected void DoMove(){
		if (moveInterval > 0) {
			moveTimer += Time.deltaTime;
			if (moveTimer >= moveInterval) {
				MoveTile ();
				moveTimer = 0;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.CompareTag (data.KillType.ToString())) {
			coll.gameObject.GetComponent<Inhabitant> ().Kill ();
		} else if (coll.gameObject.CompareTag (data.type.ToString())) {
			if (manager != null) {
				manager.SpawnAnimalAt(tileLoc);			
			}
		}

	}

	void MoveTile(){
		Random.InitState (Time.frameCount + gameObject.GetInstanceID());
		Vector2 dir = new Vector2 ();

		int xDir = 0;
		if (tileLoc.x == 0) {
			xDir = Random.Range (0, 2);
		} else if (tileLoc.x == GameManager.instance.boardManager.size.x - 1) {
			xDir = Random.Range (-1, 1);
		} else {
			xDir = Random.Range (-1, 2);
		}
		int yDir = 0;
		if (tileLoc.y == 0) {
			yDir = Random.Range (0, 2);
		} else if (tileLoc.y == GameManager.instance.boardManager.size.y - 1) {
			yDir = Random.Range (-1, 1);
		} else {
			yDir = Random.Range (-1, 2);
		}

		dir = new Vector2 (xDir, yDir);
		Vector2 result = dir + tileLoc;
		transform.SetParent (GameManager.instance.boardManager.tiles [result].transform, false);
		tileLoc = result;
	}
}
