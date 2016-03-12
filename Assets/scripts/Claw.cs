using UnityEngine;
using System.Collections;

public class Claw : MonoBehaviour {

	public Transform lineOrigin;
	public Transform origin;
	public Transform anotherOrigin;
	public Claw anotherClaw;
	public float speed = 4f;
	public Gun gun;
	public Gun anotherGun;
	public ScoreManager scoreManager;

	private AudioSource sound01;
	private AudioSource sound02;

	private Vector3 target;
	private GameObject childObject;
	private LineRenderer lineRenderer;
	private bool hitJewel;
	private bool retracting;

	void Start () {

		AudioSource[] audioSources = GetComponents<AudioSource>();
		sound01 = audioSources[0];
		sound02 = audioSources[1];
	}

	void Awake ()
	{
		lineRenderer = GetComponent<LineRenderer>();
	}


	void Update () 
	{
		float step = speed * Time.deltaTime;

		transform.position = Vector3.MoveTowards (transform.position, target, step);
		lineRenderer.SetPosition(0, lineOrigin.position);
		lineRenderer.SetPosition(1, transform.position);

		if (transform.position == origin.position || anotherClaw.transform.position == anotherClaw.origin.position ) {
			if (retracting){
				gun.CollectedObject ();
			if (hitJewel) {
			
				hitJewel = false;
			}
			Destroy (childObject);
			gameObject.SetActive (false);
			anotherClaw.gameObject.SetActive (false);
		}
		}
	}

	public void ClawTarget (Vector3 pos)
	{
		target = pos;
	}

	void OnTriggerEnter (Collider other)
	{
		
		retracting = true;
		target = origin.position;
		anotherClaw.target = anotherOrigin.position;

		gun.StopSound();
		anotherGun.StopSound ();
		sound01.PlayOneShot(sound01.clip);

		if (other.gameObject.CompareTag("Coin"))
		{
			sound02.PlayOneShot(sound02.clip);
			hitJewel = true;
			childObject = other.gameObject;
			other.transform.SetParent(this.transform);
		}
	}
}