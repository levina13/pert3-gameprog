using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Rigidbody projectTile;
    public Transform shotPos;
    // Arah Tembakan
    private Vector3 offset;
    public float turnSpeed = 1f;
    public float moveSpeed = 1f;
    public float shotForce = 1f;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // kendali AIMbola
        float h = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float v = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        // update lokasi kamera
        transform.Translate(new Vector3(h, 0f, v));

        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * turnSpeed, Vector3.right) * offset;
        transform.LookAt(transform.position + offset);

        if (Input.GetKeyDown(KeyCode.Space)) // Ke Lompat
        {
            Rigidbody shot = Instantiate(projectTile, shotPos.position, shotPos.rotation) as Rigidbody;
            shot.AddForce(shotPos.forward * shotForce);
        }
    }


}
