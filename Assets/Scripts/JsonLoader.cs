using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class JsonLoader : MonoBehaviour {

    string path;
    string jsonStr;
	// Use this for initialization
	void Start () {
        path = Application.streamingAssetsPath + "/story.json";
        jsonStr = File.ReadAllText(path);

        Debug.Log(jsonStr);
        var book= JsonUtility.FromJson<StoryList>(jsonStr);

        Debug.Log(book.stories.First().sentences.First().content);
	}
	
	 
}
[System.Serializable]
public class StoryList {
    public string sceneName;
    public List<Story> stories;

}
[System.Serializable]
public class Story{
    public List<Sentence> sentences;
    public string id;
}
[System.Serializable]
public class Sentence{
    public  string name;
    public string content;
}


[System.Serializable]
public class EnemyList{
    public List<Enemy> enemies;
}
[System.Serializable]
public class Enemy{
    public bool use;
    public string perfabs;
    public int level;
    public string name;

    public int magic;
    public int strength;
    public int intellect;
    public int luck;
    public int gold;

    public string stage;
    public string abilityCode;
}