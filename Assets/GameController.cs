using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject taupeContainer;
	public TextMesh infoText;
	public Player player;
	public float minimumSpawnDuration = 0.5f;
	public float spawnDecrement = 0.1f;
	public float spawnDuration = 1.5f;
	public float gameTimer = 15f;

	private Taupe[] taupes;
	private float spawnTimer = 0f;
	private float resetTimer = 3f;

	// Use this for initialization
	void Start () {
		taupes = taupeContainer.GetComponentsInChildren<Taupe> ();

	}
	
	// Update is called once per frame
	void Update () {

		gameTimer -= Time.deltaTime;
		if (gameTimer > 0f) {
			infoText.text = "Tape toutes les taupes !\nTemps restant : " + Mathf.Floor (gameTimer) + "\nScore : " + player.score;
			spawnTimer -= Time.deltaTime;	
			if (spawnTimer <= 0f) {
				//récupère une taupe du plateau au hasard et la fait monter
				taupes[Random.Range(0,taupes.Length)].Rise();

				//Fait spawn de plus en plus vite les taupes
				spawnDuration -= spawnDecrement;

				if (spawnDuration < minimumSpawnDuration) {
					spawnDuration = minimumSpawnDuration;
				}
				spawnTimer = spawnDuration;
			}
		
		
		
		} else {
			infoText.text = "Temps écoulé ! Score final : " + Mathf.Floor (player.score);

			resetTimer -= Time.deltaTime;

			if (resetTimer < 0f) {
				SceneManager.LoadScene (SceneManager.GetActiveScene().name);
			}
		}
	}
}
