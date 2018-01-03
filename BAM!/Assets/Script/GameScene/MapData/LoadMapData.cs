using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
///  맵데이터들을 저장합니다.
///  camera              ->    메인 카메라
///  buildingNum        ->   건물 개수
///  animalType         ->   이 맵에 등장하는 동물종류 3가지 ( size 3 설정 )
///  gameTime          ->   게임의 제한시간
///  awardGoldNum   ->   보상 골드
///  gameDifficulty     ->   게임 난이도
///  playerLocation    -> 플레이어 스폰 장소
/// </summary>
public class LoadMapData : MonoBehaviour
{

    public GameObject gameCamera;
    public int buildingNum;
    public List<eAnimal> animalType;
    public int gameTime;
    public int awardGoldNum;
    public int gameDifficulty;
    public Transform playerPos;

    void Awake()
    {
        GameManager.getInstance.loadMapData = this;
       // GameManager.getInstance.gameCamera = gameCamera;
        gameCamera.active = false;
        //GameManager.getInstance.loadMapData = this;
    }

    /// <summary>
    /// camera On/Off 
    /// </summary>
    /// <param name="isOn"></param>
    void IsLoadMapCamera(bool isOn)
    {
        gameCamera.SetActive(isOn);
    }

    /// <summary>
    ///  Save Map to Json
    ///  였지만 그냥 엑셀에서 바로 바꿉시다 ^^
    /// </summary>

}
