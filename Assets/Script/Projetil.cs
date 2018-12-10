using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour {

    private Rigidbody2D rb;

	public string direcao = "esquerda";
//	private float initializationTime;
	
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();		
		
		if(direcao == "esquerda")
		{					
			Vector2 newv2;
			newv2 = gameObject.transform.position;
			newv2.x = newv2.x - 0.6f;
			gameObject.transform.position= newv2;
		}
//		initializationTime = Time.timeSinceLevelLoad;
	DestroyObjectDelayed();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 v2 = rb.velocity;		
//		float timeSinceInitialization = Time.timeSinceLevelLoad - initializationTime;
		
//			Debug.Log(timeSinceInitialization);
		
		if(direcao == "direita")
		{		
			rb.velocity = new Vector2(4.0f, v2.y);	
		}
		else if(direcao == "esquerda")
		{	
			rb.velocity = new Vector2(-4.0f, v2.y);	
		}		
	}
	
	void DestroyObjectDelayed()
    {
        // Kills the game object in 5 seconds after loading the object
        Destroy(gameObject, 5);
    }
	
	void OnTriggerEnter2D(Collider2D col)
    {
		if(col.gameObject.tag != "Player" && col.gameObject.tag != "Projetil") 
		{
			Destroy(gameObject);
			Debug.Log("Colidiu");	
		}		
	}
	
}
