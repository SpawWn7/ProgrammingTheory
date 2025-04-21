using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 15.0f;
    private PlayerController playerControllerScript; // We will need to reference the player controller script as that is where we know when the game is over so that this script can make the background stop moving
    private float leftBound = -15.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false) // If the player controller script's variable (gamneOver) is false, then we keep the background moving. Otherwise we stop moving the background.
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        
        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle")) // Here we are destroying all obstacle objects that move past -15 along the x-axis
        {
            Destroy(gameObject);
        }
    }
}
