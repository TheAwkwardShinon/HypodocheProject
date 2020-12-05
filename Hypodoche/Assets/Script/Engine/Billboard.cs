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
        #endregion

        #region Methods

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        void Update()
        {
            if(_spriteRenderer != null)
                _spriteRenderer.sortingOrder = -Mathf.RoundToInt(transform.position.z * 10f);
            Vector3 target = new Vector3(transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
            transform.LookAt(target, Vector3.up);
        }
        #endregion
    }
}