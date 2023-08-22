
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject _skillButton;
    [SerializeField] private GameObject _gameOver;

    private void Start()
    {
        Instance = this;
    }

    public void ShowsSkills()
    {
        _skillButton.SetActive(true);
    }

    public void GameOver()
    {
        _gameOver.SetActive(true);
        _skillButton.SetActive(false);
    }
}
