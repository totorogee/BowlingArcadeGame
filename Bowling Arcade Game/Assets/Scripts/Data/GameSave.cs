using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSave 
{

	public static int First_Score
    {
        get
        {
            return PlayerPrefs.GetInt("First", 100);
        }
        set
        {
			PlayerPrefs.SetInt("First", value);
        }
    }

	public static int Second_Score
    {
        get
        {
			return PlayerPrefs.GetInt("Second", 80);
        }
        set
        {
			PlayerPrefs.SetInt("Second", value);
        }
    }

	public static int Third_Score
    {
        get
        {
			return PlayerPrefs.GetInt("Third", 60);
        }
        set
        {
			PlayerPrefs.SetInt("Third", value);
        }
    }

    public static int Fourth_Score
    {
        get
        {
			return PlayerPrefs.GetInt("Fourth", 40);
        }
        set
        {
			PlayerPrefs.SetInt("Fourth", value);
        }
    }
	public static int Fifth_Score
    {
        get
        {
			return PlayerPrefs.GetInt("Fifth", 20);
        }
        set
        {
			PlayerPrefs.SetInt("Fifth", value);
        }
    }

}
