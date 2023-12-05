using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Movement
{
    public class PlayerMoveStateManager : MonoBehaviour
    {
        public static PlayerMoveStateManager current;
        public ObjAudioScript objAudioScript;
        [SerializeField] public float speed;

        private float placedHeight = 0;
        public static float highestPlacedHeight = 0;


        public Rigidbody myRigidbody;

        public PlayerBaseState currentState { get; private set; }

        //states
        public PlayerIdleState playerIdle = new PlayerIdleState();
        public PlayerMoveState playerMove = new PlayerMoveState();
        public PlayerFallState playerFall = new PlayerFallState();
        public PlayerPlacedState playerPlaced = new PlayerPlacedState();
        public PlayerLostState playerLost = new PlayerLostState();


        // Start is called before the first frame update
        void Start()
        {
            objAudioScript ??= GetComponentInChildren<ObjAudioScript>();
            current = this;
            myRigidbody = GetComponent<Rigidbody>();
            currentState = playerIdle;
            currentState.EnterState(this);
        }

        // Update is called once per frame
        void Update()
        {
            currentState.UpdateState(this);
        }

        private void FixedUpdate()
        {
            currentState.FixedUpdateState(this);
        }


        public void SwitchState(PlayerBaseState state)
        {
            currentState = state;
            state.EnterState(this);
        }

        private void OnCollisionEnter(Collision other)
        {
            currentState.OnCollisionEnterState(this, other);
        }

        public void setPlacedHeight()
        {
            if (placedHeight == 0)
            {
                placedHeight = myRigidbody.transform.position.y;
            }

            if (placedHeight >= highestPlacedHeight)
            {
                highestPlacedHeight = placedHeight;
            }
        }

        private void OnCollisionExit(Collision other)
        {
        }
    }
}