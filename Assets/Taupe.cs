using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taupe : MonoBehaviour {

	public float hauteurVisible = 0.2f;
	public float hauteurNonVisible = -0.3f;
	public float speed = 4f;
	public float tempsDeDisparition = 1.5f; //1,5 sec


	private Vector3 targetPosition;
	private float timerDeDisparition = 0f;

	// Use this for initialization
	void Awake () {
		targetPosition = new Vector3 (
			transform.localPosition.x,
			hauteurNonVisible,
			transform.localPosition.z
		);
		transform.localPosition = targetPosition;
	}
	
	// Update is called once per frame
	void Update () {
		timerDeDisparition -= Time.deltaTime;
		if (tempsDeDisparition <= 0f) {
			Hide ();
		}
		//Fait descendre la taupe
		transform.localPosition = Vector3.Lerp (transform.localPosition, targetPosition, Time.deltaTime * speed);
	}

	public void Rise()
	{
		//Transforme la position cible vers le dessus de la table
		targetPosition = new Vector3 (
			transform.localPosition.x,
			hauteurVisible,
			transform.localPosition.z
		);
		timerDeDisparition = tempsDeDisparition;
	}


	/// <summary>
	/// Actions au clic sur la taupe
	/// </summary>
	public void OnHit(){
		Hide ();
	}


	public void Hide()
	{
		//Transforme la position cible vers le dessous de la table
		targetPosition = new Vector3 (
			transform.localPosition.x,
			hauteurNonVisible,
			transform.localPosition.z
		);

	}
}
