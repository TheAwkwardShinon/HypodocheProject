using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDirector : MonoBehaviour
{
    private bool _waited = false;
    [SerializeField] Animator _transition;
    [SerializeField] float _transitionTime = 1f;
    public void Defeat(float seconds)
    {
        StartCoroutine(WaitForDeathAnimation(seconds));
    }

    private IEnumerator WaitForDeathAnimation(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("DefeatScene");
    }

    public void LoadNextScene()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadSceneAtIndex(int sceneIndex)
    {
        StartCoroutine(LoadScene(sceneIndex));
    }

    public void LoadSceneByName(string sceneName)
    {
        StartCoroutine(LoadScene(sceneName));
    }

    IEnumerator LoadScene(string sceneName)
    {
        _transition.SetTrigger("Start");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
        StartCoroutine(QuitGame());
    }
    private IEnumerator QuitGame()
    {
        _transition.SetTrigger("Start");
        yield return new WaitForSeconds(2);
        Application.Quit();
    }

    private IEnumerator LoadScene(int sceneIndex)
    {
        _transition.SetTrigger("Start");
        yield return new WaitForSeconds(_transitionTime);
        SceneManager.LoadScene(sceneIndex);
    }
}
