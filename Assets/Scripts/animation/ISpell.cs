

using UnityEngine;

public interface ISpell
{
    void Create(GameObject target, Vector3 position);
    void Create(GameObject spellObj, GameObject target, Vector3 position);
    void Play();
}
