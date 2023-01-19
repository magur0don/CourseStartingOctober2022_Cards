using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Dealer : MonoBehaviour
{
    private Deck Deck = new Deck();

    [SerializeField]
    private SpriteAtlas CardAtlas;

    // トランプを表示するImage
    public Image CardImage;

    // ディーラーにターンを判定してもらう
    public enum Turn {
        Player,
        CPU
    }
    public Turn ActorTurn = Turn.Player;

    // 1つ前に選択したカード
    private Card currentCard;
    // 1つ前に選択したカード
    private Image currentCardImage;

    // トランプを産むルート
    [SerializeField]
    private RectTransform cardBG;

    [SerializeField]
    private ConcentrationPlayerBase Player;

    [SerializeField]
    private ConcentrationPlayerBase CPU;

    private void Start()
    {
        Deck.GetDeck();

        // Linqにおける例：where
        // ラムダ式でboolを判定し、List内に判定条件に合致する要素を返す
        var clubCards = Deck.CardDeck.Where(card => card.CardSuit == Card.Suit.Club).ToList();

        var clubOne = clubCards.FirstOrDefault();
        // clubの1

        // Linqにおける例：any
        // ラムダ式でboolを判定し、List内に判定条件に合致するかtrueかflaseで返す
        var clubCardsInHeartCard = clubCards.Any(card => card.CardSuit == Card.Suit.Heart);
        // false

        // カードを産む
        foreach (var card in Deck.CardDeck)
        {
            var cardImage = Instantiate(CardImage, cardBG);
            // カードを文字列をフックに表示する
            //cardImage.sprite = CardAtlas.GetSprite($"Card_{((int)card.CardSuit * 13) + card.Number - 1}");
            cardImage.sprite = CardAtlas.GetSprite($"Card_54");

            var button = cardImage.gameObject.AddComponent<Button>();

            button.onClick.AddListener(() =>
            {
                switch (ActorTurn)
                {
                    // PlayerのターンだったらCPUのターンに
                    case Turn.Player:
                        Player.CardChoice(card,cardImage);
                        if (!Player.IsMyTurn) {
                            // 選択されたカードを裏むける
                            cardImage.sprite = CardAtlas.GetSprite($"Card_54");
                            Player.currentChoiceCardImage.sprite = CardAtlas.GetSprite($"Card_54");
                            ActorTurn = Turn.CPU;
                            return;
                        }
                        break;

                    case Turn.CPU:
                        // CPUのターンだったらPlayerのターンに
                        CPU.CardChoice(card, cardImage);
                        if (!CPU.IsMyTurn)
                        {
                            // 選択されたカードを裏むける
                            cardImage.sprite = CardAtlas.GetSprite($"Card_54");
                            CPU.currentChoiceCardImage.sprite = CardAtlas.GetSprite($"Card_54");

                            ActorTurn = Turn.Player;
                            return;
                        }
                        break;
                }
                cardImage.sprite = CardAtlas.GetSprite($"Card_{((int)card.CardSuit * 13) + card.Number - 1}");

            });
        }
    }

    // ディーラーに
    private void Update()
    {
        
    }
}
