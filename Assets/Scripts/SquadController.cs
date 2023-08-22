using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class SquadController : MonoBehaviour
{
    [SerializeField]
    private SquadConfig _config;
    public SquadController _enemy;

    public GameObject[] _units;

    private bool _performAttack;
    private bool _performedSkill;
    private SquadSkillManager _skillManager;

    [HideInInspector]
    public float _maxHealth;
    [HideInInspector]
    public float _curHealth;
    [HideInInspector]
    public float _attack;
    [HideInInspector]
    public float _shield;
    [HideInInspector]
    public float _attackSpeed;

    public static UnityEvent damageEvent = new UnityEvent();

    public float enemyCurHealth;
    public float enemyPrevHealth;

    private float healthPerUnit;
    private List<GameObject> _unitList = new List<GameObject>();



    private void Awake()
    {
        _maxHealth = _config.health;
        _curHealth = _config.health;
        _attack = _config.attack;
        _shield = _config.shield;
        _attackSpeed = _config.attackSpeed;

        _skillManager = GetComponentInChildren<SquadSkillManager>();

        healthPerUnit = _maxHealth / _units.Length;
        _unitList = _units.ToList();
    }

    private void FixedUpdate()
    {
        if (_enemy != null)
        {
            if (!_performAttack)
            {
                _performAttack = true;
                StartCoroutine(AttackPause());
            }
        }
    }

    public void ReceiveDamage(float damage)
    {
        _curHealth -= _attack - (_attack * _shield / 100);
        damageEvent.Invoke();

        if (_curHealth < healthPerUnit * (_unitList.Count - 1) && _unitList.Count > 1)
        {
            Death();
        }
        if (_curHealth <= 0 && _unitList.Count > 0)
        {
            _curHealth = 0;
            Death();
        }
    }

    public void DealDamage()
    {
        enemyCurHealth = _enemy._curHealth / _enemy._maxHealth * 100;

        _enemy.ReceiveDamage(_attack);
        _skillManager.CheckSkillConditions();
        _performAttack = false;

        enemyPrevHealth = enemyCurHealth;

        StartCoroutine( EndBattleCheck());
    }


    private IEnumerator AttackPause()
    {
        yield return new WaitForSeconds(1 / _attackSpeed);
        DealDamage();
    }

    private void Death()
    {
        _unitList[0].gameObject.GetComponent<Animator>().SetTrigger("Death");
        Debug.Log("2");
        _unitList.Remove(_unitList[0]);
        Debug.Log("3");
        _units = _unitList.ToArray();
        Debug.Log("4");
    }

    private IEnumerator EndBattleCheck()
    {
        if (_enemy._curHealth <= 0 || _curHealth <= 0)
        {   
            gameObject.transform.Find("AttackTrace").GetComponent<ParticleSystem>().Stop();

            foreach (var unit in _units)
            {
                unit.gameObject.GetComponent<Animator>().SetBool("Idle", true);
            }
            _enemy = null;
            yield return new WaitForSeconds(3);
            StopAllCoroutines();
            MainManager.Instance.FinishGame();
        }
    }
}

