using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems; // for recognize button which was clicked


public class MainMenu : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }
    public void RollerLevel()
    {
        string level = EventSystem.current.currentSelectedGameObject.name;

        switch(level)
        {
            case "Level1Button":
                SceneManager.LoadScene(4);
                break;
            case "Level2Button":
                SceneManager.LoadScene(5);
                break;
            case "Level3Button":
                Debug.Log(level);
                break;
            default:
                Debug.LogError("You should not see this Error msg");
                break;
        }
    }
    public void RocketLevel()
    {
        string level = EventSystem.current.currentSelectedGameObject.name;

        switch (level)
        {
            case "Level1Button":
                SceneManager.LoadScene(1);
                break;
            case "Level2Button":
                SceneManager.LoadScene(2);
                break;
            case "Level3Button":
                SceneManager.LoadScene(3);
                break;
            default:
                Debug.LogError("You should not see this Error msg");
                break;
        }
    }

    public void Difficulty()
    {
        string difficulty = EventSystem.current.currentSelectedGameObject.name;
        
        switch (difficulty)
        {
            case "EasyButton":
                Debug.Log(difficulty);
                break;
            case "NormalButton":
                Debug.Log(difficulty);
                break;
            default:
                Debug.LogError("You should not see this Error msg");
                break;
        }
    }
    //public void RollerLevel1()
    //{
    //    SceneManager.LoadScene(1);
    //}

    //public void RollerLevel2()
    //{

    //}

    //public void RollerLevel3()
    //{

    //}
    //public void EasyRocket()
    //{

    //}
    //public void NormalRocket()
    //{

    //}
}
