using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GopherManager : AnimalManager {


	// Update is called once per frame
	void Update () {
		populationText.text = animals.Count.ToString() + "/" + allowedAnimalCount.ToString();
		if (animals.Count > 0) {
			populationText.color = overPopulationColor;
		} else {
			populationText.color = underPopulationColor;
		}
		if (isComplete)
			return;

		timer += Time.deltaTime;
		if (timer > interval) {
			Random.InitState (Time.frameCount);
			SpawnRandomAnimal();
			timer = 0;
		}

		if (animals.Count > 0) {
			interval = 50 / animals.Count;
		}
		if (animals.Count >= GameManager.instance.boardManager.size.x * GameManager.instance.boardManager.size.y * .6f) {
			GameManager.instance.SetMessage ("The gophers are getting out of control!!");
		}
		if (animals.Count >= GameManager.instance.boardManager.size.x * GameManager.instance.boardManager.size.y * .9f) {
			GameManager.instance.GameOver ("Gophergeddon!  The gophers have overrun the entire planet.", true);
		}
	}

	public override void SpawnRandomAnimal(){
		Vector2 size = GameManager.instance.boardManager.size;
		Vector2 gPos = new Vector2(Random.Range (0, (int)size.x), Random.Range (0, (int)size.y));
		GameObject tile = GameManager.instance.boardManager.tiles [gPos];
		if (tile.transform.childCount == 0) {
			GameObject gopher = Instantiate (AnimalData.prefab, tile.transform);
			gopher.GetComponent<Inhabitant> ().manager = this;
			animals.Add (gopher);
		} else {
			timer = interval * .8f;
		}


	}

	public void SpawnInitialGophers(){
		for (int i = 0; i < GameManager.instance.boardManager.size.x; i++) {
			Random.InitState (Time.frameCount + i);
			SpawnRandomAnimal ();
		}
	}
}
