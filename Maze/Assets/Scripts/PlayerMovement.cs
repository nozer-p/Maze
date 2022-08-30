using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private Camera camera;
    private NavMeshAgent agent;
    private float speed;
    [SerializeField] private GameObject finish;

    [SerializeField] private GameObject prefabEffDead;
    [SerializeField] private GameObject prefabEffWin;
    [SerializeField] private float offsetY;

    private bool shield;
    private MeshRenderer render;
    [SerializeField] private Material standartMaterial;
    [SerializeField] private Material shieldMaterial;


    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Vector3 spawnPlayer;

    private bool isWin;
    private GameObject winConfetti;

    private void Start()
    {
        isWin = false;
        camera = Camera.main;
        render = GetComponent<MeshRenderer>();
        agent = GetComponent<NavMeshAgent>();
        speed = agent.speed;
    }

    private void Update()
    {
        if (isWin && (agent.pathEndPosition - transform.position).magnitude <= 0.62f)
        {
            if (!winConfetti)
            {
                Application.LoadLevel(Application.loadedLevel);
            }

            /*
            DampingScreen damping = FindObjectOfType<DampingScreen>();
            if (damping != null)
            {
                damping.OnState();

                if (!winConfetti)
                {
                    Application.LoadLevel(Application.loadedLevel);
                }
            }
            */

        }

        if (finish != null && agent != null)
        {
            agent.SetDestination(finish.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            winConfetti = Instantiate(prefabEffWin, new Vector3(transform.position.x, transform.position.y + offsetY, transform.position.z), Quaternion.identity);
            isWin = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {        
        if (other.gameObject.tag == "DeadZone" && !shield)
        {
            Instantiate(prefabEffDead, new Vector3(transform.position.x, transform.position.y + offsetY, transform.position.z), Quaternion.identity);
            Instantiate(playerPrefab, spawnPlayer, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    public void OnShield()
    {
        shield = true;
        render.material = shieldMaterial;   
    }

    public void OffShield()
    {
        shield = false;
        render.material = standartMaterial;
    }

    public void StopPlayer()
    {
        if (agent != null) agent.speed = 0f;
    }

    public void UnStopPlayer()
    {
        if (agent != null) agent.speed = speed;
    }
}