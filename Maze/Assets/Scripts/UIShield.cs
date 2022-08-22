using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIShield : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private float timeBtwTap;
    [SerializeField] private float startTimeBtwTap;

    private PlayerMovement player;

    private bool isHold;

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        isHold = true;
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        isHold = false;
    }

    private void Start()
    {
        timeBtwTap = startTimeBtwTap;
        isHold = false;
    }

    private void Update()
    {
        player = FindObjectOfType<PlayerMovement>();
        if (player != null)
        {
            if (isHold)
            {
                if (timeBtwTap <= 0f)
                {
                    player.OffShield();
                }
                else
                {
                    player.OnShield();
                    timeBtwTap -= Time.deltaTime;
                }
            }
            else
            {
                player.OffShield();
                timeBtwTap = startTimeBtwTap;
            }
        }
    }
}
