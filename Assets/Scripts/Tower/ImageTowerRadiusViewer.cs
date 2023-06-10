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
            case Tower.Type.Tower1: return Tower.TowerDataList[1, 1].range;
            case Tower.Type.Tower2: return Tower.TowerDataList[2, 1].range;
            case Tower.Type.Tower3: return Tower.TowerDataList[3, 1].range;
            case Tower.Type.Tower4: return Tower.TowerDataList[4, 1].range;
            default: return 0;
        }
    }
}
