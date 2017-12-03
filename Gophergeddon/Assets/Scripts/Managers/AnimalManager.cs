using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalManager : MonoBehaviour {

	public float interval = 1;
	protected float timer = 0;
	public GameObject AnimalPrefab;
	public Text populationText;
	public List<GameObject> animals = new List<GameObject> ();
	public int allowedAnimalCount;
	public Color overPopulationColor;
	public Color underPopulationColor;

	public Button BuildAnimalButton;
	public Button BuildKillerButton;


	public bool isComplete {
		get {
			if (animals.Count <= allowedAnimalCount)
				return true;

			return false;
		}
	}
	public virtual void LevelUp(){
		ClearAnimals ();
	}
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		populationText.text = animals.Count.ToString() + "/" + allowedAnimalCount.ToString();
		if (animals.Count > allowedAnimalCount) {
			populationText.color = overPopulationColor;
			if (BuildKillerButton != null) {
				BuildKillerButton.gameObject.SetActive (true);
			}
		} else {
			populationText.color = underPopulationColor;
		}
	}
	public void ClearAnimals(){
		for (int i = animals.Count - 1; i >= 0; i--) {
			Destroy (animals[i]);
		}
		animals.Clear ();
	}
	public virtual void SpawnRandomAnimal(){
		Vector2 size = GameManager.instance.boardManager.size;
		Vector2 pos = new Vector2 (Random.Range (0, (int)size.x), Random.Range (0, (int)size.y));
		timer = interval + 1;
		SpawnAnimalAt (pos);
	}

	public virtual void SpawnAnimalAt(Vector2 pos){
		if (timer > interval && animals.Count < GameManager.instance.boardManager.size.x * GameManager.instance.boardManager.size.y / 2) {
			timer = 0;
			GameObject tile = GameManager.instance.boardManager.tiles [pos];
			GameObject animal = Instantiate (AnimalPrefab, tile.transform);
			animals.Add (animal);
			animal.GetComponent<Inhabitant> ().manager = this;
		}	

	}


}
