using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse.AI;
using Verse;
using RimWorld.Planet;
using UnityEngine;

namespace GrimworldSummon
{
    public class CompAbilityEffect_EmperorLOTD : VEF.Abilities.Ability
    {
        public override void Cast(params GlobalTargetInfo[] targets)
        {
            int num = Mathf.Max(1, Mathf.FloorToInt(pawn.psychicEntropy.PsychicSensitivity / 0.5f));

            HediffDef temporaryHediff;
            switch(num)
            {
                case 1:
                    temporaryHediff = HediffDef.Named("GW_Ruler_EmperorLOTD_6Hours");
                    break;
                case 2:
                    temporaryHediff = HediffDef.Named("GW_Ruler_EmperorLOTD_12Hours");
                    break;
                default:
                    temporaryHediff = HediffDef.Named("GW_Ruler_EmperorLOTD_24Hours");
                    break;
            }
            for (int i = 0; i < num; i++)
            {
                PawnKindDef kindDef = PawnKindDef.Named("LOTD");

                Faction faction = pawn.Faction;

                Pawn newPawn = PawnGenerator.GeneratePawn(kindDef, faction);
                GenSpawn.Spawn(newPawn, targets.First().Cell, pawn.Map);


                newPawn.health.AddHediff(temporaryHediff);


                Job newJob = JobMaker.MakeJob(JobDefOf.Follow, pawn);
                newPawn.jobs.StartJob(newJob, JobCondition.Incompletable);
            }
        }
    }
}
