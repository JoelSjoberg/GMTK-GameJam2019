using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class scoreText : MonoBehaviour
{
    TextMeshProUGUI t;
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<TextMeshProUGUI>();
        t.text = "Score: " + GameStatusManager.points; 
    }

    // Update is called once per frame
    void Update()
    {
        t.text = "Score: " + GameStatusManager.points;
    }
}
