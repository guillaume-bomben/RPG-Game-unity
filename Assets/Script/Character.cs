using UnityEngine;

class Character : MonoBehaviour{
    public Stats Basestats;
    private Stats CurrentStats;
    public uint Level;
    public uint Experience;
    private uint ExperienceToNextLevel;
    private uint MaxLevel = 100;
    private Sprite sprite;

    public void CalculateCurrentStats(){
        CurrentStats =  Basestats.Clone();
        foreach (StatEntry entry in CurrentStats.statEntries){
            CurrentStats.CalculateStat(entry.stat, Level);
        }
        Debug.Log("Stats Apres Calcul: ");
        foreach (StatEntry entry in CurrentStats.statEntries){
            Debug.Log(entry.stat + ": " + entry.value);
        }
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