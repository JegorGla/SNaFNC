using UnityEngine;
using UnityEngine.UI;

public class CloseComputer : MonoBehaviour
{
    public GameObject ComputerCanvas; // The Canvas to control
    public GameObject ExitButton;

    private Animator _anim; // Animator component reference
    private bool isClose; // Flag to check if the computer is closed

    private void Start()
    {
        _anim = GetComponent<Animator>(); // Get the Animator component
        ComputerCanvas.SetActive(true); // Make sure the Canvas is initially active
    }

    // Method to close the computer
    public void Close_Computer()
    {
        isClose = !isClose; // Toggle the isClose flag
        if (isClose)
        {
            _anim.SetTrigger("TrgClose"); // Trigger the close animation
            ComputerCanvas.SetActive(false); // Deactivate the Canvas
            ExitButton.SetActive(false);
        }
    }
}
