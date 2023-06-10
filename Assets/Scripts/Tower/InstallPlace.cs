using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstallPlace : MonoBehaviour
{
    int count;
    public bool canPlace()
    {
        return count == 0;
    }

    private void Start()
    {
        count = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "InstallPlace" || collision.tag == "TileRoad")
            count++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "InstallPlace" || collision.tag == "TileRoad")
            count--;
    }
}
