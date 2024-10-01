using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBehaviourState : MonoBehaviour
{
    protected PlayerStateController sc;

    public void OnStateEnter(PlayerStateController stateController)
    {
        // Code placed here will always run
        sc = stateController;
        OnEnter();
    }

    public virtual void OnEnter()
    {
        // Code placed here can be overridden
    }

    public void OnStateUpdate()
    {
        // Code placed here will always run
        OnUpdate();
        
    }

    public virtual void OnUpdate()
    {
        // Code placed here can be overridden
    }


    public void OnStateExit()
    {
        // Code placed here will always run
        OnExit();
    }

    public virtual void OnExit()
    {
        // Code placed here can be overridden
    }
}