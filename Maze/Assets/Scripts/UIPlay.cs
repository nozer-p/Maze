using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlay : MonoBehaviour
{
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject exit;

    private void Start()
    {
        pause.SetActive(true);
        exit.SetActive(true);
    }

    public void Play()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
        pause.SetActive(true);
        exit.SetActive(false);
    }
}
