using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaldosaHermeticaCode : MonoBehaviour {

	public const int scaleYParedes = 5;
	public GameObject activacionParedes;
	public GameObject cierreHermeticoUp;
	public GameObject cierreHermeticoDown;
	public GameObject cierreHermeticoRight;
	public GameObject cierreHermeticoLeft;
	public GameObject paredFrontal;
	public GameObject paredTrasera;
	public GameObject paredDerecha;
	public GameObject paredIzquierda;

	public int numeroBaldosaCreada;
	public Vector3 baldosaPositionLocal;

	// Use this for initialization
	void Start () 
	{
		
	}

	public int getNumeroBaldosaCreada()
	{
		return numeroBaldosaCreada;
	}

	public void setNumeroBaldosaCreada(int n)
	{
		numeroBaldosaCreada = n;
	}

	public void ocultarCierres()
	{
		activacionParedes.GetComponent<Renderer>().enabled = false;
		cierreHermeticoDown.GetComponent<Renderer>().enabled = false;
		cierreHermeticoLeft.GetComponent<Renderer>().enabled = false;
		cierreHermeticoRight.GetComponent<Renderer>().enabled = false;
		cierreHermeticoUp.GetComponent<Renderer>().enabled = false;
	}

	public void mostrarCierres()
	{
		activacionParedes.GetComponent<Renderer>().enabled = true;
		cierreHermeticoDown.GetComponent<Renderer>().enabled = true;
		cierreHermeticoLeft.GetComponent<Renderer>().enabled = true;
		cierreHermeticoRight.GetComponent<Renderer>().enabled = true;
		cierreHermeticoUp.GetComponent<Renderer>().enabled = true;
	}

	public void comprobarCierres()
	{
		if(cierreHermeticoUp.GetComponent<EstadosCierresHermeticos>().getEstadoCierreHermetico() == false)
		{
			paredFrontal.transform.localScale = new Vector3(0.5f,5.0f,0.5f);
		}else{
			paredFrontal.transform.localScale = new Vector3(0.5f,0.0f,0.5f);
		}

		if(cierreHermeticoDown.GetComponent<EstadosCierresHermeticos>().getEstadoCierreHermetico() == false)
		{
			paredTrasera.transform.localScale = new Vector3(0.5f,5.0f,0.5f);
		}else{
			paredTrasera.transform.localScale = new Vector3(0.5f,0.0f,0.5f);
		}

		if(cierreHermeticoRight.GetComponent<EstadosCierresHermeticos>().getEstadoCierreHermetico() == false)
		{
			paredDerecha.transform.localScale = new Vector3(0.5f,5.0f,0.5f);
		}else{
			paredDerecha.transform.localScale = new Vector3(0.5f,0.0f,0.5f);
		}

		if(cierreHermeticoLeft.GetComponent<EstadosCierresHermeticos>().getEstadoCierreHermetico() == false)
		{
			paredIzquierda.transform.localScale = new Vector3(0.5f,5.0f,0.5f);
		}else{
			paredIzquierda.transform.localScale = new Vector3(0.5f,0.0f,0.5f);
		}
	}

	public void apagarCierres()
	{
		paredFrontal.transform.localScale = new Vector3(0.5f,0.0f,0.5f);
		paredTrasera.transform.localScale = new Vector3(0.5f,0.0f,0.5f);
		paredDerecha.transform.localScale = new Vector3(0.5f,0.0f,0.5f);
		paredIzquierda.transform.localScale = new Vector3(0.5f,0.0f,0.5f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		baldosaPositionLocal = transform.position + transform.parent.position;
	}

	void OnMouseOver() 
	{
		// al pasar por encima de las baldosas me dice la textura que tiene y el numero de baldosa
		// Debug.Log(GetComponent<Renderer>().material + "numero de baldosa: " + numeroBaldosaCreada);
	}
}
