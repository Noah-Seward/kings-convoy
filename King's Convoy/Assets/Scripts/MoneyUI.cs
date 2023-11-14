using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    public TMP_Text moneyText;

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "$" + PlayerStats.Money.ToString();
    }
}
