using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    // Encapsulation of the base class memeber fields so that only the children of this class can access it through their public properties
    [SerializeField] private GameObject obstacle;
    [SerializeField] private float obstacleSpeed;
    [SerializeField] private AudioClip obstacleClip;                   

    public virtual GameObject pObstacle { get => obstacle; protected set => obstacle = value; }
    public virtual float pObstacleSpeed { get => obstacleSpeed; protected set => obstacleSpeed = value; }
    public virtual AudioClip pObstacleClip { get => obstacleClip; protected set => obstacleClip = value; }



    /*
    public abstract GameObject obstacle { get; protected set; }
    public abstract float obstacleSpeed { get; protected set; }
    public abstract AudioClip obstacleClip { get; protected set; }
    */

}
