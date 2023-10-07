using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class MovePlayer : MonoBehaviour
{
    public Rigidbody projectTile;
    public Transform shotPos;
    // Arah Tembakan
    private Vector3 offset;
    public float turnSpeed = 1f;
    public float moveSpeed = 1f;
    public float shotForce = 1f;
    public TMP_Text WaktuSisa;
    public static float batasWaktu = 60f;

    int TotalCoin;
    public static int coins;
    public TMP_Text ShowCoin;
    public AudioSource shootsound;
    public Animator LedakanAnim;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position;
        batasWaktu = 60f;
        coins = 0;
        TotalCoin = GameObject.FindGameObjectsWithTag("Coin").Length;
        ShowCoin.text = "Coin: " + coins;
    }

    // Update is called once per frame
    void Update()
    {
        ShowCoin.text = "Coin: " + coins;
        // kendali AIMbola
        float h = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float v = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        // update lokasi kamera
        transform.Translate(new Vector3(h, 0f, v));

        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * turnSpeed, Vector3.right) * offset;
        transform.LookAt(transform.position + offset);

        if (Input.GetKeyDown(KeyCode.Space)) // Shoot
        {
            Rigidbody shot = Instantiate(projectTile, shotPos.position, shotPos.rotation) as Rigidbody;
            shot.AddForce(shotPos.forward * shotForce);
            shootsound.Play();
            LedakanAnim.SetTrigger("ledakanState");
        }
        DisplayTime(batasWaktu);
        batasWaktu -= Time.deltaTime;
        if (batasWaktu < 0f)
        {
            GameOver();
        }
        if (coins == TotalCoin)
        {
            YouWin();
        }
    }
    public void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        WaktuSisa.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "rintangan")
        {
            Debug.Log("matii");
            GameOver();
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "rintangan")
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }

    public void YouWin()
    {
        SceneManager.LoadScene(3);
    }
}
