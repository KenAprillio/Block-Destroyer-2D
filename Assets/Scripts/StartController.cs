using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    Scene scene;
    string sceneName;

    GameObject controlsPanel;
    public GameObject winPanel;
    public GameObject gameoverPanel;

    public bool isEscapeForExit;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
        
        if (sceneName == "Level 1")
        {
            controlsPanel = GameObject.Find("Panel Controls");
            controlsPanel.SetActive(true);

            gameoverPanel = GameObject.Find("GameOver");
            gameoverPanel.SetActive(false);

            winPanel = GameObject.Find("WinPanel");
            winPanel.SetActive(false);

            Data.scoreData = 0;
        }

        if (sceneName == "Level 2")
        {
            gameoverPanel = GameObject.Find("GameOver");
            gameoverPanel.SetActive(false);

            winPanel = GameObject.Find("WinPanel");
            winPanel.SetActive(false);

            controlsPanel = GameObject.Find("StartPanel");
            controlsPanel.SetActive(true);

            Data.scoreData = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(sceneName == "StartGame")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Level 1");
            }
        }

        if (sceneName == "Level 1")
        {
            if (controlsPanel.activeSelf && Input.GetKeyDown(KeyCode.Space))
            {
                controlsPanel.SetActive(false);
                GameObject.Find("Circle").GetComponent<BallController>().launch = true;
            }

            if (winPanel.activeSelf && Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Level 2");
            }
        }

        if (sceneName == "Level 2")
        {
            if (controlsPanel.activeSelf && Input.GetKeyDown(KeyCode.Space))
            {
                controlsPanel.SetActive(false);
                GameObject.Find("Circle").GetComponent<BallController>().launch = true;
            }

            if (winPanel.activeSelf && Input.GetKeyDown(KeyCode.Space))
            {
                GoToMenu();
                
            }
        }

        if (!isEscapeForExit)
        {
            if (!controlsPanel.activeSelf && Input.GetKeyDown(KeyCode.R))
            {
                RetryLevel();
                Debug.Log("Its reset");
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GoToMenu();
            }
        } else { 
        }
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("StartGame");
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(sceneName);
    }
}
