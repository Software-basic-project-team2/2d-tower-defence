using System.Linq;
using UnityEngine;

public class EnemyrController : MonoBehaviour
{
    public Transform[] waypoints; // Waypoints를 저장할 배열
    public float moveSpeed = 5f; // 캐릭터의 이동 속도
    private int currentWaypointIndex = 0; // 현재 Waypoint 인덱스

    private void Start()
    {
        if (GameManager.instance.easyMode) // 이지 모드가 선택되었을 때
        {
            waypoints = GameObject.FindGameObjectsWithTag("easy").Select(obj => obj.transform).ToArray();
        }

        if (GameManager.instance.hardMode) // 하드 모드가 선택되었을 때
        {
            waypoints = GameObject.FindGameObjectsWithTag("hard").Select(obj => obj.transform).ToArray();
        }


    }

    private void Update()
    {
<<<<<<< Updated upstream
        if (waypoints == null || waypoints.Length == 0)
            return;
=======

        if (currentWaypointIndex >= waypoints.Length) return;

        if (waypoints == null || waypoints.Length == 0)
            return;

>>>>>>> Stashed changes

        // 현재 Waypoint를 향해 이동
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, moveSpeed * Time.deltaTime);

        // 현재 Waypoint에 도착한 경우 다음 Waypoint로 이동
        if (Vector2.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            currentWaypointIndex++;
        }
    }
}
