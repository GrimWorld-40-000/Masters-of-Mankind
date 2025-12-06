using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace GrimworldSummon
{
    public class HediffCompProperties_DespawnAfterHediffRemoved : HediffCompProperties
    {
        public HediffCompProperties_DespawnAfterHediffRemoved()
        {
            compClass = typeof(HediffComp_DespawnAfterHediffRemoved);
        }
    }
}
