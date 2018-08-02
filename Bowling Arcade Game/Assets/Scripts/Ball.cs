using UnityEngine;

public class Ball : MonoBehaviour
{
	private const float destoryTime = 5;
	private float counter = 0;
	private bool destoryTiggered = false;

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
