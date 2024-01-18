    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameSetting : MonoBehaviour
{
    //ui오브젝트를 인스펙터 창에서 받아온 뒤 프리펩 오브젝트로 따로 생성
    protected GameObject m_missionUI;
    protected GameObject m_timeUI;
    protected GameObject m_countUI;
    protected GameObject m_clearUI;
    protected GameObject m_failUI;
    protected GameObject m_missionPrefab;
    protected GameObject m_timePrefab;
    protected GameObject m_countPrefab;
    protected GameObject m_clearPrefab;
    protected GameObject m_failPrefab;

    private void Awake()
    {
        m_missionUI = MiniGameManager.Instance.InGameUIs[0];
        m_timeUI = MiniGameManager.Instance.InGameUIs[1];
        m_countUI = MiniGameManager.Instance.InGameUIs[2];
        m_clearUI = MiniGameManager.Instance.InGameUIs[3];
        m_failUI = MiniGameManager.Instance.InGameUIs[4];
    }

    protected void StartSetting()
    {
        //미니게임 오브젝트 하위에 생성되도록 하기
        m_missionPrefab = Instantiate(m_missionUI, transform.position, Quaternion.identity, transform);
        m_timePrefab = Instantiate(m_timeUI, transform.position, Quaternion.identity, transform);
        m_countPrefab = Instantiate(m_countUI, transform.position, Quaternion.identity, transform);
        m_clearPrefab = Instantiate(m_clearUI, transform.position, Quaternion.identity, transform);
        m_failPrefab = Instantiate(m_failUI, transform.position, Quaternion.identity, transform);

        //초기에는 false로 설정되도록 
        m_missionPrefab.SetActive(false);
        m_timePrefab.SetActive(false);
        m_countPrefab.SetActive(false);
        m_clearPrefab.SetActive(false);
        m_failPrefab.SetActive(false);
    }

    //게임 클리어, 실패 함수
    protected void GameClear()
    {
        MiniGameManager.Instance.GameClear();
    }

    protected void GameFail()
    {
        MiniGameManager.Instance.GameFail();
    }


}
