using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Path : MonoBehaviour
{
	[SerializeField] private GameObject finish;
	[SerializeField] private NavMeshAgent agent;

	[SerializeField] private GameObject point; // префаб для Waypoints
	[SerializeField] private GameObject line; // префаб для линий, между Waypoints

	[SerializeField] private float distance = 1; // минимальная дистанция между точками, чтобы не рисовать те, которые слишком близко
	[SerializeField] private float height = 0.01f; // коррекция позиции по высоте

	private List<GameObject> points;
	private Vector3 agentPoint;
	private Vector3 lastPoint;
	private List<GameObject> lines;

	void Awake()
	{
		points = new List<GameObject>();
		lines = new List<GameObject>();
		UpdatePath();
	}

	void ClearArray() // удаление объектов и очистка массивов
	{
		foreach (GameObject obj in points)
		{
			Destroy(obj);
		}
		foreach (GameObject obj in lines)
		{
			Destroy(obj);
		}
		lines = new List<GameObject>();
		points = new List<GameObject>();
	}

	bool IsDistance(Vector3 distancePoint) // проверка дистанции между Waypoints
	{
		bool result = false;
		float dis = Vector3.Distance(lastPoint, distancePoint);
		if (dis > distance) result = true;
		lastPoint = distancePoint;
		return result;
	}

	void UpdatePath() // рисуем путь
	{
		lastPoint = agent.transform.position + Vector3.forward * 100f; // чтобы создать точку в текущей позиции

		ClearArray();

		for (int j = 0; j < agent.path.corners.Length; j++)
		{
			if (IsDistance(agent.path.corners[j]))
			{
				GameObject p = Instantiate(point) as GameObject;
				p.transform.position = agent.path.corners[j] + Vector3.up * height; // создаем точку и корректируем позицию 
				p.transform.position = new Vector3(p.transform.position.x, 0.5f, p.transform.position.z);
				points.Add(p);
			}
		}

		for (int j = 0; j < points.Count; j++)
		{
			if (j + 1 < points.Count)
			{
				Vector3 center = (points[j].transform.position + points[j + 1].transform.position) / 2; // находим центр между точками
				Vector3 vec = points[j].transform.position - points[j + 1].transform.position; // находим вектор от точки А, к точке Б
				float dis = Vector3.Distance(points[j].transform.position, points[j + 1].transform.position); // находим дистанцию между А и Б

				GameObject p = Instantiate(line) as GameObject;
				p.transform.position = center - Vector3.up * height;
				p.transform.position = new Vector3(p.transform.position.x, 0.5f, p.transform.position.z);
				p.transform.rotation = Quaternion.FromToRotation(Vector3.right, vec.normalized); // разворот по вектору
				p.transform.localScale = new Vector3(dis, p.transform.localScale.y, p.transform.localScale.z); // растягиваем по Х
				lines.Add(p);
			}
		}
	}

	void Update()
	{
		if (finish != null && agent != null)
		{
			agent.SetDestination(finish.transform.position);

			if (agentPoint != agent.path.corners[agent.path.corners.Length - 1]) UpdatePath(); // рисуем путь если был изменена конечная точка назначения
			agentPoint = agent.path.corners[agent.path.corners.Length - 1]; // запоминаем текущую конечную точку назначения

			if (agent.path.corners.Length == 1 && points.Count > 1) UpdatePath(); // рисуем путь, после прибытия в точку назначения
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Finish")
		{
			Destroy(gameObject);
		}
	}
}