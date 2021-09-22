using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class listaTexturasSuelos : MonoBehaviour {

	public GameObject contenido;
	public GameObject boton;
	public List<GameObject> listaBotonesSuelos;

	public Sprite[] texturas;
	public Material[] materiales;


	// Use this for initialization
	void Start () 
	{
		
		texturas = Resources.LoadAll<Sprite> ("suelos");
		materiales = Resources.LoadAll<Material> ("texturasSuelos");
		
		for(int i = 0; i < texturas.Length; i++)
		{
			GameObject current = Instantiate(boton,transform.position,transform.rotation);
			current.GetComponent<PropiedadesBoton>().setTexture(texturas[i]);
			current.GetComponent<PropiedadesBoton>().setMaterial(materiales[i]);
			current.name = texturas[i].name.ToString();
			current.GetComponent<PropiedadesBoton>().setNumeroLista(i);
			current.transform.SetParent(contenido.transform);
			current.GetComponent<Image>().sprite = texturas[i];
			// baldosa.GetComponent<Renderer>().material.mainTexture = texturas;
			// listaBotonesSuelos.Add(current);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
