using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMilitary : MonoBehaviour {


	void Awake(){
		AudioSource aSource = GetComponent<AudioSource> ();
		aSource.clip = GetComponent<Inhabitant>().data.sound;
		aSource.Play ();
	}
	void OnCollisionEnter2D(Collision2D coll) {
		if(!coll.gameObject.CompareTag(InhabitantType.EnemyMilitary.ToString())){
			coll.gameObject.GetComponent<Inhabitant> ().Kill ();
		}
	}

}
