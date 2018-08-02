using UnityEngine;

public class GameLogic : MonoBehaviour 
{
	public static GameLogic  Instance;

	private float timePressed = 0;
	private bool gameStart = false;
	private float chargeSpeedMultiplier = 1;

	[SerializeField] private AnimationCurve powerBarCurve;
	[SerializeField] private GameObject BallPrefabs;
    [SerializeField] private Vector3 MaxForce;
    [SerializeField] private float powerBar;

	public float ChargeSpeedMultiplier
    {
        get
        {
            return chargeSpeedMultiplier;
        }
        set
        {
            chargeSpeedMultiplier = value;
        }
    }

	public bool GameStart
    {
        get 
		{ 
			return gameStart; 
		}
        set 
		{ 
			gameStart = value; 
		}
    }

	private void Awake()
	{
		if (Instance !=null)
		{
			Destroy(Instance);
		}
		Instance = this;
	}

	void Update () 
	{
		if (GameStart)
		{

            if (Input.GetMouseButtonDown(0))
            {
                timePressed = 0;
            }

            if (Input.GetMouseButton(0))
            {
				timePressed += Time.deltaTime * chargeSpeedMultiplier;
                powerBar = timePressed % 2f;
                powerBar = powerBarCurve.Evaluate(powerBar);
                GameController.Instance.powerBarFill.fillAmount = powerBar;
            }

			if(Input.GetMouseButtonUp(0))
			{
				ReturnClickedObject();
			}
		}
	}

	void Shoot(Vector3 start)
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
			if (target.name == "Plane")
			Shoot(hit.point + new Vector3 (0,1.2f,0));
        }
      
        return target;
    }



}
