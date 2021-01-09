using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class OpenTutorial : MonoBehaviour
    {
        #region Variables
        [SerializeField] private SceneDirector _director;
        #endregion

        #region Methods
        public void StartTutorial()
        {
            _director.LoadSceneAtIndex(6); //Tutorial
        }
        #endregion
    }
}
