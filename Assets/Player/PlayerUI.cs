using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI bugsCountText;

    void Start()
    {
    }

    public void UpdateBugDisplay(int bugCount)
    {
        bugsCountText.text = "Bugs: " + bugCount.ToString();
    }
}
