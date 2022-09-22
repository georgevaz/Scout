using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using static Models;

public class GroundItem : MonoBehaviour, ISerializationCallbackReceiver, Interactable
{
    public ItemObject item;

    public void Interact(InteractableParameters interactableParameters)
    {
        interactableParameters.entityInventory.PickUpItem(interactableParameters.collider);
    }

    public void OnAfterDeserialize()
    {

    }
    public void OnBeforeSerialize()
    {
        if (item != null)
        {
#if UNITY_EDITOR
            GetComponentInChildren<MeshFilter>().mesh = item.prefab.GetComponent<MeshFilter>().sharedMesh;
            EditorUtility.SetDirty(GetComponentInChildren<MeshFilter>());
            GetComponentInChildren<MeshRenderer>().material = item.prefab.GetComponent<MeshRenderer>().sharedMaterial;
            EditorUtility.SetDirty(GetComponentInChildren<MeshRenderer>());
            transform.GetChild(0).transform.localScale = item.prefab.transform.localScale;
            EditorUtility.SetDirty(transform.GetChild(0).transform);
#endif

        }
    }
}
