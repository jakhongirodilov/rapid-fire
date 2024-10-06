using UnityEngine;
using UnityEngine.UI;

namespace RapidFire
{
    /// <summary>
    /// GameManager
    /// This class manages the game state, including the score.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        
        [Header("UI Elements")]
        [SerializeField]
        private Text scoreText;  // Reference to the UI Text component to display score

        private int score;

        private void Awake()
        {
            // Singleton pattern to ensure only one GameManager exists
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            score = 0;
            UpdateScoreText();
        }

        /// <summary>
        /// Adds score and updates the UI.
        /// </summary>
        /// <param name="points">Points to add to the score.</param>
        public void AddScore(int points)
        {
            score += points;
            UpdateScoreText();
        }

        /// <summary>
        /// Updates the score text UI.
        /// </summary>
        private void UpdateScoreText()
        {
            if (scoreText != null)
            {
                scoreText.text = "Score: " + score.ToString();
            }
        }
    }
}
