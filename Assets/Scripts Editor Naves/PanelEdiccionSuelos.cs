using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelEdiccionSuelos : MonoBehaviour {

	public Button botonAdd;
	public Button botonDel;
	private GameObject cuboEditorScript;

	public Sprite addSuelto;
	public Sprite addPulsado;
	public Sprite delSuelto;
	public Sprite delPulsado;

	// Use this for initialization
	void Start () 
	{
		botonAdd.GetComponent<Button>().image.sprite = addPulsado;
		cuboEditorScript = GameObject.Find("CubeEditor");
	}

	public void pulsarAdd()
	{
		cuboEditorScript.GetComponent<MovimientoCuboEditor>().setEliminarBaldosasCreadas(false);
		botonAdd.GetComponent<Button>().image.sprite = addPulsado;
		botonDel.GetComponent<Button>().image.sprite = delSuelto;
	}

	public void pulsarDel()
	{
		cuboEditorScript.GetComponent<MovimientoCuboEditor>().setEliminarBaldosasCreadas(true);
		botonAdd.GetComponent<Button>().image.sprite = addSuelto;
		botonDel.GetComponent<Button>().image.sprite = delPulsado;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
