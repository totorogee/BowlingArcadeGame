using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour {

	[SerializeField] private int score = 100;
	[SerializeField] private Text scoreText;
    


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
        if (other.tag == "Balls")
        {
            other.enabled = false;
			other.gameObject.layer = LayerMask.NameToLayer("FallingBall");
        }
        GameController.Instance.TotalScore += score;
	}



	public void SetScore(int score)
	{
		this.score = score;
		scoreText.text = score.ToString();
		if (score == 0){
			scoreText.text = " ";
		}
	}

}
