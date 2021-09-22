using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class demoWalk : MonoBehaviour {


	private NavMeshAgent agent;
	public Vector3 vectorDestino;
	

	// Use this for initialization
	void Start () 
	{
		agent = GetComponent<NavMeshAgent> (); 
	}
	
	// Update is called once per frame
	void Update () 
	{
		agent.destination = vectorDestino;
	}
}
