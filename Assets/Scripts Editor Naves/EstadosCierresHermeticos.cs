using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadosCierresHermeticos : MonoBehaviour {

	public Material cierreOFF;
	public Material cierreON;
	public bool estadoCierre;

	// Use this for initialization
	void Start () 
	{
		GetComponent<Renderer>().material = cierreOFF;
	}
	
	public bool getEstadoCierreHermetico()
	{
		return estadoCierre;
	}

	private void OnTriggerEnter(Collider other) 
	{
		if(other.GetComponent<Collider>().tag == "cierreHermetico")
		{
			estadoCierre = true;
			GetComponent<Renderer>().material = cierreON;
		}
		
	}
	private void OnTriggerStay(Collider other) 
	{
		if(other.GetComponent<Collider>().tag == "cierreHermetico")
		{
			estadoCierre = true;
			GetComponent<Renderer>().material = cierreON;
		}
	}

	private void OnTriggerExit(Collider other) 
	{
		if(other.GetComponent<Collider>().tag == "cierreHermetico")
		{
			estadoCierre = false;
			GetComponent<Renderer>().material = cierreOFF;
		}
	}
}
