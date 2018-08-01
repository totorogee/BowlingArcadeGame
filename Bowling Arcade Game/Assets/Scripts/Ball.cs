using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

	private const float destoryTime = 5;
	private float counter = 0;
	private bool destoryTiggered = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(destoryTiggered && Time.time > counter)
		{
			destoryTiggered = false;
			Destroy(this.gameObject);
		}
	}

	public void DelayDestory()
	{
		counter = destoryTime + Time.time;
		destoryTiggered = true;
	}

	private void OnCollisionEnter(Collision collision)
    {
		DelayDestory();
    }

}
