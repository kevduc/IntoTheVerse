using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMechanics : MonoBehaviour
{
    private PlayerUI playerUI;

    private int bugs = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerUI = GetComponent<PlayerUI>();
        bugs = 0;
        playerUI.UpdateBugDisplay (bugs);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("BugItem")) return;

        other.gameObject.SetActive(false);
        bugs += 1;

        playerUI.UpdateBugDisplay (bugs);
    }
}
