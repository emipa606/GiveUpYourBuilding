using System.Linq;
using RimWorld;
using UnityEngine;
using Verse;

namespace ZeroTech;

public class Designator_GiveUpBuilding : Designator
{
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

    public override int DraggableDimensions => 2;

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

    public override AcceptanceReport CanDesignateThing(Thing t)
    {
        return t is Building building && building.Faction == Faction.OfPlayer;
    }

    public override void DesignateThing(Thing t)
    {
        t.SetFaction(null);
        foreach (var intVec3 in t.OccupiedRect())
        {
            FleckMaker.ThrowMetaPuffs(new TargetInfo(intVec3, Map));
        }
    }
}