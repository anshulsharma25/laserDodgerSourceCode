using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headscript : MonoBehaviour
{
    public float Rotate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Rotate * GameManager.instance.levels * Time.deltaTime, 0);
    }
}
