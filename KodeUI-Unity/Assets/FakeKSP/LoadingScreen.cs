using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KodeUI
{
    public class LoadingScreen : MonoBehaviour
    {
        public static LoadingScreen Instance;

        public List<LoadingSystem> loaders = new List<LoadingSystem>();

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            Debug.Log("Start LoadingScreen");

            loaders.Add(new GameObject("KodeUI_Loader").AddComponent<KodeUI_Loader.Loader>());
            loaders.Add(UITester.Instance);

            StartCoroutine(Load());
        }

        private IEnumerator Load()
        {
            foreach (LoadingSystem loader in loaders)
            {
                loader.StartLoad();

                while (!loader.IsReady())
                {
                    yield return null;
                    Debug.Log("Loaded  " + loader.GetType().Name);
                }
            }
        }
    }
}