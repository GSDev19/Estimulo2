using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Transform respawnPosition;

        void OnTriggerEnter2D(Collider2D other)
        {
               if(other.gameObject.CompareTag("Player"))
        {
            ControladorJuego.Instance.setRespawnPosition(respawnPosition.position);
        }
        } 


}
