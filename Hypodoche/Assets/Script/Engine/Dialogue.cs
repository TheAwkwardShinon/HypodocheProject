using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche
{
    [System.Serializable]
    public class Dialogue
    {
        [TextArea(3,10)]
        public string[] sentences;
        public string name;
    }

}
