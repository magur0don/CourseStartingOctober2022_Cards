using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ConcentrationPlayer : ConcentrationPlayerBase
{


    public TextMeshProUGUI ScoreText;
    /// <summary>
    /// Playerの選択を
    /// </summary>
    public override void CardChoice(Card choiceCard,Image choiceCardImage)
    {
        base.CardChoice(choiceCard,choiceCardImage);
        ScoreText.text = $"PlayerScore:{Score}";

    }
}
