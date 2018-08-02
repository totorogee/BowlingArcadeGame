using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Application : MonoBehaviour {

	public static Application Instance;

	private void Awake()
	{
		if (Instance != null)
		{
			Destroy(Instance);
			Destroy(Instance.gameObject);
		}

			Instance = this;
            DontDestroyOnLoad(this.gameObject);
   
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadScene(int number)
    {
		if (SceneManager.sceneCount < number -1)
		{
			Debug.LogWarning("Worng Scene Number :" + number);
			return;
		}
		SceneManager.LoadScene(number, LoadSceneMode.Single);
    }
}
