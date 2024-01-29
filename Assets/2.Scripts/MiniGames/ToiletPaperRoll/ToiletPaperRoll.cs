using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletPaperRoll : MiniGameSetting
{
    private int m_winCount = 1; // 승리 카운트 선언
    public int m_rollCount; // 실제 휴지 회전 카운트
    public int m_level; // 현재 미니게임 난이도
    private float m_timer;
    private bool m_end = false;

    protected override void Awake()
    {
        base.Awake();
        // m_level을 매니저에서 가져오기 임시로 레벨 1로 부여
        m_level = 3;
        switch (m_level)
        {
            case 0:
            case 1:
                m_rollCount = 30;
                break;
            case 2:
                m_rollCount = 40;
                break;
            case 3:
                m_rollCount = 50;
                break;
        }
    }
    private void Start()
    {
        //인게임 text내용 설정 + 게임 승리조건
        m_missionText.text = "Use up all the toilet paper";
        m_timeText[0].text = "TimeLimit";
        m_countText[0].text = "Count";

        CameraManager.Instance.ChangeCamera(CameraView.ZeroView);
    }
    void Update()
    {
        UiTime();
        CheckWinLose();
    }
    void UiTime()
    {
        //시간과 카운트 반영되는 코드
        m_timeText[1].text = m_timer.ToString("0.00");
        m_countText[1].text = m_winCount.ToString();

        //게임 시작 후 미션을 보여주고 타임제한을 보여주도록 함
        m_timer += Time.deltaTime;
        if (m_timer > 0 && m_missionPrefab.activeSelf == false)
        {
            m_missionPrefab.SetActive(true);

        }
        if (m_timer > 1 && m_missionPrefab.activeSelf == true)
        {
            m_missionPrefab.SetActive(false);
            m_timePrefab.SetActive(true);
        }

        //2초 후 부터 실제 게임시작 - 시간제한과 클리어를 위한 카운트 ui를 출력
        if (m_timer > 2)
        {
            m_timePrefab.SetActive(true);
            m_countPrefab.SetActive(true);
        }
    }

    void CheckWinLose() // 승리 패배 판단 함수
    {
        if (!m_end)
        {
            if (m_rollCount == 0)
            {
                // 승리시 로직
                m_winCount = 0;
                Debug.Log("이겼다!");
                m_clearPrefab.SetActive(true);
                m_end = true;
                Invoke("GameClear", 1);
            }
            else if (m_winCount > 0 && m_timer > 12)
            {
                // 패배시 로직
                Debug.Log("졌다!");
                m_failPrefab.SetActive(true);
                m_end = true;
                Invoke("GameFail", 1);
            }
        }
    }
}