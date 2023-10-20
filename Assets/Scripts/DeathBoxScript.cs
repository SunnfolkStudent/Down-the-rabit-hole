using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBoxScript : MonoBehaviour
{
    
    //private SceneController sceneController;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
