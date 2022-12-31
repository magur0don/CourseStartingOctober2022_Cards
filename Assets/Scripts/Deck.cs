using System;
using System.Collections.Generic;
using System.Linq;

public class Deck
{
    /// <summary>
    /// トランプのカードデック
    /// </summary>
    public List<Card> CardDeck = new List<Card>();

    /// <summary>
    /// 昇順のDeckをゲットする
    /// </summary>
    public List<Card> GetDeck()
    {
        // 一度作られたデッキがある場合はCardDeckを返す
        if (CardDeck.FirstOrDefault() != null) {
            return CardDeck;
        }

        // デッキがない場合はここでデッキを作成する
        for (int i = 0; i < CardHelper.CardMax; i++)
        {
            CardDeck.Add(new Card(CardHelper.CardSuitJudge(i), CardHelper.CardNumJudge(i)));
        }
        return CardDeck;
    }
}
