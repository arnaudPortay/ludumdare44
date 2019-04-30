using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AppHandler : MonoBehaviour
{
    public GameObject restartButton;
    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif        
    }

    public void RestartGame()
    {
        if (restartButton)
        {
            restartButton.GetComponentInChildren<Text>().text = "Loading...";
            restartButton.GetComponent<Button>().interactable = false;
        }
            
        SceneManager.LoadScene(0);
    }
}
