using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NotesList : MonoBehaviour
{
    [Serializable]
    private class NotesItem
    {
        public float time;
        public NotesManager.NotesPositon Pos;
    }

    private List<NotesItem> notesList;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReadJsonFromResource(string fileName)
    {
        var v = (Resources.Load($"Json/{fileName}") as TextAsset).text;

		notesList = JsonUtility.FromJson<Serialization<NotesItem>>(v).ToList();
    }
}
