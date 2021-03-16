using UnityEngine;
public interface ICharacter: IDestructible, ISkills
{
    float Life
    {
        get;
        set;
    } 
    bool Def
    {
        get;
        set;
    }
    CharacterData Data
    {
        get;
    }
}
