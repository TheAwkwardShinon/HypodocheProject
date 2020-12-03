using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hypodoche
{
    public interface Boss
    {
        void DestroyBoss();
        void stepOnTrap(Collider col);
        float getHealth();
    }
}