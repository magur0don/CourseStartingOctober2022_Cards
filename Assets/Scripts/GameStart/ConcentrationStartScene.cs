using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Unity.VisualScripting;

public class ConcentrationStartScene : MonoBehaviour
{
    [SerializeField]
    Button OnePlayerStartButton;
    [SerializeField]
    Button TwoPlayerStartButton;

    void Start()
    {
        OnePlayerStartButton.onClick.AddListener(() => {

            GameSceneUtil.Instance.SingleSceneTransration(ConcentrationGameStringResource.CONCENTRATION_GAME_MAIN_SCENE,
                ()=> OnePlayerStartButtonAction());

        });

        TwoPlayerStartButton.onClick.AddListener(() => {

            GameSceneUtil.Instance.SingleSceneTransration(ConcentrationGameStringResource.CONCENTRATION_GAME_MAIN_SCENE);

        });
    }

    /// <summary>
    /// 呼び出し先のConcentrationGameProgressionManagerにCPUCardはComputerが選択してと伝える
    /// </summary>
    public void OnePlayerStartButtonAction() {
        var gameProgressionManagerGameObject = GameSceneUtil.Instance.
            NextSceneRootGetGameObjects.Where(x =>x.GetComponent<ConcentrationGameProgressionManager>()).FirstOrDefault();
        if (gameProgressionManagerGameObject != null) {

            var gameProgressionManager = gameProgressionManagerGameObject.GetComponent<ConcentrationGameProgressionManager>();
            gameProgressionManager.GameMode = ConcentrationGameProgressionManager.GameModes.CPUCardIsComputersChoice;
        }

    }
}
