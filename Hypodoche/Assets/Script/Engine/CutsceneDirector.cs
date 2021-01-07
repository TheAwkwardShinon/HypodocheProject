using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Hypodoche
{
    public class CutsceneDirector : MonoBehaviour
    {
        #region Variables
        [SerializeField] private DialogueTrigger _dialogueTrigger;
        [SerializeField] private Text _dialogueState;
        private int _stringCounter = 0;
        [SerializeField] private AudioSource _music;
        [SerializeField] private Animator _animator;
        #endregion

        #region Methods
        private void Start()
        {
            _animator.GetComponent<Animator>();
            _dialogueTrigger.TriggerStartingDialogue();
        }

        private void Update()
        {
            if(_stringCounter == 3)
            {
                _animator.SetTrigger("FadeIn");
                _music.Play();
            }
        }

        public void IncreaseCounter()
        {
            _stringCounter++;
        }
        #endregion
    }
}
