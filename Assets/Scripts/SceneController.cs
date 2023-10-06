using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void Loadscene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("LoadNextLevel"))
        {
            if (SceneManager.GetActiveScene().buildIndex == 8)
            {
                print("last level");
                Application.Quit();
            }
            else
            {
                 SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            }
        }
    }
}
