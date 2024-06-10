using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TurnSegment {
	AtStartOfTurn,
	AfterStartOfTurn,
	InitiativePhaseStart,
	AfterInitiativePhaseStart,
	BeforePlayerOrderSelected,
	WhenPlayerOrderSelected,
	AfterPlayerOrderSelected,
	BeforeSurfaceCardIsDrawn,
	WhenSurfaceCardIsDrawn,
	//WhenPlacingSurfaceCard
	AfterSurfaceCardIsDrawn,
	BeforeSelectDayCycle,
	WhenSelectDayCycle,
	AfterSelectDayCycle,
	WhenPlanningPhaseStarts,
	AfterPlanningPhaseStarts,
	PlayCard,
	WhenDayPhaseStarts,
	AfterDayPhaseStarts,
	Initiative,
	Planning,
	Day,
	Night,
	Resolution,
	Upkeep
}
