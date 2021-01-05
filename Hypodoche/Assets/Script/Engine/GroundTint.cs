using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class GroundTint : MonoBehaviour
    {
        #region Variables
        [SerializeField] private PlayerStatus _pStatus;
        [SerializeField] private SpriteRenderer _image;
        private float _pValue;
        private Color _color;
        #endregion

        #region Methods
        private void Update()
        {
            _pValue = _pStatus.GetPlayerHealth();
            _color = _image.color;
            _color.a = (100 - _pValue) / 255;
            _image.color = _color;
            Debug.Log(_color.a);
        } 
        #endregion
    }
}
