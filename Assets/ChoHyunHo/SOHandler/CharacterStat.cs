using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]//����ȭ ����ȭ ������ class,struct�� ������� ��üinstantiate�� ���¸� ����, ���� �����ϴٰ� �Ѵ�
//MonoBehavior�� ������� ���� = ������Ʈ �ƴ� = newŰ����� ���� �Ұ�

//���� ������ PlayerStatHandler���� �� �ʱ�ȭ ��
public class CharacterStat
{
    [Header ("playerStatHandler���� �ʱ�ȭ �� ����")]
    [Header ("ĳ���� ������ �´� SO�� �����ؾ���")]
    public CharacterStatSO characterStatSO;
    public BulletSO bulletSO;
}
