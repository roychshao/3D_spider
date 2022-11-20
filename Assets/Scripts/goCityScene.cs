using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Button
using UnityEngine.SceneManagement; //SceneManager

public class goCityScene : MonoBehaviour
{
    public int sceneIndex = 1;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => {
            ClickEvent();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ClickEvent() {
        SceneManager.LoadScene(sceneIndex);
    }
}
