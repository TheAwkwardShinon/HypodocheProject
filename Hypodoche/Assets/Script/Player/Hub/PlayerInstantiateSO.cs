using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    [CreateAssetMenu(menuName = "Data/InstantiatePlayerPosition")]
    public class PlayerInstantiateSO : ScriptableObject
    {
        [SerializeField] private Vector3 _position;

        public Vector3 GetPosition()
        {
            return _position;
        }

        public void SetPosition(Vector3 position)
        {
            _position = position;
        }
    }
}
