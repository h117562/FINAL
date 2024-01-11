using System.Collections;
using UnityEngine;

public class MakeFood : MonoBehaviour
{
    [SerializeField] private GameObject Banana;
    [SerializeField] private GameObject Cheese;
    [SerializeField] private GameObject Cherry;
    [SerializeField] private int repetition; // ��� �ݺ�����

    void Start()
    {
        StartCoroutine(FoodMakeCoroutine()); // �ڷ�ƾ ����
    }

    IEnumerator FoodMakeCoroutine() // �ڷ�ƾ repetition �� ��ŭ �ݺ�
    {
        while (repetition != 0)
        {
            FoodContainerPosition(); // �������� �ٲٰ�
            MakeFoods(); // Ǫ�带 �����.
            repetition--; // 1�� �����Ҷ����� repetition ���� -
            yield return new WaitForSeconds(.5f); // 0.5�ʿ� �ѹ���
        }
    }

    void FoodContainerPosition() // Ǫ�� �����̳� ��ġ�� ���� ����
    {
        float rndY = Random.Range(1f, -6.5f); // Y�� ��ġ�� ����� ���� ����
        int rnd = Random.Range(0, 2); // 50%�� ����� ���� ����
        if (rnd == 0)
        {
            transform.position = new Vector3(-6, rndY, 0); // rnd �� 0�Ͻ� �ش� ��ǥ�� �̵�
        }
        else
        {
            transform.position = new Vector3(6, rndY, 0);// rnd �� 1�Ͻ� �ش� ��ǥ�� �̵�
        }
    }

    void MakeFoods() // ���� Ǫ�� ����
    {
        int rnd = Random.Range(0, 3);
        switch (rnd)
        {
            case 0:
                Instantiate(Banana, transform.position, Quaternion.identity);
                break;
            case 1:
                Instantiate(Cheese, transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(Cherry, transform.position, Quaternion.identity);
                break;
        }
    }
}

