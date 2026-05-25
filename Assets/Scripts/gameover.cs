using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    public void GameOver()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
