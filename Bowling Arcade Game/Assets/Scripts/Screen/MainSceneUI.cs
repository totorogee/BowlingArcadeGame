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

	private int startCounter;
	private float startingTime;
	private bool gameReady = false;


	private void OnEnable()
	{

	}

	// Use this for initialization
	void Start () 
	{
		startingTime = Time.time;
		startCounter = 3;
        countDownText.text = startCounter.ToString();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (startCounter >=0)
		{
			countDownText.text = startCounter.ToString();
			startCounter = 3 - Mathf.FloorToInt(Time.time - startingTime);

		}
		else
		{
			gameReady = true;
			GameTesting.Instance.GameStart = true;
			countDownScreen.gameObject.SetActive(false);
		}

	}
}
