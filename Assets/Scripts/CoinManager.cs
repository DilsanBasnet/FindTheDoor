using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
   public int totalcoins;
   public TMP_Text cointext;

    void Start(){
        cointext.text = "Total Coin:" + totalcoins;
    }
    public void Changecoins(int amount) {
        totalcoins += amount;
        cointext.text = "Total Coin: " + totalcoins;

    }
}
