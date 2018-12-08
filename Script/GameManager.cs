using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public int lives;
	public int level;
	public Text livesText;
	public Text levelText;
	public bool gameOver;
	public GameObject gameOverPanel;
	public GameObject loadLevelPanel;
	public int numberOfBricks;
	public bool speedUp;
	public Transform[] levels;
	public int currentLevelIndex = 0;

	// Use this for initialization
	void Start () {
		livesText.text = "Lives: " + lives;
		levelText.text = "Level: " + level;
		numberOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Fungsi edit live + cek game over
	public void UpdateLives(int changeLives){
		lives += changeLives;

		if (lives <= 0){
			lives = 0;
			GameOver();
		}

		livesText.text = "Lives: " + lives;
	}

	public void UpdateLevel(int level){
		levelText.text = "Level: " + level;
	}

	// Set game over
	void GameOver(){
		gameOver = true;
		gameOverPanel.SetActive(true);
	}

	// Kontrol jumlah brick
	public void UpdateNumberOfBricks(){
		numberOfBricks--;
		if(numberOfBricks <= 0){
			if(currentLevelIndex >= levels.Length - 1){
				GameOver();
			} else {
				loadLevelPanel.SetActive(true);
				loadLevelPanel.GetComponentInChildren<Text>().text = "Level " + (currentLevelIndex + 2);
				gameOver = true;
				Invoke("LoadLevel", 3f);
			}
		}
	}

	// Fungsi meload level
	void LoadLevel(){
		currentLevelIndex++;
		Instantiate(levels[currentLevelIndex], Vector2.zero, Quaternion.identity);
		numberOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
		gameOver = false;
		loadLevelPanel.SetActive(false);
	}

	// Kondisi speed
	public void SpeedUp(){
		speedUp = true;
	}
}
