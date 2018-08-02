using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class StageSetting : MonoBehaviour 
{
	public static StageSetting Instance;
	public List<StageData> Datas = new List<StageData>();

	private Dictionary<int, StageData> avaliableIStageDic;
	private int selectedStage = 0;
	private int stageCount = 1;

	[SerializeField] private PhysicMaterial ballMaterial;
	[SerializeField] private TextAsset stageConfig;

	public int SelectedStage
    {
        get
        {
            return selectedStage;
        }
        set
        {
            selectedStage = value;
        }
    }

    public int StageCount
    {
        get {
			stageCount = GetStageDatas().Count;
			return stageCount; }
    }
    
	private void Awake()
	{
		Instance = this;
	}

	void Start () {
		Datas = GetStageDatas();
		stageCount = Datas.Count;
	}

    /// <summary>
	/// Gets the stage datas on the config text. See https://docs.google.com/spreadsheets/d/111CWJuutraCiOK7WDOeW3XsgWInL8TKAzI8LvNLYLkU/edit#gid=0
    /// </summary>
    /// <returns>The stage datas.</returns>
	public List<StageData> GetStageDatas()
    {
		if (avaliableIStageDic == null)
        {
			Dictionary<string, StageData> dic = JsonConvert.DeserializeObject<Dictionary<string, StageData>>(stageConfig.text);
			avaliableIStageDic = dic.ConvertKey();
        }
		return new List<StageData>(avaliableIStageDic.Values);
    }
    
    /// <summary>
    /// Setting Up Stage for target size, score, ball bounciness and charging speed.
    /// </summary>
    /// <param name="targets">Targets in the plane.</param>
	public void InitStage(List<Target> targets)
	{
		StageData data = GetStageDatas()[SelectedStage];
		ballMaterial.bounciness = data.BallBounciness;
		GameLogic.Instance.ChargeSpeedMultiplier = data.PowerChargeSpeed;

		// Target[0] is the buttom hole; The shape of the wall is different
		InitTarget(targets[0], data.Score0, data.Size0);
		InitTarget(targets[1], data.Score1, data.Size1);
		InitTarget(targets[2], data.Score2, data.Size2);
		InitTarget(targets[3], data.Score3, data.Size3);
		InitTarget(targets[4], data.Score4, data.Size4);
		InitTarget(targets[5], data.Score5, data.Size5);
		InitTarget(targets[6], data.Score6, data.Size6);
		InitTarget(targets[7], data.Score7, data.Size7);
		InitTarget(targets[8], data.Score8, data.Size8);
		InitTarget(targets[9], data.Score9, data.Size9);
	}

    /// <summary>
    /// Inits each target.
    /// </summary>
    /// <param name="target">Target object with target script.</param>
	/// <param name="score">Target's Score.</param>
	/// <param name="size">Target's Size.</param>
	public void InitTarget(Target target, int score , float size)
	{
        
		if (size <=0.1)
		{
			target.gameObject.SetActive(false);
			target.SetScore(0);
		}
		else 
		{
			target.gameObject.SetActive(true);
			target.transform.localScale = new Vector3 (size , 1 , size);
			target.SetScore(score);
		}
	}

    /// <summary>
    /// Get the time allowed for current stage
    /// </summary>
	public int TimeForStage()
	{
		return Datas[SelectedStage].TimeAllowed;
	}

    /// <summary>
    /// Gets the stage name
    /// </summary>
	public string GetStageName()
    {
		return Datas[SelectedStage].StageName;
    }
}
