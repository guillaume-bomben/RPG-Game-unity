using UnityEngine;

public class InfoDisplay : MonoBehaviour{

    public Stats stats;
    public GameObject Character;

    void Start(){
        if (gameObject.name.EndsWith("_Bar")){
            UpdateBar();
        }
        else if (gameObject.name.EndsWith("_Value")){
            UpdateValues();
        }
        else if (gameObject.name == "LV Value"){
            GetComponent<TMPro.TextMeshProUGUI>().text = "" + Character.GetComponent<Character>().Level;
        }
    }

    void Update(){
        if (gameObject.name.EndsWith("_Bar")){
            UpdateBar();
        }
        else if (gameObject.name.EndsWith("_Value")){
            UpdateValues();
        }
        else if (gameObject.name == "LV Value"){
            GetComponent<TMPro.TextMeshProUGUI>().text = "" + Character.GetComponent<Character>().Level;
        }
    }

    public void UpdateBar(){
        if (gameObject.name == "HP_Bar"){
            UpdateHealthBar();
        }
        else if (gameObject.name == "MP_Bar"){
            UpdateManaBar();
        }
        else if (gameObject.name == "STA_Bar"){
            UpdateStaminaBar();
        }
    }

    public void UpdateHealthBar(){
        float health = stats.GetStat(Stat.CurrentHealth);
        float maxHealth = stats.GetStat(Stat.Health);
        float healthPercent = health / maxHealth;
        transform.localScale = new Vector3(healthPercent, 1, 1);
    }

    public void UpdateManaBar(){
        float mana = stats.GetStat(Stat.CurrentMana);
        float maxMana = stats.GetStat(Stat.Mana);
        float manaPercent = mana / maxMana;
        transform.localScale = new Vector3(manaPercent, 1, 1);
    }

    public void UpdateStaminaBar(){
        float stamina = stats.GetStat(Stat.CurrentStamina);
        float maxStamina = stats.GetStat(Stat.Stamina);
        float staminaPercent = stamina / maxStamina;
        transform.localScale = new Vector3(staminaPercent, 1, 1);
    }


    public void UpdateValues(){
        if (gameObject.name == "HP_Value"){
            UpdateHealthValues();
        }
        else if (gameObject.name == "MP_Value"){
            UpdateManaValues();
        }
        else if (gameObject.name == "STA_Value"){
            UpdateStaminaValues();
        }
    }

    public void UpdateHealthValues(){
        float health = stats.GetStat(Stat.CurrentHealth);
        float maxHealth = stats.GetStat(Stat.Health);
        GetComponent<TMPro.TextMeshProUGUI>().text = health + "/" + maxHealth;
    }

    public void UpdateManaValues(){
        float mana = stats.GetStat(Stat.CurrentMana);
        float maxMana = stats.GetStat(Stat.Mana);
        GetComponent<TMPro.TextMeshProUGUI>().text = mana + "/" + maxMana;
    }

    public void UpdateStaminaValues(){
        float stamina = stats.GetStat(Stat.CurrentStamina);
        float maxStamina = stats.GetStat(Stat.Stamina);
        GetComponent<TMPro.TextMeshProUGUI>().text = stamina + "/" + maxStamina;
    }
}
