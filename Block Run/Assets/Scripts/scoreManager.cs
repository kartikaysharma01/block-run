using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreManager : MonoBehaviour
{
    public int score;
    public TextMesh scoretext;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        // scoretext = GetComponent<TextMesh>();
        scoretext.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScore(string tagname) {
        // award 1 point for walls obstacle
        if (tagname == "Wall") {
            Debug.Log(tagname + "jumped, award 1 point");
            score = score + 1;
        } 
        // award 3 point for barrel obstacle
        else if (tagname == "barrel") {
            Debug.Log(tagname + "jumped, award 3 point");
            score = score + 3;
        }
        // award 5 point for Barrier obstacle
        else if (tagname == "Barrier") {
            Debug.Log(tagname + "jumped, award 5 point");
            score = score + 5;
        }
        scoretext.text = "Score: " + score;
    }
}
