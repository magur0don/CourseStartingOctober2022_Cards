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
    /// デッキを取得する
    /// </summary>
    /// <param name="isShuffle">シャッフルするか否か</param>
    /// <returns></returns>
    public List<Card> GetDeck(bool isShuffle = false)
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

        //  シャッフルする場合はCardDeckをGuidを使って並べ替える
        if (isShuffle)
        {
            return CardDeck = CardDeck.OrderBy(card => Guid.NewGuid()).ToList();
        }

        return CardDeck;
    }

}
