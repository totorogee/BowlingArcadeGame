using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSave 
{

	public static int First_Score
    {
        get
        {
            return PlayerPrefs.GetInt("First", 0);
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
			return PlayerPrefs.GetInt("Second", 0);
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
			return PlayerPrefs.GetInt("Third", 0);
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
			return PlayerPrefs.GetInt("Fourth", 0);
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
			return PlayerPrefs.GetInt("Fifth", 0);
        }
        set
        {
			PlayerPrefs.SetInt("Fifth", value);
        }
    }

	public static string First_Stage
    {
        get
        {
			return PlayerPrefs.GetString("First_Stage", " ");
        }
        set
        {
			PlayerPrefs.SetString("First_Stage", value);
        }
    }

	public static string Second_Stage
    {
        get
        {
			return PlayerPrefs.GetString("Second_Stage", " ");
        }
        set
        {
			PlayerPrefs.SetString("Second_Stage", value);
        }
    }

	public static string Third_Stage
    {
        get
        {
			return PlayerPrefs.GetString("Third_Stage", " ");
        }
        set
        {
			PlayerPrefs.SetString("Third_Stage", value);
        }
    }
	public static string Fourth_Stage
    {
        get
        {
			return PlayerPrefs.GetString("Fourth_Stage", " ");
        }
        set
        {
			PlayerPrefs.SetString("Fourth_Stage", value);
        }
    }
	public static string Fifth_Stage
    {
        get
        {
			return PlayerPrefs.GetString("Fifth_Stage", " ");
        }
        set
        {
			PlayerPrefs.SetString("Fifth_Stage", value);
        }
    }


}
