using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {

	public int score = 0;
	public Text scoreText;
	public Text timeText;
	public Text gameOverText;

	public int timePerLevel = 15;
	public GameObject youWon;
	public GameObject gameOver;
    


	private float clockSpeed = 1f;
	private AudioSource sound01;
	void Start () {
		sound01 = GetComponent<AudioSource> ();
	}

	void Awake () 
	{
		scoreText.text = ("Coin: 0");

		InvokeRepeating("Clock", 0, clockSpeed);
	}

	void Clock()
	{
		timePerLevel--;
		timeText.text = ("Time: " + timePerLevel);
		if (timePerLevel == 0)
		{
			CheckGameOver();
            GameData.Instance.addCoins(score);
            Application.LoadLevel("main-scene");
        }
	}

	public void AddPoints(int pointScored)
	{
		score += pointScored;
		scoreText.text = ("Coin: " + score);
	}



    void CheckGameOver()
	{
		Time.timeScale = 0;
		sound01.PlayOneShot(sound01.clip);
		gameOverText.text = ("YOU WON " + score + " COINS" );
		gameOver.SetActive(true);
          
	}
}