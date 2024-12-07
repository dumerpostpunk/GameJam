using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using a;


public class EnemyAi : MonoBehaviour
{
    [SerializeField] private State startingState;
    [SerializeField] private float roamingDistanceMax = 7f;
    [SerializeField] private float roamingDistanceMin = 3f;
    [SerializeField] private float roamingTimerMax = 2f;

    private NavMeshAgent navMeshAgent;
    private State state;
    private float roamingTime;
    private Vector3 roamPos;
    private Vector3 startingPosition;
    private enum State
    {
        Idle,
        Roaming
    }
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        state = startingState;
    }
    private void Start()
    {
     startingPosition= transform.position;
    }

    private void Update()
    {
        switch (state)
        {
            default: 
            case State.Idle:
            break;
            case State.Roaming:
                roamingTime -=Time.deltaTime;
                if (roamingTime < 0)
                {
                    Roaming();
                    roamingTime = roamingTimerMax;
                }
            break;
        }
    }
    private void Roaming()
    {
        roamPos = GetRoamingPositions();
        navMeshAgent.SetDestination(roamPos);
    }
    private Vector3 GetRoamingPositions()
    {
        return startingPosition + Utits.GetRandomDir() * UnityEngine.Random.Range(roamingDistanceMin, roamingDistanceMax);
    }



}
