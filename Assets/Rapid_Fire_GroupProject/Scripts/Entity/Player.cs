using UnityEngine;
using UnityEngine.SceneManagement;

namespace RapidFire
{
    public class Player : MonoBehaviour
    {
        [Header("Prefab explosion")]
        [SerializeField]
        GameObject prefabExplosion;

        public void DestroyNow()
        {
            // Instantiate the destroy effect
            GameObject.Instantiate(this.prefabExplosion, transform.position, Quaternion.identity);

            // Deactivate the player
            gameObject.SetActive(false);

            // Call the GameOver method in PlayManager (optional)
            PlayManager.Instance.GameOver();

            // Notify GameOverHandler that the player is destroyed
            GameOverHandler.PlayerDestroyed();

            // Load the Start scene
            SceneManager.LoadScene("Start");
        }
    }
}
