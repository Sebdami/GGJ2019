using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float FadeInDuration = 1f;
    public float FadeOutDuration = 1f;
    public bool CanInteract = true;
    public Action OnMinigameWin;
    public Action<int> OnColorUnlock;
    int unlockedColors = 0;

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

    public int UnlockedColors { get => unlockedColors; private set => unlockedColors = value; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    public void UnlockNextColor()
    {
        if(UnlockedColors < 4)
        {
            UnlockedColors++;
            OnColorUnlock?.Invoke(unlockedColors);
        }
    }

    public void PausePlayerController()
    {
        if(PlayerController)
            PlayerController.State = PlayerController.PlayerState.Paused;
    }

    public void UnpausePlayerController()
    {
        if(PlayerController)
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

    public void MinigameWin()
    {
        UnlockNextColor();
        OnMinigameWin?.Invoke();
        GameManager.Instance.LoadLevel("Main");
    }
    
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void Update()
    {
        
    }

}
