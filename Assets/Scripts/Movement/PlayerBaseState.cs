using UnityEngine;

namespace Movement
{
    public abstract class PlayerBaseState
    {
        public abstract void EnterState(PlayerMoveStateManager playerMovement);
        public abstract void UpdateState(PlayerMoveStateManager playerMovement);
        public abstract void FixedUpdateState(PlayerMoveStateManager playerMovement);
        public abstract void OnCollisionEnterState(PlayerMoveStateManager playerMovement, Collision other);

    }
}