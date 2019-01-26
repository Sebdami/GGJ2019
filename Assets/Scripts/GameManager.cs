using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float FadeInDuration = 1f;
    public float FadeOutDuration = 1f;



    PlayerController playerController;
    public PlayerController PlayerController
    {
        get
        {
            if (playerController == null)
                playerController = GameObject.FindObjectOfType<PlayerController>();
            return playerController;
        }
    }

    public void PausePlayerController()
    {
        PlayerController.State = PlayerController.PlayerState.Paused;
    }

    public void UnpausePlayerController()
    {
        PlayerController.State = PlayerController.PlayerState.Moving;
    }

    public void LoadLevel(string levelName)
    {
        StartCoroutine(LoadLevelWithFadeOutAndIn(levelName));
    }
    IEnumerator LoadLevelWithFadeOutAndIn(string levelName)
    {
        if(PlayerController != null)
            PlayerController.State = PlayerController.PlayerState.Paused;
        FadeManager.Instance.FadeOut(FadeOutDuration);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelName);

    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        FadeManager.Instance.FadeIn(FadeInDuration);
    }
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void Update()
    {
        
    }

}
