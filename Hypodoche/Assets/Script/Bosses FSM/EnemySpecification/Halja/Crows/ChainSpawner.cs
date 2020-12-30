using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche{
    public class ChainSpawner : MonoBehaviour
    {
        public void spawn(GameObject go,Vector3 position, Quaternion rotation)
            {
                Instantiate(go, position, rotation);
            }
    }
}
