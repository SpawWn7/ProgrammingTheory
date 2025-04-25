using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
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
