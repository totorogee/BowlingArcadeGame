using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

	[SerializeField] private int score = 100;
    


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision collision)
	{
		Debug.Log("hit : " + collision.collider.tag);
		GameController.Instance.TotalScore += score;
	}

}
