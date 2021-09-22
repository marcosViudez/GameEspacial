using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

[System.Serializable]

public class MovimientoCuboEditor : MonoBehaviour {

	public GameObject nave_espacial;
	public bool eliminarBaldosas;
	private GameObject botonesBaldosas;
	private GameObject masterEditor;
	public GameObject cuboArray;
	public GameObject guiaX;
	public GameObject guiaZ;
	public Text textoMatriz;
	public bool mouseOverCube;
	public bool editandoBaldosas;
	private RaycastHit hit;
	private Ray ray;
	private int moverX;
	private int moverZ;
	public Vector3[,] arrayPosiciones;
	public List<Vector3> listaArray;

	public List<Vector3> baldosasCreadas;
	public List<GameObject> objBaldosasCreadas;
	
	public Vector3 lastPosition;
	public Vector3 currentPosition;
	public int valorX;
	public int valorZ;
	public int indice;
	public bool activarCierres;
	public bool visibilidadCierres;

	// Use this for initialization
	void Start () 
	{
		masterEditor = GameObject.Find("MasterEditor");
		botonesBaldosas = GameObject.Find("PanelLista");
		arrayPosiciones = new Vector3[100,100];
		valorX = 1;
		valorZ = 1;
	}

	public void activarCierresHermeticos()
	{
		for(int i = 0; i < objBaldosasCreadas.Count; i++)
		{
			objBaldosasCreadas[i].GetComponent<BaldosaHermeticaCode>().comprobarCierres();
		}
		
	}

	public void desactivarCierresHermeticos()
	{
		for(int i = 0; i < objBaldosasCreadas.Count; i++)
		{
			objBaldosasCreadas[i].GetComponent<BaldosaHermeticaCode>().apagarCierres();
		}
		
	}

	public void mostrarCierresHermeticos()
	{
		for(int i = 0; i < objBaldosasCreadas.Count; i++)
		{
			objBaldosasCreadas[i].GetComponent<BaldosaHermeticaCode>().mostrarCierres();
		}
	}

	public void ocultarCierresHermeticos()
	{
		for(int i = 0; i < objBaldosasCreadas.Count; i++)
		{
			objBaldosasCreadas[i].GetComponent<BaldosaHermeticaCode>().ocultarCierres();
		}
	}

	public void setMostrarCierresHermeticos()
	{
		visibilidadCierres = !visibilidadCierres;
	}

	public void setCierresHermeticos()
	{
		activarCierres = !activarCierres;
	}
	
	public void setEliminarBaldosasCreadas(bool estado)
	{
		eliminarBaldosas = estado;
	}

	public Vector3 getLastPosition()
	{
		return lastPosition;
	}

	public Vector3 getCurrentPosition()
	{
		return currentPosition;
	}

	public int getValorX()
	{
		return valorX;
	}

	public int getValorZ()
	{
		return valorZ;
	}

	void guardarBaldosasCreadas(Vector3 obj)
	{
		// guarda las baldosas si no fueron creadas
		baldosasCreadas.Add(obj);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		funcionesMouseSuelos();

		if(activarCierres)
		{
			activarCierresHermeticos();
		}else{
			desactivarCierresHermeticos();
		}

		if(visibilidadCierres)
		{
			ocultarCierresHermeticos();
		}else{
			mostrarCierresHermeticos();
		}
		
	}

	void funcionesMouseSuelos()
	{
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if(Physics.Raycast(ray, out hit))
		{
			//  muevo el cuboEditor si las unidades X o Z son pares, ya que mi cuboEditor mide 2x2x2
			if((int)hit.point.x % 2 == 0)
			{
				moverX = (int)hit.point.x;
			}

			if((int)hit.point.z % 2 == 0)
			{
				moverZ = (int)hit.point.z;
			}

			// posicion del cubo de creacion con la altura del plano
			transform.position = new Vector3(moverX,0,moverZ);

			// pulsar down izquierdo del mouse
			// grabar coordenadas del calculo de la matriz de construccion
			if(Input.GetMouseButtonDown(0))
			{
				// calculamos la posicion last
				lastPosition = transform.position;
				// GetComponent<CubesCurrentDos>().setLastPosition(lastPosition);
				valorX = 1;
				valorZ = 1;
			}

			// soltar up izquierdo del mouse
			if(Input.GetMouseButtonUp(0))
			{
				// calculamos la posicion presente
				currentPosition = transform.position;
				guardarDatosIFMatrices();

				if(!eliminarBaldosas)
				{
					crearBaldosasLista();
				}else{
					eliminarBaldosasCreadas();
				}
				
				editandoBaldosas = false;
			}	

			// mientras tengo pulsado boton izquierdo mouse
			if(Input.GetMouseButton(0))
			{
				editandoBaldosas = true;
				// crearCuboHabitaculoCurrent();
				creandoMatrizSuelo();
			}
		}

		textoMatriz.transform.position = Input.mousePosition;
		// Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red);	
	}

	public void bakeSuelo()
	{
		for(int i = 0; i < objBaldosasCreadas.Count; i++)
		{
			objBaldosasCreadas[i].GetComponent<NavMeshSurface>().BuildNavMesh();
		}
	}

	void guardarDatosIFMatrices()
	{
		if(valorX == 1 || valorZ == 1)
		{
			// Debug.Log("alguno es uno");
			// creacion de baldosas Horizontales y Verticales ----------------------------------------------------------------------------
			if(lastPosition.x == currentPosition.x && lastPosition.z == currentPosition.z)
			{
				guardarMatrizDatosVerticales((int)lastPosition.x,(int)currentPosition.x,(int)lastPosition.z,(int)currentPosition.z);
			}
				
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
		listaArray.Clear();

		for(int i = menorX; i <= mayorX; i+=2)
		{
			listaArray.Add(new Vector3(i,0,menorZ));
		}
	}

	void guardarMatrizDatosVerticales(int menorX, int mayorX, int menorZ, int mayorZ)
	{
		listaArray.Clear();

		for(int i = menorZ; i <= mayorZ; i+=2)
		{
			listaArray.Add(new Vector3(menorX,0,i));
		}
	}

	public bool busquedaBaldosasCreadas(Vector3 pos)
	{
		// me dice si la baldosa buscada esta ya creada
		for(int i = 0; i < baldosasCreadas.Count; i++)
		{
			if(pos.Equals(baldosasCreadas[i]))
			{
				return true;
			}
		}
		return false;
	}

	void guardarMatrizDatos(int menorX, int mayorX, int menorZ, int mayorZ)
	{
		listaArray.Clear();

		for(int i = menorX; i <= mayorX; i+=2)
		{
			for(int j = menorZ; j <= mayorZ; j+=2)
			{
				listaArray.Add(new Vector3(i,0,j));
			}
		}
	}

	void crearBaldosasLista()
	{
		// crea las baldosas de la lista de posiciones
		for(int i = 0 ; i < listaArray.Count; i++)
		{
			if(!busquedaBaldosasCreadas(listaArray[i]))
			{
				// Debug.Log("baldosa creada");
				GameObject baldosaBuild = Instantiate(cuboArray,listaArray[i],Quaternion.Euler(0.0f,0.0f,0.0f));
				baldosaBuild.transform.SetParent(nave_espacial.transform);
				baldosaBuild.GetComponent<BaldosaHermeticaCode>().setNumeroBaldosaCreada(baldosasCreadas.Count + 1);
				objBaldosasCreadas.Add(baldosaBuild);
				guardarBaldosasCreadas(listaArray[i]);
				if(activarCierres)
				{
					activarCierresHermeticos();
				}
			}else{
				 // cambiaria la textura de la baldosa
				for(int j = 1; j < objBaldosasCreadas.Count; j++)
				{
					if(listaArray[i].Equals(objBaldosasCreadas[j].transform.position))
					{
						// Debug.Log(objBaldosasCreadas[j].GetComponent<BaldosaHermeticaCode>().getNumeroBaldosaCreada());
						// objBaldosasCreadas[objBaldosasCreadas[j].GetComponent<BaldosaHermeticaCode>().getNumeroBaldosaCreada()].GetComponent<Renderer>().material = 
						// masterEditor.GetComponent<MasterEditor>().GetMaterial();
					}
				}
				
			}
		}
		borrarTextoMatriz();
		listaArray.Clear();
	}

	void eliminarBaldosasCreadas()
	{
		for(int i = 0 ; i < listaArray.Count; i++)
		{
			for(int j = 0 ; j < baldosasCreadas.Count; j++)
			{
				if(listaArray[i] == baldosasCreadas[j])
				{
					// Debug.Log(i + ", elimino = " + j);
					objBaldosasCreadas[j].transform.position = new Vector3(objBaldosasCreadas[j].transform.position.x,-4,objBaldosasCreadas[j].transform.position.z);
					Destroy(objBaldosasCreadas[j],0.1f);
					objBaldosasCreadas.RemoveAt(j);
					baldosasCreadas.RemoveAt(j);
				}
			}
		}

		borrarTextoMatriz();
		listaArray.Clear();
	}

	void creandoMatrizSuelo()
	{
		if((int)hit.point.x % 2 == 0)
		{
			moverX = (int)hit.point.x;
		}

		if((int)hit.point.z % 2 == 0)
		{
			moverZ = (int)hit.point.z;
		}

		// calculo tamaño matriz mientras movemos pulsado el boton del raton izquierdo
		valorX = (((Mathf.Abs((int)lastPosition.x - (int)hit.point.x)) / 2) + 1);
		valorZ = (((Mathf.Abs((int)lastPosition.z - (int)hit.point.z)) / 2) + 1);
				
		// Debug.Log(transform.position);
		arrayPosiciones[valorX,valorZ] = this.transform.position;

		textoMatriz.text = valorX + "x" + valorZ;
	}

	public void eliminarBaldosaLista()
	{
		// elimina una baldosa de las listas y el gameobject
		baldosasCreadas.RemoveAt(5);
		Destroy(objBaldosasCreadas[5]);
		objBaldosasCreadas.RemoveAt(5);
	}

	void borrarTextoMatriz()
	{
		valorX = 1;
		valorZ = 1;
		textoMatriz.text = "";
	}

	private void OnMouseDrag() 
	{
		// transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,0,Input.mousePosition.y));
		transform.position = new Vector3(hit.point.x,0,hit.point.z);
	}

}
