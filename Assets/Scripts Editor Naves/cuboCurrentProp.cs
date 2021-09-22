using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuboCurrentProp : MonoBehaviour {

	public bool estoyCreado;
	
	public void setEstoyCreado(bool estado)
	{
		estoyCreado = estado;
	}

	public bool getEstoyCreado()
	{
		return estoyCreado;
	}
}
