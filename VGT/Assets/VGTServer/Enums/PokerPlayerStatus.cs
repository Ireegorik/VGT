using System;
using System.Collections.Generic;
using System.Text;

namespace VGTDataStore.Core.Models.Enums
{
    public enum PokerPlayerStatus
    {
        WaitingForStart = 0,
        ReadyForStart = 1,
        MakesMove = 2,
        WaitingForMove = 3
    }
}
