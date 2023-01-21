using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConcentrationStartScene : MonoBehaviour
{
    [SerializeField]
    Button startButton;
    void Start()
    {
        startButton.onClick.AddListener(() => {
            GameSceneUtil.Instance.SingleSceneTransration(ConcentrationGameStringResource.CONCENTRATION_GAME_MAIN_SCENE);
        });
    }
}
