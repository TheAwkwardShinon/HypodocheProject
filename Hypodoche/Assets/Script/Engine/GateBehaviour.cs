using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class GateBehaviour : MonoBehaviour
    {
        #region Variables
        [SerializeField] private SceneDirector _sceneDirector;
        private Animator _animator;
        #endregion

        #region Methods

        private void Start()
        {
            _animator = GetComponentInChildren<Animator>();
        }
        public void Interact()
        {
            _animator.SetTrigger("Open");
            StartCoroutine(WaitForAnimation());
        }

        private IEnumerator WaitForAnimation()
        {
            yield return new WaitForSeconds(1.5f);
            _sceneDirector.LoadSceneAtIndex(3);
        }
        #endregion
    }
}
