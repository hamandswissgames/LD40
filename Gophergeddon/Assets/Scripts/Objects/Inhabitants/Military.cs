using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Military : MonoBehaviour {


	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.CompareTag (InhabitantType.EnemyMilitary.ToString())) {
			coll.gameObject.GetComponent<Inhabitant> ().Kill ();
		} 
	}

}
