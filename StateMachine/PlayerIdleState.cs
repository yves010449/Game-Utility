using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBehaviourState
{

    public override void OnEnter()
    {
        Debug.Log("idle");
    }
}
