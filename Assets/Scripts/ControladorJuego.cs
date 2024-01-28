using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorJuego : MonoBehaviour
{
    public static ControladorJuego Instance;
    [SerializeField] private GameObject jugador;
    public Vector3 respawnPosition;
    bool isPaused = false;

    public GameObject pausePanel;
    private int indexPuntosDeControl;

    private void Awake(){
        if (!Instance)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }

        isPaused = false;
    }

    public void setPlayer(GameObject player){
        jugador = player;
    }
    public void setRespawnPosition(Vector3 pos)
    {
        respawnPosition = pos;
    }

    public void respawn(){
        jugador.transform.position = respawnPosition;
    }

    public void HandlePause()
    {
        isPaused = !isPaused;

        if( isPaused = true ){
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }

    }
    public void DespausarPause(){
            Time.timeScale = 1;
            pausePanel.SetActive(false);
    }

}
