using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{
    public TextMeshProUGUI itemCounter;

    public int score = 0;

    // Update is called once per frame
    void Update()
    {
        itemCounter.text = "Score:  " + score.ToString();
    }
}
