using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Text;
using System;

public struct AnimalData
{
    public int id;
    public float speed;
    public float maxSpeed;
    public int hp;
}

public class AnimalParser : MonoBehaviour
{
    public List<AnimalData> animalData;
    // 파싱 할 xml 파일 명
    string xmlName = "AnimalData.xml";

    void Awake()
    {
        animalData = new List<AnimalData>();
        StartCoroutine(Process());
    }

    IEnumerator Process()
    {
        string strPath = string.Empty;
#if(UNITY_EDITOR || UNITY_STANDALONE_WIN)
        strPath += ("file:///");
        strPath += (Application.streamingAssetsPath + "/" + xmlName);
#elif UNITY_ANDROID
      strPath =  "jar:file://" + Application.dataPath + "!/assets/" + xmlName;
#endif
        WWW www = new WWW(strPath);
        yield return www;

        Debug.Log("Read Content : " + www.text);

        Interpret(www.text);
    }

    private void Interpret(string _strSource)
    {
        // 인코딩 문제 예외처리
        // 읽은 데이터의 앞의 2바이트 제거 (BOM 제거)
        // 오류시에 BOM 부분 제거 후 실행
        StringReader stringReader = new StringReader(_strSource);

        XmlNodeList xmlNodeList = null;

        XmlDocument xmlDoc = new XmlDocument();
        // XML 로드하고
        xmlDoc.LoadXml(stringReader.ReadToEnd());
        // 최상위 로드를 선택합니다.
        xmlNodeList = xmlDoc.SelectNodes("AnimalData");

        foreach(XmlNode node in xmlNodeList)
        {
            // 자식이 있을때 돈다
            if(node.Name.Equals("AnimalData") && node.HasChildNodes)
            {
                foreach(XmlNode child in node.ChildNodes)
                {
                    AnimalData data;
                    data.id = Int32.Parse(child.Attributes.GetNamedItem("id").Value);
                    data.speed = float.Parse(child.Attributes.GetNamedItem("speed").Value);
                    data.maxSpeed = float.Parse(child.Attributes.GetNamedItem("maxSpeed").Value);
                    data.hp = Int32.Parse(child.Attributes.GetNamedItem("hp").Value);
                    animalData.Add(data);
                }
            }
        }
    } 
}
