using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/Skills/Heal")] 
public class Heal : AbstractSkill
{
    [SerializeField] private float _amount;
    public override void Execute(ICharacter target)
    {
        target.Life += _amount; 
        base.Execute(target);
    }
}
