using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControlledDoor : MonoBehaviour
{
    public GameObject button;
    public string requiredButtonTag = "PlayerButton";
    public float interactionRange = 3f;
    private bool isOpen = false;
    
    void Update()
    {
        if (!isOpen && IsButtonPressed())
        {
            OpenDoor();
        }
    }

    bool IsButtonPressed()
    {
        if (button != null)
        {
            float distance = Vector2.Distance(transform.position, button.transform.position);
            bool isButtonTagCorrect = button.CompareTag(requiredButtonTag);

            return distance < interactionRange && isButtonTagCorrect && Input.GetKeyDown(KeyCode.E);
        }
        return false;
    }

    void OpenDoor()
    {
        transform.Rotate(Vector3.up, 90f);

        isOpen = true;
    }
}
