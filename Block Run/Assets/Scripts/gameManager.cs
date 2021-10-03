using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    private float restartDelay = 5.0f;
    public bool gameHasEnded = false;
    // public GameObject gameOverUI;
    // public Text scoreEnd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndGame() {
        gameHasEnded = true;
        // string score = "Score: " +  FindObjectOfType<score>().scoreCount.ToString();
        // Debug.Log("GAME OVER!!! Score: " + score);
        // scoreEnd.text = score;
        // gameOverUI.SetActive(true);
        Invoke("Restart", restartDelay);
    }

    void Restart() {
        SceneManager.LoadScene(0);
    }

    public void DestroyPrefabsInScene(string tagName) {
        GameObject[] prefabs = GameObject.FindGameObjectsWithTag(tagName);
        foreach (GameObject prefab in prefabs) {
            Destroy(prefab);
        }
    }
}
