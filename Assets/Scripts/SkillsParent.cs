using UnityEngine;

public class SkillsParent : ScriptableObject
{
    public virtual void Activate(GameObject squad)
    {
        return;
    }

    public virtual bool CheckConditions(GameObject squad)
    {
        return false;
    }
}
