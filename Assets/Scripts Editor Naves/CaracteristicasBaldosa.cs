using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaracteristicasBaldosa : MonoBehaviour {

	public Vector3 miPosicionBaldosa;
	public bool baldosaCreada;


	// Use this for initialization
	void Start () 
	{
		setBaldosaCreada(true);
		miPosicionBaldosa = transform.position;
	}

	public bool getBaldosaCreada()
	{
		return baldosaCreada;
	}

	public void setBaldosaCreada(bool estado)
	{
		baldosaCreada = estado;
	}

	public Vector3 getMiPosicionBaldosa()
	{
		return miPosicionBaldosa;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
