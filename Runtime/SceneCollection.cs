using UnityEditor;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor.Callbacks;
using UnityEditor.SceneManagement;
#endif

namespace VoydVoyd.SceneCollections
{
	[CreateAssetMenu(order = 201, fileName = "New Scene Collection", menuName = "Scene Collection")]
    public class SceneCollection : ScriptableObject
    {
    	//[HorizontalGroup("Lighting")]
    	//[SerializeField] private LightingSettings lightingSettings;
        [SerializeField] private SceneReference[] sceneReferences;
    
        public SceneReference[] SceneReferences => sceneReferences;
    
    #if UNITY_EDITOR
    
    	// [Button("Apply"), HorizontalGroup("Lighting")]
     //    private void ApplyLightSettings()
     //    {
    	//     if (lightingSettings != null)
    	//     {
    	// 	    SceneSetup[] sceneSetups = EditorSceneManager.GetSceneManagerSetup();
    	// 	    foreach (var sceneReference in sceneReferences)
    	// 	    {
    	// 		    if (sceneReference == null) continue;
    	// 		    
    	// 		    Scene scene = EditorSceneManager.OpenScene(sceneReference.ScenePath);
    	// 		    EditorSceneManager.SetActiveScene(scene);
    	// 		    Lightmapping.SetLightingSettingsForScene(scene, lightingSettings);
    	// 		    EditorSceneManager.SaveScene(scene);
    	// 	    }
    	// 	    EditorSceneManager.RestoreSceneManagerSetup(sceneSetups);
    	//     }
     //    }
    
        [OnOpenAsset( 1 )]
        static bool OnOpenAsset ( int id, int line ) {
        	var obj = EditorUtility.InstanceIDToObject( id );
            if (obj is SceneCollection collection)
            {
    	        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
    	        {
    		        bool firstSceneLoaded = false;
    		        foreach (var reference in collection.sceneReferences)
    		        {
    			        if (!firstSceneLoaded)
    			        {
    				        EditorSceneManager.OpenScene(reference.ScenePath, OpenSceneMode.Single);
    				        firstSceneLoaded = true;
    			        }
    			        else
    			        {
    				        EditorSceneManager.OpenScene(reference.ScenePath, OpenSceneMode.Additive);
    			        }
    		        }
    	        }
    	        
    	        return true;
            }
    
            return false;;
        }
    #endif
    }
}

