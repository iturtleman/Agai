using System;
using System.Collections.Generic;
using System.Text;

namespace AgaiEngine.Attacks
{
    public enum EffectDuration
    {
        Instantaneous = 0,
        Time =1,
        UntilDispelled = int.MaxValue-1,
        Special = -1,
    }
}
