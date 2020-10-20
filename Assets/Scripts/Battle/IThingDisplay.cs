
using UnityEngine;

public interface IThingDisplay   {

   GameObject itself { get; set; }

    void Place(GameObject gameObject);
}
