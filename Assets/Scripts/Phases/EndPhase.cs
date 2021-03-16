using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/Phases/EndPhase")] 
public class EndPhase : AbstractPhase<BattleSystem>
{
    public override void Execute(BattleSystem fsm)
    {
        fsm.DestroyEnemy();

        fsm.ChangeAction(GameManager.Instance._beginningPhase);
    }
}
