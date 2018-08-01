using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class GameTesting : MonoBehaviour {

	public bool TestShootTrigger = false;
	public Transform TestShootStartPoint;
	public GameObject BallPrefabs;

	public Vector3 MaxForce;
	public float powerBar;
	private float timePressed = 0;

	[SerializeField] private AnimationCurve powerBarCurve;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () 
	{
		if(TestShootTrigger)
		{
			TestShootTrigger = false;
			TestShoot();
		}
        
		if (Input.GetMouseButtonDown(0))
		{
			timePressed = 0;
		}

		if (Input.GetMouseButton(0))
		{
			timePressed += Time.deltaTime;
			powerBar = timePressed % 2f;
			powerBar = powerBarCurve.Evaluate(powerBar);
			GameController.Instance.powerBarFill.fillAmount = powerBar;
		}

		if(Input.GetMouseButtonUp(0))
		{
			Debug.Log(ReturnClickedObject().name);

		}
        
	}


	void TestShoot(Vector3? start = null )
	{
		GameObject ball;
		if (start != null){
			ball = Instantiate(BallPrefabs, (Vector3)start, Quaternion.identity);
		}
		else{
            ball = Instantiate(BallPrefabs, TestShootStartPoint.position, Quaternion.identity);
		}


        Rigidbody rb = null;
        if (ball.GetComponent<Rigidbody>() != null)
        {
            rb = ball.GetComponent<Rigidbody>();
        }
        else
        {
            rb = ball.AddComponent<Rigidbody>();
        }

		rb.AddForce(MaxForce * powerBar, ForceMode.Impulse);
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
