using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
        
		if(Input.GetMouseButtonUp(0)){
			Debug.Log(ReturnClickedObject().name);
		}

	}


	void TestShoot(Vector3 start )
	{ 
		GameObject ball = Instantiate(BallPrefabs, start, Quaternion.identity);
        Rigidbody rb = null;
        if (ball.GetComponent<Rigidbody>() != null)
        {
            rb = ball.GetComponent<Rigidbody>();
        }
        else
        {
            rb = ball.AddComponent<Rigidbody>();
        }

        rb.AddForce(Force, ForceMode.Impulse);
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

	public GameObject ReturnClickedObject()
    {
        RaycastHit hit;
        GameObject target = null;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
        }

        if (target != null)
        {
			TestShoot(hit.point + new Vector3 (0,1.2f,0));
        }

		Debug.Log(hit.point);

        return target;
    }



}
