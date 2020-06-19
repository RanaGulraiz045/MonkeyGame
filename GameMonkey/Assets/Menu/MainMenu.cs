using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SceneFader sceneFader;
    public void PlayGame()
    {
        sceneFader.FadeTo(StartGame());
    }
    public void LevelSelector()
    {
        sceneFader.FadeTo("LevelSelect");
    }
    string level;
    int levelReachVal = PlayerPrefs.GetInt("levelReached",1);
    
    string StartGame()
    {
        switch (levelReachVal)
        {
            case 1:
                {
                    level = "Level01";
                    return level;
                }
            case 2:
                {
                    level = "Level02";
                    return level;
                }
            case 3:
                {
                    level = "Level03";
                    return level;
                }
            case 4:
                {
                    level = "Level04";
                    return level;
                }
            default:
                {
                    level = "Level01";
                    return level;
                }
        }
        
    }
}
