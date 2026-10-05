using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.Lumin;
public class MovingEnemy : MonoBehaviour
{
    //문제1
    //위치를 랜덤으로 가게 만들기  끝
    //문제2
    //도착후 일정 시간동안 제자리에 머무르게  끝


    private NavMeshAgent navMeshAgent;

    public Transform[] waypoints;
    private int currentIndex = 0;

    private bool isWayting = false;




    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        GotoNextWaypoint();
    }

    void GotoNextWaypoint()
    {
        if (waypoints.Length == 0) return;
        
        currentIndex = Random.Range(0, waypoints.Length);
        navMeshAgent.SetDestination(waypoints[currentIndex].position);



    }

    void Update()
    {
        if (waypoints.Length == 0 || isWayting) return;
        



        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= 0.15f)
        {
           

            StartCoroutine(WaitAtWaypoint());

           
        }
    }

    IEnumerator WaitAtWaypoint()
    {
        isWayting = true;

        yield return new WaitForSeconds(1.5f);

        GotoNextWaypoint();

        isWayting=false;

    }

    


}
