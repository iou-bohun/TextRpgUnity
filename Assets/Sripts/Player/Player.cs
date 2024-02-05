using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Stat
{
    public string name;
    public int level;
    public int exp;

    public int Def;
    public int Atk;
    public int Health;
}

[System.Serializable]
public class Condition
{
    [HideInInspector]
    public float curValue;
    public float maxValue;
    public float startValue;
    public float regenRate;
    public float decayRate;
    public Slider slider;

    public void Add(float amount)
    {
        curValue = Mathf.Min(curValue +amount, maxValue); // 증가해야하느 요소는 Max이상으로 커지면 안되니까 MIn으로 
    }

    public void Subtract(float amount)
    {
        curValue = Mathf.Max(curValue - amount, 0.0f); // 감소해야하는 요소는 Min 이하로 작아지면 안되니까 Max로 
    }

    public float GetPercentage()
    {
        return curValue / maxValue;
    }
}


public class Player : MonoBehaviour
{
    public Action OnUIUpdateEvent;

    public Stat stat;
    public Condition exp;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] public TextMeshProUGUI expText;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private TextMeshProUGUI defText;
    [SerializeField] private TextMeshProUGUI atkText;
    [SerializeField] private TextMeshProUGUI goldText;

    public Sprite testicon;

    private void Awake()
    {
        OnUIUpdateEvent += SetTexts;
    }
    private void Start()
    {
        exp.curValue = exp.startValue;
        OnUIUpdateEvent?.Invoke();
    }

    private void Update()
    {
        exp.slider.value = exp.GetPercentage();
    }

    private void SetTexts()
    {
        nameText.text = stat.name;
        levelText.text = stat.level.ToString();
        expText.text = exp.curValue.ToString() +"/" + exp.maxValue.ToString();
        hpText.text = stat.Health.ToString();
        defText.text = stat.Def.ToString();
        atkText.text = stat.Atk.ToString();
        goldText.text = Bank.instance.CurrentBalance.ToString();

    }

}
