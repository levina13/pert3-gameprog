using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rintangan : MonoBehaviour
{
    private Rigidbody rg;
    public float speed = 2;
    private bool Positive;

    public bool GerakX;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Positive == true)
        {
            Positive = false;
        }
        else
        {
            Positive = true;
        }
    }

    void MovePositive()
    {
        if (GerakX)
        {
            // // transform.position = transform.position + new Vector3(10 * speed * Time.deltaTime, 0, 0);
            Vector3 positiveForce = new Vector3(10, 0, 0);
            rg.AddForce(positiveForce * speed);
        }
        else
        {
            // // transform.position = transform.position + new Vector3(0, 0, 10 * speed * Time.deltaTime);
            Vector3 positiveForce = new Vector3(0, 0, 10);
            rg.AddForce(positiveForce * speed);
        }
    }
    void MoveNegative()
    {
        if (GerakX)
        {
            // // transform.position = transform.position + new Vector3(-10 * speed * Time.deltaTime, 0, 0);
            Vector3 negativeForce = new Vector3(-10, 0, 0);
            rg.AddForce(negativeForce * speed);
        }
        else
        {
            // // transform.position = transform.position + new Vector3(0, 0, -10 * speed * Time.deltaTime);
            Vector3 negativeForce = new Vector3(0, 0, -10);
            rg.AddForce(negativeForce * speed);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Positive)
        {
            MovePositive();
        }
        else
        {
            MoveNegative();
        }
    }
}
