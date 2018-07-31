using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTesting : MonoBehaviour {

	public bool TestShootTrigger = false;
	public Transform TestShootStartPoint;
	public GameObject BallPrefabs;

	public Vector3 Force;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(TestShootTrigger){
			TestShootTrigger = false;
			TestShoot();
		}
	}

	void TestShoot(){
		GameObject ball = Instantiate(BallPrefabs, TestShootStartPoint.position, Quaternion.identity);
		Rigidbody rb = null;
		if (ball.GetComponent<Rigidbody>() != null){
			rb = ball.GetComponent<Rigidbody>();
		}
		else{
			rb =  ball.AddComponent<Rigidbody>();
		}

		rb.AddForce(Force, ForceMode.Impulse);


	}
}
