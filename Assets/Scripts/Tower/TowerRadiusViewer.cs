using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRadiusViewer : MonoBehaviour
{
    public Transform Center;
    float radius;
    //public float ratio;

    private void Start()
    {
        radius = GetRadius();
        UpdateRadius();
    }

    protected virtual float GetRadius()
    {
        return GetComponent<Tower>().AttackRadius;
    }

    void UpdateRadius()
    {
        //Debug.Log("Radius: " + radius);
        radius = GetRadius();
        Center.localScale = 0.39f * radius * new Vector3(1, 1, 1);
    }

    public void OnTowerAttackRadius()
    {
        UpdateRadius();
        Center.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
    }

    public void OffTowerAttackRadius()
    {
        Center.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 0);
    }
}
