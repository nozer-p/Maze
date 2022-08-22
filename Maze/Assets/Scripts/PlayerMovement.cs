using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private Camera camera;
    private NavMeshAgent agent;
    [SerializeField] private GameObject finish;

    [SerializeField] private GameObject prefabEffDead;

    private bool shield;
    private MeshRenderer render;
    [SerializeField] private Material standartMaterial;
    [SerializeField] private Material shieldMaterial;

    private void Start()
    {
        camera = Camera.main;
        render = GetComponent<MeshRenderer>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (finish != null)
        {
            agent.SetDestination(finish.transform.position);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            Debug.Log("Win");
        }
        
        if (other.gameObject.tag == "DeadZone" && !shield)
        {
            Destroy(this.gameObject);
            Debug.Log("Lose");
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
}