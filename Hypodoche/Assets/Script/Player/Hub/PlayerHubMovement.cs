using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class PlayerHubMovement : MonoBehaviour
    {
        #region Variables
        private Rigidbody _rigidbody;
        private Vector3 _movement;
        [SerializeField] private float _playerSpeed;
        private bool _facesLeft = true;
        [SerializeField] private GameObject _sprite;
        [SerializeField] private float _sprintMultiplier;
        private bool _isSprinting;
        #endregion

        #region Getters and Setters
        public void SetMovement(Vector3 movement)
        {
            _movement = movement;
        }

        public void SetIsSprinting(bool isSprinting)
        {
            _isSprinting = isSprinting;
        }
        #endregion

        #region Methods
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            UpdateSpriteDirection(_movement);
            if(_isSprinting)
                UpdatePosition(_movement * _playerSpeed * _sprintMultiplier, Time.fixedDeltaTime);
            else
                UpdatePosition(_movement * _playerSpeed, Time.fixedDeltaTime);
        }

        private void UpdatePosition(Vector3 movement, float delta)
        {
            if (movement.magnitude != 0)
                _rigidbody.velocity = Vector3.zero; 
            _rigidbody.MovePosition(_rigidbody.position + movement * delta);
        }

        private void UpdateSpriteDirection(Vector3 movement)
        {
            if (movement.x > 0 && _facesLeft ||
                movement.x < 0 && !_facesLeft)
                Flip();
        }

        private void Flip()
        {
            if(_facesLeft){
                _sprite.transform.rotation = Quaternion.Euler(-30,180,0);
            }
            else{
                _sprite.transform.rotation = Quaternion.Euler(30,0,0);     
            }
            _facesLeft = !_facesLeft;
        }
        #endregion   
    }
}
