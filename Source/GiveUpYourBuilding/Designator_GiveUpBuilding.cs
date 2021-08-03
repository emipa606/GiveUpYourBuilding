using System.Linq;
using RimWorld;
using UnityEngine;
using Verse;

namespace ZeroTech
{
    // Token: 0x02000002 RID: 2
    public class Designator_GiveUpBuilding : Designator
    {
        // Token: 0x06000002 RID: 2 RVA: 0x00002064 File Offset: 0x00000264
        public Designator_GiveUpBuilding()
        {
            defaultLabel = "GiveUpBuilding".Translate();
            defaultDesc = "GiveUpBuildingDesc".Translate();
            icon = ContentFinder<Texture2D>.Get("UI/Designators/GiveUpBuilding");
            soundDragSustain = SoundDefOf.Designate_DragStandard;
            soundDragChanged = SoundDefOf.Designate_DragStandard_Changed;
            useMouseIcon = true;
            soundSucceeded = SoundDefOf.Designate_Claim;
            hotKey = KeyBindingDefOf.Misc1;
        }

        // Token: 0x17000001 RID: 1
        // (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        public override int DraggableDimensions => 2;

        // Token: 0x06000003 RID: 3 RVA: 0x000020E8 File Offset: 0x000002E8
        public override AcceptanceReport CanDesignateCell(IntVec3 c)
        {
            if (!c.InBounds(Map))
            {
                return false;
            }

            if (c.Fogged(Map))
            {
                return false;
            }

            if (!(from t in c.GetThingList(Map)
                where CanDesignateThing(t).Accepted
                select t).Any())
            {
                return "MessageNoCanGiveUpBuilding".Translate();
            }

            return true;
        }

        // Token: 0x06000004 RID: 4 RVA: 0x00002174 File Offset: 0x00000374
        public override void DesignateSingleCell(IntVec3 c)
        {
            var thingList = c.GetThingList(Map);
            foreach (var thing in thingList)
            {
                var accepted = CanDesignateThing(thing).Accepted;
                if (accepted)
                {
                    DesignateThing(thing);
                }
            }
        }

        // Token: 0x06000005 RID: 5 RVA: 0x000021D4 File Offset: 0x000003D4
        public override AcceptanceReport CanDesignateThing(Thing t)
        {
            return t is Building building && building.Faction == Faction.OfPlayer;
        }

        // Token: 0x06000006 RID: 6 RVA: 0x00002208 File Offset: 0x00000408
        public override void DesignateThing(Thing t)
        {
            t.SetFaction(null);
            foreach (var intVec3 in t.OccupiedRect())
            {
                FleckMaker.ThrowMetaPuffs(new TargetInfo(intVec3, Map));
            }
        }
    }
}