using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OpeningSceneUI : MonoBehaviour {

	[SerializeField] private Transform leaderBoard;

	[SerializeField] private Button leaderBoardButton;
	[SerializeField] private Button startGameButton;
	[SerializeField] private Button leaderBoardBackButton;

	private void OnEnable()
	{
		leaderBoardButton.onClick.AddListener(OpenLeaderBoard);
		startGameButton.onClick.AddListener(StartGame);
		leaderBoardBackButton.onClick.AddListener(CloseLeaderBoard);
	}

	private void OnDisable()
    {
		leaderBoardButton.onClick.RemoveAllListeners();
		startGameButton.onClick.RemoveAllListeners();
		leaderBoardBackButton.onClick.RemoveAllListeners();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OpenLeaderBoard()
	{
		leaderBoard.gameObject.SetActive(true);
	}

	void StartGame()
    {
		Application.Instance.LoadScene(1);
    }

	void CloseLeaderBoard()
    {
		leaderBoard.gameObject.SetActive(false);
    }
}
