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
            case 5:
                {
                    level = "Level05";
                    return level;
                }
            case 6:
                {
                    level = "Level06";
                    return level;
                }
            case 7:
                {
                    level = "Level07";
                    return level;
                }
            case 8:
                {
                    level = "Level08";
                    return level;
                }
            case 9:
                {
                    level = "Level09";
                    return level;
                }
            case 10:
                {
                    level = "Level10";
                    return level;
                }
            case 11:
                {
                    level = "Level11";
                    return level;
                }
            case 12:
                {
                    level = "Level12";
                    return level;
                }
            case 13:
                {
                    level = "Level13";
                    return level;
                }
            case 14:
                {
                    level = "Level14";
                    return level;
                }
            case 15:
                {
                    level = "Level15";
                    return level;
                }
            case 16:
                {
                    level = "Level16";
                    return level;
                }
            case 17:
                {
                    level = "Level17";
                    return level;
                }
            case 18:
                {
                    level = "Level18";
                    return level;
                }
            case 19:
                {
                    level = "Level19";
                    return level;
                }
            case 20:
                {
                    level = "Level20";
                    return level;
                }
            case 21:
                {
                    level = "Level21";
                    return level;
                }
            case 22:
                {
                    level = "Level22";
                    return level;
                }
            case 23:
                {
                    level = "Level23";
                    return level;
                }
            case 24:
                {
                    level = "Level24";
                    return level;
                }
            case 25:
                {
                    level = "Level25";
                    return level;
                }
            case 26:
                {
                    level = "Level26";
                    return level;
                }
            case 27:
                {
                    level = "Level27";
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
