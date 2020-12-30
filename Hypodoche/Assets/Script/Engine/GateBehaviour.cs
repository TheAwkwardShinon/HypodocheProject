using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class GateBehaviour : MonoBehaviour
    {
        #region Variables
        [SerializeField] private SceneDirector _sceneDirector;
        #endregion

        #region Methods
        public void Interact()
        {
            _sceneDirector.LoadSceneAtIndex(3);
        }
        #endregion
    }
}
