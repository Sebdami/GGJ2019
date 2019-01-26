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

    public void LoadLevel(string levelName)
    {
        StartCoroutine(LoadLevelWithFadeOutAndIn(levelName));
    }
    IEnumerator LoadLevelWithFadeOutAndIn(string levelName)
    {
        PlayerController.State = PlayerController.PlayerState.Paused;
        FadeManager.Instance.FadeOut(FadeOutDuration);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelName);

    }

    private void OnLevelWasLoaded(int level)
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
    }

    public void Update()
    {
        
    }

}
