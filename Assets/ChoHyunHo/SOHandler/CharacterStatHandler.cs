using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�÷��̾��� ������ ���ʿ� �ʱ�ȭ�� ���� Ŭ����
public class CharacterStatHandler : MonoBehaviour
{
    [SerializeField] private CharacterStat characterStat;//�ν����Ϳ��� ���� �� �� �ش� ĳ���Ϳ� �´� SO�� �����ؾ���
    private CharacterStatSO instanceCharacterStatSO;//�ν����Ϳ��� ������ ����� �ƴ�
    private BulletSO instanceBulletSO;//�ν����Ϳ��� ������ ����� �ƴ�
    //�ֻ��� �θ� SO�� ���� ��ӹ޴� SO�� �� ȣȯ�ȴ� ������ ������ SO�� characterStat�� SO�� (ĳ���� ������ �´� SO�� �־���Ѵ�)

    //�ƹ��� ��ȸ���� ������ �� Ŭ������
    public CharacterStat currentStat { get; private set; }

    private void Awake()
    {
        InitialSetup();//�ʱ⼳�� �̶�� ��
    }
    
    private void InitialSetup()
    {
        instanceCharacterStatSO = null;
        instanceBulletSO = null;
        //currentStat�� ����ȭ�Ǿ� ���°� ����,���� �ȴ� �ƹ��͵� ���� ��(����)�� �ʱ�ȭ�Ѵ�
        if (characterStat.characterStatSO == null)
        {
            Debug.Log("characterStatSO ������������");
        }
        if (characterStat.bulletSO == null)
        {
            Debug.Log("bulletSO ������������");
        }
        
        if (characterStat.bulletSO != null)
        {
            instanceBulletSO = Instantiate(characterStat.bulletSO);
            //���� CharacterStat ������Ƽ �ʱ�ȭ�� �ٷ� ��� �Ұ� bulletSO = Instantiate(characterStat.bulletSO)�ȵ�
        }

        if (characterStat.characterStatSO != null)
        {
            instanceCharacterStatSO = Instantiate(characterStat.characterStatSO);
        }

        currentStat = new CharacterStat
        {
            characterStatSO = instanceCharacterStatSO,
            bulletSO = instanceBulletSO
        };
        //ShowDebug();
    }

    private void ShowDebug()
    {
        Debug.Log(gameObject.name);
        Debug.Log("�ʱ⼳�� ����SO : " + currentStat.characterStatSO);
        Debug.Log("�ʱ⼳�� �ִ�HP : " + currentStat.characterStatSO.MaxHP);
        Debug.Log("�ʱ⼳�� �̵��ӵ� : " + currentStat.characterStatSO.MoveSpeed);
        Debug.Log("�ʱ⼳�� �Ѿ�SO : " + currentStat.bulletSO);
        Debug.Log("�Ѿ�SO Ÿ��(����) : " + currentStat.bulletSO.targetLayer);
        Debug.Log("�Ѿ�SO ���ݷ� : " + currentStat.bulletSO.damage);
        Debug.Log("�Ѿ�SO ũ�� : " + currentStat.bulletSO.size);
        Debug.Log("�Ѿ�SO �ӵ� : " + currentStat.bulletSO.speed);
        Debug.Log("�Ѿ�SO ������ : " + currentStat.bulletSO.delay);
        Debug.Log("�Ѿ�SO ������(����) : " + currentStat.bulletSO.bulletPrefab);
    }

}


