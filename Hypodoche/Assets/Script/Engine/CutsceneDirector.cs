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
        [SerializeField] private OracleDialogueProgression _odp;
        private int _stringCounter = 0;
        [SerializeField] private AudioSource _music;
        [SerializeField] private Animator _animator;
        [SerializeField] private Animator _radixAnimator;
        [SerializeField] private Image _background;
        [SerializeField] private GameObject _buttons;
        [SerializeField] private GameObject _continue;
        private PlayerHubInputManager _playerInput;
        #endregion

        #region Methods
        private void Start()
        {
            _playerInput = FindObjectOfType<PlayerHubInputManager>();
            _animator.GetComponent<Animator>();
            Advance();
        }

        private void Update()
        {
            if(_stringCounter == 3)
            {
                _animator.SetTrigger("FadeIn");
                _music.Play();
            }
        }

        public void Advance()
        {
            Debug.Log("Advancing " + _odp.GetIndex());
            switch (_odp.GetIndex()){
                case 0:
                    _background.enabled = true;
                    _dialogueTrigger.TriggerDialogue();
                    _playerInput.SetAllowInput(false);
                    break;
                case 1:
                    _radixAnimator.SetTrigger("Animate");
                    break;
                case 2:
                    _dialogueTrigger.TriggerDialogue();
                    break;
                case 3:
                    _playerInput.SetAllowInput(true);
                    break;
                case 4: //Default
                default:
                    //ATTIVA BOTTONI
                    _playerInput.SetAllowInput(false);
                    _buttons.SetActive(true);
                    _continue.SetActive(false);
                    _dialogueTrigger.TriggerDialogue();
                    break;
                case 5: //Prediction
                    _dialogueTrigger.TriggerDialogue();
                    _continue.SetActive(false);
                    break;
                case 6: //Quit game
                    _dialogueTrigger.TriggerDialogue();
                    break;
                case 7: //Quit Dialogue
                    _continue.SetActive(true);
                    _dialogueTrigger.TriggerDialogue();
                    _playerInput.SetAllowInput(true);
                    _odp.SetIndex(3);
                    break;

            }
        }

        public void IncreaseCounter()
        {
            _stringCounter++;
        }
        #endregion
    }
}
