using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NavBola : MonoBehaviour
{
    private Rigidbody rg;
    public float speed;
    public float jumpPower;
    public int diLantai;
    public TMP_Text WaktuSisa;
    public TMP_Text ShowCoin;
    public static int coins = 0;
    public GameObject lantai;
    public static float batasWaktu = 60f;
    private int TotalCoin;
    // Start is called before the first frame update
    void Start()
    {
        coins = 0;
        batasWaktu = 60f;
        rg = GetComponent<Rigidbody>();
        TotalCoin = GameObject.FindGameObjectsWithTag("Coin").Length;
        UpdateCoin();
    }
    // Update is called once per frame
    void Update()
    {
        DisplayTime(batasWaktu);
        batasWaktu -= Time.deltaTime;
        MoveControll();
        if (transform.position.y < lantai.transform.position.y)
        {
            GameOver();
        }
        if (batasWaktu < 0f)
        {
            GameOver();
        }
        if (coins == TotalCoin)
        {
            YouWin();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "tagLantai")
        {
            diLantai = 1;
        }
        if (collision.gameObject.tag == "rintangan")
        {
            Debug.Log("matii");
            GameOver();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        diLantai = 0;
    }
    public void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Coin")
        {
            Col.gameObject.SetActive(false);
            coins++;
            UpdateCoin();
        }
    }

    public void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        WaktuSisa.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    void MoveControll()
    {
        if (Input.GetKey("d")) // Ke kanan
        {
            Vector3 kanan = new Vector3(10, 0, 0);
            rg.AddForce(kanan * speed);
        }
        if (Input.GetKey("a")) // Ke kiri
        {
            Vector3 kiri = new Vector3(-10, 0, 0);
            rg.AddForce(kiri * speed);
        }
        if (Input.GetKey("w")) // Ke Maju
        {
            Vector3 maju = new Vector3(0, 0, 10);
            rg.AddForce(maju * speed);
        }
        if (Input.GetKey("s")) // Ke Mundur
        {
            Vector3 mundur = new Vector3(0, 0, -10);
            rg.AddForce(mundur * speed);
        }
        if (Input.GetKey(KeyCode.Space) && diLantai == 1) // Ke Lompat
        {
            Vector3 atas = new Vector3(0, 10, 0);
            rg.AddForce(atas * speed);
        }
    }
    public void UpdateCoin()
    {
        ShowCoin.text = "Coin: " + coins;
    }
    void GameOver()
    {
        SceneManager.LoadScene(2);
    }

    void YouWin()
    {
        SceneManager.LoadScene(3);
    }
}
