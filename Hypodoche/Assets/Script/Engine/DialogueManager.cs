using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Hypodoche
{
    public class DialogueManager : MonoBehaviour
    {
        #region Variables
        private Queue<string> _sentences;
        [SerializeField] private Text _dialogueText;
        [SerializeField] private Text _nameText;
        [SerializeField] private Animator _animator;
        [SerializeField] private CutsceneDirector _cutsceneDirector;
        [SerializeField] private GameObject _displayInteraction;

        private bool _currentlyTyping;
        private string _completeText;
        #endregion

        #region Methods
        private void Start()
        {
            _sentences = new Queue<string>();
        }

        public void StartDialogue(Dialogue dialogue)
        {
            Debug.Log("Starting Dialogue");
            _displayInteraction.SetActive(false);
            _animator.SetBool("isOpen", true);
            _nameText.text = dialogue.name;

            _sentences.Clear();

            foreach (string sentence in dialogue.sentences)
            {
                _sentences.Enqueue(sentence);
            }
            DisplayNextSentence();
        }

        public void DisplayNextSentence()
        {
            if (_currentlyTyping)
            {
                CompleteText();
                StopAllCoroutines();
                _currentlyTyping = false;                  
                return;
            }

            if (_sentences.Count == 0){
                EndDialogue();
                return;
            }

            string sentence = _sentences.Dequeue();
            _completeText = sentence;
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }

        IEnumerator TypeSentence(string sentence)
        {
            _currentlyTyping = true;
            _dialogueText.text = "";
            foreach(char c in sentence.ToCharArray())
            {
                _dialogueText.text += c;
                yield return new WaitForSeconds(0.07f);
            }
            _currentlyTyping = false;
        }

        private void CompleteText()
        {
            _dialogueText.text = _completeText;
        }

        private void EndDialogue()
        {
            Debug.Log("End Dialogue");
            _displayInteraction.SetActive(true);
            _animator.SetBool("isOpen", false);
            _cutsceneDirector.Advance();
        }

        public void HideDialogue()
        {
            _animator.SetBool("isOpen", false);
        }
        #endregion
    }
}
