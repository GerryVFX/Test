using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour
{
    private NavMeshAgent _agent;

    public Transform _currentObjetive;
    public Transform[] _objetives;
    public Transform player;

    public bool playerDetected;

    RaycastHit hit;
    public float timeToReturn;
    
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();      
        _currentObjetive = _objetives[1];
    }

    private void OnTriggerEnter(Collider other)
    {
        
            if (other.CompareTag("obj01"))
                _currentObjetive = _objetives[2];
            if (other.CompareTag("obj02"))
                _currentObjetive = _objetives[3];
            if (other.CompareTag("obj03"))
                _currentObjetive = _objetives[0];
            if (other.CompareTag("obj00"))
                _currentObjetive = _objetives[1];  
    }


    void Update()
    {
        //Uso de raycast para detectar el player

        Ray ray= new Ray(transform.position, transform.forward);

        if(Physics.Raycast(ray, out hit, 5f))
        {
            print(hit.transform.gameObject.name);

            if (hit.transform.gameObject.CompareTag("Player"))
            {
                timeToReturn = 10;
                playerDetected = true;
            }
        }

        //Revisar distancia entre el jugador y volver a objetivos
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance > 1.5f) 
        {
            timeToReturn -= Time.deltaTime;
        }

        if(timeToReturn <= 0)
        {
            playerDetected = false;
        }

        //Cambio de objetivo
        if (playerDetected == false) 
        {
            _agent.destination = _currentObjetive.position;
            _agent.stoppingDistance = 0;
        }     
        else
        {   
            _agent.destination = player.position;
            _agent.stoppingDistance = 1.5f;
        }
        
    }
}
