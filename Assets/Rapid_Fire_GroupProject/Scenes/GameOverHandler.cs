using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField]
    private Text gameOverText;  // Reference to the UI Text object for "Game Over"

    private static bool playerDestroyed = false;  // Static flag to track if the player was destroyed

    private void Awake()
    {
        // Ensure the Game Over text is hidden initially
        if (gameOverText != null)
        {
            gameOverText.enabled = false;
        }

        // Listen to the scene change event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the player was destroyed and if we are in the "Start" scene
        if (playerDestroyed && scene.name == "Start")
        {
            // Show the Game Over text if the scene loaded is Start
            if (gameOverText != null)
            {
                gameOverText.enabled = true;  // Enable the "Game Over" text
            }
        }
    }

    public void ShowGameOver()
    {
        if (gameOverText != null)
        {
            gameOverText.enabled = true;  // Enable the "Game Over" text
        }

        playerDestroyed = false;  // Reset the flag for future sessions
    }

    // This method is called by the Player script when the player is destroyed
    public static void PlayerDestroyed()
    {
        playerDestroyed = true;  // Set the static flag to true
    }

    private void OnDestroy()
    {
        // Unsubscribe from the scene loaded event when the object is destroyed
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
