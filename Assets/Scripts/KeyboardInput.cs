using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            Debug.Log(Input.GetAxis("Horizontal"));
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            Debug.Log(Input.GetAxis("Horizontal"));
        }
    }
}
