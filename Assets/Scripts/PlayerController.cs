using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb; // This is a reference to the game object's rigidbody component
    private Animator playerAnim;  // This is a reference to the game object's animator component
    public ParticleSystem explosionParticle; // This is a reference to the explosion effect particle we have as a child object on the player game object
    public ParticleSystem dirtParticle; // This is a reference to the dirt effect particle we have as a child object on the player game object
    private AudioSource playerAudio; // We need the player's audio source component in order to play the two below audio clips. We get the reference to a component in the Start() method per usual
    public AudioClip jumpSound; // This is a reference to an audio clip that makes a jumping sound effect when the player jumps
    public AudioClip crashSound; // This is a reference to an audio clip that makes a crashing sound effect when the player hits an obstacle
    public float jumpForce; // This is how strong the player's jumping force is (Set on the Inspector)
    public float gravityModifier; // We want to set and modify Unity's gravity physics (Set on the Inspector)
    public bool isOnGround = true;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>(); // Since Rigidbodies are not a default component of game objects, we set the component once when the game starts
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
        playerAnim.SetFloat("Speed_f", 1.0f); // We are setting the speed of the animator controller parameter so that the running animation can play
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // We are applying an upward force using the rigidbody component so that the player moves up realistically using Unity's physics engine. ForceMode.Impusle makes it so that the applied force happens isntantly
            playerAnim.SetTrigger("Jump_trig"); // We are setting the trigger parameter of the animator controller by passing in the trigger's name, which can be found on the animator window on Unity. We are making the player do the jump animation.
            isOnGround = false;
            dirtParticle.Stop(); // We stop playing the dirt particle effects when the player is in the air jumping
            playerAudio.PlayOneShot(jumpSound, 0.5f); // We play the jump sound effect when the player jumps through the audio source
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // If the player collides with a collider that is tagged as ground (So the player collides or lands on the ground), then we can allow the player to jump once again
        {
            isOnGround = true;
            dirtParticle.Play(); // We continue kicking up dirt when the player is running on the ground
        }
        else if(collision.gameObject.CompareTag("Obstacle")) // If the player collides with an obstacle then the game is over
        {
            Debug.Log("Game Over");
            playerAnim.SetBool("Death_b", true); // We are setting the players death animation to true so it can reach the death state in the animator controller
            playerAnim.SetInteger("DeathType_int", 1); // We are choosing a specific death animation to play which has an ID of 1
            gameOver = true;
            explosionParticle.Play(); // The explosion sound effect player when the player crashes into an obstacle
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 0.5f); // We play the crash sound effect when the player crashes into an obstacle
        }
    }
}
