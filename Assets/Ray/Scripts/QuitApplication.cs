using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitApplication : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if (SceneManager.GetActiveScene().buildIndex == 1)
                SceneManager.LoadScene(PlayerPrefs.GetInt("Saved"));
            else
                SaveStage();
            //Application.Quit();
        }
    }
    void SaveStage()
    {
        PlayerPrefs.SetInt("Saved", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(1);
    }
}
