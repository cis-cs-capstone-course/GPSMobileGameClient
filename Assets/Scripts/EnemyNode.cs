﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNode : NodeStructure
{
    private string _type;

    public override string Type {
        get => _type;
        set => _type = value;
    }
}
}
