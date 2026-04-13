using System;
using System.Collections;
using UnityEngine;

public class Hero : Character
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case CharState.Walk:
                WalkUpdate();
                break;
            case CharState.WalkToEnemy:
                WalkToEnemyUpdate();
                break;
            case CharState.Attack:
                AttackUpdate();
                break;
            case CharState.WalkToMagicCast:
                WalkToMagicCastUpdate();
                break;
            case CharState.walkToNPC:
                WalkToNpcUpdate();
                break;
        }
    }

    protected void WalkToNpcUpdate()
    {
        float distance = Vector3.Distance(transform.position,
                                        curCharTarget.transform.position);
        if (distance <= 2)
        {
            navAgent.isStopped = true;
            SetState(CharState.Idle);

            Npc npc = curCharTarget.GetComponent<Npc>();

            uiManager.PrepareDialogueBox(npc);
        }
    }

}
