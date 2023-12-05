using System.Collections;
using System.Collections.Generic;
using Movement;
using UnityEngine;

public class ObjAudioManager : MonoBehaviour
{
    private PlayerMoveStateManager obj;
    
    private bool hasFallen = false;
    // Start is called before the first frame update
    void Start()
    {
        obj ??= GetComponentInParent<PlayerMoveStateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckFalling();
    }

    void CheckFalling()
    {
        if (hasFallen)
        {
            return;
        }
        if (this.obj.currentState is PlayerPlacedState || this.obj.currentState is PlayerLostState)
        {
            obj.objAudioScript.objStopFallingEvent.Invoke();
            obj.objAudioScript.objLandedEvent.Invoke();
            hasFallen = true;
        }
        if (this.obj.currentState is PlayerFallState)
        {
            obj.objAudioScript.objFallingEvent.Invoke();
        }
    }
    
}
