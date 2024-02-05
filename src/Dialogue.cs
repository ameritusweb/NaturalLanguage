using System.Runtime.CompilerServices;

namespace NaturalLanguageProcess
{
    public class Dialogue
    {
        private StoryGenerator storyGenerator;
        private ScenePropertyCollection scenePropertyCollection;
        private Random random;

        public SentencePurposeType BeginPurpose { get; set; }

        public Dialogue(StoryGenerator storyGenerator)
        {
            this.storyGenerator = storyGenerator;
            this.scenePropertyCollection = new ScenePropertyCollection();
            this.random = new Random();
        }

        public Scene PopulateScene()
        {
            Scene scene = new Scene();
            scene.AControversialDecisionMade = GetRandomStoryWord(ScenePropertyType.AControversialDecisionMade);
            scene.ACriticalClue = GetRandomStoryWord(ScenePropertyType.ACriticalClue);
            scene.ACriticalDetailMissed = GetRandomStoryWord(ScenePropertyType.ACriticalDetailMissed);
            scene.ActionObjectThatContributesToTheMission = GetRandomStoryWord(ScenePropertyType.ActionObjectThatContributesToTheMission);
            scene.ActionThatContributesToSafety = GetRandomStoryWord(ScenePropertyType.ActionThatContributesToSafety);
            scene.ActionThatContributesToTheMission = GetRandomStoryWord(ScenePropertyType.ActionThatContributesToTheMission);
            scene.ActionThatDetractsFromTheMission = GetRandomStoryWord(ScenePropertyType.ActionThatDetractsFromTheMission);
            scene.AFateIfTheMissionFails = GetRandomStoryWord(ScenePropertyType.AFateIfTheMissionFails);
            scene.AHiddenActionOfTheProtagonists = GetRandomStoryWord(ScenePropertyType.AHiddenActionOfTheProtagonists);
            scene.AMistakeMadeByTheProtagonists = GetRandomStoryWord(ScenePropertyType.AMistakeMadeByTheProtagonists);
            scene.AMomentOfJoy = GetRandomStoryWord(ScenePropertyType.AMomentOfJoy);
            scene.AnActionThatContributesToSafety = GetRandomStoryWord(ScenePropertyType.AnActionThatContributesToSafety);
            scene.AnActionThatLedToSuccess = GetRandomStoryWord(ScenePropertyType.AnActionThatLedToSuccess);
            scene.AnActionToUncoverSecrets = GetRandomStoryWord(ScenePropertyType.AnActionToUncoverSecrets);
            scene.AnAlternativeStrategy = GetRandomStoryWord(ScenePropertyType.AnAlternativeStrategy);
            scene.ANaturalPhenomenon = GetRandomStoryWord(ScenePropertyType.ANaturalPhenomenon);
            scene.ANegativeFactorThatNecessitatedTheMission = GetRandomStoryWord(ScenePropertyType.ANegativeFactorThatNecessitatedTheMission);
            scene.AnEnemyOfTheEnemy = GetRandomStoryWord(ScenePropertyType.AnEnemyOfTheEnemy);
            scene.AnEnemyOfTheMission = GetRandomStoryWord(ScenePropertyType.AnEnemyOfTheMission);
            scene.AnImmediateDangerToTheMission = GetRandomStoryWord(ScenePropertyType.AnImmediateDangerToTheMission);
            scene.AnImmediateDangerToTheProtagonists = GetRandomStoryWord(ScenePropertyType.AnImmediateDangerToTheProtagonists);
            scene.AnIndicatorThatTheMissionStarted = GetRandomStoryWord(ScenePropertyType.AnIndicatorThatTheMissionStarted);
            scene.AnObstacleToTheMission = GetRandomStoryWord(ScenePropertyType.AnObstacleToTheMission);
            scene.AnotherActionThatContributesToTheMission = GetRandomStoryWord(ScenePropertyType.AnotherActionThatContributesToTheMission);
            scene.AnOverwhelmingChallenge = GetRandomStoryWord(ScenePropertyType.AnOverwhelmingChallenge);
            scene.AnUmbrellaTermThatDescribesTheNatureOfTheEnemy = GetRandomStoryWord(ScenePropertyType.AnUmbrellaTermThatDescribesTheNatureOfTheEnemy);
            scene.AnUnexpectedAlly = GetRandomStoryWord(ScenePropertyType.AnUnexpectedAlly);
            scene.AnUnexpectedEvent = GetRandomStoryWord(ScenePropertyType.AnUnexpectedEvent);
            scene.APastEvent = GetRandomStoryWord(ScenePropertyType.APastEvent);
            scene.APastEventMirroringTheCurrentMission = GetRandomStoryWord(ScenePropertyType.APastEventMirroringTheCurrentMission);
            scene.APlaceToCommunicate = GetRandomStoryWord(ScenePropertyType.APlaceToCommunicate);
            scene.APlanToSucceedAtMission = GetRandomStoryWord(ScenePropertyType.APlanToSucceedAtMission);
            scene.APositiveTurnOfEvents = GetRandomStoryWord(ScenePropertyType.APositiveTurnOfEvents);
            scene.APossibleProblemToAvoid = GetRandomStoryWord(ScenePropertyType.APossibleProblemToAvoid);
            scene.APriorityForTheMission = GetRandomStoryWord(ScenePropertyType.APriorityForTheMission);
            scene.ARejectedPlanOfTheMission = GetRandomStoryWord(ScenePropertyType.ARejectedPlanOfTheMission);
            scene.ARelatedNegativePastEvent = GetRandomStoryWord(ScenePropertyType.ARelatedNegativePastEvent);
            scene.ARoleOfTheProtagonist = GetRandomStoryWord(ScenePropertyType.ARoleOfTheProtagonist);
            scene.ASafeApproach = GetRandomStoryWord(ScenePropertyType.ASafeApproach);
            scene.ASaferLocation = GetRandomStoryWord(ScenePropertyType.ASaferLocation);
            scene.ASecretHidingSpot = GetRandomStoryWord(ScenePropertyType.ASecretHidingSpot);
            scene.ASecretWeapon = GetRandomStoryWord(ScenePropertyType.ASecretWeapon);
            scene.ASkillOfTheEnemy = GetRandomStoryWord(ScenePropertyType.ASkillOfTheEnemy);
            scene.ASkillOfTheProtagonists = GetRandomStoryWord(ScenePropertyType.ASkillOfTheProtagonists);
            scene.ASolution = GetRandomStoryWord(ScenePropertyType.ASolution);
            scene.AStrategicMoveByTheEnemy = GetRandomStoryWord(ScenePropertyType.AStrategicMoveByTheEnemy);
            scene.ASuccessFactorOfTheMission = GetRandomStoryWord(ScenePropertyType.ASuccessFactorOfTheMission);
            scene.AThreatOfTheEnemy = GetRandomStoryWord(ScenePropertyType.AThreatOfTheEnemy);
            scene.ATraitorInTheRanks = GetRandomStoryWord(ScenePropertyType.ATraitorInTheRanks);
            scene.ATrapForTheProtagonists = GetRandomStoryWord(ScenePropertyType.ATrapForTheProtagonists);
            scene.AWayToEscape = GetRandomStoryWord(ScenePropertyType.AWayToEscape);
            scene.AWeakness = GetRandomStoryWord(ScenePropertyType.AWeakness);
            scene.AWeaponAgainstTheEnemy = GetRandomStoryWord(ScenePropertyType.AWeaponAgainstTheEnemy);
            scene.AWeaponOfTheEnemy = GetRandomStoryWord(ScenePropertyType.AWeaponOfTheEnemy);
            scene.CohortToBeRescuedFromTheEnemy = GetRandomStoryWord(ScenePropertyType.CohortToBeRescuedFromTheEnemy);
            scene.FriendsOfTheProtagonists = GetRandomStoryWord(ScenePropertyType.FriendsOfTheProtagonists);
            scene.HelpfulEntitiesForTheMission = GetRandomStoryWord(ScenePropertyType.HelpfulEntitiesForTheMission);
            scene.HowTheEnemyCouldTriggerFailureOfTheMission = GetRandomStoryWord(ScenePropertyType.HowTheEnemyCouldTriggerFailureOfTheMission);
            scene.ImportanceLevelOfMission = GetRandomStoryWord(ScenePropertyType.ImportanceLevelofMission);
            scene.ImportantOutcomeOfMission = GetRandomStoryWord(ScenePropertyType.ImportantOutcomeOfMission);
            scene.InitialAssessmentOfMission = GetRandomStoryWord(ScenePropertyType.InitialAssessmentOfMission);
            scene.LengthOfTimeThePotentialSolutionWillLast = GetRandomStoryWord(ScenePropertyType.LengthOfTimeThePotentialSolutionWillLast);
            scene.LocationOfTheEnemy = GetRandomStoryWord(ScenePropertyType.LocationOfTheEnemy);
            scene.LocationOfTheMission = GetRandomStoryWord(ScenePropertyType.LocationOfTheMission);
            scene.LocationOfTheObjectThatAssistsTheMission = GetRandomStoryWord(ScenePropertyType.LocationOfTheObjectThatAssistsTheMission);
            scene.LocationOfTheVictim = GetRandomStoryWord(ScenePropertyType.LocationOfTheVictim);
            scene.MissionComparison = GetRandomStoryWord(ScenePropertyType.MissionComparison);
            scene.MissionOriginator = GetRandomStoryWord(ScenePropertyType.MissionOriginator);
            scene.MissionProgress = GetRandomStoryWord(ScenePropertyType.MissionProgress);
            scene.ObjectThatAssistsTheMission = GetRandomStoryWord(ScenePropertyType.ObjectThatAssistsTheMission);
            scene.ObjectYouAreLookingFor = GetRandomStoryWord(ScenePropertyType.ObjectYouAreLookingFor);
            scene.PossibleProblemToAvoid = GetRandomStoryWord(ScenePropertyType.PossibleProblemToAvoid);
            scene.PossibleSolutionToConsider = GetRandomStoryWord(ScenePropertyType.PossibleSolutionToConsider);
            scene.PreparationForTheMission = GetRandomStoryWord(ScenePropertyType.PreparationForTheMission);
            scene.ProtagonistsForTheMission = GetRandomStoryWord(ScenePropertyType.ProtagonistsForTheMission);
            scene.SpectatorToOrAudienceOfTheMission = GetRandomStoryWord(ScenePropertyType.SpectatorToOrAudienceOfTheMission);
            scene.StatusOfTheMainCauseOfTheProblem = GetRandomStoryWord(ScenePropertyType.StatusOfTheMainCauseOfTheProblem);
            scene.StatusOfTheMission = GetRandomStoryWord(ScenePropertyType.StatusOfTheMission);
            scene.StatusOfTheObstacleToTheMission = GetRandomStoryWord(ScenePropertyType.StatusOfTheObstacleToTheMission);
            scene.TheAchievementsOfTheGroup = GetRandomStoryWord(ScenePropertyType.TheAchievementsOfTheGroup);
            scene.TheBattle = GetRandomStoryWord(ScenePropertyType.TheBattle);
            scene.TheBeforeAndAfter = GetRandomStoryWord(ScenePropertyType.TheBeforeAndAfter);
            scene.TheBurdenCarriedByTheProtagonists = GetRandomStoryWord(ScenePropertyType.TheBurdenCarriedByTheProtagonists);
            scene.TheChaosCausedByTheEnemy = GetRandomStoryWord(ScenePropertyType.TheChaosCausedByTheEnemy);
            scene.TheCurrentSituation = GetRandomStoryWord(ScenePropertyType.TheCurrentSituation);
            scene.TheDeedsOrActionsOfTheEnemy = GetRandomStoryWord(ScenePropertyType.TheDeedsOrActionsOfTheEnemy);
            scene.TheEnemy = GetRandomStoryWord(ScenePropertyType.TheEnemy);
            scene.TheEnemyActions = GetRandomStoryWord(ScenePropertyType.TheEnemyActions);
            scene.TheGoalOfTheMission = GetRandomStoryWord(ScenePropertyType.TheGoalOfTheMission);
            scene.TheHeroesOfTheStory = GetRandomStoryWord(ScenePropertyType.TheHeroesOfTheStory);
            scene.TheIdealFutureStateOfTheMission = GetRandomStoryWord(ScenePropertyType.TheIdealFutureStateOfTheMission);
            scene.TheIdealMentalStateForTheMission = GetRandomStoryWord(ScenePropertyType.TheIdealMentalStateForTheMission);
            scene.TheIdealStrategyForTheMission = GetRandomStoryWord(ScenePropertyType.TheIdealStrategyForTheMission);
            scene.TheImmediateEffectsOfTheProblem = GetRandomStoryWord(ScenePropertyType.TheImmediateEffectsOfTheProblem);
            scene.TheInjusticeFaced = GetRandomStoryWord(ScenePropertyType.TheInjusticeFaced);
            scene.TheLossesWeHaveSuffered = GetRandomStoryWord(ScenePropertyType.TheLossesWeHaveSuffered);
            scene.TheMainCauseOfTheProblem = GetRandomStoryWord(ScenePropertyType.TheMainCauseOfTheProblem);
            scene.TheMentalStateOfTheEnemy = GetRandomStoryWord(ScenePropertyType.TheMentalStateOfTheEnemy);
            scene.TheMissionObjective = GetRandomStoryWord(ScenePropertyType.TheMissionObjective);
            scene.TheMystery = GetRandomStoryWord(ScenePropertyType.TheMystery);
            scene.TheMysteryUnfolding = GetRandomStoryWord(ScenePropertyType.TheMysteryUnfolding);
            scene.TheNeedsOfTheEnemy = GetRandomStoryWord(ScenePropertyType.TheNeedsOfTheEnemy);
            scene.ThePhysicalStateOfTheProtagonists = GetRandomStoryWord(ScenePropertyType.ThePhysicalStateOfTheProtagonists);
            scene.TheProblem = GetRandomStoryWord(ScenePropertyType.TheProblem);
            scene.TheRootCauseOfTheProblem = GetRandomStoryWord(ScenePropertyType.TheRootCauseOfTheProblem);
            scene.TheSoundOfTheEnemy = GetRandomStoryWord(ScenePropertyType.TheSoundOfTheEnemy);
            scene.TheStateOfTheObjectThatAssistsTheMission = GetRandomStoryWord(ScenePropertyType.TheStateOfTheObjectThatAssistsTheMission);
            scene.TheStatusOfTheMainCauseOfTheProblem = GetRandomStoryWord(ScenePropertyType.TheStatusOfTheMainCauseOfTheProblem);
            scene.TheSurvivors = GetRandomStoryWord(ScenePropertyType.TheSurvivors);
            scene.TheTimeLeftToCompleteTheMission = GetRandomStoryWord(ScenePropertyType.TheTimeLeftToCompleteTheMission);
            scene.TheUnknownFactors = GetRandomStoryWord(ScenePropertyType.TheUnknownFactors);
            scene.TheUnsungHeroes = GetRandomStoryWord(ScenePropertyType.TheUnsungHeroes);
            scene.TimeOfDay = GetRandomStoryWord(ScenePropertyType.TimeOfDay);
            scene.TypeOfMission = GetRandomStoryWord(ScenePropertyType.TypeOfMission);
            scene.VictimsOfTheEnemy = GetRandomStoryWord(ScenePropertyType.VictimsOfTheEnemy);
            scene.WhatTheSuccessOfTheMissionHingesOn = GetRandomStoryWord(ScenePropertyType.WhatTheSuccessOfTheMissionHingesOn);
            return scene;
        }

        private StoryWord GetRandomStoryWord(ScenePropertyType scenePropertyType)
        {
            return new StoryWord() { WordText = scenePropertyCollection.ScenePropertyMap[scenePropertyType][random.Next(scenePropertyCollection.ScenePropertyMap[scenePropertyType].Count)] };
        }
    }
}
