using UnityEngine;

[CreateAssetMenu(fileName = "New SkillAttack", menuName = "Skill Attack", order = 51)]
public class SkillAttack : SkillsParent
{
    public int[] thresholds = new int[] { 20, 60 };

    public override void Activate(GameObject squad)
    {
        var squ = squad.GetComponent<SquadController>();
        foreach (var unit in squ._units)
        {
            var animator = unit.gameObject.GetComponent<Animator>();
            if (animator)
            {
                animator.SetTrigger("Skill");
                unit.transform.Find("Fury").GetComponent<ParticleSystem>().Play();
            }
        }
        squ._curHealth -= squ._curHealth * 0.1f;
    }

    public override bool CheckConditions(GameObject squad)
    {
        var ssm = squad.GetComponent<SquadController>();

        foreach (var value in thresholds)
        {
            if (ssm.enemyCurHealth < value && ssm.enemyPrevHealth > value)
                return true;
        }
        return false;
    }
}
