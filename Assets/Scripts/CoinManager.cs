using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
   public int collectableitems;
   public TMP_Text cointext;

    void Start(){
        cointext.text = "Collectable Items: " + collectableitems;
    }
    public void Changecoins(int amount) {
        collectableitems += amount;
        cointext.text = "Collectable Items: " + collectableitems;

    }
}
