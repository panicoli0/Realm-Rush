using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;
    Enemy enemy;

    // Start is called before the first frame update
    void OnEnable()
    { 
        FindPath();
        ResetToStart();
        StartCoroutine(FollowPath());
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void FindPath()
    {
        path.Clear(); //limpia elbuffer de camino

        GameObject parent = GameObject.FindGameObjectWithTag("Path"); //Busca todos los obj dentro del array con tag Path

        foreach (Transform child in parent.transform) //Recorre el array y por cada waypoint...
        {

            Waypoint waypoint = child.GetComponent<Waypoint>();
            if (waypoint != null)
            {
                path.Add(waypoint); //Agregar al array path la lista de waypoints
            }

        }
    }

    void ResetToStart()
    {
        transform.position = path[0].transform.position; //devolver al obj a la pos inicial
    }

    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path) //recorre toda la lista path y por cada waypoint toma una accion
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while (travelPercent < 1f)
            {
                travelPercent += speed * Time.deltaTime;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();


            }
        }
        finishPath();
    }

    void finishPath()
    {
        enemy.PenaltyGold();
        gameObject.SetActive(false);
    }
}
