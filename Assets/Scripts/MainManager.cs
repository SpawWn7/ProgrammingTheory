using UnityEngine;
using UnityEngine.SceneManagement;
public class MainManager : MonoBehaviour
{
    private static MainManager Instance;
    private string name;

    private void Awake()
    {
        if(Instance!=null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
