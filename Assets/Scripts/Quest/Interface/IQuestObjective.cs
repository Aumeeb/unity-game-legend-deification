using UnityEngine;

public interface IQuestObjectve
{
    string Title { get; }
    string Decsription { get; }
    void UpdateProgress();
    void CheckProgress();
}