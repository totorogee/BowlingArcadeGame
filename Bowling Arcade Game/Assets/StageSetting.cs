using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft;


public class StageSetting : MonoBehaviour {

	[SerializeField] private TextAsset stageConfig;
	private Dictionary<int, StageData> avaliableIStageDic;

	public List<StageData> Datas =new List<StageData>();

	// Use this for initialization
	void Start () {
		Datas = GetStageDatas();
		Debug.Log(Datas.Count + " " + Datas[1].Score9);
	}

	// Update is called once per frame
	void Update () {
		
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
