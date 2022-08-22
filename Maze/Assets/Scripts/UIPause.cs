using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPause : MonoBehaviour
{
    [SerializeField] private GameObject play;
    [SerializeField] private GameObject exit;

    private void Start()
    {
        play.SetActive(false);
        exit.SetActive(false);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        gameObject.SetActive(false);
        play.SetActive(true);
        exit.SetActive(true);
    }
}
