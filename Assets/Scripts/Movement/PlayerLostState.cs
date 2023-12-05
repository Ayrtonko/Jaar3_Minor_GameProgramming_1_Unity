using System.Collections;
using System.Collections.Generic;
using Movement;
using UnityEngine;

public class PlayerLostState : PlayerBaseState
{
    public override void EnterState(PlayerMoveStateManager playerMovement)
    {
        Debug.Log("U lost bro");
        ObjectSpawnManager.isAllowdToSpawnFalseEvent?.Invoke();
        GameManager.gameLostEvent?.Invoke();
    }

    public override void UpdateState(PlayerMoveStateManager playerMovement)
    {
        if (ObjectSpawnManager.isAllowedToSpawn)
        {
            playerMovement.SwitchState(playerMovement.playerIdle);
        }
    }

    public override void FixedUpdateState(PlayerMoveStateManager playerMovement)
    {
        // throw new System.NotImplementedException();
    }

    public override void OnCollisionEnterState(PlayerMoveStateManager playerMovement, Collision other)
    {
        playerMovement.objAudioScript.objBouncingEvent.Invoke();

        // throw new System.NotImplementedException();
    }
}