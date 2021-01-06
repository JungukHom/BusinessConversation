﻿namespace RESC
{
    // C#
    using System.Collections.Generic;

    // Unity
    using UnityEngine;

    // Project
    // Alias

    using static RESC.CSVQuizOXDataHeader;

    public class CSVQuizOXDataContainer : CSVDataContainer
    {
        private static CSVQuizOXDataContainer _instance = null;

        public static CSVQuizOXDataContainer GetOrCreateInstance() => _instance ?? (_instance = new CSVQuizOXDataContainer());

        private readonly List<CSVQuizOXDataHolder> holderList = new List<CSVQuizOXDataHolder>();

        private CSVQuizOXDataContainer()
        {
            List<Dictionary<string, object>> dataList = CSVReader.Read("Datas/db_quiz_ox");

            //// TODO : Delete debugging log
            //for (int i = 0; i < dataList.Count; i++)
            //{
            //    Dictionary<string, object> dic = dataList[i];
            //    string temp = $"{i} ->\n";
            //    foreach (KeyValuePair<string, object> pair in dic)
            //    {
            //        temp += $"{pair.Key.ToString()} : {pair.Value.ToString()}\n";
            //    }
            //    Debug.Log(temp);
            //}

            for (int i = 0; i < 42; i++)
            {
                try
                {
                    Dictionary<string, object> data = dataList[i];

                    string _location = data[Location].ToString();
                    string _lesson = data[Lesson].ToString();
                    string _index = data[Index].ToString();

                    string _question = data[Question].ToString();
                    string _explain = data[Explain].ToString();

                    string _answer = data[Answer].ToString();

                    string _korean = data[Korean].ToString();
                    string _commentary = data[Commentary].ToString();
                    string _fileName = data[FileName].ToString();

                    holderList.Add(new CSVQuizOXDataHolder(_location, _lesson, _index,
                                                                    _question, _explain,
                                                                    _answer, _korean, _commentary, _fileName));
                }
                catch
                {
                    Debug.Log($"Error at i : {i}");
                    break;
                }
            }
        }

        public List<CSVQuizOXDataHolder> GetData(ELocation location, EHotelLesson lesson)
        {
            string _location = GetStringLocation(location);
            string _lesson = GetStringLesson(lesson);

            return GetData(_location, _lesson);
        }

        public List<CSVQuizOXDataHolder> GetData(ELocation location, EAirportLesson lesson)
        {
            string _location = GetStringLocation(location);
            string _lesson = GetStringLesson(lesson);

            return GetData(_location, _lesson);
        }

        private List<CSVQuizOXDataHolder> GetData(string location, string lesson)
        {
            List<CSVQuizOXDataHolder> tempList = new List<CSVQuizOXDataHolder>();

            foreach (CSVQuizOXDataHolder holder in holderList)
            {
                if (holder.location == location &&
                    holder.lesson == lesson)
                {
                    tempList.Add(holder);
                }
            }

            return tempList;
        }
    }
}
