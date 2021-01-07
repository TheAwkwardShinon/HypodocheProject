using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hypodoche
{
    public interface Minion
    {
        void DestroyMinion();

        float getHealth();

        bool IsIneluttable();
    }
}
