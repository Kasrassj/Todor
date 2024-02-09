using UnityEngine;
using UnityEngine.SceneManagement; // Import the SceneManager namespace

public class NextScene : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that triggered the event is the player
        if (other.CompareTag("Player")) // Make sure the player has the tag "Player"
        {
            // Get the current scene index
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            // Calculate the next scene index
            int nextSceneIndex = currentSceneIndex + 1;

            // Check if the next scene index exceeds the number of scenes available
            if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
            {
                // If it's the last scene, you might want to loop back to the first one or handle it differently
                // For now, we'll just loop back to the first scene
                nextSceneIndex = 0;
            }

            // Load the next scene
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
