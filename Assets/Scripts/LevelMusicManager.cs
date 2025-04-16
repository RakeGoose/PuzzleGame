using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMusicManager : MonoBehaviour
{

    private static LevelMusicManager instance;
    private AudioSource audioSource;

    void Awake()
    {

        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
        SceneManager.sceneLoaded += OnSceneLoaded;

        string sceneName = SceneManager.GetActiveScene().name.ToLower();

        if (!IsGameplayScene(sceneName))
        {
            Destroy(gameObject);
        }

        var menuMusic = FindObjectOfType<MenuMusicPlayer>();
        if(menuMusic != null)
        {
            var source = menuMusic.GetComponent<AudioSource>();
            if(source != null)
            {
                source.Stop();
            }
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string sceneName = scene.name.ToLower();

        if (!IsGameplayScene(sceneName))
        {
            Destroy(gameObject);
        }
    }

    private bool IsGameplayScene(string sceneName)
    {
        return sceneName.Contains("level") && !sceneName.Contains("select");
    }

    void OnDestroy()
    {
        if(instance = this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            instance = null;
        }
    }
}
