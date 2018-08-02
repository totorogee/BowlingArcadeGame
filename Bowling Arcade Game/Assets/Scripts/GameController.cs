using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{

	public static GameController Instance;
	public int totalScore = 0;
	private bool scoreUpdated = true;

	[SerializeField] private Text scoreText;
	[SerializeField] public Image powerBarFill;
	[SerializeField] List<Target> targets = new List<Target>();

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
    
	void Start () 
	{
		StageSetting.Instance.InitStage(targets);
	}

	void Update () 
	{
		if (scoreUpdated)
		{
			scoreText.text = totalScore.ToString();
		}
	}
}
