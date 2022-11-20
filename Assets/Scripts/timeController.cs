using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Text = TMPro.TextMeshProUGUI;
public class timeController : MonoBehaviour
{
    public Text time;
    // Start is called before the first frame update
    void Start()
    {
        time.text = "SURVIVE TIME: " + decimal.Round((decimal)PlayerPrefs.GetFloat("surviveTime", 0f), 2).ToString() + "(sec)";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}