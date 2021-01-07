using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Hypodoche
{
    public class OracleBehaviour : MonoBehaviour
    {
        #region Variables
        [SerializeField] private CanvasGroup _dialogueGroup;
        [SerializeField] private CanvasGroup _interactionGroup;
        private DialogueTrigger _dialogueTrigger;       
        #endregion

        #region Methods
        private void Start()
        {
            _dialogueTrigger = GetComponent<DialogueTrigger>();
        }
        public void Interact()
        {
            _dialogueGroup.alpha = 1;
            _dialogueGroup.interactable = true;
            _dialogueGroup.blocksRaycasts = true;
            _interactionGroup.alpha = 0;
            _dialogueTrigger.TriggerDialogue();
            Debug.Log("Oracle is working");
        }
        #endregion
    }
}
