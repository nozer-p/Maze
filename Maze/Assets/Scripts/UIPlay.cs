using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlay : MonoBehaviour
{
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject exit;
    private PlayerMovement player;
    private DampingScreen damping;

    private void Start()
    {
        damping = FindObjectOfType<DampingScreen>();
    }

    private void Update()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    public void Play()
    {
        if (player != null)
        {
            damping.OffState();
            player.UnStopPlayer();
            gameObject.SetActive(false);
            pause.SetActive(true);
            exit.SetActive(false);
        }
    }
}