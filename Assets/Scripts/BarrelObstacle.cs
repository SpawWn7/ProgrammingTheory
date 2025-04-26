using UnityEngine;

// The children inherit from the Obstacle class. The concept of polymorphism is achieved by the children uniquely modifying their movement speeds.
public class BarrelObstacle : Obstacle
{
    public override float pObstacleSpeed { get; protected set; } = 4.5f;
}
