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
            if(_sentences.Count == 0){
                EndDialogue();
                return;
            }
            string sentence = _sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }

        IEnumerator TypeSentence(string sentence)
        {
            _dialogueText.text = "";
            foreach(char c in sentence.ToCharArray())
            {
                _dialogueText.text += c;
                yield return new WaitForSeconds(0.05f);
            }
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
