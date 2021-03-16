using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/Phases/PlayerTurn")]
public class PlayerTurn : AbstractPhase<BattleSystem>
{
    public override IEnumerator Enter(BattleSystem fsm)
    {
        ICommand skill = fsm.Player.GetSkills()[0];

        fsm.Player.GetSkills().RemoveAt(0);

        if (skill.SelfTarget)
        {
            skill.Execute(fsm.Player);
        }
        else
        {
            skill.Execute(fsm.Enemy);
        } 
        return base.Enter(fsm);
    }
    public override void Execute(BattleSystem fsm)
    {
        if(fsm.Enemy.Life > 0)
        {
            if(fsm.Player.GetSkills().Count > 0)
            { 
                fsm.ChangeAction(GameManager.Instance._enemyTurn);
            }
            else
            {
                fsm.ChangeAction(GameManager.Instance._beginningPhase);
            }
        }
        else
        {
            fsm.ChangeAction(GameManager.Instance._endPhase);
        }
    }
}
