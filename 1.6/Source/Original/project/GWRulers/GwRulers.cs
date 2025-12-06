using RimWorld;
using Verse;
using Verse.AI; 


namespace gwrulers
{
    public class CompAbilityEffect_EmperorLOTD : CompAbilityEffect
    {
        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            PawnKindDef kindDef = PawnKindDef.Named("LOTD"); 
            
            Faction faction = parent.pawn.Faction; 

            Pawn newPawn = PawnGenerator.GeneratePawn(kindDef, faction);
            GenSpawn.Spawn(newPawn, dest.Cell, parent.pawn.Map);

            
            HediffDef temporaryHediff = HediffDef.Named("LOTDHediff"); 
            newPawn.health.AddHediff(temporaryHediff);
            
            
            Job newJob = JobMaker.MakeJob(JobDefOf.Follow, parent.pawn);
            newPawn.jobs.StartJob(newJob, JobCondition.Incompletable);

            
        }
    }
}
