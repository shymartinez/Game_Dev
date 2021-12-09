using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [Header("Hud")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI ammoText;
    public Image healthBarFill;

    [Header("Pause Menu")]
    public Gameobject pauseMenu

    [Header("End Game Screen")]
    public Gameobject endGameScreen;
    public TextMeshProUGUI endGameHeaderText;
    public TextMeshProGUI endGameScoreText;

    // Instance
    public static GameUI instance;
     
     void Awake()
     {
        //Set The Instance To the Script 
        instance = this; 
     }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void UpdateHealthBar(int curHP, int maxHP); 
    {
        healthBarFill.fillAmount = (float)curHP / (float)maxHP;
    }

    public void UpdateScoreText(int score)
}
