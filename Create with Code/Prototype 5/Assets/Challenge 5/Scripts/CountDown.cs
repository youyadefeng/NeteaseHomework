using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
    private int leftTime = 10;
    private TextMeshProUGUI countDownText;
    private GameManagerX gameManagerX;
    // Start is called before the first frame update
    void OnEnable()
    {
        countDownText = GetComponent<TextMeshProUGUI>();
        gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();
        DownTimeAndUpdateText(0);
        StartCoroutine("DownTime");
    }

    public IEnumerator DownTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            DownTimeAndUpdateText(1);
            if(leftTime <= 0)
            {
                gameManagerX.GameOver();
                StopCoroutine("DownTime");
            }
        }
    }

    void DownTimeAndUpdateText(int descreaseTime)
    {
        leftTime -= descreaseTime;
        countDownText.text = "Time:" + leftTime;
    }
}
