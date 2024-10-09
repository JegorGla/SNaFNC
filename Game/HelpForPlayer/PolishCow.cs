using UnityEngine;
using UnityEngine.AI;

public class PolishCow : MonoBehaviour
{
    public AudioSource TylkoJednoWGlowieMam;
    public Transform Player;
    private NavMeshAgent agent;

    public float speed = 1.5f; // Скорость бота
    public float turnSpeed = 2.0f; // Скорость поворота
    public float followDistance = 3.0f; // Минимальная дистанция до игрока

    private void Start()
    {
        // Получаем компонент NavMeshAgent
        agent = GetComponent<NavMeshAgent>();

        // Устанавливаем медленную скорость перемещения
        agent.speed = speed;

        // Отключаем автоматическое обновление поворотов, чтобы управлять вручную
        agent.updateRotation = false;
    }

    private void Update()
    {
        if (Player != null)
        {
            // Рассчитываем дистанцию до игрока
            float distanceToPlayer = Vector3.Distance(transform.position, Player.position);

            // Если дистанция больше заданной, бот начинает двигаться к игроку
            if (distanceToPlayer > followDistance)
            {
                agent.SetDestination(Player.position);

                // Рассчитываем направление к игроку
                Vector3 direction = (Player.position - transform.position).normalized;

                // Плавно поворачиваем бота в сторону игрока
                if (direction != Vector3.zero)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
                }
            }
            else
            {
                // Останавливаем движение, если бот на заданном расстоянии от игрока
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
