using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesManager : MonoBehaviour
{

    #region  editor
    [SerializeField]
    private GameObject startPos1;

    [SerializeField]
    private GameObject startPos2;

    [SerializeField]
    private GameObject startPos3;

    [SerializeField]
    private GameObject startPos4;

    [SerializeField]
    private GameObject startPos5;

    [SerializeField]
    private GameObject endPos1;

    [SerializeField]
    private GameObject endPos2;

    [SerializeField]
    private GameObject endPos3;

    [SerializeField]
    private GameObject endPos4;

    [SerializeField]
    private GameObject endPos5;

    [SerializeField]
    private GameObject NotesPrefab;
    #endregion

    #region Postion
    private Vector3 start1, start2, start3, start4, start5;
    private Vector3 end1, end2, end3, end4, end5;
    #endregion

	// 動作しているノーツのリスト
	private List<GameObject> NotesList = new List<GameObject>();

	private const float NotesTimeToDist = 2.0f;

    // ノーツの種類
    public enum NotesKind
    {
        Normal,
        HighScore,
    }

    // ノーツの場所
    public enum NotesPositon
    {
        Pos1,
        Pos2,
        Pos3,
        Pos4,
        Pos5,
    }

    // Use this for initialization
    void Start()
    {
        start1 = startPos1.transform.position;
        start2 = startPos2.transform.position;
        start3 = startPos3.transform.position;
        start4 = startPos4.transform.position;
        start5 = startPos5.transform.position;

        end1 = endPos1.transform.position;
        end2 = endPos2.transform.position;
        end3 = endPos3.transform.position;
        end4 = endPos4.transform.position;
        end5 = endPos5.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MakeNotes(NotesKind kind, NotesPositon pos)
    {
		GameObject obj = null;

        switch (pos)
        {
            case NotesPositon.Pos1:
				obj = Instantiate(NotesPrefab, start1, NotesPrefab.transform.rotation);
				obj.GetComponent<NotesMove>().SetMoveInf(end1, NotesTimeToDist);
                break;
            case NotesPositon.Pos2:
				obj = Instantiate(NotesPrefab, start2, NotesPrefab.transform.rotation);
				obj.GetComponent<NotesMove>().SetMoveInf(end2, NotesTimeToDist);
                break;
            case NotesPositon.Pos3:
				obj = Instantiate(NotesPrefab, start3, NotesPrefab.transform.rotation);
				obj.GetComponent<NotesMove>().SetMoveInf(end3, NotesTimeToDist);
                break;
            case NotesPositon.Pos4:
				obj = Instantiate(NotesPrefab, start4, NotesPrefab.transform.rotation);
				obj.GetComponent<NotesMove>().SetMoveInf(end4, NotesTimeToDist);
                break;
            case NotesPositon.Pos5:
				obj = Instantiate(NotesPrefab, start5, NotesPrefab.transform.rotation);
				obj.GetComponent<NotesMove>().SetMoveInf(end5, NotesTimeToDist);
                break;
        }

		if(obj != null)
			NotesList.Add(obj);
    }
}
