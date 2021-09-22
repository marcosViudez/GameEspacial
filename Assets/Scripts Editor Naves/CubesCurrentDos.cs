using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesCurrentDos : MonoBehaviour {

	public int valorX;
	public int valorZ;
	public Vector3 lastPosition;
	public Vector3 currentPosition;
	public GameObject cubo;

	public List<Vector3> listaSueloCurrent;
	public List<GameObject> SueloCurrent;
	private GameObject masterEditor;

	// Use this for initialization
	void Start () 
	{
		masterEditor = GameObject.Find("MasterEditor");
	}

	public void setLastPosition(Vector3 pos)
	{
		lastPosition = pos;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
			botonesCreacionCurrent();
		
		
	}

	void botonesCreacionCurrent()
	{
		if((int)transform.position.x % 2 == 0)
		{
			currentPosition.x = (int)transform.position.x;
		}

		if((int)transform.position.z % 2 == 0)
		{
			currentPosition.z = (int)transform.position.z;
		}
		
		currentPosition.y = 0;

		valorX = GetComponent<MovimientoCuboEditor>().getValorX();
		valorZ = GetComponent<MovimientoCuboEditor>().getValorZ();
		
		if(Input.GetMouseButtonDown(0))
		{
			lastPosition = transform.position;
		}

		if(Input.GetMouseButton(0))
		{
			guardarDatosMatrices();
		}

		if(Input.GetMouseButtonUp(0))
		{
			listaSueloCurrent.Clear();
			eliminarObjetosSuelo();
		}
	}

	void guardarDatosMatrices()
	{

		if(valorX == 1 && valorZ == 1)
		{
			if(lastPosition.x == currentPosition.x && lastPosition.z == currentPosition.z)
			{
				guardarMatrizDatosVerticales((int)lastPosition.x,(int)currentPosition.x,(int)lastPosition.z,(int)currentPosition.z);
			}
		}

		if(valorX == 1 || valorZ == 1)
		{
			// Debug.Log("alguno es uno");
			// creacion de baldosas Horizontales y Verticales ----------------------------------------------------------------------------	
			if(lastPosition.x == currentPosition.x && lastPosition.z < currentPosition.z)
			{
				guardarMatrizDatosVerticales((int)lastPosition.x,(int)currentPosition.x,(int)lastPosition.z,(int)currentPosition.z);
			}

			if(lastPosition.x == currentPosition.x && lastPosition.z > currentPosition.z)
			{
				guardarMatrizDatosVerticales((int)lastPosition.x,(int)currentPosition.x,(int)currentPosition.z,(int)lastPosition.z);
			}

			if(lastPosition.x > currentPosition.x && lastPosition.z == currentPosition.z)
			{
				guardarMatrizDatosHorizontales((int)currentPosition.x,(int)lastPosition.x,(int)lastPosition.z,(int)currentPosition.z);
			}

			if(lastPosition.x < currentPosition.x && lastPosition.z == currentPosition.z)
			{
				guardarMatrizDatosHorizontales((int)lastPosition.x,(int)currentPosition.x,(int)lastPosition.z,(int)currentPosition.z);
			}
			// ---------------------------------------------------------------------------------------------------------------------------
		}

		if(valorX != 1 && valorZ !=1)
		{
			// Debug.Log("los dos diferentes");
			// creacion de matrices de baldosas ------------------------------------------------------------------------------------------
			if(lastPosition.x < currentPosition.x && lastPosition.z < currentPosition.z)
			{
				guardarMatrizDatos((int)lastPosition.x,(int)currentPosition.x,(int)lastPosition.z,(int)currentPosition.z);
			}

			if(lastPosition.x < currentPosition.x && lastPosition.z > currentPosition.z)
			{
				guardarMatrizDatos((int)lastPosition.x,(int)currentPosition.x,(int)currentPosition.z,(int)lastPosition.z);
			}

			if(lastPosition.x > currentPosition.x && lastPosition.z < currentPosition.z)
			{
				guardarMatrizDatos((int)currentPosition.x,(int)lastPosition.x,(int)lastPosition.z,(int)currentPosition.z);
			}

			if(lastPosition.x > currentPosition.x && lastPosition.z > currentPosition.z)
			{
				guardarMatrizDatos((int)currentPosition.x,(int)lastPosition.x,(int)currentPosition.z,(int)lastPosition.z);
			}
		// ---------------------------------------------------------------------------------------------------------------------------
		}
	}

	void guardarMatrizDatosHorizontales(int menorX, int mayorX, int menorZ, int mayorZ)
	{
		listaSueloCurrent.Clear();
		 eliminarObjetosSuelo();

		for(int i = menorX; i <= mayorX; i+=2)
		{
			listaSueloCurrent.Add(new Vector3(i,0,menorZ));
			SueloCurrent.Add(Instantiate(cubo,new Vector3(i,0,menorZ),transform.rotation));
		}
	}

	void guardarMatrizDatosVerticales(int menorX, int mayorX, int menorZ, int mayorZ)
	{
		listaSueloCurrent.Clear();
		 eliminarObjetosSuelo();

		for(int i = menorZ; i <= mayorZ; i+=2)
		{
			listaSueloCurrent.Add(new Vector3(menorX,0,i));	
			SueloCurrent.Add(Instantiate(cubo,new Vector3(menorX,0,i),transform.rotation));
		}
	}

	void guardarMatrizDatos(int menorX, int mayorX, int menorZ, int mayorZ)
	{
		listaSueloCurrent.Clear();
		 eliminarObjetosSuelo();

		for(int i = menorX; i <= mayorX; i+=2)
		{
			for(int j = menorZ; j <= mayorZ; j+=2)
			{
				listaSueloCurrent.Add(new Vector3(i,0,j));
				SueloCurrent.Add(Instantiate(cubo,new Vector3(i,0,j),transform.rotation));
				// Debug.Log("creado");
			}
		}
	}

	void eliminarObjetosSuelo()
	{
		for(int i = 0; i < SueloCurrent.Count; i++)
		{
			GameObject.Destroy(SueloCurrent[i]);
		}
		SueloCurrent = new List<GameObject>();
	}


}
