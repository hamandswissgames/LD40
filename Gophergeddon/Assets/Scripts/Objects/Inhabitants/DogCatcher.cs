using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogCatcher : MonoBehaviour {


	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.CompareTag (InhabitantType.Cat.ToString ())) {
			coll.gameObject.GetComponent<Inhabitant> ().Kill ();
			GetComponent<Inhabitant> ().Kill ();
		} else if (coll.gameObject.CompareTag (InhabitantType.Dog.ToString ())) {
			GetComponent<Inhabitant> ().Kill ();
		}
	}

}
