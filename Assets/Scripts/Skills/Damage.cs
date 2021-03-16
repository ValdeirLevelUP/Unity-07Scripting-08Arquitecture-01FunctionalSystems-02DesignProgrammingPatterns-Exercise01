using UnityEngine;

[CreateAssetMenu(menuName ="Prototype/Skills/Damage")]
public class Damage : AbstractSkill
{
    [SerializeField] private float _amount;
    public override void Execute(ICharacter target)
    {
        target.TakeDamage(_amount);
        base.Execute(target);
    }
}
