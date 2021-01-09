using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    [CreateAssetMenu()]
    public class OracleDialogueProgression : ScriptableObject
    {
        #region Variables
        [SerializeField] private int _index = 0;
        [SerializeField] private List<Dialogue> _dialogues;
        #endregion

         #region Getters and Setters
         public int GetIndex()
         {
             return _index;
         }

         public void SetIndex(int index)
         {
             _index = index;
         }
         #endregion

        #region Methods
        public Dialogue AdvanceDialogue(){
            Dialogue _nextDialogue = _dialogues[_index];
            _index++;
            if(_index == _dialogues.Count)
                _index--;
            return _nextDialogue;
        }

        public void IncreaseIndex()
        {
            _index++;
        }

        public void ResetIndex()
        {
            _index = 0;
        }
        #endregion
    }
}
