using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterEditor : MonoBehaviour {

	public Material usingMaterial;
	public bool editandoSuelos;
	public bool editandoParedes;

	// Use this for initialization
	void Start () 
	{
		
	}

	public void setEditandoSuelo(bool estado)
	{
		editandoSuelos = estado;
	}

	public bool getEditandoSuelo()
	{
		return editandoSuelos;
	}

	public void setEditandoParedes(bool estado)
	{
		editandoParedes = estado;
	}

	public bool getEditandoParedes()
	{
		return editandoParedes;
	}

	public void cambiaMaterial(Material mat)
	{
		usingMaterial = mat;
	}

	public Material GetMaterial()
	{
		return usingMaterial;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
