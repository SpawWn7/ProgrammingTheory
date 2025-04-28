using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

//This script handles the UI in the main game scene. It should display the user's name entered from the previous scene and also a game over text.
public class MainSceneUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameDisplay;
    private PlayerController playerControllerScript;

    private void Start()
    {
        playerControllerScript = GetComponent<PlayerController>();
        nameDisplay.text = $"{nameDisplay.text} " + MainManager.Instance.name;
    }

    private void Update()
    {
        if (playerControllerScript.gameOver)
        {
            nameDisplay.text = "GAME OVER!\nPress spacebar to restart";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
                    