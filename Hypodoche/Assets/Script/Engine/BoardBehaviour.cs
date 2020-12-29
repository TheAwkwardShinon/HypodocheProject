using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class BoardBehaviour : MonoBehaviour
    {
        #region Variables
        [SerializeField] private SceneDirector _sceneDirector;
        [SerializeField] private PlayerInstantiateSO _playerPosition;
        [SerializeField] private Transform _playerTransform;
        #endregion

        #region Getters and Setters
        public void SetPlayerTransform(Transform playerTransform)
        {
            _playerTransform = playerTransform;
        }
        #endregion

        #region Methods
        public void Interact()
        {
            _playerPosition.SetPosition(_playerTransform.position);
            _sceneDirector.LoadSceneAtIndex(2);
        }
        #endregion
    }
}
