using UnityEngine;

public class coin : MonoBehaviour
{
    public CoinManager coinManager;
    public int value =1;
    void Start()
    {
        if(coinManager == null)
        {
            coinManager = FindAnyObjectByType<CoinManager>();
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
       
        if(coinManager != null)
        {
           coinManager.ChangeCoins(value);
        }
        Destroy(gameObject);
         }
    }
}
