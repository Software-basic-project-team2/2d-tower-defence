using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRadiusViewer : MonoBehaviour
{
    public Transform Center;
    float radius;

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
        Debug.Log("Radius: " + radius);
        radius = GetRadius();
        Center.localScale = new Vector3(1, 1, 1) * radius;
    }

    public void OnTowerAttackRadius()
    {

    }

    public void OffTowerAttackRadius()
    {

    }
}
