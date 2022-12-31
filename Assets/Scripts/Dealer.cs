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
    }
}
