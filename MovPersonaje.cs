using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovPersonaje : MonoBehaviour {

	Animator movi;
	public float speed = 0;
	public float speed1 = 0;
	public float atras = 0;
	public float movimientoA = 0;
	public float movimientoB = 0;
	public GameObject cabeza;


	public bool objeto = false;  	//casco
	public bool objeto1 = false; 	//audifonos
	public bool objeto2 = false;	//guantes
	public bool objeto3 = false;	//chaleco
	public bool objeto4 = false;	//motocierra
	public bool objeto5 = false;	//mascara
	public bool objeto6 = false;	//overol
	public bool objeto7 = false;	//botas
	public bool objeto8 = false;	//casco soldar
	public bool objeto9 = false;	//peto
	public bool objeto10 = false;	//soldador

	float a;
	bool paused = false;


	enum STATES{IDLE,WALK,WalkBack} // quieto,caminar, caminar hacia atras
	STATES currentState;


	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == "casco") 
		{
			objeto = true;
		}
		else
		{
			if (other.tag == "audifonos") 
			{
				objeto1 = true;	
			}
			else
			{
				if (other.tag =="guantes") 
				{
					objeto2 = true;	
				}
				else 
				{
					if (other.tag == "chaleco") 
					{
						objeto3 = true;	
					}		
				}
			}
		}
		///////////////////////// SEGUNDO NIVEL ///////////////////////////////////////
		if (other.tag == "motocierra") 
		{
			objeto4 = true;
		} 
		else 
		{
			if (other.tag == "mascara") 
			{
				objeto5 = true;
			} 
			else 
			{
				if (other.tag == "overol") 
				{
					objeto6 = true;
				} 
				else 
				{
					if (other.tag == "botas") 
					{
						objeto7 = true;
					} 	
				}
			}
		}
		///////////////////////// TERCER NIVEL ///////////////////////////////////////
		if (other.tag == "cascosold") 
		{
			objeto8 = true;
		} 
		else 
		{
			if (other.tag == "peto") 
			{
				objeto9 = true;
			} 
			else 
			{
				if (other.tag == "soldador") 
				{
					objeto10 = true;
				} 	
			}
		}

	}




	void Start () 
	{
		movi = GetComponent<Animator>();
		currentState = STATES.IDLE;
	}

	void Update () 
	{
		CheckConditions();	

		movimientoA = transform.position.x;
		transform.Translate(Vector3.forward * -Input.GetAxis("Mouse X") * speed1); 
		movimientoB = transform.position.x;

		if (movimientoA == movimientoB) 
		{
			a = -Input.GetAxis ("Mouse X");
		} 
		else 
		{
			a = Input.GetAxis ("Mouse X");

		}


	}


	void CheckConditions()
	{

		//Button0 es para el boton B del control	Joystick1Button0
		//Button1 es para el boton D del control	Joystick1Button1
		//Button2 es para el boton C del control	Joystick1Button
		//Button3 es para el boton A del control   	Joystick1Button4

		//Button6 es para el GATILLO DE arriba  del control   	Joystick1Button5

		// adelante
		if (a == 0.1f) 
		{
			currentState = STATES.WalkBack;

		} else if (a == -0.1f) 
		{
			currentState = STATES.WALK;

		} else 
		{
			currentState = STATES.IDLE;
		}

		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		if (Input.GetKey (KeyCode.Joystick1Button5)) // el gatillo de abajo  COGER OBJETO
		{
			movi.SetBool ("recoger", true);	
		} 
		else 
		{
			movi.SetBool ("recoger", false);

		}

		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		//if (Input.GetKey (KeyCode.Joystick1Button1)) // reiniciar el juego  BOTON D  
		//{
			//Application.LoadLevel ("Menu Inicio");
			//Application.LoadLevel ("JOBSECURITY");
		//} 

		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		//if (Input.GetKey (KeyCode.Joystick1Button0) && paused == false)  // Pausa del juego  BOTON B
		//{
		//	paused = true;
		//	Time.timeScale = 0;
		//	Application.LoadLevel ("Pausa");
		//}
		//else if (Input.GetKey (KeyCode.Joystick1Button0) && paused == true)
		//{
		//	paused = false;
		//	Time.timeScale = 1;
		//}
		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




		MakeBehaviour();	
	}

	void MakeBehaviour()
	{

		switch (currentState)
		{
		case STATES.IDLE:
			QUIETO ();
			break;

		case STATES.WALK:
			CAMINAR ();
			break;

		case STATES.WalkBack:
			CAMAtras ();
			break;
		}



	}

	void QUIETO()
	{
		movi.SetBool("quieto", true);
		movi.SetBool("CamAtras", false);
		movi.SetBool("caminar", false);

	}

	void CAMINAR()
	{
		//transform.Translate(Vector3.forward * -Input.GetAxis("Mouse X"));



		movi.SetBool("CamAtras", false);
		movi.SetBool("quieto", false);
		movi.SetBool("caminar", true);

	}

	void CAMAtras()
	{
		//transform.Translate (Vector3.back * atras * Time.deltaTime);


		movi.SetBool("CamAtras", true);
		movi.SetBool("quieto", false);
		movi.SetBool("caminar", false);


	}


}
