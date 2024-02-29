using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doors : MonoBehaviour
{
    public string sceneToLoad;
    public float interactionRange = 3f;
    private bool isOpen = false;

    void Update()
    {
        if (!isOpen && IsPlayerNear())
        {
            OpenDoor();
            LoadNextScene();
        }
    }

    bool IsPlayerNear()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            return distance < interactionRange;
        }
        return false;
    }

    void OpenDoor()
    {
        transform.Rotate(Vector3.up, 90f);

        isOpen = true;
    }

    void LoadNextScene()
    {
        Invoke("LoadScene", 2f);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
