using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] presets;

    private float spawn;

    private SpeedControlleer sp;

    void Start()
    {
        sp = FindAnyObjectByType<SpeedControlleer>().GetComponent<SpeedControlleer>();
    }

    private void FixedUpdate() {
        spawn -= Time.deltaTime;
        if(spawn <= 0){
            spawn = 12 / sp.speed;
            Instantiate(presets[Random.Range(0, presets.Length)], transform.position, Quaternion.identity);
        }
    }
}
