
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
   public int collectableItems = 0;
   public TextMeshProUGUI Cointext;

void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;

        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start(){
      UpdateUI();
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
  void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Cointext = FindAnyObjectByType<TextMeshProUGUI>();
    }
   public void ChangeCoins(int amount)
    {
        collectableItems += amount;
        UpdateUI();
    }
    public void UpdateUI()
    {
        if(Cointext != null)
        {
            Cointext.text = "Collectable Items : "+ collectableItems.ToString();
        }
    }
}
