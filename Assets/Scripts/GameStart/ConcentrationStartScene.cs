using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
public class ConcentrationStartScene : MonoBehaviour
{
    [SerializeField]
    Button OnePlayerStartButton;
    [SerializeField]
    Button TwoPlayerStartButton;

    private bool resoucesLoadComplete = false;
    void Start()
    {
        GameSoundManager.Instance.Initialize();
        OnePlayerStartButton.onClick.AddListener(() =>
        {
            if (!resoucesLoadComplete)
            {
                return;
            }
            GameSceneUtil.Instance.SingleSceneTransration(ConcentrationGameStringResource.CONCENTRATION_GAME_MAIN_SCENE,
                ()=> OnePlayerStartButtonAction());

        });

        TwoPlayerStartButton.onClick.AddListener(() =>
        {
            if (!resoucesLoadComplete)
            {
                return;
            }
            GameSceneUtil.Instance.SingleSceneTransration(ConcentrationGameStringResource.CONCENTRATION_GAME_MAIN_SCENE);

        });

        // BGMなどのサウンドファイルをロードする
        StartCoroutine(soundResourcesLoad());
        // エフェクトをロードする
        StartCoroutine(effectResourcesLoad());

        StartCoroutine(startBGM());
    }

    IEnumerator soundResourcesLoad()
    {
        var bgmLoadhandle = Addressables.LoadAssetsAsync<AudioClip>("BGM", null);
        yield return bgmLoadhandle;
        for(int i = 0; i < bgmLoadhandle.Result.Count; i++)
        {
            GameSoundManager.Instance.SetBGMAudioClips(bgmLoadhandle.Result[i]);
        }
        Addressables.Release(bgmLoadhandle);

        var seLoadhandle = Addressables.LoadAssetsAsync<AudioClip>("SE", null);
        yield return seLoadhandle;
        for (int i =0 ; i < seLoadhandle.Result.Count; i++)
        {
            GameSoundManager.Instance.SetSEAudioClips(seLoadhandle.Result[i]);
        }
        Addressables.Release(seLoadhandle);
    }

    IEnumerator effectResourcesLoad()
    {
        var effectLoadhandle = Addressables.LoadAssetsAsync<GameObject>("GameMainFX", null);
        yield return effectLoadhandle;
        for (int i = 0; i < effectLoadhandle.Result.Count; i++)
        {
            GameVisualEffectManager.Instance.SetGameMainResultParticleSystems(effectLoadhandle.Result[i]);
        }
        Addressables.Release(effectLoadhandle);

        resoucesLoadComplete = true;
    }

    IEnumerator startBGM() {

        yield return new WaitUntil(()=> resoucesLoadComplete);

        GameSoundManager.Instance.PlayBGM(GameSoundManager.BGMTypes.GameStart);
    }
    /// <summary>
    /// 呼び出し先のConcentrationGameProgressionManagerにCPUCardはComputerが選択してと伝える
    /// </summary>
    public void OnePlayerStartButtonAction() {
        var gameProgressionManagerGameObject = GameSceneUtil.Instance.
            NextSceneRootGetGameObjects.Where(x => x.GetComponentInChildren<ConcentrationGameProgressionManager>()).FirstOrDefault();
        if (gameProgressionManagerGameObject != null) {

            var gameProgressionManager = gameProgressionManagerGameObject.GetComponent<ConcentrationGameProgressionManager>();
            gameProgressionManager.GameMode = ConcentrationGameProgressionManager.GameModes.CPUCardIsComputersChoice;
        }

    }
}
