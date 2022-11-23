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
        [SerializeField] private Animator animator;
        private NavMeshAgent _navMeshAgent;
        private FarmTile _targetTile;
        private Plant _planTToSeed;
        private State _currentState;
        private static readonly int Pose = Animator.StringToHash("Pose");

        private enum State
        {
            None,
            PickingPlant,
            PlantingPlant
        }

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            animator.SetInteger(Pose, 0);
        }

        public void SeedTile(FarmTile targetTile, Plant planTToSeed)
        {
            _targetTile = targetTile;
            _planTToSeed = planTToSeed;
            _currentState = State.PlantingPlant;
        }

        public void PickupPlant(FarmTile targetTile)
        {
            _targetTile = targetTile;
            _currentState = State.PickingPlant;
        }


        private void Update()
        {
            if (_targetTile != null)
            {
                animator.SetInteger(Pose, 1);
                _navMeshAgent.isStopped = false;
                _navMeshAgent.destination = _targetTile.transform.position;
                if (Vector3.Distance(transform.position, _targetTile.transform.position) <= destinationThreshold)
                {
                    if (_currentState == State.PlantingPlant)
                    {
                        animator.SetInteger(Pose, 2);
                        _targetTile.SeedTile(_planTToSeed);
                    }
                    else if (_currentState == State.PickingPlant)
                    {
                        animator.SetInteger(Pose, 2);
                        _targetTile.TryMowPlant();
                    }

                    _targetTile = null;
                    _planTToSeed = null;
                    _navMeshAgent.isStopped = true;
                    _currentState = State.None;
                }
            }
        }
    }
}