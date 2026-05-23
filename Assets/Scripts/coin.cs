using UnityEngine;

public class coin : MonoBehaviour
{
    public CoinManager coinManager;
    public int value;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        coinManager.Changecoins(1);
        Destroy(gameObject);
    }
}
