using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class SquadSkillManager : MonoBehaviour
{

    [SerializeField]
    private SkillsParent[] _skills;
    public GameObject squad;

    private void Awake()
    {
        squad = gameObject.transform.parent.gameObject;
    }

    public void ActivateSkill(SkillsParent skill)
    {
        skill.Activate(squad);
    }

    public void CheckSkillConditions()
    {
        foreach (var skill in _skills)
        {
            if (skill.CheckConditions(squad))
            {
                if (squad.CompareTag("Player"))
                {
                    UIManager.Instance.ShowsSkills(); //simplified version for example because of only 1 skill
                }
                else
                {
                    ActivateSkill(skill);
                }
            }
        }
    }
}


