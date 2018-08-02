using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{

	[SerializeField] private List<Text> scoreTexts = new List<Text>();
	[SerializeField] private List<Text> stageTexts = new List<Text>();

	private void OnEnable()
	{
		SetText(0, GameSave.First_Score, GameSave.First_Stage);
		SetText(1, GameSave.Second_Score, GameSave.Second_Stage);
		SetText(2, GameSave.Third_Score, GameSave.Third_Stage);
		SetText(3, GameSave.Fourth_Score, GameSave.Fourth_Stage);
		SetText(4, GameSave.Fifth_Score, GameSave.Fifth_Stage);
	}

	private void SetText(int n, int score, string stage)
	{
		if (score == 0)
		{
			scoreTexts[n].text = "Nil";
			stageTexts[n].text = "Stage : -";
		}
		else
		{
			scoreTexts[n].text = score.ToString();
			stageTexts[n].text = "Stage : " + stage;
		}
	}

}
