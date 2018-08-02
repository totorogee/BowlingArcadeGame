using UnityEngine;
using UnityEngine.SceneManagement;

public class GameApplication : MonoBehaviour
{
    public static GameApplication Instance;

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

    public void LoadScene(int number)
    {
        if (SceneManager.sceneCount < number - 1)
        {
            Debug.LogWarning("Worng Scene Number :" + number);
            return;
        }
        SceneManager.LoadScene(number, LoadSceneMode.Single);
    }
}
