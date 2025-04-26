using UnityEngine;

// The children inherit from the Obstacle class. The concept of polymorphism is achieved by the children uniquely modifying their movement speeds.
public class RockObstacle : Obstacle
{
    //public override GameObject pObstacle { get; protected set; }
    public override float pObstacleSpeed { get; protected set; } = -3.5f;
    //public override AudioClip pObstacleClip { get; protected set; }
}
