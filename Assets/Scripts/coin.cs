using UnityEngine;

public class coin : MonoBehaviour
{
    public CoinManager coinManager;
    public int value;
    void Start()
    {
        if(coinManager == null)
        {
            coinManager = FindAnyObjectByType<CoinManager>();
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(coinManager != null)
        {
            coinManager.Changecoins(1);
        }
        else
        {
            Debug.LogError("coinManager missing");
        }
        Destroy(gameObject);
    }
}
