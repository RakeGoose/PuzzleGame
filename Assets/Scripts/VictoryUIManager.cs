using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryUIManager : MonoBehaviour
{

    public RectTransform panelTransform;
    public float bounceHeight = 60f;
    public float animationSpeed = 15f;

    private Vector2 targetPosition;
    private Vector2 velocity;

    void OnEnable()
    {
        panelTransform.anchoredPosition = new Vector2(0, Screen.height + 500);
        targetPosition = Vector2.zero;

        StartCoroutine(BounceIn());
    }

    IEnumerator BounceIn()
    {
        for(int i = 0; i < 2; i++)
        {
            Vector2 overshoot = targetPosition - new Vector2(0, bounceHeight / (i + 1));
            while (Vector2.Distance(panelTransform.anchoredPosition, overshoot) > 1f)
            {
                panelTransform.anchoredPosition = Vector2.SmoothDamp(panelTransform.anchoredPosition, overshoot, ref velocity, 0.15f);
                yield return null;
            }
        }

        while (Vector2.Distance(panelTransform.anchoredPosition, targetPosition) > 0.1f)
        {
            panelTransform.anchoredPosition = Vector2.SmoothDamp(panelTransform.anchoredPosition, targetPosition, ref velocity, 0.1f);
            yield return null;
        }

        panelTransform.anchoredPosition = targetPosition;
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
