using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 神経衰弱のプレイヤーの基底クラス
/// </summary>
public class ConcentrationPlayerBase : MonoBehaviour
{
    public int Score;

    public Card currentChoiceCard;

    public Image currentChoiceCardImage;

    // 継承先で処理をかく
    public virtual void CardChoice(Card choiceCard, Image choiceCardImage) {

        if (currentChoiceCard == null)
        {
            currentChoiceCard = choiceCard;
            currentChoiceCardImage = choiceCardImage;
            return;
        }
        if (currentChoiceCard.Number == choiceCard.Number)
        {
            // ペアが揃ったので消す
            currentChoiceCardImage.gameObject.SetActive(false);
            choiceCardImage.gameObject.SetActive(false);
            currentChoiceCard = null;
            return;
        }

    }
}
