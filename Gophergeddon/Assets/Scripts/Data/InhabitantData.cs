using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InhabitantType {
	Gopher, Flower, Cat, Dog, DogCatcher, Police, Bloodhound, Military, EnemyMilitary
}

[CreateAssetMenu()]
public class InhabitantData : ScriptableObject {

	public string Name;
	public Sprite sprite;
	public InhabitantType type;
	public InhabitantType KillType;
	public AudioClip sound;
	public GameObject prefab;
	[Range(0, 10)]
	public int TotalHealth;
	public float Health;

	public void init(InhabitantData _data){
		Name = _data.Name;
		sprite = _data.sprite;
		type = _data.type;
		KillType = _data.KillType;
		sound = _data.sound;
		prefab = _data.prefab;
		TotalHealth = 1;
		Health = TotalHealth;

	}
}
