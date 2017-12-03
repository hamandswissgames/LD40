using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour {

	bool mouseDown;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			mouseDown = true;
		}
		if (Input.GetMouseButtonUp (0)) {
			mouseDown = false;
		}
		if (mouseDown) {			

			Vector3 mousePosition = Input.mousePosition;

			Vector2 v = Camera.main.ScreenToWorldPoint(mousePosition);

			Collider2D[] col = Physics2D.OverlapPointAll(v);

			if(col.Length > 0){
				foreach(Collider2D c in col)
				{
					Inhabitant inhabitant = c.gameObject.GetComponent<Inhabitant> ();
					inhabitant.Clicked ();
				}
			}
		}
	}
}
