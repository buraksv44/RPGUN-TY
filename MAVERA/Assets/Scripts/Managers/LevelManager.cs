using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    private int currentExp;
    private int Level;
    private int expToNextLevel;
    public int GetLevel { get { return Level + 1; } }
    public static LevelManager instance;

    public Image ExBar;
    public Text LevelText;

    public GameObject LevelUpVFX;
    private Transform Player;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
        Level = 0;
        currentExp = 0;
        expToNextLevel = 100;
        ExBar.fillAmount = 0f;
        UpdateLevelText();
        Player = GameObject.Find("Player").gameObject.transform;

    }
    //private void Update()
   // {
        //if(Input.GetKeyDown(KeyCode.Z))
        //{
            //AddExp(100);
            //print(Level);
        //}
    //}

    public void AddExp(int amount)
    {
        currentExp+= amount;
        ExBar.fillAmount = (float)currentExp / expToNextLevel;
        if(currentExp > expToNextLevel)
        {
            Level++;
            GameObject LevelUpVFXClon = Instantiate(LevelUpVFX, Player.position, Quaternion.identity);
            LevelUpVFXClon.transform.SetParent(Player);
            UpdateLevelText();
            currentExp -= expToNextLevel;
            ExBar.fillAmount = 0f;
        }
    }
    void UpdateLevelText()
    {
        LevelText.text = GetLevel.ToString();
    }
    private void OnEnable()
    {
        EnemyHealth.OnDeath += AddExp;
    }
    private void OnDisable()
    {
        EnemyHealth.OnDeath -= AddExp;
    }
}
