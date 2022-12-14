using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DampingScreen : MonoBehaviour
{
    private Image panel;

    private bool state;
    //private bool restart;
    //private bool up_down;

    [SerializeField] private float speed;
    private float speedOld;

    private PlayerMovement player;

    //private float time;
    //[SerializeField] float startTime;

    private void Start()
    {
        //time = startTime;
        speedOld = 1f;

        panel = GetComponent<Image>();
        panel.color = new Color(Color.black.r, Color.black.g, Color.black.b, speedOld);

        //restart = false;
        //up_down = false;
    }

    public void OnState()
    {
        state = true;
    }

    public void OffState()
    {
        state = false;
    }

    public void RestartLevel()
    {
        //restart = true;
    }

    private bool CheckPlayer()
    {
        player = FindObjectOfType<PlayerMovement>();
        return (player == null) ? false : true;
    }

    private void FixedUpdate()
    {
        /*
        if (restart)
        {
            if (panel.color.a > 0.99f && !up_down)
            {
                panel.enabled = true;
                speedOld = 1f;
                Instantiate(playerPrefab, spawnPlayer, Quaternion.identity);
                CheckPlayer();
                player.StopPlayer();
                up_down = true;
            }

            if (panel.color.a < 0.2f && up_down)
            {
                speedOld = 0f;
                up_down = false;
            }

            if (up_down)
            {
                speedOld -= speed * Time.deltaTime;
            }
            else
            {
                speedOld += speed * Time.deltaTime;
            }

            panel.color = new Color(Color.black.r, Color.black.g, Color.black.b, speedOld);

            if (time <= 0f)
            {
                state = false;
                restart = false;
                time = startTime;
                panel.enabled = false;
                if (player != null) player.UnStopPlayer();
            }
            else
            {
                time -= Time.deltaTime;
            }
        }
        else
        {
            if (state && panel.color.a < 0.7f)
            {
                panel.enabled = true;
                player.StopPlayer();
                speedOld += speed * Time.deltaTime;
                panel.color = new Color(Color.black.r, Color.black.g, Color.black.b, speedOld);
            }
            
            if (!state && panel.color.a > 0f)
            {
                if (player != null)
                {
                    panel.enabled = true;
                    player.StopPlayer();
                }
                
                speedOld -= speed * Time.deltaTime;

                if (speedOld <= 0f)
                {
                    if (player != null)
                    {
                        panel.enabled = false;
                        player.UnStopPlayer();
                    }
                    speedOld = 0f;
                }
                
                panel.color = new Color(Color.black.r, Color.black.g, Color.black.b, speedOld);
            }
        }

        CheckPlayer();
        */

        if (CheckPlayer())
        {
            if (state && panel.color.a < 0.7f)
            {
                panel.enabled = true;
                player.StopPlayer();
                speedOld += speed * Time.deltaTime;
                panel.color = new Color(Color.black.r, Color.black.g, Color.black.b, speedOld);
            }

            if (!state && panel.color.a > 0f)
            {
                panel.enabled = true;
                player.StopPlayer();

                speedOld -= speed * Time.deltaTime;

                if (speedOld <= 0f)
                {
                    panel.enabled = false;
                    player.UnStopPlayer();
                    speedOld = 0f;
                }

                panel.color = new Color(Color.black.r, Color.black.g, Color.black.b, speedOld);
            }
        }
    }
}