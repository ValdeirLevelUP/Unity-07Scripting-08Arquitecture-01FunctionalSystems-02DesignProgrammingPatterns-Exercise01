using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/Skills/Defend")] 
public class Defend : AbstractSkill
{ 
    public override void Execute(ICharacter target)
    {
        target.Def = true; 
        base.Execute(target);
    }
}
