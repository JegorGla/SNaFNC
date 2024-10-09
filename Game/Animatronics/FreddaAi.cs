using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class FreddaAi : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent agent;

    public Transform[] waypoints;
    private int currentWaypointIndex = 0;
    public float sightRange = 10f;

    public LookingFredda nakrutkaScript;

    private bool canAct = false;
    private bool playerInSight = false;

    public AudioSource ISeeYou;
    public AudioSource RUN;
    public Image Nakrutka;

    public float currentNakrutka;
    public float propadanije_nakrutki;

    public LayerMask obstacleMask;

    public float maxVolumeDistance = 5f;
    public float minVolumeDistance = 15f;

    public float normalSpeed = 5.5f;
    public float chaseSpeed = 10.0f;
    public float rotationSpeed = 3f;

    private enum AIState { Patrolling, Chasing }
    private AIState currentState = AIState.Patrolling;

    void Start()
    {
        currentNakrutka = 75f;
        propadanije_nakrutki = 1f;

        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");

        agent.speed = normalSpeed;

        if (nakrutkaScript != null)
        {
            nakrutkaScript.onNakrutkaZero.AddListener(OnNakrutkaZero);
        }
    }

    private void OnEnable()
    {
        if (nakrutkaScript != null)
        {
            nakrutkaScript.onNakrutkaZero.AddListener(OnNakrutkaZero);
        }
    }

    public void OnDisable()
    {
        if (nakrutkaScript != null)
        {
            nakrutkaScript.onNakrutkaZero.RemoveListener(OnNakrutkaZero);
        }
    }

    public void OnNakrutkaZero()
    {
        if (!canAct)
        {
            canAct = true;
            Debug.Log("AI can now act: " + canAct);
            SetNextDestination();
        }
    }


    void Update()
    {
        if (!canAct) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        Debug.Log($"Distance to player: {distanceToPlayer}");

        // Уменьшаем накрутку, если она больше нуля
        if (currentNakrutka > 0)
        {
            currentNakrutka -= propadanije_nakrutki * Time.deltaTime;
            currentNakrutka = Mathf.Clamp(currentNakrutka, 0f, 100f);
        }

        if (currentNakrutka <= 0 && !playerInSight && !canAct) // Проверка canAct
        {
            OnNakrutkaZero();
        }


        switch (currentState)
        {
            case AIState.Patrolling:
                Patrol();
                if (distanceToPlayer <= sightRange && IsPlayerVisible())
                {
                    StartChasing();
                }
                break;

            case AIState.Chasing:
                ChasePlayer(distanceToPlayer);
                if (distanceToPlayer > sightRange || !IsPlayerVisible())
                {
                    StopChasing();
                }
                break;
        }

        // Проверка расстояния для преследования (если хотите)
        if (currentState == AIState.Chasing)
        {
            agent.SetDestination(player.transform.position);
        }
    }


    public void Patrol()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance + 0.1f)
        {
            Debug.Log("Reached waypoint: " + currentWaypointIndex);
            SetNextDestination();
        }
    }



    public void SetNextDestination()
    {
        if (waypoints.Length == 0) return;

        agent.SetDestination(waypoints[currentWaypointIndex].position);
        Debug.Log("Moving to waypoint: " + currentWaypointIndex);
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
    }



    public bool IsPlayerVisible()
    {
        Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (Physics.Raycast(transform.position, directionToPlayer, out RaycastHit hit, distanceToPlayer, obstacleMask))
        {
            Debug.Log($"Hit object: {hit.transform.name}");
            return hit.transform.gameObject == player;
        }

        return false;
    }

    private void StartChasing()
    {
        Debug.Log("Starting to chase the player.");
        playerInSight = true;
        if (!ISeeYou.isPlaying) ISeeYou.PlayOneShot(ISeeYou.clip);
        if (!RUN.isPlaying) RUN.PlayOneShot(RUN.clip);
        agent.speed = chaseSpeed;
        currentState = AIState.Chasing;
    }

    private void StopChasing()
    {
        Debug.Log("Stopped chasing the player.");
        playerInSight = false;
        RUN.Stop();
        ISeeYou.Stop();
        agent.speed = normalSpeed;
        currentState = AIState.Patrolling;
        SetNextDestination();
    }

    private void ChasePlayer(float distanceToPlayer)
    {
        agent.SetDestination(player.transform.position);
        AdjustVolume(distanceToPlayer);
    }

    public void AdjustVolume(float distanceToPlayer)
    {
        float volume = Mathf.Clamp01(1 - (distanceToPlayer - maxVolumeDistance) / (minVolumeDistance - maxVolumeDistance));
        ISeeYou.volume = volume;
    }
}
