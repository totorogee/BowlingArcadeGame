using System.Collections;
using System.Collections.Generic;
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

	// Use this for initialization
	void Start () 
	{
		startCounter = Time.time;
		startCountDown = 3;
		countDownText.text = startCountDown.ToString();

		gameTotalTime = StageSetting.Instance.TimeForStage();

		endCountDown = gameTotalTime;
		inGameTime.text = endCountDown.ToString();
	}
	
	// Update is called once per frame
	void Update () 
	{
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
                    GameTesting.Instance.GameStart = true;
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
                    GameTesting.Instance.GameStart = false;
                    endGameScore.text = GameController.Instance.TotalScore.ToString();
                    // DEBUG
                    rank = Random.Range(0, 5);

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
		Application.Instance.LoadScene(1);
	}
	void OnBackToMain() 
	{ 
		Application.Instance.LoadScene(0);
	}
		


}
