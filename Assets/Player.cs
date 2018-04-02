using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public int score = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//Si le bouton du cardboard ou la barre d'espace a été appuyé 
		if(GvrViewer.Instance.Triggered || Input.GetKeyDown("space")){
			RaycastHit hit;

			//Test si le joueur regarde un objet
			if(Physics.Raycast(transform.position,transform.forward, out hit))
			{
				//Si le joueur regarde une taupe
				if (hit.transform.GetComponent<Taupe> () != null) 
				{
					Taupe taupe = hit.transform.GetComponent<Taupe> ();
					taupe.OnHit ();

					//incrémentation du score
					score++;
				}
			}
		}
	}
}
