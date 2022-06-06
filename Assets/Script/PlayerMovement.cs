using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator playerAnimation;
    Rigidbody2D myRigidbody;
    List<GameObject> horst=new List<GameObject>();
    [SerializeField] float moveSpeed;
    bool sideWalk;
    bool frontWalk;
    public bool isWalking,isOnCliff;
    public bool isSearchingPokemon = true;
    public float pokemonSearchTime=2f;
    void Start()
    {
        playerAnimation = GetComponent<Animator>(); 
        myRigidbody = GetComponent<Rigidbody2D>();
        FindHorst();
    }

    void Update()
    {
        MoveTowardsYaxis();
        MoveTowardsXaxis();
        WaitForPokemonSearch();
        EnableWalkOnHorst();
    }
    void MoveTowardsYaxis()
    {
        
        if (Input.GetAxis("Vertical")!=0&&!sideWalk)
        {
            float moveVector=Input.GetAxis("Vertical")*moveSpeed*Time.deltaTime;
            transform.position += new Vector3(0,moveVector );
            playerAnimation.SetBool("MoveForward", true);
            frontWalk = true;
            isWalking = true;

        }
        else
        {
            frontWalk=false;
            isWalking =false;
        }
        PlayWalkAnimationOnYaxis();
    }
    void PlayWalkAnimationOnYaxis()
    {
       
        if(Input.GetAxis("Vertical")>0&&!sideWalk)
        {
            playerAnimation.SetBool("MoveForward", true);
        }
        else
        {
            playerAnimation.SetBool("MoveForward", false);
        }
        if(Input.GetAxis("Vertical") < 0&&!sideWalk)
        {
          playerAnimation.SetBool("MoveBackward",true);
        }
        else
        {
            playerAnimation.SetBool("MoveBackward", false);
        }
    }
    void MoveTowardsXaxis()
    {
        if(Input.GetAxis("Horizontal")!=0 && Input.GetAxis("Vertical") == 0)
        {
            float moveVector=Input.GetAxis("Horizontal")*moveSpeed * Time.deltaTime;
            transform.position += new Vector3(moveVector,0);
            sideWalk = true;
            isWalking=true;
        }
        else
        {
            sideWalk=false;
            isWalking=false;
        }
        PlayWalkAnimationOnXaxis();
    }
    void PlayWalkAnimationOnXaxis()
    {
        
        if (Input.GetAxis("Horizontal") > 0&&!frontWalk)
        {
            playerAnimation.SetBool("MoveRight", true);
        }
        else
        {
            playerAnimation.SetBool("MoveRight", false);
        }
        if (Input.GetAxis("Horizontal") < 0&&!frontWalk)
        {
            
            playerAnimation.SetBool("MoveLeft", true);
        }
        else
        { 
            playerAnimation.SetBool("MoveLeft", false);
        }
    }
    void WaitForPokemonSearch()
    {
        pokemonSearchTime -= Time.deltaTime;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HorstBorder")
        {
            isOnCliff = false;
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HorstBorder")
        {
            isOnCliff = true;
            Debug.Log(isOnCliff);
        }
    }
    void EnableWalkOnHorst()
    {
        for(int i = 0; i < horst.Count; i++)
        {
            if (isOnCliff)
            {
                Debug.Log("false");
                horst[i].SetActive(false);
            }
            else
            {
                horst[i].SetActive(true);
            }
        }
        
    }
   void FindHorst()
    {
        horst.Clear();
        GameObject[] horsts = GameObject.FindGameObjectsWithTag("Horst");
        foreach(GameObject horster in horsts)
        {
            horst.Add(horster);
        }
    }


}
