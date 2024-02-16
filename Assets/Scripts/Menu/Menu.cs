using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private int _gameSceneIndex;
    public void RunGame()
    {
        SceneManager.LoadScene(_gameSceneIndex);
    }
}