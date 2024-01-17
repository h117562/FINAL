using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameSetting : MonoBehaviour
{
    [SerializeField] protected GameObject m_missionUI;
    [SerializeField] protected GameObject m_timeUI;
    [SerializeField] protected GameObject m_countUI;
    [SerializeField] protected GameObject m_clearUI;
    [SerializeField] protected GameObject m_failUI;
    protected GameObject m_missionPrefab;
    protected GameObject m_timePrefab;
    protected GameObject m_countPrefab;
    protected GameObject m_clearPrefab;
    protected GameObject m_failPrefab;


    protected void StartSetting()
    {
        m_missionPrefab = Instantiate(m_missionUI, transform.position, Quaternion.identity, transform);
        m_timePrefab = Instantiate(m_timeUI, transform.position, Quaternion.identity, transform);
        m_countPrefab = Instantiate(m_countUI, transform.position, Quaternion.identity, transform);
        m_clearPrefab = Instantiate(m_clearUI, transform.position, Quaternion.identity, transform);
        m_failPrefab = Instantiate(m_failUI, transform.position, Quaternion.identity, transform);

        m_missionPrefab.SetActive(false);
        m_timePrefab.SetActive(false);
        m_countPrefab.SetActive(false);
        m_clearPrefab.SetActive(false);
        m_failPrefab.SetActive(false);
    }
    protected void GameClear()
    {
        MiniGameManager.Instance.GameClear();
    }

    protected void GameFail()
    {
        MiniGameManager.Instance.GameFail();
    }


}
