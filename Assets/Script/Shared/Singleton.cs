using UnityEngine;
using System.Collections;
// ! 測試用
public class Singleton : MonoBehaviour
{
    private static Singleton _instance;

    public static Singleton Instance
    {
        get
        {
            if (_instance == null)
            {
                if (_instance == null)
                {
                    GameObject singleton = new GameObject();

                    _instance = singleton.AddComponent<Singleton>();
                    singleton.name = "[Singleton] " + typeof(Singleton).ToString();

                    DontDestroyOnLoad(singleton);

                    Debug.Log("[Singleton] An instance of " + typeof(Singleton) +
                              " is needed in the scene, so '" + singleton +
                              "' was created with DontDestroyOnLoad.");
                }
                else
                {
                    Debug.Log("[Singleton] Using instance already created: " +
                              _instance.gameObject.name);
                }
            }

            return _instance;
        }
    }
}