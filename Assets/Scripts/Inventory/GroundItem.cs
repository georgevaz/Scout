using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GroundItem : MonoBehaviour, ISerializationCallbackReceiver
{
    public ItemObject item;

    public void OnAfterDeserialize()
    {

    }
    public void OnBeforeSerialize()
    {
        GetComponentInChildren<MeshFilter>().mesh = item.prefab.GetComponent<MeshFilter>().sharedMesh;
        EditorUtility.SetDirty(GetComponentInChildren<MeshFilter>());
        GetComponentInChildren<MeshRenderer>().material = item.prefab.GetComponent<MeshRenderer>().sharedMaterial;
        EditorUtility.SetDirty(GetComponentInChildren<MeshRenderer>());
        transform.GetChild(0).transform.localScale = item.prefab.transform.localScale;
        EditorUtility.SetDirty(transform.GetChild(0).transform);

    }
}
