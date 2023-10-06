using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Jobs;

public class NavBola : MonoBehaviour
{
    private Rigidbody rg;
    public float speed;
    public float jumpPower;
    public int diLantai;
    public TMP_Text WaktuSisa;
    public GameObject lantai;
    public static float batasWaktu = 60f;
    private int TotalCoin;
    // Tambahan untuk Peluru
    // Start is called before the first frame update
    void Start()
    {
        batasWaktu = 60f;
        rg = GetComponent<Rigidbody>();
        TotalCoin = GameObject.FindGameObjectsWithTag("Coin").Length;
    }
    // Update is called once per frame
    void Update()
    {

        DisplayTime(batasWaktu);
        batasWaktu -= Time.deltaTime;
        if (transform.position.y < lantai.transform.position.y)
        {
            GameOver();
        }
        if (batasWaktu < 0f)
        {
            GameOver();
        }
        if (MovePlayer.coins == TotalCoin)
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
    public void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        WaktuSisa.text = string.Format("{0:00}:{1:00}", minutes, seconds);
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
