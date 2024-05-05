using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnedUtil
{
    [CreateAssetMenu(fileName = "New Ened Dialog Classic Data", menuName = "EnedUtil/Ened Dialog Classic Data")]
    public class EnedDialogClassicData : ScriptableObject, IEDialogConvertible
    {
        public List<EnedSentenceClassicData> sentenceClassicDatas;
        public List<EnedSentence> ConvertToSentenceList(out bool isSuccess)
        {
            List<EnedSentence> result = new List<EnedSentence>();
            foreach (EnedSentenceClassicData sentence in sentenceClassicDatas)
            {
                result.Add(sentence.ConvertToSentence());
            }
            isSuccess = result.Count > 0;

            return result;
        }
    }
    [Serializable]
    public class EnedSentenceClassicData : IESentenceConvertible
    {
        [SerializeField] private string sentenceID;
        [SerializeField] private string actorID; // LOC
        [SerializeField] private string contentID; // LOC
        [SerializeField] private string conditionID;
        [SerializeField] private string eventTriggerID;
        public EnedSentence ConvertToSentence()
        {
            EnedSentence result = new EnedSentence();

            result.SentenceID = this.sentenceID;
            result.ActorID = this.actorID;
            result.ContentID = this.contentID;
            result.ConditionID = this.conditionID;
            result.EventTriggerID = this.eventTriggerID;

            return result;
        }
    }
}