using UnityEngine;
using UnityEngine.Events;

namespace Movement
{
    public class PlayerPlacedState : PlayerBaseState
    {
        public override void EnterState(PlayerMoveStateManager playerMovement)
        {
            Debug.Log("Placed-state");
            playerMovement.setPlacedHeight();
            if (ObjectSpawnManager.isAllowedToSpawn)
            {
                ObjectSpawnManager.spawnObjEvent?.Invoke();
            }
        }

        public override void UpdateState(PlayerMoveStateManager playerMovement)
        {
            // throw new System.NotImplementedException();
        }

        public override void FixedUpdateState(PlayerMoveStateManager playerMovement)
        {
            // throw new System.NotImplementedException();
        }

        public override void OnCollisionEnterState(PlayerMoveStateManager playerMovement, Collision other)
        {
            playerMovement.objAudioScript.objBouncingEvent.Invoke();
            if (other.gameObject.CompareTag("Floor"))
            {
                playerMovement.SwitchState(playerMovement.playerLost);
            }
        }
    }
}