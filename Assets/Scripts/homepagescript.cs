using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class homepagescript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void start()
    {
        SceneManager.LoadScene("MainScene");

    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
    public void tips()
    {
        SceneManager.LoadScene("Tip");
    }


}
