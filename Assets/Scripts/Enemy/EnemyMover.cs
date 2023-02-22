using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform[] _enemyPoints;

    private NavMeshAgent _enemyAgent;
    private Transform _placeToGo;

    private void Start()
    {
        _enemyAgent = GetComponent<NavMeshAgent>();
        SetNewPath();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spots"))
            SetNewPath();
    }

    public void SetNewPath()
    {
        Transform moveTo = _enemyPoints[Random.Range(0, _enemyPoints.Length)];
        
        if(_placeToGo != null && _placeToGo.position == moveTo.position)
        {
            SetNewPath();
            return;
        }

        _placeToGo = moveTo;

        if(_enemyAgent.enabled)
            _enemyAgent.SetDestination(moveTo.position);
    }
}
