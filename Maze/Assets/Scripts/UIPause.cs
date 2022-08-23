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
            play.SetActive(true);
            exit.SetActive(true);
        }
    }
}
