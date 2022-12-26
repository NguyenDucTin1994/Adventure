using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Checkpoint currentCheckPoint;
    private PlayerController player;
    private CameraController _camera;
    public GameObject playerDeathParticle;
    public GameObject playerRespawnParticle;
    public float respawnDelay;
    // Start is called before the first frame update
    void Start()
    {
        player=FindObjectOfType<PlayerController>(); 
        _camera=FindObjectOfType<CameraController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }

    public IEnumerator RespawnPlayerCo()
    {
        SoundManager.PlaySound(2);
        Instantiate(playerDeathParticle, player.transform.position, player.transform.rotation);
        HealthManager.DecreaseHealth();
        player.isActive = false;
        player.rb.velocity = Vector2.zero;
        _camera.isFollowing = false;
        player.GetComponent<Renderer>().enabled = false;
        player.GetComponent<CircleCollider2D>().enabled = false;    

        yield return new WaitForSeconds(respawnDelay);

        
        player.transform.position = currentCheckPoint.transform.position;
        Instantiate(playerRespawnParticle, player.transform.position, player.transform.rotation);
        player.GetComponent<Renderer>().enabled = true;
        player.isActive = true;
        player.GetComponent<CircleCollider2D>().enabled = true;
        _camera.isFollowing = true;
    }
}
