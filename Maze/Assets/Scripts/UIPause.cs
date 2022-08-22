using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPause : MonoBehaviour
{
    [SerializeField] private GameObject play;
    [SerializeField] private GameObject exit;
    private PlayerMovement player;
    private DampingScreen damping;

    private void Start()
    {
        damping = FindObjectOfType<DampingScreen>();
        play.SetActive(false);
        exit.SetActive(false);
    }

    private void Update()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    public void Pause()
    {
        if (player != null)
        {
            damping.OnState();
            player.StopPlayer();
            gameObject.SetActive(false);
            play.SetActive(true);
            exit.SetActive(true);
        }
    }
}
