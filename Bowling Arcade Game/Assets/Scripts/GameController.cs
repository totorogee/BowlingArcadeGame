using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static GameController Instance;
	private int totalScore = 0;
	private bool scoreUpdated = true;

	[SerializeField] private Text scoreText;
	[SerializeField] public Image powerBarFill;

	public int TotalScore {
		get {
			return totalScore;
		}
		set {
			scoreUpdated = true;
			totalScore = value; 
		}
	}

	private void Awake()
	{
		Instance = this;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (scoreUpdated)
		{
			scoreText.text = totalScore.ToString();
		}


	}
}
