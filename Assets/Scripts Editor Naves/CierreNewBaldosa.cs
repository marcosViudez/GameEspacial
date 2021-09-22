using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CierreNewBaldosa : MonoBehaviour {

	private void OnTriggerEnter(Collider other) 
	{
		if(other.GetComponent<Collider>().tag == "cierreHermetico")
		{
			gameObject.GetComponent<Renderer>().enabled = false;
		}
	}

	private void OnTriggerStay(Collider other) 
	{
		if(other.GetComponent<Collider>().tag == "cierreHermetico")
		{
			gameObject.GetComponent<Renderer>().enabled = false;
		}
	}

	private void OnTriggerExit(Collider other) 
	{
		if(other.GetComponent<Collider>().tag == "cierreHermetico")
		{
			gameObject.GetComponent<Renderer>().enabled = true;
		}
	}
}
