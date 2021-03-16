using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/Phases/EnemyTurn")]
public class EnemyTurn : AbstractPhase<BattleSystem>
{
    public override IEnumerator Enter(BattleSystem fsm)
    {
        ICommand skill = fsm.Enemy.GetSkills()[0];

        fsm.Enemy.GetSkills().RemoveAt(0);

        if (skill.SelfTarget)
        { 
            skill.Execute(fsm.Enemy);
        }
        else
        {
            skill.Execute(fsm.Player);
        }

        return base.Enter(fsm);
    }
    public override void Execute(BattleSystem fsm)
    {
        if (fsm.Player.Life > 0)
        {
            fsm.ChangeAction(GameManager.Instance._playerTurn);
        }
        else
        {
            fsm.ChangeAction(GameManager.Instance._endPhase);
        }
    }
}
