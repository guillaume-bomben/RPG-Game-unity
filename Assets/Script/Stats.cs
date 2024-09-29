using System.Collections.Generic;
using System.Resources;
using UnityEngine;

[System.Serializable]
public class StatEntry {
    public Stat stat;
    public uint value;
}

[CreateAssetMenu(fileName = "Stats", menuName = "Scriptable Objects/Stats")]
public class Stats : ScriptableObject {

    public List<StatEntry> statEntries = new();

    public void SetStat(Stat stat, uint value) {
        var entry = statEntries.Find(e => e.stat == stat);
        if (entry != null) {
            entry.value = value;
        } else {
            statEntries.Add(new StatEntry { stat = stat, value = value });
        }
    }

    public int GetStat(Stat stat) {
        var entry = statEntries.Find(e => e.stat == stat);
        return entry != null ? (int)entry.value : 0;
    }

    public void AddStat(Stat stat, uint value) {
        var entry = statEntries.Find(e => e.stat == stat);
        if (entry != null) {
            entry.value += value;
        } else {
            statEntries.Add(new StatEntry { stat = stat, value = value });
        }
    }

    public void RemoveStat(Stat stat, uint value) {
        var entry = statEntries.Find(e => e.stat == stat);
        if (entry != null) {
            entry.value -= value;
        }
    }

    public void CalculateStat(Stat stat, uint level) {
        float newValue = 0;
        var entry = statEntries.Find(e => e.stat == stat);
        if (entry != null) {
            float baseStat = entry.value;
            // Calcul suivant la formule donnée
            if (stat == Stat.Health) {
                newValue = (level / 100f + 1 ) * baseStat / 1.5f + ((Mathf.Sqrt(baseStat) + level) / 2.5f);
            }
            else{
                newValue = ((level / 100f + 1 ) * baseStat) + level + ((Mathf.Sqrt(baseStat) + level) / 2.5f);
            }
            // Mettre à jour la valeur de la stat
            entry.value = (uint)newValue;
        }
    }

    public Stats Clone() {
        Stats clone = ScriptableObject.CreateInstance<Stats>();
        foreach (StatEntry entry in statEntries) {
            StatEntry newEntry = new StatEntry {
                stat = entry.stat,
                value = entry.value
            };
            clone.statEntries.Add(newEntry);
        }
        return clone;
    }

}
