using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche{
    public class DialogueTrigger : MonoBehaviour
    {
        #region Variables
        [SerializeField] private OracleDialogueProgression _odp;
        public Dialogue _startingDialogue;
        #endregion

        #region Methods
        public void TriggerDialogue()
        {
            FindObjectOfType<DialogueManager>().StartDialogue(_odp.AdvanceDialogue());
        }
        #endregion
    }
}
