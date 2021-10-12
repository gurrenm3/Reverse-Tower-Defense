using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public NextLevelInfo nextLevelInfo;

    public int health;

    private bool i = true;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            var collider = collision.gameObject.GetComponent<Projectile>();
            health =- collider.towerInformation.attackDamage;
            Destroy(collision.gameObject);
        }
    }

    void Update()
    {
        if (i == true)
        {
            
            if (health <= 0)
            {
                LevelControler newLevelControler = GameObject.Find("WinSquare").GetComponent<LevelControler>();

                newLevelControler.WinScreenAppear();

                i = false;

            }
        }
        if (i == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LevelControler newLevelControler = GameObject.Find("WinSquare").GetComponent<LevelControler>();
                Debug.Log("space pressed");
                newLevelControler.LevelChanger(nextLevelInfo.nextLevel.ToString());
                Debug.Log("after space pressed");
            }

        }
    }
           
        
        
    
       
    
      

}

