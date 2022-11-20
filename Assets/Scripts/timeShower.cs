using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Text = TMPro.TextMeshProUGUI;

public class timeShower : MonoBehaviour
{
    public Text time;
    private float accumulateTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        accumulateTime += Time.deltaTime;
        time.text = "TIME: " + decimal.Round((decimal)accumulateTime, 2) + " sec";
    }
}
