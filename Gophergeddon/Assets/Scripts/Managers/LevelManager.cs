using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameManager.instance.boardManager.BuildBoard ();
		GameManager.instance.gopherManager.SpawnInitialGophers ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.gopherManager.isComplete &&
			GameManager.instance.catManager.isComplete &&
			GameManager.instance.dogManager.isComplete &&
			GameManager.instance.dogCatcherManager.isComplete &&
			GameManager.instance.policeManager.isComplete &&
			GameManager.instance.bloodHoundManager.isComplete) {
			int catCount = GameManager.instance.catManager.animals.Count;
			int dogCount = GameManager.instance.dogManager.animals.Count;
			int dogCatcherCount = GameManager.instance.dogCatcherManager.animals.Count;
			int policeCount = GameManager.instance.policeManager.animals.Count;
			int bloodHoundCount = GameManager.instance.bloodHoundManager.animals.Count;
			int militaryCount = GameManager.instance.militaryManager.animals.Count;

			GameManager.instance.gopherManager.LevelUp();
			GameManager.instance.catManager.LevelUp();
			GameManager.instance.dogManager.LevelUp();
			GameManager.instance.dogCatcherManager.LevelUp();
			GameManager.instance.policeManager.LevelUp();
			GameManager.instance.bloodHoundManager.LevelUp();
			GameManager.instance.militaryManager.LevelUp();

			GameManager.instance.boardManager.IncreaseBoardSize ();

			GameManager.instance.gopherManager.SpawnInitialGophers ();
			for (int i = 0; i < catCount; i++) {
				GameManager.instance.catManager.SpawnRandomAnimal ();
			}
			for (int i = 0; i < dogCount; i++) {
				GameManager.instance.dogManager.SpawnRandomAnimal ();
			}
			for (int i = 0; i < dogCatcherCount; i++) {
				GameManager.instance.dogCatcherManager.SpawnRandomAnimal ();
			}
			for (int i = 0; i < policeCount; i++) {
				GameManager.instance.policeManager.SpawnRandomAnimal ();
			}
			for (int i = 0; i < bloodHoundCount; i++) {
				GameManager.instance.bloodHoundManager.SpawnRandomAnimal ();
			}
			for (int i = 0; i < militaryCount; i++) {
				GameManager.instance.militaryManager.SpawnRandomAnimal ();
			}
		}
	}
}
