using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {


	public GameObject claw;
	public Gun anotherGun;
	public Animator minerAnimator;
	public Animator faceAnimator;
	public Claw clawScript;
	public bool isShooting;

	private AudioSource sound01;

	void Start () {
		sound01 = GetComponent<AudioSource> ();
	}

	void Update () 
	{
		if (Input.GetButtonDown("Fire1") && !isShooting)
		{
			LaunchClaw();
		}

	}
	public void StopSound()
	{
		sound01.Stop();
	}
	void LaunchClaw()
	{
		sound01.PlayOneShot(sound01.clip);
		isShooting = true;
		minerAnimator.speed = 0;
		faceAnimator.speed = 0;
		GetComponent<Renderer> ().enabled = false;//delete the original hand

		RaycastHit hit;
		Vector3 down = transform.TransformDirection(Vector3.down);
	
		if(Physics.Raycast(transform.position, down, out hit, 100))
		{
			claw.SetActive(true);
			clawScript.ClawTarget(hit.point);
		}

	}

	public void CollectedObject()
	{
		anotherGun.isShooting = false;
		isShooting = false;

		minerAnimator.speed = 1;
		faceAnimator.speed = 1;
		anotherGun.minerAnimator.speed = 1;

		GetComponent<Renderer> ().enabled = true;
		anotherGun.GetComponent<Renderer> ().enabled = true;
	}
}