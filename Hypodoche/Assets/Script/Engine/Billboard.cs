using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    #region Required Components
    [RequireComponent(typeof(SpriteRenderer))]
    #endregion
    public class Billboard : MonoBehaviour
    {
        #region Variables
        private SpriteRenderer _spriteRenderer;
        private int _initialValue;
        #endregion

        #region Methods

        private void Awake()
        { 
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _initialValue = _spriteRenderer.sortingOrder;
        }
        void Update()
        {
            if(_spriteRenderer != null)
                _spriteRenderer.sortingOrder = _initialValue - Mathf.RoundToInt(transform.position.z * 10f);
            Vector3 target = new Vector3(transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
            transform.LookAt(target, Vector3.up);
        }
        #endregion
    }
}