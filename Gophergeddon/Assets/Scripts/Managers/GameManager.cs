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
	public EnemyMilitaryManager enemyMilitaryManager;
	public AudioSource audioManager;

	public GameObject MainMenuPanel;
	public GameObject GameOverPanel;
	public UnityEngine.UI.Text GameOverReasonText;
	public bool GameRunning = false;
	public List<AnimalManager> managers = new List<AnimalManager>();

	public Transform messageParent;
	public GameObject messagePrefab;

	public Transform FamineBackground;
	public Transform WarBackground;

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
		enemyMilitaryManager = GetComponent<EnemyMilitaryManager> ();
		audioManager = GetComponent<AudioSource> ();

		managers.Add (gopherManager);
		managers.Add (catManager);
		managers.Add (dogManager);
		managers.Add (dogCatcherManager);
		managers.Add (policeManager);
		managers.Add (bloodHoundManager);
		managers.Add (militaryManager);
		managers.Add (enemyMilitaryManager);
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

	public void StartGame(){
		GameRunning = true;
		MainMenuPanel.SetActive (false);
		GameOverPanel.SetActive (false);
		foreach (AnimalManager manager in managers) {
			manager.Reset ();
		}
		boardManager.size = new Vector2 (4f, 4f);
		boardManager.BuildBoard ();
		gopherManager.SpawnInitialGophers ();
	}

	public void GameOver(string reason, bool isFamine){	
		GameOverReasonText.text = reason;
		GameOverPanel.SetActive (true);
		boardManager.Reset ();
		foreach (AnimalManager manager in managers) {
			manager.Reset ();
		}
		GameRunning = false;
		if (isFamine) {
			FamineBackground.gameObject.SetActive (true);
			WarBackground.gameObject.SetActive (false);
		} else {
			FamineBackground.gameObject.SetActive (false);
			WarBackground.gameObject.SetActive (true);
		}
	}

	public void GoMainMenu(){
		GameRunning = false;
		MainMenuPanel.SetActive (true);
		GameOverPanel.SetActive (false);
	}

	public void SetMessage(string msg){
		for (int i = messageParent.childCount - 1; i >= 0; i--) {
			Destroy (messageParent.GetChild (i).gameObject);
		}
		GameObject newMessage = Instantiate (messagePrefab, messageParent);
		newMessage.GetComponent<UnityEngine.UI.Text> ().text = msg;
	}
}
