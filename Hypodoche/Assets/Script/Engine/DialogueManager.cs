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
        #endregion

        #region Methods
        private void Start()
        {
            _sentences = new Queue<string>();
        }

        public void StartDialogue(Dialogue dialogue)
        {
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
                yield return new WaitForSeconds(0.1f);
            }
        }

        private void EndDialogue()
        {
            _animator.SetBool("isOpen", false);
            Debug.Log("End of conv");
        }
        #endregion
    }
}
