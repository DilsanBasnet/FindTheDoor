using UnityEngine;
using UnityEngine.SceneManagement;

public class Killer : MonoBehaviour
{

    
    private void OnTriggerEnter2D(Collider2D collision){
        string SceneName = SceneManager.GetActiveScene().name;
        {
            
        
         if(collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneName);
        }
        }
    }
}
