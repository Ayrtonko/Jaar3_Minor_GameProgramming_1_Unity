using UnityEngine;

namespace Movement
{
    public class PlayerIdleState : PlayerBaseState
    {
        public override void EnterState(PlayerMoveStateManager playerMovement)
        {
            Debug.Log("Idle-state");
        }

        public override void UpdateState(PlayerMoveStateManager playerMovement)
        {
            MoveCheck(playerMovement);
            FallCheck(playerMovement);
        }

        public override void FixedUpdateState(PlayerMoveStateManager playerMovement)
        {
        }

        public override void OnCollisionEnterState(PlayerMoveStateManager playerMovement, Collision other)
        {
            if (other.gameObject.CompareTag("Floor"))
            {
                playerMovement.SwitchState(playerMovement.playerLost);
            }
        }

        private void MoveCheck(PlayerMoveStateManager playerMovement)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                playerMovement.SwitchState(playerMovement.playerMove);
            }
        }

        private void FallCheck(PlayerMoveStateManager playerMovement)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                playerMovement.SwitchState(playerMovement.playerFall);
            }
        }
    }
}