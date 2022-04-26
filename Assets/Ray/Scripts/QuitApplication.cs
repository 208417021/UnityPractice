using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitApplication : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            Debug.LogError("Game Closed");
            //Application.Quit();
            SceneManager.LoadScene(0);
        }
    }
}
