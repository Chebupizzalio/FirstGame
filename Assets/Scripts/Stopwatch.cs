using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour
{
    private int sec;
    private int min;
    private Text stopwatchText;
    private int delta;

    private void Start()
    {
        stopwatchText = GameObject.Find("Stopwatch").GetComponent<Text>();
        StartCoroutine(IStopwatch());
        delta = 1;
    }
    
    IEnumerator IStopwatch()
    {
        while (true)
        {
            if (sec == 59)
            {
                min += 1;
                sec = -1;
            }
            sec += delta;
            stopwatchText.text = min.ToString("D2") + " : " + sec.ToString("D2");
            yield return new WaitForSeconds(1);
        }
    }
}
