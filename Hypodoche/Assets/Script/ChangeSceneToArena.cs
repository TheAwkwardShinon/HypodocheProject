using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hypodoche
{
    public class ChangeSceneToArena : MonoBehaviour
    {
        public void playGame()
        {
            SceneManager.LoadScene("ArenaScene");
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
