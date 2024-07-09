using UnityEngine;

public class GasGasGas : MonoBehaviour
{
    public AudioClip sound;
    private AudioSource audioSource;
    private bool isPlaying = false;
    private Walk playerController;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerController = FindFirstObjectByType<Walk>();


        if (sound != null)
        {
            audioSource.clip = sound;
        }
        else
        {
            Debug.LogWarning("No audio clip assigned to GasGasGas script!");
        }

        // Останавливаем аудиоклип, если он уже играет
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    private void Update()
    {
        Gas();
    }

    private void Gas()
    {
        // Проверяем состояние приседа
        if (playerController != null && playerController.IsCrouching())
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
                isPlaying = false;
            }
            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (!audioSource.isPlaying && sound != null)
            {
                audioSource.Play();
                isPlaying = true;
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
                isPlaying = false;
            }
        }
    }
}
