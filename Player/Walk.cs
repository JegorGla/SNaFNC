using UnityEngine;

public class Walk : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float runSpeed = 22f;
    public float crouchSpeed = 5f;
    public float gravity = -19.81f;
    public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask GroundMask;
    public float stamina = 5f;
    public float staminaDrainRate = 1f;
    public float staminaRecoveryTime = 15f;
    public float crouchHeightMultiplier = 0.6f;

    public AudioSource stepAudioSource;
    public AudioClip walkClip;
    public Animator cameraAnimator; // Animator component for the camera

    private float staminaRegenRate;
    private Vector3 velocity;
    private bool isGround;
    private float currentStamina;
    private bool isExhausted = false;
    private bool isCrouching = false;
    private float originalHeight;
    private float stepInterval = 0.5f; // Interval between steps
    private float stepTimer;

    public GameObject CameraRightWall;

    private float maxLookAngle = 90f;

    public float CurrentStamina
    {
        get { return currentStamina; }
    }

    private void Start()
    {
        if (CameraRightWall != null)
        {
            CameraRightWall.SetActive(false);
        }
        currentStamina = stamina;
        staminaRegenRate = stamina / staminaRecoveryTime;
        originalHeight = controller.height;
        stepAudioSource = GetComponent<AudioSource>();
        stepTimer = 0f;
    }

    void Update()
    {
        isGround = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        if (isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (CameraRightWall.activeSelf)
        {
            move = Vector3.zero;
        }
        else
        {
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

                float moveSpeed = isCrouching ? crouchSpeed : speed;
                controller.Move(move * moveSpeed * Time.deltaTime);

                if (!isCrouching && !isRunning)
                {
                    PlayFootstepSound(walkClip);
                }
            }
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Camera animation logic
        if (move.magnitude > 0 && isGround)
        {
            cameraAnimator.SetBool("isWalking", true);
        }
        else
        {
            cameraAnimator.SetBool("isWalking", false);
        }
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
        if (isGround && (controller.velocity.magnitude > 0.1f))
        {
            stepTimer -= Time.deltaTime;
            if (stepTimer <= 0f)
            {
                stepAudioSource.clip = clip;
                stepAudioSource.Play();
                stepTimer = stepInterval; // Reset timer
            }
        }
    }

    bool IsPlayerLookingAtCamera()
    {
        if (CameraRightWall == null)
            return false;

        Vector3 playerDirection = transform.forward;
        Vector3 cameraDirection = (CameraRightWall.transform.position - transform.position).normalized;

        float angle = Vector3.Angle(playerDirection, cameraDirection);

        return angle < maxLookAngle;
    }

    public bool IsCrouching()
    {
        return isCrouching;
    }
}
