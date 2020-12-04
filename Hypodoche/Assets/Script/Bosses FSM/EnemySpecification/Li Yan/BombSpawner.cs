using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hypodoche {

    public class BombSpawner : MonoBehaviour
    {
        private List<GameObject> _toInstantiate;

        public BombSpawner(List<GameObject> go) {
            _toInstantiate = go;
        }

        void Start()
        {

        }

        public void spawn(Vector3 position, Quaternion rotation)
        {
            Instantiate(_toInstantiate[UnityEngine.Random.Range(0, _toInstantiate.Count)], position, rotation);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
