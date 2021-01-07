using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Hypodoche
{
    public class InteractionDisplayBehaviour : MonoBehaviour
    {
        #region Variables
        [SerializeField] private CanvasGroup _displayElement;
        private Text _displayText;
        #endregion

        #region Methods
        private void Start()
        {
            _displayText = _displayElement.GetComponentInChildren<Text>();
        }
        private void OnTriggerEnter(Collider other)
        {
            _displayElement.alpha = 1;
            PlayerHubInputManager input = other.GetComponent<PlayerHubInputManager>();
            if (input != null)
                input.SetInteractingObject(gameObject);
        }

        private void OnTriggerExit(Collider other)
        {
            _displayElement.alpha = 0;
            PlayerHubInputManager input = other.GetComponent<PlayerHubInputManager>();
            if (input != null)
                input.SetInteractingObject(null);
        }
        #endregion
    }
}
