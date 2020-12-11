using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    private Animator _animator;
    private int _triggerHash = Animator.StringToHash("Start");
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey)
            _animator.SetTrigger(_triggerHash);
    }
}
