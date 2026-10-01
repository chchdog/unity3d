using UnityEditor.Analytics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class movingenemy : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    [SerializeField]
    Transform[] waypoint;
    private int currentIndex = 0;



    void Start()
    {
        print("다음 이동할 웨이포인트 번호" + currentIndex);
        navMeshAgent = GetComponent<NavMeshAgent>();
        Gotonextwaypoint();
    }

    void Gotonextwaypoint()
    {
        if (waypoint.Length == 0) return;

        navMeshAgent.SetDestination(waypoint[currentIndex].position);

        currentIndex = (currentIndex + 1) % waypoint.Length; 
    }

    // Update is called once per frame
    void Update()
    {
         if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= 0.5f)
        {
            Gotonextwaypoint();
        }
    }
}
