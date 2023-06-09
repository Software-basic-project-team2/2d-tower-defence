using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< Updated upstream
=======
[CreateAssetMenu]
>>>>>>> Stashed changes
public class TowerLevel : MonoBehaviour
{
    public GameObject towerPrefab;
    public Weapon[] weapon;

    [System.Serializable]
    public struct Weapon {
        public Sprite sprite; // 보이는 타워 이미지
        public float damage; // 데미지
        public float rate; //공격 속도
        public float range; //범위
        public int cost; //가격
    
    }

}
