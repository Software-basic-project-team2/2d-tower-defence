using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageTowerRadiusViewer : TowerRadiusViewer
{
    public Tower.Type type;
    protected override float GetRadius()
    {
        switch (type)
        {
            case Tower.Type.Tower1: return Tower.Tower1Level1AttackRadius;
            case Tower.Type.Tower2: return Tower.Tower2Level1AttackRadius;
            case Tower.Type.Tower3: return Tower.Tower3Level1AttackRadius;
            case Tower.Type.Tower4: return Tower.Tower4Level1AttackRadius;
            default: return 0;
        }
    }

    protected override void SetVisible()
    {
        OnTowerAttackRadius();
    }
}
