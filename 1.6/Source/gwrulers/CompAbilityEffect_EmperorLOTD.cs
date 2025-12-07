using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using UnityEngine;
using Verse;
using static UnityEngine.GraphicsBuffer;
using Verse.AI;

namespace gwrulers
{
    public class CompAbilityEffect_EmperorLOTD : CompAbilityEffect
    {
        private new CompProperties_AbilityEmperorLOTD Props => (CompProperties_AbilityEmperorLOTD)props;

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            int num = Mathf.Max(1, Mathf.FloorToInt(parent.pawn.psychicEntropy.PsychicSensitivity / 0.5f));

            HediffDef temporaryHediff;
            switch (num)
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

                Faction faction = parent.pawn.Faction;

                Pawn newPawn = PawnGenerator.GeneratePawn(kindDef, faction);
                GenSpawn.Spawn(newPawn, target.Cell, parent.pawn.Map);


                newPawn.health.AddHediff(temporaryHediff);


                Job newJob = JobMaker.MakeJob(JobDefOf.Follow, parent.pawn);
                newPawn.jobs.StartJob(newJob, JobCondition.Incompletable);
            }

            base.Apply(target, dest);
        }
    }
}
