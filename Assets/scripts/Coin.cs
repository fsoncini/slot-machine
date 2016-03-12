using UnityEngine;
using System.Collections;


public class Coin : MonoBehaviour {

	public bool isFree;
	public ScoreManager scoremanager;

	private AudioSource sound01;

	void Start () {
		isFree = true;
		sound01 = GetComponent<AudioSource> ();
	}

	void Update () {
		if (!isFree) {
			Destroy (gameObject);
		}

	}

	void OnTriggerEnter (Collider other){
		sound01.PlayOneShot(sound01.clip);
		scoremanager.AddPoints(1);
		isFree = false;
	}
}
