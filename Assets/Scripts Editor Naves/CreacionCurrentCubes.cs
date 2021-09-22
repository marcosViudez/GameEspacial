using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreacionCurrentCubes : MonoBehaviour {
	public int valorX;
	public int valorZ;
	public Vector3 lastPosition;
	public GameObject cuboCurrent;
	public List<Vector3> listaCurrent;
	public List<Vector3> listaCubosCurrent;
	public List<GameObject> cubos;

	

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		valorX = GetComponent<MovimientoCuboEditor>().getValorX();
		valorZ = GetComponent<MovimientoCuboEditor>().getValorZ();
		lastPosition = GetComponent<MovimientoCuboEditor>().getLastPosition();

		if(Input.GetMouseButton(0))
		{
			guardarDatosIFMatrices();
			addCubos(listaCurrent);

		}

		if(Input.GetMouseButtonUp(0))
		{
			eliminarCubosCurrent();
		}
	}

	void guardarDatosIFMatrices()
	{
		if(valorX == 1 || valorZ == 1)
		{
			// Debug.Log("alguno es uno");
			// creacion de baldosas Horizontales y Verticales ----------------------------------------------------------------------------
			if(lastPosition.x == transform.position.x && lastPosition.z == transform.position.z)
			{
				guardarMatrizDatosVerticales((int)lastPosition.x,(int)transform.position.x,(int)lastPosition.z,(int)transform.position.z);
			}
				
			if(lastPosition.x == transform.position.x && lastPosition.z < transform.position.z)
			{
				guardarMatrizDatosVerticales((int)lastPosition.x,(int)transform.position.x,(int)lastPosition.z,(int)transform.position.z);
			}

			if(lastPosition.x == transform.position.x && lastPosition.z > transform.position.z)
			{
				guardarMatrizDatosVerticales((int)lastPosition.x,(int)transform.position.x,(int)transform.position.z,(int)lastPosition.z);
			}

			if(lastPosition.x > transform.position.x && lastPosition.z == transform.position.z)
			{
				guardarMatrizDatosHorizontales((int)transform.position.x,(int)lastPosition.x,(int)lastPosition.z,(int)transform.position.z);
			}

			if(lastPosition.x < transform.position.x && lastPosition.z == transform.position.z)
			{
				guardarMatrizDatosHorizontales((int)lastPosition.x,(int)transform.position.x,(int)lastPosition.z,(int)transform.position.z);
			}
			// ---------------------------------------------------------------------------------------------------------------------------
		}

		if(valorX != 1 && valorZ !=1)
		{
			// Debug.Log("los dos diferentes");
			// creacion de matrices de baldosas ------------------------------------------------------------------------------------------
			if(lastPosition.x < transform.position.x && lastPosition.z < transform.position.z)
			{
				guardarMatrizDatos((int)lastPosition.x,(int)transform.position.x,(int)lastPosition.z,(int)transform.position.z);
			}

			if(lastPosition.x < transform.position.x && lastPosition.z > transform.position.z)
			{
				guardarMatrizDatos((int)lastPosition.x,(int)transform.position.x,(int)transform.position.z,(int)lastPosition.z);
			}

			if(lastPosition.x > transform.position.x && lastPosition.z < transform.position.z)
			{
				guardarMatrizDatos((int)transform.position.x,(int)lastPosition.x,(int)lastPosition.z,(int)transform.position.z);
			}

			if(lastPosition.x > transform.position.x && lastPosition.z > transform.position.z)
			{
				guardarMatrizDatos((int)transform.position.x,(int)lastPosition.x,(int)transform.position.z,(int)lastPosition.z);
			}
		// ---------------------------------------------------------------------------------------------------------------------------
		}
	}

	void addCubos(List<Vector3> lista)
	{
		for(int i = 0; i < lista.Count; i++)
		{
			if(!listaCubosCurrent.Contains(lista[i]) && valorX%2==0 && valorZ%2==0)
			{
				listaCubosCurrent.Add(lista[i]);
				cubos.Add(Instantiate(cuboCurrent,lista[i],transform.rotation));
			}
		}
	}

	void guardarMatrizDatosHorizontales(int menorX, int mayorX, int menorZ, int mayorZ)
	{
		eliminarCubosCurrent();

		for(int i = menorX; i <= mayorX; i+=2)
		{
			listaCurrent.Add(new Vector3(i,0,menorZ));
		}
	}

	void guardarMatrizDatosVerticales(int menorX, int mayorX, int menorZ, int mayorZ)
	{
		eliminarCubosCurrent();

		for(int i = menorZ; i <= mayorZ; i+=2)
		{
			listaCurrent.Add(new Vector3(menorX,0,i));	
		}
	}

	void guardarMatrizDatos(int menorX, int mayorX, int menorZ, int mayorZ)
	{
		eliminarCubosCurrent();

		for(int i = menorX; i <= mayorX; i+=2)
		{
			for(int j = menorZ; j <= mayorZ; j+=2)
			{
				listaCurrent.Add(new Vector3(i,0,j));
			}
		}
	}

	void eliminarCubosCurrent()
	{
		listaCubosCurrent.Clear();
		listaCurrent.Clear();

		for(int i = 0; i < cubos.Count; i++)
		{
			GameObject.Destroy(cubos[i]);
		}
		cubos = new List<GameObject>();
		
	}
}
