using UnityEngine;

public class Walk : MonoBehaviour
{
    public CharacterController controller;
    public float walkSpeed = 4f; // Скорость при ходьбе
    public float runSpeed = 8f;  // Скорость при беге
    public float crouchSpeed = 2f; // Скорость при приседании
    public float gravity = -19.81f;
    public float stamina = 5f;
    public float staminaDrainRate = 1f;
    public float staminaRecoveryTime = 15f;
    public float crouchHeightMultiplier = 0.6f;

    public AudioSource stepAudioSource;
    public AudioClip walkClip;
    public AudioClip runClip; // Добавим звук для бега
    public AudioClip crouchClip; // Добавим звук для приседания

    private float staminaRegenRate;
    private Vector3 velocity;
    private float currentStamina;
    private bool isExhausted = false;
    private bool isCrouching = false;
    private float originalHeight;
    private float stepInterval = 0.5f; // Интервал между шагами
    private float stepTimer;

    public GameObject[] cameras; // Массив камер для проверки их состояния

    private float maxLookAngle = 90f;

    public float CurrentStamina
    {
        get { return currentStamina; }
    }

    private void Start()
    {
        currentStamina = stamina;
        staminaRegenRate = stamina / staminaRecoveryTime;
        originalHeight = controller.height;
        stepAudioSource = GetComponent<AudioSource>();
        stepTimer = 0f;
    }

    void Update()
    {
        // Проверяем, активна ли какая-либо из камер
        bool anyCameraActive = false;
        foreach (GameObject camera in cameras)
        {
            if (camera.activeSelf)
            {
                anyCameraActive = true;
                break;
            }
        }

        if (anyCameraActive)
        {
            return;
        }

        // Получаем ввод пользователя для передвижения
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;

        HandleCrouch();

        bool isRunning = Input.GetKey(KeyCode.LeftShift) && !isExhausted && !isCrouching;

        if (isRunning && currentStamina > 0)
        {
            float moveSpeed = runSpeed;
            currentStamina -= staminaDrainRate * Time.deltaTime;
            currentStamina = Mathf.Clamp(currentStamina, 0, stamina);

            if (currentStamina <= 0)
            {
                isExhausted = true;
            }

            controller.Move(move * moveSpeed * Time.deltaTime);
            PlayFootstepSound(runClip);
        }
        else
        {
            if (!isRunning)
            {
                currentStamina += staminaRegenRate * Time.deltaTime;
                currentStamina = Mathf.Clamp(currentStamina, 0, stamina);

                if (currentStamina >= stamina)
                {
                    isExhausted = false;
                }
            }

            float moveSpeed = isCrouching ? crouchSpeed : walkSpeed;
            controller.Move(move * moveSpeed * Time.deltaTime);

            if (isCrouching)
            {
                PlayFootstepSound(crouchClip);
            }
            else if (!isRunning)
            {
                PlayFootstepSound(walkClip);
            }
        }

        // Проверяем, стоит ли игрок на земле
        if (controller.isGrounded)
        {
            velocity.y = -2f;  // Сбрасываем вертикальную скорость, если на земле
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;  // Применяем гравитацию
        }

        controller.Move(velocity * Time.deltaTime);
    }


    private void HandleCrouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            ToggleCrouch();
        }

        if (isCrouching)
        {
            controller.height = originalHeight * crouchHeightMultiplier;
        }
        else
        {
            controller.height = originalHeight;
        }
    }

    private void ToggleCrouch()
    {
        isCrouching = !isCrouching;
    }

    private void PlayFootstepSound(AudioClip clip)
    {
        if (controller.velocity.magnitude > 0.1f)
        {
            stepTimer -= Time.deltaTime;

            // Замедляем шаги, если игрок присел
            float currentStepInterval = isCrouching ? stepInterval * 1.5f : stepInterval;
                
            if (stepTimer <= 0f)
            {
                stepAudioSource.clip = clip;
                stepAudioSource.Play();
                stepTimer = currentStepInterval; // Сбрасываем таймер
            }
        }
    }

    bool IsPlayerLookingAtCamera()
    {
        if (cameras == null || cameras.Length == 0)
            return false;

        Vector3 playerDirection = transform.forward;
        foreach (GameObject camera in cameras)
        {
            if (camera == null)
                continue;

            Vector3 cameraDirection = (camera.transform.position - transform.position).normalized;
            float angle = Vector3.Angle(playerDirection, cameraDirection);

            if (angle < maxLookAngle)
            {
                return true;
            }
        }
        return false;
    }

    public bool IsCrouching()
    {
        return isCrouching;
    }
}
