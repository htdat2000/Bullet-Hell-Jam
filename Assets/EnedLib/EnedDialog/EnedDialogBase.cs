using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

namespace EnedUtil
{
    public class EnedDialog
    {
        private List<EnedSentence> sentences = new();
        private int currentSentenceIndex = 0;
        public List<EnedSentence> LoadDialog(IEDialogConvertible rawData)
        {
            if (rawData == null)
            {
                Debug.LogError("[EnedDialog/LoadDialog] failed because rawData = null!!!");
                return this.sentences;
            }
            
            List<EnedSentence> result = rawData.ConvertToSentenceList(out bool isSuccess);

            if (isSuccess)
                this.sentences = result;

            return this.sentences;
        }
        public EnedSentence GetEnedSentence(out bool isSuccess, int sentenceIndex = -1)
        {
            if (sentenceIndex < 0)
                sentenceIndex = currentSentenceIndex;

            if (sentences != null && sentenceIndex < sentences.Count)
            {
                currentSentenceIndex++;
                isSuccess = true;
                return sentences[sentenceIndex];
            }
            Debug.Log("[EnedDialog/GetEnedSentence] End of dialog");
            isSuccess = false;
            return null;
        }
        // public EnedSentence NextSentence(out bool isFinish)
        // {
        //     isFinish = false;
        //     return null;
        // }
    }

    public class EnedSentence
    {
        public string SentenceID {get; set;}
        public string ActorID {get; set;}
        public string ContentID {get; set;}
        public string ConditionID {get; set;}
        public string EventTriggerID {get; set;}

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            char breakLine = '\n';

            stringBuilder.Append("SentenceID : " + this.SentenceID);
            stringBuilder.Append(breakLine);
            stringBuilder.Append("ActorID : " + this.ActorID);
            stringBuilder.Append(breakLine);
            stringBuilder.Append("ContentID : " + this.ContentID);
            stringBuilder.Append(breakLine);
            stringBuilder.Append("ConditionID : " + this.ConditionID);
            stringBuilder.Append(breakLine);
            stringBuilder.Append("EventTriggerID : " + this.EventTriggerID);

            return stringBuilder.ToString();
        }
    }

    public interface IESentenceConvertible
    {
        public EnedSentence ConvertToSentence();
    }
    public interface IEDialogConvertible
    {
        public List<EnedSentence> ConvertToSentenceList(out bool isSuccess);
    }
}
