namespace NaturalLanguageProcess
{
    public class ExpositionCollection
    {
        private Dictionary<SentencePurposeType, List<Func<Scene, string>>> expositions;

        public ExpositionCollection()
        {
            expositions = new Dictionary<SentencePurposeType, List<Func<Scene, string>>>();
            Initialize();
        }

        private void Initialize()
        {
            var shareAnExperienceList = new List<Func<Scene, string>>
            {
                scene => $"Look, I found some {scene.ObjectThatAssistsTheMission.WordText}!.",
                scene => $"I found some {scene.ObjectThatAssistsTheMission.WordText} in the {scene.LocationOfTheObjectThatAssistsTheMission.WordText}.",
                scene => $"I found a {scene.ObjectThatAssistsTheMission.WordText}; it might help us {scene.ActionThatContributesToTheMission.WordText}.",
                scene => $"I found some {scene.ObjectThatAssistsTheMission.WordText} in the {scene.LocationOfTheObjectThatAssistsTheMission.WordText}; it will be useful.",
                scene => $"I heard about this in {scene.APastEventMirroringTheCurrentMission.WordText}, but never thought I'd experience it.",
                scene => $"I've dealt with {scene.AnUmbrellaTermThatDescribesTheNatureOfTheEnemy.WordText} before.",
            };
            this.expositions.Add(SentencePurposeType.ShareAnExperience, shareAnExperienceList);

            var giveGuidance = new List<Func<Scene, string>>
            {
                scene => $"I think we should {scene.ActionThatContributesToTheMission.WordText}.",
                scene => $"We should {scene.ActionThatContributesToTheMission.WordText} a {scene.ActionObjectThatContributesToTheMission.WordText} for the {scene.TimeOfDay.WordText}.",
                scene => $"In the meantime, we should {scene.ActionThatContributesToTheMission.WordText} our {scene.ActionObjectThatContributesToTheMission.WordText}.",
                scene => $"Let's transfer {scene.VictimsOfTheEnemy.WordText} to {scene.ASaferLocation.WordText}.",
                scene => $"Let's continue monitoring the {scene.VictimsOfTheEnemy.WordText} closely.",
                scene => $"Please remain calm and stay in {scene.ASaferLocation.WordText}.",
                scene => $"Make sure to {scene.ActionThatContributesToTheMission.WordText} the {scene.ActionObjectThatContributesToTheMission.WordText} and check for any {scene.PossibleProblemToAvoid.WordText}. We don't want another {scene.ARelatedNegativePastEvent.WordText}.",
                scene => $"Remember our {scene.PreparationForTheMission.WordText}, stay focused, and prioritize {scene.APriorityForTheMission.WordText}.",
                scene => $"Please, follow {scene.HelpfulEntitiesForTheMission} instructions calmly and orderly.",
                scene => $"We should head for {scene.ASaferLocation.WordText}, away from the {scene.AnImmediateDangerToTheMission.WordText}.",
                scene => $"{scene.ARejectedPlanOfTheMission.WordText} is not a good idea; some {scene.VictimsOfTheEnemy} are excellent {scene.ASkillOfTheEnemy.WordText}.",
            };
            this.expositions.Add(SentencePurposeType.GiveGuidance, giveGuidance);

            var warnOfImpendingDanger = new List<Func<Scene, string>>
            {
                scene => $"We need to {scene.ActionThatContributesToTheMission.WordText} now!",
                scene => $"We need to {scene.ActionThatContributesToTheMission.WordText} now, or we'll be {scene.AFateIfTheMissionFails.WordText}!",
                scene => $"Get down! Stay quiet!",
                scene => $"We need to move fast. Let's grab the {scene.ObjectYouAreLookingFor.WordText} and {scene.AWayToEscape.WordText}!",
                scene => $"Emergency alert! All {scene.ProtagonistsForTheMission.WordText}, report to the {scene.ASaferLocation.WordText} immediately!",
                scene => $"We need to get out of here quickly!",
                scene => $"I spotted {scene.AnEnemyOfTheMission} approaching from the {scene.LocationOfTheEnemy}!",
                scene => $"We've received a tip about a {scene.AnEnemyOfTheMission} operating in {scene.LocationOfTheEnemy}.",
                scene => $"Stop or face {scene.AnImmediateDangerToTheProtagonists}!",
                scene => $"We've got a problem, the {scene.AnEnemyOfTheMission.WordText} has gone {scene.TheMentalStateOfTheEnemy}!",
                scene => $"Time is of the essence. If they breach our {scene.ASaferLocation.WordText}, it could be catastrophic.",
                scene => $"We'll resort to {scene.AThreatOfTheEnemy} if {scene.TheNeedsOfTheEnemy} aren't met!",
                scene => $"Time is running out!",
                scene => $"{scene.ActionThatContributesToSafety}, everyone! We need to take action fast!",
                scene => $"I hear {scene.TheSoundOfTheEnemy}! {scene.TheEnemy} are closing in!",
                scene => $"Attention, everyone! We have a {scene.AnImmediateDangerToTheMission} emergency in the {scene.LocationOfTheMission}",
            };
            this.expositions.Add(SentencePurposeType.WarnOfImpendingDanger, warnOfImpendingDanger);
        }
    }
}
