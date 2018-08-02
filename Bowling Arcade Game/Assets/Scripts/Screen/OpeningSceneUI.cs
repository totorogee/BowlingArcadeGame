using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OpeningSceneUI : MonoBehaviour {

	[SerializeField] private Transform leaderBoard;

	[SerializeField] private Button leaderBoardButton;
	[SerializeField] private Button startGameButton;
	[SerializeField] private Button leaderBoardBackButton;
	[SerializeField] private Button selectStageButton;
	[SerializeField] private Text stageText;

	private void OnEnable()
	{
		leaderBoardButton.onClick.AddListener(OpenLeaderBoard);
		startGameButton.onClick.AddListener(StartGame);
		leaderBoardBackButton.onClick.AddListener(CloseLeaderBoard);
		selectStageButton.onClick.AddListener(SelectStage);
	}

	private void OnDisable()
    {
		leaderBoardButton.onClick.RemoveAllListeners();
		startGameButton.onClick.RemoveAllListeners();
		leaderBoardBackButton.onClick.RemoveAllListeners();
		selectStageButton.onClick.RemoveAllListeners();
    }

	private void Start()
	{
		stageText.text = StageSetting.Instance.GetStageDatas()[StageSetting.Instance.SelectedStage].StageName;
    
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

	void SelectStage()
	{
		
		if (StageSetting.Instance.SelectedStage < StageSetting.Instance.StageCount -1 )
		{
			StageSetting.Instance.SelectedStage++;
		}
		else
		{
			StageSetting.Instance.SelectedStage = 0;
		}

		stageText.text = StageSetting.Instance.GetStageDatas()[StageSetting.Instance.SelectedStage].StageName;

	}
}
