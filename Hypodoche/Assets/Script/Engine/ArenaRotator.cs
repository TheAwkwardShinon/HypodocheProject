using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaRotator : MonoBehaviour
{
    #region Variables
    [SerializeField] private float _rotationSpeed = 10f;
    #endregion
    #region Methods
    private void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * _rotationSpeed);
    }
    #endregion
}
