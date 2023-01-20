using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcentrationGameProgressionManager : MonoBehaviour
{
    [SerializeField]
    private Dealer Dealer;

    public enum GameStates
    {
        Invalide = -1,
        Start,
        Deal,
        Choice,
        GameEnd
    }

    private GameStates gameState = GameStates.Invalide;

    public GameStates GetGameStates {
        get { return gameState; }
    }

    private void Update()
    {
        switch (gameState) {
            case GameStates.Invalide:
                gameState = GameStates.Start;
                break;
            case GameStates.Start:
                // スタートの演出などしたい場合にここで指定する
                gameState = GameStates.Deal;
                break;
            case GameStates.Deal:
                Dealer.Deal();
                gameState = GameStates.Choice;
                break;

            case GameStates.Choice:
                // カードを取り切る
                if (Dealer.GetPlayerCardCount + Dealer.GetCPUCardCount == 52)
                {
                    gameState = GameStates.GameEnd;
                }
                break;

            case GameStates.GameEnd:
                if (Dealer.GetPlayerCardCount > Dealer.GetCPUCardCount)
                {
                    Debug.Log("Playerの勝ち");
                }
                else {

                    Debug.Log("CPUの勝ち");
                }
                break;
        }
        
    }

}
