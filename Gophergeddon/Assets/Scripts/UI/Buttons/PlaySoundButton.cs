using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlaySoundButton : MonoBehaviour {

	Button btn;
	public AudioClip sound;
	// Use this for initialization
	void Start () {
		btn = GetComponent<Button> ();
		btn.onClick.AddListener (Clicked);
	}
	
	// Update is called once per frame
	void Clicked() {
		GameManager.instance.audioManager.clip = sound;
		GameManager.instance.audioManager.Play ();
	}
}
