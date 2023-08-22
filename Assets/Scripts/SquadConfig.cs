using UnityEngine;

[CreateAssetMenu(fileName = "New Squad Config", menuName = "Squad Config", order = 51)]
public class SquadConfig : ScriptableObject
{
    public float health;
    public float shield;
    public float attack;
    public float attackSpeed;
}
