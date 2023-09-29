using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Peluru : MonoBehaviour
{
    // public static int coins = 0;
    // public TMP_Text ShowCoin;
    // Start is called before the first frame update
    void Start()
    {
        UpdateCoin();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Coin")
        {
            Col.gameObject.SetActive(false);
            MovePlayer.coins++;
            UpdateCoin();
        }
    }

    void UpdateCoin()
    {
        // ShowCoin.text = "Coin: " + MovePlayer.coins;
    }
}
