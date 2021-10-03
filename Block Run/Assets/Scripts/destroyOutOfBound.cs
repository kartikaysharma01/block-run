using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOutOfBound : MonoBehaviour
{
    private float leftBound = -10.0f;
    private float playerPosX = 6.25f;
    private bool obstacle_counted = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        // if the obstacle has passed the player position, update the score
        if (transform.position.x < playerPosX && !obstacle_counted) {
            FindObjectOfType<scoreManager>().updateScore(gameObject.tag);
            obstacle_counted = true;
        }

        if (transform.position.x < leftBound) {
            obstacle_counted = false;
            Destroy(gameObject);
        }
    }
}
