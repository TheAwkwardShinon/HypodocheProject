using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    public class Billboard : MonoBehaviour
    {
        #region Methods
        void Update()
        {
            Vector3 target = new Vector3(transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
            transform.LookAt(target, Vector3.up);
        }
        #endregion
    }
}
