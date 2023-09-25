using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rintangan2 : MonoBehaviour
{
    public GameObject posPositive;
    public GameObject posNegative;
    public float speed = 1f;
    void Start()
    {
    }
    void Update()
    {
        transform.position = Vector3.Lerp(posPositive.transform.position, posNegative.transform.position, Mathf.PingPong(Time.time * speed, 1));
    }
    // Start is called before the first frame update


}
