using System.Collections.Generic;
using UnityEngine;

public interface ISkills
{
    List<AbstractSkill> GetSkills();

    Sprite SelectSkills(int value);
}
