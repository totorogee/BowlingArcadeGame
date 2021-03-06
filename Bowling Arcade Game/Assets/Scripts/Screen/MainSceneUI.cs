﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneUI : MonoBehaviour {
    
	[SerializeField] private Transform countDownScreen;
	[SerializeField] private Text countDownText;
    
	[SerializeField] private Text inGameScore;
    [SerializeField] private Text inGameTime;

	[SerializeField] private Transform endGamePopup;
	[SerializeField] private Text endGameScore;
	[SerializeField] private Text endGameRank;
	[SerializeField] private Text endGameText;
    
	[SerializeField] private Button endGameRestartButton;
	[SerializeField] private Button endGameMainMenuButton;

	[SerializeField] private List<string> rankText = new List<string>();
	[SerializeField] private List<string> endText = new List<string>();
    
    /// <summary>
    /// The rank. Rank = 0 if Score is too low for a Rank
    /// </summary>
	private int rank = 1;

	// Count Down for game to Start;
	private int startCountDown = 3 ;

	// Counter for start game count down
	private float startCounter;
	private bool gameReady = false;

	// Count Down for game to end;
    private int endCountDown;
    
    // Counter for end game count down
    private float endCounter;
	private bool end = false;
	private int gameTotalTime = 5;


	private void OnEnable()
    {
		endGameRestartButton.onClick.AddListener(OnRestart);
		endGameMainMenuButton.onClick.AddListener(OnBackToMain);
    }

    private void OnDisable()
    {
		endGameRestartButton.onClick.RemoveAllListeners();
		endGameMainMenuButton.onClick.RemoveAllListeners();
    }
    
	void Start () 
	{
		startCounter = Time.time;
		startCountDown = 3;
		countDownText.text = startCountDown.ToString();

		gameTotalTime = StageSetting.Instance.TimeForStage();

		endCountDown = gameTotalTime;
		inGameTime.text = endCountDown.ToString();
	}

	void Update () 
	{
		if (Input.GetKeyDown("escape"))
        {
			OnBackToMain();
        }

		if (!end)
		{
			if (!gameReady)
            {
                if (startCountDown >= 0)
                {
                    countDownText.text = startCountDown.ToString();
                    startCountDown = 3 - Mathf.FloorToInt(Time.time - startCounter);
                }
                else
                {
                    gameReady = true;
					GameLogic.Instance.GameStart = true;
                    countDownScreen.gameObject.SetActive(false);

                    endCountDown = gameTotalTime;
                    endCounter = Time.time;
                }
            }

            if (gameReady)
            {
                if (endCountDown >= 0)
                {
                    inGameTime.text = endCountDown.ToString();
                    endCountDown = gameTotalTime - Mathf.FloorToInt(Time.time - endCounter);
                }
                else
                {
                    gameReady = false;
					GameLogic.Instance.GameStart = false;
                    endGameScore.text = GameController.Instance.TotalScore.ToString();

					rank = SetRank(GameController.Instance.TotalScore);

                    endGameRank.text = rankText[rank];
                    endGameText.text = endText[rank];

                    endGamePopup.gameObject.SetActive(true);
                    endGameRestartButton.gameObject.SetActive(true);

                    if (rank == 1)
                    {
                        endGameRestartButton.gameObject.SetActive(false);
                    }
					end = true;
                }
            }
		}
	}

	void OnRestart()
	{
		GameApplication.Instance.LoadScene(1);
	}
	void OnBackToMain() 
	{ 
		GameApplication.Instance.LoadScene(0);
	}
		
	private int SetRank(int finalScore)
	{
		int result = 0;

		List<int> record = new List<int>
		{
			GameSave.First_Score,
			GameSave.Second_Score,
			GameSave.Third_Score,
			GameSave.Fourth_Score,
			GameSave.Fifth_Score
		};

		List<string> stage = new List<string>
        {
            GameSave.First_Stage,
			GameSave.Second_Stage,
			GameSave.Third_Stage,
			GameSave.Fourth_Stage,
			GameSave.Fifth_Stage
        };

        for (int i = 0; i < 5; i++)
		{
			if (finalScore > record[i])
			{
				result = i + 1;
				break;
			}
		}

		if (result==0)
		{
			return 0;
		}

		record.Insert(result - 1, finalScore);
		stage.Insert(result - 1, StageSetting.Instance.GetStageName());

		GameSave.First_Score = record[0];
		GameSave.Second_Score = record[1];
		GameSave.Third_Score = record[2];
		GameSave.Fourth_Score = record[3];
		GameSave.Fifth_Score = record[4];

		GameSave.First_Stage = stage[0];
		GameSave.Second_Stage = stage[1];
		GameSave.Third_Stage = stage[2];
		GameSave.Fourth_Stage = stage[3];
		GameSave.Fifth_Stage = stage[4];

		return result;
	}
}
