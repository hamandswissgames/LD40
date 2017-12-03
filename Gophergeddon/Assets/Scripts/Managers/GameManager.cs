using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public LevelManager levelManager;
	public BoardManager boardManager;
	public ClickManager clickManager;
	public GopherManager gopherManager;
	public CatManager catManager;
	public DogManager dogManager;
	public DogCatcherManager dogCatcherManager;
	public PoliceManager policeManager;
	public BloodhoundManager bloodHoundManager;
	public MilitaryManager militaryManager;
	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);		
		DontDestroyOnLoad (gameObject);
		levelManager = GetComponent<LevelManager> ();
		boardManager = GetComponent<BoardManager> ();
		clickManager = GetComponent<ClickManager> ();

		gopherManager = GetComponent<GopherManager> ();
		catManager = GetComponent<CatManager> ();
		dogManager = GetComponent<DogManager> ();
		dogCatcherManager = GetComponent<DogCatcherManager> ();
		policeManager = GetComponent<PoliceManager> ();
		bloodHoundManager = GetComponent<BloodhoundManager> ();
		militaryManager = GetComponent<MilitaryManager> ();
		Screen.SetResolution (800, 800, false);
	}
	public int timeScale = 1;
	void Update(){
		Time.timeScale = timeScale;
	}

	public void SetFastForward(){
		timeScale = 10;
	}


	public void SetNormalSpeed(){
		timeScale = 1;
	}
}
