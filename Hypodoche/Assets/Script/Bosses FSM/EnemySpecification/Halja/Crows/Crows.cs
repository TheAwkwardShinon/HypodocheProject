using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypodoche{
    public interface Crows
    {
        Crows_idleState GetIdleState();
        Crows_MoveState GetMoveState();
        void Movecrow();

    }
}
