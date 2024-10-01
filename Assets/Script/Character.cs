#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

class Character : MonoBehaviour{
    public Stats Basestats;
    public Stats CurrentStats;
    public uint Level;
    public uint Experience;
    private uint ExperienceToNextLevel;
    private uint MaxLevel = 100;
    public bool isAlive;
    private Sprite sprite;

    public void Start(){
        CalculateCurrentStats();
    }


    public void CalculateCurrentStats(){
        foreach (StatEntry entry in CurrentStats.statEntries){
            CurrentStats.SetStat(entry.stat, (uint)Basestats.GetStat(entry.stat));
            CurrentStats.CalculateStat(entry.stat, Level);
        }
        CurrentStats.SetStat(Stat.CurrentHealth, (uint)CurrentStats.GetStat(Stat.Health));
        if (CurrentStats.GetStat(Stat.Mana) > 0){
            CurrentStats.SetStat(Stat.CurrentMana, (uint)CurrentStats.GetStat(Stat.Mana));
        }
        if (CurrentStats.GetStat(Stat.Stamina) > 0){
            CurrentStats.SetStat(Stat.CurrentStamina, (uint)CurrentStats.GetStat(Stat.Stamina));
        }
        Debug.Log("Stats Apres Calcul: ");
        foreach (StatEntry entry in CurrentStats.statEntries){
            Debug.Log(entry.stat + ": " + entry.value);
        }

        #if UNITY_EDITOR
        UnityEditor.EditorUtility.SetDirty(CurrentStats);
        AssetDatabase.SaveAssets();
        #endif
    }

    public void GainExperience(uint value){
        Experience += value;
        if (Experience >= ExperienceToNextLevel){
            LevelUp();
        }
    }

    public void LevelUp(){
        if (Level < MaxLevel){
            Level++;
            if (Level == MaxLevel){
                Experience = 0;
                ExperienceToNextLevel = 0;
            }
            else{
                Experience -= ExperienceToNextLevel;
                ExperienceToNextLevel = (uint)(ExperienceToNextLevel * 1.1f);
            }
            CalculateCurrentStats();
        }
    }
}