using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesPick : MonoBehaviour {

	CollectiblesController cc;
	  
    private AudioSource source;
	[SerializeField] private AudioClip collectSound;

	void Start(){
		//getting the CollectiblesControler GAME OBJECT
		GameObject ccgo = GameObject.Find ("CollectiblesController");

		//getting the CollectiblesController SCRIPT from the 
		//CollectiblesController game object
		cc = ccgo.GetComponent<CollectiblesController>(); 
	}

	void OnTriggerEnter (Collider col) {
		Debug.Log ("You've collected: " + gameObject.name);
		source = col.GetComponent<AudioSource> ();
		source.PlayOneShot (collectSound, 1f);
		Destroy (gameObject);

		cc.IncrementCount (gameObject);
	}
}
