using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayerOrderer : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private int _initialOrder;
    private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _initialOrder = _spriteRenderer.sortingOrder;
        }
    void Update()
    {
        if(_spriteRenderer != null)
            _spriteRenderer.sortingOrder = _initialOrder - Mathf.RoundToInt(transform.root.position.z * 10f);
            Vector3 target = new Vector3(transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
    }
}
