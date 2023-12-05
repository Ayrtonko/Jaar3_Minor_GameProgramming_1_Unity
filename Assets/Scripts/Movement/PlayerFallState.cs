using UnityEngine;

namespace Movement
{
    public class PlayerFallState : PlayerBaseState
    {
        public override void EnterState(PlayerMoveStateManager playerMovement)
        {
            Debug.Log("Fall-state");
            playerMovement.myRigidbody.useGravity = true;
        }

        public override void UpdateState(PlayerMoveStateManager playerMovement)
        {
            CheckIfUnderFloor(playerMovement);
        }

        public override void FixedUpdateState(PlayerMoveStateManager playerMovement)
        {
            //throw new System.NotImplementedException();
        }

        public override void OnCollisionEnterState(PlayerMoveStateManager playerMovement, Collision other)
        {
            playerMovement.objAudioScript.objBouncingEvent.Invoke();

            if (other.gameObject.CompareTag("Table") || other.gameObject.CompareTag("Player"))
            {
                playerMovement.SwitchState(playerMovement.playerPlaced);
            }

            if (other.gameObject.CompareTag("Floor"))
            {
                playerMovement.SwitchState(playerMovement.playerLost);
            }
        }

        public void CheckIfUnderFloor(PlayerMoveStateManager playerMovement)
        {
            if (playerMovement.myRigidbody.transform.position.y < -3)
            {
                playerMovement.SwitchState(playerMovement.playerLost);
            }
        }
    }
}