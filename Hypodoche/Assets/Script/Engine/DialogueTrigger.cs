using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche{
    public class DialogueTrigger : MonoBehaviour
    {
        #region Variables
        public Dialogue _dialogue;
        public Dialogue _startingDialogue;
        #endregion

        #region Methods
        public void TriggerDialogue()
        {
            FindObjectOfType<DialogueManager>().StartDialogue(_dialogue);
        }

        public void TriggerStartingDialogue()
        {
            FindObjectOfType<DialogueManager>().StartDialogue(_startingDialogue);
        }
        #endregion
    }
}
