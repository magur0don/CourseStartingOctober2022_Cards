using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Dealer : MonoBehaviour
{
    private Deck Deck = new Deck(); 

    private void Start()
    {
        Deck.GetDeck();
        Debug.Log($"スート：{Deck.CardDeck.FirstOrDefault().CardSuit} " +
            $"数字：{Deck.CardDeck.FirstOrDefault().Number}");

        // Linqにおける例：where
        // ラムダ式でboolを判定し、List内に判定条件に合致する要素を返す
        var clubCards = Deck.CardDeck.Where(card => card.CardSuit == Card.Suit.Club).ToList();
        var clubOne = clubCards.FirstOrDefault();
        // clubの1


        // Linqにおける例：any
        // ラムダ式でboolを判定し、List内に判定条件に合致するかtrueかflaseで返す
        var clubCardsInHeartCard = Deck.CardDeck.Any(card => card.CardSuit == Card.Suit.Heart);
        // false
    }
}
