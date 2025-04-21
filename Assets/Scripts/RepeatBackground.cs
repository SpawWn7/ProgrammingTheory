using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 startPos; // This is the starting position of the backhround that we want to reset to when we reached the half way point (repeatWidth)
    private float repeatWidth; // This is what we will use to determine when to reset or repeat the background for a seamless transition through the scenery
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2; // We aquire the half way point along the x-axis through the box collider component
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - repeatWidth) // Once the background has moved far enough from the starting position (half way / repeat width) we will reset the position of the background of it's original position
        {
            transform.position = startPos;
        }
    }
}
