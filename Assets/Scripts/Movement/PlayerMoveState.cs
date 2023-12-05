using System.Linq;
using UnityEngine;

namespace Movement
{
    public class PlayerMoveState : PlayerBaseState
    {
        public override void EnterState(PlayerMoveStateManager playerMovement)
        {
            Debug.Log("Move-state");
        }

        public override void UpdateState(PlayerMoveStateManager playerMovement)
        {
        }

        public override void FixedUpdateState(PlayerMoveStateManager playerMovement)
        {
            IdleCheck(playerMovement);
            FallCheck(playerMovement);
            Move(playerMovement);
        }

        public override void OnCollisionEnterState(PlayerMoveStateManager playerMovement, Collision other)
        {
            playerMovement.objAudioScript.objBouncingEvent.Invoke();

            if (other.gameObject.CompareTag("Floor"))
            {
                playerMovement.SwitchState(playerMovement.playerLost);
            }
        }

        private void Move(PlayerMoveStateManager playerMovement)
        {
            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
            {
                playerMovement.myRigidbody.velocity = Vector3.zero;
                Debug.Log("pressing left + rights inputs simultaniously");
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                playerMovement.myRigidbody.AddForce(new Vector3(-playerMovement.speed, 0) * Time.fixedDeltaTime);
            }

            else if (Input.GetKey(KeyCode.RightArrow))
            {
                playerMovement.myRigidbody.AddForce(new Vector3(playerMovement.speed, 0) * Time.fixedDeltaTime);
            }
        }

        private void IdleCheck(PlayerMoveStateManager playerMovement)
        {
            if (!Input.anyKey)
            {
                playerMovement.myRigidbody.velocity = Vector3.zero;
                playerMovement.SwitchState(playerMovement.playerIdle);
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