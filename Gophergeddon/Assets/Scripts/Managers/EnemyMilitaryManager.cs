using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMilitaryManager : AnimalManager {

	public bool activated = false;
	public int spawnInterval = 5;
	float spawnTimer = 0;


	public override void Reset(){
		base.Reset ();
		activated = false;
		spawnTimer = 0;
	}
	protected override void DoUpdate(){
		if (GameManager.instance.militaryManager.animals.Count > 3) {
			activated = true;
			GameManager.instance.SetMessage ("The Enemy Army has declared WAR due to too much military activity!");
		}
		if (activated) {
			spawnTimer += Time.deltaTime;
			if (spawnTimer >= spawnInterval) {
				spawnTimer = 0;
				Random.InitState (Time.frameCount);
				SpawnRandomAnimal ();
			}
		}
		if (animals.Count > 5) {
			GameManager.instance.GameOver ("The enemy military is growing in power!", false);
		}
		if (animals.Count > 10) {
			GameManager.instance.GameOver ("The enemy military started a nuclear war. Everybody is dead.", false);
		}
	}


}
