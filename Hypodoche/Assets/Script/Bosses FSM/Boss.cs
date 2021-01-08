using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hypodoche
{
    public interface Boss
    {
        void DestroyBoss();
        void stepOnTrap(Effects effect);
        float getHealth();

        void setHealth(float value);

        void exitFromTrap();
    }
}