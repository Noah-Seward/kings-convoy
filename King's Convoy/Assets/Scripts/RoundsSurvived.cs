using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoundsSurvived : MonoBehaviour
{
    public TMP_Text roundsText;

    private void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
    }
}
