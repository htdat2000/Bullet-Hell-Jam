using System.Collections;
using System.Collections.Generic;
using EnedUtil;
using UnityEngine;

namespace Dialog
{
    public class EnedDialogSampleManager : MonoBehaviour
    {
        [SerializeField] private EnedDialogClassicData data;
        private EnedDialog dialogData;
        private void Start()
        {
            dialogData = new();
            dialogData.LoadDialog(data);

            Debug.Log(dialogData.GetSentence(out bool _)?.ToString());
            Debug.Log(dialogData.GetSentence(out bool _)?.ToString());
            Debug.Log(dialogData.GetSentence(out bool _)?.ToString());
            Debug.Log(dialogData.GetSentence(out bool _)?.ToString());
        }
    }
}
