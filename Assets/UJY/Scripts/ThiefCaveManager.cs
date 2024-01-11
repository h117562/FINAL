using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class ThiefCaveManager : MonoBehaviour
{
    public static ThiefCaveManager Instance;
    private int stage = 3;
    public Vector3[] m_hidePosition { get; private set; }
    public GameObject Thief;
    public GameObject Cave;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        m_hidePosition = new Vector3[stage * 2 + 1];
        //������ ��ġ�� ������ ���� ���� ����
        for (int i = 0; i < stage * 2  + 1; i++)
        {
            m_hidePosition[i] = new Vector3(Random.Range(-8, 8), 0, Random.Range(-2, 8));
            Instantiate(Cave);
            Cave.transform.position = m_hidePosition[i];
        }

        Instantiate(Thief);


    }

}
