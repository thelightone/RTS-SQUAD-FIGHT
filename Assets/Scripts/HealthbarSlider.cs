using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField]
    private SquadController _squadController;

    private Slider _slider;
    private TMP_Text _damage;
    private Animator _animation;
    int i = 0;
    void Start()
    {
        _slider = GetComponentInChildren<Slider>();
        _damage = GetComponentInChildren<TMP_Text>();
        _animation = _damage.gameObject.GetComponent<Animator>();

        _slider.maxValue = _squadController._maxHealth;
        _slider.value = _squadController._curHealth;
        SquadController.damageEvent.AddListener(UpdateValue);
    }

    private void UpdateValue()
    {

        var diff = _slider.value - _squadController._curHealth;
        if (diff>=1)
        { 
            _damage.text = Convert.ToInt32(diff).ToString();
            _animation.SetTrigger("Change");
        }
        _slider.value = _squadController._curHealth;
    }
}
