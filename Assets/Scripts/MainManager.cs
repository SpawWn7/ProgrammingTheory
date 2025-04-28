using UnityEngine;
using UnityEngine.SceneManagement;

// This will allow some data persistance between scenes. Specifically we are allowing the name entered by the user to be displayed on the next scene.
public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public string name;

    private void Awake()
    {
        if(Instance!=null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        name = "John Doe";
        DontDestroyOnLoad(gameObject);
    }

    public void StartMainScene()
    {
        SceneManager.LoadScene(1);
    }

    public void ReadUserInput(string input)
    {
        name = input;
    }
}