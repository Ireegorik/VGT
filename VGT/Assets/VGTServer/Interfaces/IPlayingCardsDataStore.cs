using System;
using System.Collections.Generic;
using System.Text;

namespace VGTDataStore.Core
{
    public interface IPlayingCardsDataStore
    {
        IDictionary<int, PlayingCards> Cards { get; }

        Dictionary<int, PlayingCards> GetCards();
    }
}
