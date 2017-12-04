using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police : MonoBehaviour {


	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.CompareTag (InhabitantType.Dog.ToString())) {
			coll.gameObject.GetComponent<Inhabitant> ().Kill ();
			GameManager.instance.bloodHoundManager.SpawnAnimalAt (GetComponent<Inhabitant>().tileLoc);
			GameManager.instance.SetMessage ("The police have transformed a dog to a Death Hound!");
		} else if (coll.gameObject.CompareTag (InhabitantType.Cat.ToString())) {
			coll.gameObject.GetComponent<Inhabitant> ().Kill ();
			GameManager.instance.bloodHoundManager.SpawnAnimalAt (GetComponent<Inhabitant>().tileLoc);
			GameManager.instance.SetMessage ("The police have transformed a cat to a Death Hound!");
		}  else if (coll.gameObject.CompareTag (InhabitantType.DogCatcher.ToString())) {
			GetComponent<Inhabitant> ().Kill ();
		} 
	}

}
