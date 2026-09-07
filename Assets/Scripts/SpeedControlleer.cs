using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SpeedControlleer : MonoBehaviour
{
    public float speed = 2f;
    [SerializeField] private float speedIncrease = 0.01f;
    [SerializeField] private float maxSpeed = 50f;

    private int coinCount = 0;
    private float score = 0;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI scoreText;


    void FixedUpdate()
    {
        scoreText.text = ((int)score).ToString();

        if(speed < maxSpeed)
            speed += speedIncrease;
        score += Time.deltaTime;
    }

    public void addCoin()
    {
        coinCount++;
    }
    public void End()
    {
        Time.timeScale = 0;
    }
}
