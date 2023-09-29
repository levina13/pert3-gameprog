using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CapsuleMati : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "rintangan")
        {
            SceneManager.LoadScene(2);
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "rintangan")
        {
            SceneManager.LoadScene(2);
        }
    }
}
