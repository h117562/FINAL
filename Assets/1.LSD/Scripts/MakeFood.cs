using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MakeFood : MonoBehaviour
{
    [SerializeField] private GameObject Banana;
    [SerializeField] private GameObject Cheese;
    [SerializeField] private GameObject Cherry;
    [SerializeField] private int repetition;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MyCoroutine());
    }
   
    // �ڷ�ƾ n�� �ݺ�
    IEnumerator MyCoroutine()
    {
        while (repetition != 0)
        {
            FoodContainerPosition();
            MakeFoods();
            repetition--;
            yield return new WaitForSeconds(.5f);
        }
    }

    // Ǫ�� �����̳� ��ġ�� ���� ����
    void FoodContainerPosition()
    {
        float rndY = Random.Range(1.6f, -6.5f);
        int rndX = Random.Range(0, 2);
        if (rndX == 0)
        {
            transform.position = new Vector3(-5, rndY, 4);
        }
        else
        {
            transform.position = new Vector3(5, rndY, 4);
        }
    }

    // Ǫ�� ����
    void MakeFoods()
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

