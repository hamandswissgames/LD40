using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitedLife : MonoBehaviour {

	public int lifeTime = 10;
	float lifeTimer = 0;
	void Update(){
		lifeTimer += Time.deltaTime;
		if (lifeTimer > lifeTime) {
			GetComponent<Inhabitant>().Kill ();
		}
	}

}
