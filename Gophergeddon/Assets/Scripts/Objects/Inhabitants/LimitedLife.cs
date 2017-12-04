using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitedLife : MonoBehaviour {

	public int lifeTime = 10;
	float lifeTimer = 0;

	void Update(){
		lifeTimer += Time.deltaTime;
		Inhabitant i = GetComponent<Inhabitant> ();
		if (lifeTimer > lifeTime) {
			if (i != null) {
				GetComponent<Inhabitant> ().Kill ();
			} else {
				Destroy (gameObject);
			}
		}
	}

}
