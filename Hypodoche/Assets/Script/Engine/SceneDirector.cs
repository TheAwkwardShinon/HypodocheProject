﻿using System.Collections;
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

    private IEnumerator LoadScene(int sceneIndex)
    {
        _transition.SetTrigger("Start");
        yield return new WaitForSeconds(_transitionTime);
        SceneManager.LoadScene(sceneIndex);
    }
}