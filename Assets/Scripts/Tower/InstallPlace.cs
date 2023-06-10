using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstallPlace : MonoBehaviour
{
    int count;
    public bool isInPlace()
    {
        return count > 0;
    }

    private void Start()
    {
        count = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "InstallPlace")
            count++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "InstallPlace")
            count--;
    }
}
