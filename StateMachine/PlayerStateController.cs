using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    PlayerBehaviourState currentState;

    public PlayerIdleState IdleState;

    private void Start()
    {
        ChangeState(IdleState);
    }

    void Update()
    {
        if (currentState != null)
        {
            currentState.OnStateUpdate();
        }
    }

    public void ChangeState(PlayerBehaviourState newState)
    {
        if (currentState != null)
        {
            currentState.OnStateExit();
        }
        currentState = newState;
        currentState.OnStateEnter(this);
        Debug.Log(currentState);
    }



}
