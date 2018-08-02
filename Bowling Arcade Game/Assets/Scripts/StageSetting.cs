using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft;


public class StageSetting : MonoBehaviour {

	public static StageSetting Instance;

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

	private int selectedStage = 0;
	private int stageCount = 1;

	[SerializeField] private TextAsset stageConfig;
	private Dictionary<int, StageData> avaliableIStageDic;

	public List<StageData> Datas =new List<StageData>();

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


}
