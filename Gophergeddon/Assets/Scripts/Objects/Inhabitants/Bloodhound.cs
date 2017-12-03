﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloodhound : MonoBehaviour {


	void OnCollisionEnter2D(Collision2D coll) {
		if (!coll.gameObject.CompareTag (InhabitantType.Gopher.ToString()) && !coll.gameObject.CompareTag (InhabitantType.Bloodhound.ToString()) && !coll.gameObject.CompareTag (InhabitantType.Military.ToString())) {
			coll.gameObject.GetComponent<Inhabitant> ().Kill ();
		} 
	}

}