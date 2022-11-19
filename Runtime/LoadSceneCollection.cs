using UnityEngine;
using UnityEngine.SceneManagement;

namespace  VoydVoyd.SceneCollections
{
    public class LoadSceneCollection : MonoBehaviour
    {
        [SerializeField] private SceneCollection multiScene = null;
    
        private void Awake()
        {
            bool firstSceneLoaded = false;
            foreach (var sceneReference in multiScene.SceneReferences)
            {
                if (!firstSceneLoaded)
                {
                    SceneManager.LoadSceneAsync(sceneReference.ScenePath, LoadSceneMode.Single);
                    firstSceneLoaded = true;
                }
                else
                    SceneManager.LoadSceneAsync(sceneReference.ScenePath, LoadSceneMode.Additive);
            }
        }
    }
}
