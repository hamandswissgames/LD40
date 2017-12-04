using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public int interval = 10;
	float timer = 0;
	// Use this for initialization

	// Update is called once per frame
	void Update () {
		if (!GameManager.instance.GameRunning)
			return;
		timer += Time.deltaTime;
		bool isComplete = true;
		foreach (AnimalManager manager in GameManager.instance.managers) {
			if (!manager.isComplete) {
				isComplete = false;
				break;
			}
		}
		if (isComplete) {
			GameManager.instance.boardManager.IncreaseBoardSize ();
			timer = 0;
			GameManager.instance.gopherManager.SpawnInitialGophers ();
		}
		
	}
}
