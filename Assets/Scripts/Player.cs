using System.Numerics;
using System.Runtime.CompilerServices;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class Player : MonoBehaviour {

    [SerializeField] private float gapMove;
    private bool canMove = true;
    private SpeedControlleer sp;

    void Start()
    {
        sp = FindAnyObjectByType<SpeedControlleer>().GetComponent<SpeedControlleer>();
        Time.timeScale = 1f;
    }
    void Update()
    {
        if(transform.position.y <= 0 && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && canMove)
        {
            MovePlayer(true);
        }
        if(transform.position.y >= 0 && (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && canMove)
        {
            MovePlayer(false);
        }
        if(Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    private void MovePlayer(bool moveSide)
    {
        transform.position = new UnityEngine.Vector2(transform.position.x, transform.position.y + (moveSide ? gapMove : -gapMove));
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy")){
            sp.End();
            canMove = false;
        }
    }
}
