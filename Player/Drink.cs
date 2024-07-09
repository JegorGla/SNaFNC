using System.Collections;
using UnityEngine;

public class Drink : MonoBehaviour
{
    public Animator mAnimator;
    private bool isDrink = false;
    public GameObject Buttle;

    public AudioClip sound;
    private AudioSource audioSource;

    void Start()
    {
        mAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = sound;
        Buttle.SetActive(false); // Изначально бутылка не активна
    }

    void Update()
    {
        if (mAnimator != null)
        {
            HandleDrinkAnimation();
        }
    }

    public void HandleDrinkAnimation()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isDrink)
            {
                Buttle.SetActive(true);
                mAnimator.SetTrigger("Drink");
                StartCoroutine(PlaySoundAfterDelay(2.011f));
                Debug.Log("GG");
            }

            Buttle.SetActive(false);
            mAnimator.SetTrigger("StopDrink");
        }
    }
    private IEnumerator PlaySoundAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSource.Play();
    }
}
