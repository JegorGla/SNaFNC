using UnityEngine;
using UnityEngine.AI;

public class PolishCow : MonoBehaviour
{
    public AudioSource TylkoJednoWGlowieMam;
    public Transform Player;
    private NavMeshAgent agent;

    public float speed = 1.5f; // �������� ����
    public float turnSpeed = 2.0f; // �������� ��������
    public float followDistance = 3.0f; // ����������� ��������� �� ������

    private void Start()
    {
        // �������� ��������� NavMeshAgent
        agent = GetComponent<NavMeshAgent>();

        // ������������� ��������� �������� �����������
        agent.speed = speed;

        // ��������� �������������� ���������� ���������, ����� ��������� �������
        agent.updateRotation = false;
    }

    private void Update()
    {
        if (Player != null)
        {
            // ������������ ��������� �� ������
            float distanceToPlayer = Vector3.Distance(transform.position, Player.position);

            // ���� ��������� ������ ��������, ��� �������� ��������� � ������
            if (distanceToPlayer > followDistance)
            {
                agent.SetDestination(Player.position);

                // ������������ ����������� � ������
                Vector3 direction = (Player.position - transform.position).normalized;

                // ������ ������������ ���� � ������� ������
                if (direction != Vector3.zero)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
                }
            }
            else
            {
                // ������������� ��������, ���� ��� �� �������� ���������� �� ������
                agent.ResetPath();
            }
        }
    }

    public void PlaayThisMusic()
    {
        TylkoJednoWGlowieMam.Play();
    }

    public void StopThisMusic()
    {
        if (TylkoJednoWGlowieMam != null)
        {
            TylkoJednoWGlowieMam.Stop();
        }
    }
}
