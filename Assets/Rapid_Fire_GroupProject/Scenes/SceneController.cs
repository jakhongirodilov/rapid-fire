using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Method to be called when the button is clicked
    public void OnStartButtonClicked()
    {
        // Load the PlayScene
        SceneManager.LoadScene("PlayScene");
    }
}
