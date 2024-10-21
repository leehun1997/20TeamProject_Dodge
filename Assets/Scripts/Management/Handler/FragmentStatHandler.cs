using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentStatHandler : CharacterStatHandler
{
    [SerializeField] public FragmentStatSO baseStatSO;

    public string desc { get; private set; }
    public int id { get; private set; }
    public double gage { get; private set; }


    protected override void InitialSetup()
    {
        FragmentStatSO playerStatSO = null;

        if (baseStatSO != null)
        {
            playerStatSO = Instantiate(baseStatSO);
        }

        currentStat = new CharacterStat
        {
            characterStatSO = playerStatSO,
        };

        maxHp = baseStatSO.MaxHP;
    }
}
