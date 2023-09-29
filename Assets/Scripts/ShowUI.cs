using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    public TMP_Text WaktuSisa;
    public TMP_Text ShowCoin;
    // Start is called before the first frame update
    void Start()
    {
        DisplayTime(NavBola.batasWaktu);
        ShowCoin.text = "Score: " + MovePlayer.coins;

    }

    public void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        WaktuSisa.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
