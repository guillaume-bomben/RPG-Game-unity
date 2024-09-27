using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatEntry {
    public Stat stat;
    public int value;
}

[CreateAssetMenu(fileName = "Stats", menuName = "Scriptable Objects/Stats")]
public class Stats : ScriptableObject {

    public List<StatEntry> statEntries = new();

    public void SetStat(Stat stat, int value) {
        var entry = statEntries.Find(e => e.stat == stat);
        if (entry != null) {
            entry.value = value;
        } else {
            statEntries.Add(new StatEntry { stat = stat, value = value });
        }
    }

    public int GetStat(Stat stat) {
        var entry = statEntries.Find(e => e.stat == stat);
        return entry != null ? entry.value : 0;
    }

    public void AddStat(Stat stat, int value) {
        var entry = statEntries.Find(e => e.stat == stat);
        if (entry != null) {
            entry.value += value;
        } else {
            statEntries.Add(new StatEntry { stat = stat, value = value });
        }
    }

    public void RemoveStat(Stat stat, int value) {
        var entry = statEntries.Find(e => e.stat == stat);
        if (entry != null) {
            entry.value -= value;
        }
    }
}
