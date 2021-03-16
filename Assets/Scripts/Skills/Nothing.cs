using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/Skills/Nothing")] 
public class Nothing : AbstractSkill
{
    public override void Execute(ICharacter target)
    { 
        base.Execute(target);
    }
}
