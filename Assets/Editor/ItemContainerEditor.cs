using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemContainer))] //dodaje do obiektów typu ItemContainer
public class ItemContainerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ItemContainer container = target as ItemContainer;
        if(GUILayout.Button("Clear container")) //tworzy przycisk do czyszczenia zawartości ekwipunku w menu inventory
        {
            for(int i=0; i < container.slots.Count; i++)
            {
                container.slots[i].Clear();
            }
        }
        DrawDefaultInspector();
    }
}
