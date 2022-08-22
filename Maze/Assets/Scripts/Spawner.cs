using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnWalls;
    [SerializeField] private GameObject[] walls;

    [SerializeField] private Transform[] spawnDeadZones;
    [SerializeField] private GameObject deadZone;
    [SerializeField] private float border;

    private void Start()
    {
        SpawnWalls();
        SpawnDeadZones();
    }

    private void SpawnWalls()
    {
        for (int i = 0; i < spawnWalls.Length; i++)
        {
            int rand = Random.Range(0, walls.Length);
            Instantiate(walls[rand], spawnWalls[i].position, Quaternion.identity);
        }
    }

    private void SpawnDeadZones()
    {
        for (int i = 0; i < spawnDeadZones.Length; i++)
        {
            int rand = Random.Range(0, 10);
            float randZ = Random.Range(-border, border);

            if (rand > 4)
            {
                if (Mathf.Abs(randZ) >= 4.5f)
                {
                    Instantiate(deadZone, new Vector3(spawnDeadZones[i].position.x, spawnDeadZones[i].position.y, randZ), Quaternion.identity);
                    Instantiate(deadZone, new Vector3(spawnDeadZones[i].position.x, spawnDeadZones[i].position.y, -randZ), Quaternion.identity);
                }
                else if (rand > 7)
                {
                    Instantiate(deadZone, new Vector3(spawnDeadZones[i].position.x, spawnDeadZones[i].position.y, randZ), Quaternion.identity);
                }

            }
            else
            {
                Instantiate(deadZone, new Vector3(spawnDeadZones[i].position.x, spawnDeadZones[i].position.y, randZ), Quaternion.identity);
            }
        }
    }
}
