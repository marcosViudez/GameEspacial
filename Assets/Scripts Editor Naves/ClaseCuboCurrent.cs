using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaseCuboCurrent : MonoBehaviour {

	public Vector3 posicion;
	public bool estoyCreada;

	public ClaseCuboCurrent()
	{
		
	}

	public ClaseCuboCurrent(Vector3 pos, bool estado)
	{
		posicion = pos;
		estoyCreada = estado;
	}

	public void setPosicion(Vector3 pos)
	{
		posicion = pos;
	} 

	public Vector3 getPosicion()
	{
		return posicion;
	}

	public void setEstadoCreacion(bool estado)
	{
		estoyCreada = estado;
	}

	public bool getEstoyCreada()
	{
		return estoyCreada;
	}
	
}
