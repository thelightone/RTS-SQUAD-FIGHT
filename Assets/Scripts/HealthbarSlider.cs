using UnityEngine;
using UnityEngine.UI;

public class HealthbarSlider : MonoBehaviour
{
    [SerializeField]
    private SquadController _squadController;

    private Slider _slider;

    void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _squadController._maxHealth;
        _slider.value = _squadController._curHealth;
        SquadController.damageEvent.AddListener(UpdateValue);
    }

    private void UpdateValue()
    {
        _slider.value = _squadController._curHealth;
    }
}
