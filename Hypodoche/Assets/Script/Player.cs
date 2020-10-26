using UnityEngine;

namespace Hypodoche
{
    #region Required Components
    [RequireComponent(typeof(Rigidbody))]
    #endregion

    public class Player : MonoBehaviour
    {
        #region Variables
        [SerializeField] [Range(0f, 10f)] private float _speed = 3f;
        private Rigidbody _rigidBody;
        private float _health;
        private float _horizontal;
        private float _vertical;
        #endregion

        #region Methods
        // Start is called before the first frame update
        void Start()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            _horizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");
        }

        private void FixedUpdate()
        {
            Vector3 movement = Vector3.zero;
            movement.x += _horizontal * _speed * Time.fixedDeltaTime;
            movement.y = 0;
            movement.z += _vertical * _speed * Time.fixedDeltaTime;
            _rigidBody.position += movement;
        }
        #endregion
    }
}
