using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour {

	[SerializeField] private int score = 100;
	[SerializeField] private Text scoreText;

    // If Ball hits the Target, Cahnge the Layer so the ball ignore plane
	private void OnTriggerEnter(Collider other)
	{
        if (other.tag == "Balls")
        {
            other.enabled = false;
			other.gameObject.layer = LayerMask.NameToLayer("FallingBall");
        }
        GameController.Instance.TotalScore += score;
	}

	public void SetScore(int score)
	{
		this.score = score;
		scoreText.text = score.ToString();
		if (score == 0)
		{
			scoreText.text = " ";
		}
	}

}
