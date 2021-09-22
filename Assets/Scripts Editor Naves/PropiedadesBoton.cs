using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropiedadesBoton : MonoBehaviour {

	public string nameBoton;
	public int numeroLista;
	public Sprite texturaBoton;
	public Material materialBoton;
	public GameObject baldosa;
	private GameObject masterEditor;

	// Use this for initialization
	void Start () 
	{
		masterEditor = GameObject.Find("MasterEditor");
	}

	public void cambiarTexturaBaldosa()
	{
		baldosa.GetComponent<Renderer>().material = materialBoton;
		masterEditor.GetComponent<MasterEditor>().cambiaMaterial(materialBoton);
	}

	public void setTexture(Sprite textura)
	{
		texturaBoton = textura;
	}

	public Sprite getTexture()
	{
		return texturaBoton;
	}

	public void setMaterial(Material material)
	{
		materialBoton = material;
	}

	public int getNumeroLista()
	{
		return numeroLista;
	}

	public void setNumeroLista(int n)
	{
		numeroLista = n;
	}
	
	public string getName()
	{
		return nameBoton;
	}

	public void nombre()
	{
		nameBoton = gameObject.name;
	}
}
