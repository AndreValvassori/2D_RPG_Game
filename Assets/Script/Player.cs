using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody2D rb;
	private GameObject sprite;
	private Animator animator;
	
	private string direcao = "direita";
	
	public bool onGround = true;
	
	// Use this for initialization
	void Start () {		
        rb = GetComponent<Rigidbody2D>();
		sprite = GameObject.Find("Sprite");		
        animator = sprite.GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey("d"))
        {
			animator.SetBool("Run", true);
			direcao = "direita";	
			
			Vector3 v3 = sprite.transform.localScale;
			v3.x = 1;
            sprite.transform.localScale = v3;
			
			Vector2 v2 = rb.velocity;
			rb.velocity = new Vector2(2.0f, v2.y);
        }
		else		
		if (Input.GetKey("a"))
        {
			animator.SetBool("Run", true);
			
			direcao = "esquerda";					
			Vector3 v3 = sprite.transform.localScale;
			v3.x = -1;
            sprite.transform.localScale = v3;	
			
			Vector2 v2 = rb.velocity;
			rb.velocity = new Vector2(-2.0f, v2.y);	
        }		
		else
		{	
			animator.SetBool("Run", false);			
		}

		if (Input.GetKeyDown("w"))
        {
			if(onGround)
			{					
				animator.SetTrigger("Jump");
				
				Vector2 v2 = rb.velocity;
				rb.velocity = new Vector2(v2.x, 3.0f);			
				
				onGround = false;
			}			
        }

		if (Input.GetKeyDown("space"))
        {
			if(Input.GetKey("a") || Input.GetKey("d"))				
			{
				animator.SetTrigger("Fire_Run");	
			}		
			else
			{
				animator.SetTrigger("Fire_Idle");	
			}
				
			Vector2 newv2;
			
			GameObject prefab = Resources.Load("Prefab/Tiro", typeof(GameObject)) as GameObject;
			GameObject instance = Instantiate(prefab);
//			prefab.direcao = direcao;
//			Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefab/tiro.prefab", typeof(GameObject));
//			GameObject clone = Instantiate(prefab, new Vector3(2.0F, 0, 0), Quaternion.identity) as GameObject;
						
			Projetil prj = prefab.GetComponent<Projetil>();
			prj.direcao = direcao;
			newv2 = gameObject.transform.position;
			newv2.x = newv2.x+1.0f;
			newv2.y = newv2.y+1.1f;
			instance.transform.position = newv2;

//			Debug.Log("Player Position: "+ gameObject.transform.position);
//			Debug.Log("Projetil Position: "+ instance.transform.position);
			
			
			
        }
	}
	
	void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Ground") || (collision.gameObject.tag == "Wall"))
        {
			onGround = true;
        }
		else if (collision.gameObject.tag == "Felippe")
		{
			
		}
		else
		{
			
		}
    }
	
	
/*	// Tipos de objetos
	
	int = numeros inteiros 
	float = 1.1, 1.6 
	bool = 	
	string = "andre vlavassori"
	
	if = se()
	
	while(onGround)
	{
		"felippe"
	}
	
*/	
	
}
