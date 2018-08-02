using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft;


public class StageSetting : MonoBehaviour {

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
        get { return stageCount; }
    }
    
	private void Awake()
	{
		Instance = this;
	}

	void Start () {
		Datas = GetStageDatas();
		stageCount = Datas.Count;
	}


	public List<StageData> GetStageDatas()
    {
		if (avaliableIStageDic == null)
        {
			Dictionary<string, StageData> dic = JsonConvert.DeserializeObject<Dictionary<string, StageData>>(stageConfig.text);
			avaliableIStageDic = dic.ConvertKey();
        }
		return new List<StageData>(avaliableIStageDic.Values);
    }
    
	public void InitStage(List<Target> targets)
	{
		StageData data = GetStageDatas()[SelectedStage];
		ballMaterial.bounciness = data.BallBounciness;
		GameTesting.Instance.chargeSpeedMultiplier = data.PowerChargeSpeed;
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

	public int TimeForStage(){
		return Datas[SelectedStage].TimeAllowed;
	}
}
