using System;
using DI;
using FarmTiles;
using Scriptable_objects.Plants;
using UnityEngine;
using UnityEngine.AI;

namespace Character
{
    public class FarmerCharacter : MonoBehaviour, IService
    {
        [SerializeField] private float destinationThreshold = 1f;
        private NavMeshAgent _navMeshAgent;
        private FarmTile _targetTile;
        private Plant _planTToSeed;

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        public void SeedTile(FarmTile targetTile, Plant planTToSeed)
        {
            _targetTile = targetTile;
            _planTToSeed = planTToSeed;
        }

        private void Update()
        {
            if (_targetTile != null)
            {
                _navMeshAgent.isStopped = false;
                _navMeshAgent.destination = _targetTile.transform.position;
                if (Vector3.Distance(transform.position, _targetTile.transform.position) <= destinationThreshold)
                {
                    _targetTile.SeedTile(_planTToSeed);
                    _targetTile = null;
                    _planTToSeed = null;
                    _navMeshAgent.isStopped = true;
                }
            }
        }
    }
}
