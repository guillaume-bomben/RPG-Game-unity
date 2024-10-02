using TMPro;
using UnityEngine;

public class DisplayManager : MonoBehaviour
{
    public Stats stats; // Assigné dans l'inspecteur
    public GameObject Character; // Le personnage dont on veut obtenir le niveau

    void Start()
    {
        UpdateAllChildren();
    }

    void Update()
    {
        UpdateAllChildren();
    }

    void UpdateAllChildren()
    {
        // Parcourir tous les objets enfants du Canvas
        foreach (Transform child in transform)
        {
            // Si l'objet est une barre (se terminant par "_Bar")
            if (child.name.EndsWith("_Bar"))
            {
                UpdateBar(child);
            }
            // Si l'objet est une valeur (se terminant par "_Value")
            else if (child.name.EndsWith("_Value"))
            {
                UpdateValues(child);
            }
            // Si l'objet est la valeur de niveau ("LV Value")
            else if (child.name == "LV Value")
            {
                UpdateLevelValue(child);
            }
        }
    }

    void UpdateBar(Transform bar)
    {
        if (bar.name == "HP_Bar")
        {
            UpdateHealthBar(bar);
        }
        else if (bar.name == "MP_Bar")
        {
            UpdateManaBar(bar);
        }
        else if (bar.name == "STA_Bar")
        {
            UpdateStaminaBar(bar);
        }
    }

    void UpdateHealthBar(Transform bar)
    {
        float health = stats.GetStat(Stat.CurrentHealth);
        float maxHealth = stats.GetStat(Stat.Health);
        float healthPercent = health / maxHealth;
        bar.localScale = new Vector3(healthPercent, 1, 1);
    }

    void UpdateManaBar(Transform bar)
    {
        float mana = stats.GetStat(Stat.CurrentMana);
        float maxMana = stats.GetStat(Stat.Mana);
        float manaPercent = mana / maxMana;
        bar.localScale = new Vector3(manaPercent, 1, 1);
    }

    void UpdateStaminaBar(Transform bar)
    {
        float stamina = stats.GetStat(Stat.CurrentStamina);
        float maxStamina = stats.GetStat(Stat.Stamina);
        float staminaPercent = stamina / maxStamina;
        bar.localScale = new Vector3(staminaPercent, 1, 1);
    }

    void UpdateValues(Transform valueObject)
    {
        TextMeshProUGUI textComponent = valueObject.GetComponent<TextMeshProUGUI>();

        if (textComponent != null)
        {
            if (valueObject.name == "HP_Value")
            {
                float health = stats.GetStat(Stat.CurrentHealth);
                float maxHealth = stats.GetStat(Stat.Health);
                textComponent.text = health + "/" + maxHealth;
            }
            else if (valueObject.name == "MP_Value")
            {
                float mana = stats.GetStat(Stat.CurrentMana);
                float maxMana = stats.GetStat(Stat.Mana);
                textComponent.text = mana + "/" + maxMana;
            }
            else if (valueObject.name == "STA_Value")
            {
                float stamina = stats.GetStat(Stat.CurrentStamina);
                float maxStamina = stats.GetStat(Stat.Stamina);
                textComponent.text = stamina + "/" + maxStamina;
            }
        }
    }

    void UpdateLevelValue(Transform levelObject)
    {
        TextMeshProUGUI textComponent = levelObject.GetComponent<TextMeshProUGUI>();

        if (textComponent != null && Character != null)
        {
            uint level = Character.GetComponent<Character>().Level;
            textComponent.text = level.ToString();
        }
    }
}
