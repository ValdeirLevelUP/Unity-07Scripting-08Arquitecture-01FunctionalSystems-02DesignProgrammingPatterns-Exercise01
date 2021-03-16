using System.Collections; 
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/Phases/BeginningPhase")]
public class BeginningPhase : AbstractPhase<BattleSystem>
{
    public override IEnumerator Enter(BattleSystem fsm)
    {
        fsm.SetEnemy();

        fsm.Player.ResetSkills();

        fsm.EndPahse = true;

        for (int i = 0; i < 3; i++)
        {
            FindObjectOfType<HudController>().SetIconEnemy(i, fsm.Enemy.SelectSkills(i));
        }

        return base.Enter(fsm);
    }
    public override void Execute(BattleSystem fsm) { }

    public override IEnumerator Exit(BattleSystem fsm)
    {
        fsm.EndPahse = false;    

        return base.Exit(fsm);
    }
}
