using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource _battleSounds;

    public static MainManager Instance;

    void Awake()
    {
        Instance = this;
    }

    public void FinishGame()
    {
        UIManager.Instance.GameOver();
        _battleSounds.Stop();
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
    }
}
