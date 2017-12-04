using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatManager : AnimalManager {

	public override void Reset ()
	{
		base.Reset ();
		BuildAnimalButton.gameObject.SetActive (true);
	}
}
