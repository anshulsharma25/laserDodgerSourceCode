using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 
    public GameObject[] gameObjects;
    public float levels = 0;
    public Text Leveltext;

    [HideInInspector]
    public bool playeralive;
    private void Awake()
    {
        playeralive = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        StartCoroutine(LevelIncrease());
    }

    // Update is called once per frame
    void Update()
    {
        Leveltext.text = "Difficulty Wave is:" + levels;
        laseractivate();
        WinScene();
        

    }
    IEnumerator LevelIncrease()
    {
        while(levels<5)
        {
            yield return new WaitForSeconds(2);
            levels++;
            Debug.Log("level is" + levels);
        }
        
    }
    void laseractivate()
    {
        switch(levels)
        {
            case 0:
                gameObjects[0].SetActive(true);
                break;
            case 1:
                gameObjects[1].SetActive(true);
                break;
            case 2:
                gameObjects[2].SetActive(true);
                break;
            case 3:
                gameObjects[3].SetActive(true);
                break;
            case 4:
                gameObjects[4].SetActive(true);
                break;

        }


    }
    IEnumerator onwin()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Won");
    }
    void WinScene ()
    {
        if(playeralive)
        {
            if(levels == 5)
            {
               StartCoroutine(onwin());
            }
         }
    }
    public void ShowLosePanel()

    {
        SceneManager.LoadScene("Lose");
    }
}
