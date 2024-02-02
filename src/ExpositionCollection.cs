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
                scene => $"I spotted {scene.AnEnemyOfTheMission.WordText} approaching from the {scene.LocationOfTheEnemy.WordText}!",
                scene => $"We've received a tip about a {scene.AnEnemyOfTheMission.WordText} operating in {scene.LocationOfTheEnemy.WordText}.",
                scene => $"Stop or face {scene.AnImmediateDangerToTheProtagonists.WordText}!",
                scene => $"We've got a problem, the {scene.AnEnemyOfTheMission.WordText} has gone {scene.TheMentalStateOfTheEnemy.WordText}!",
                scene => $"Time is of the essence. If they breach our {scene.ASaferLocation.WordText}, it could be {scene.AFateIfTheMissionFails.WordText}.",
                scene => $"We'll resort to {scene.AThreatOfTheEnemy.WordText} if {scene.TheNeedsOfTheEnemy.WordText} aren't met!",
                scene => $"Time is running out!",
                scene => $"{scene.ActionThatContributesToSafety.WordText}, everyone! We need to take action fast!",
                scene => $"I hear {scene.TheSoundOfTheEnemy}! {scene.TheEnemy.WordText} are closing in!",
                scene => $"Attention, everyone! We have a {scene.AnImmediateDangerToTheMission.WordText} emergency in the {scene.LocationOfTheMission.WordText}",
            };
            this.expositions.Add(SentencePurposeType.WarnOfImpendingDanger, warnOfImpendingDanger);

            var expressConcern = new List<Func<Scene, string>>
            {
                scene => $"I hope this {scene.AnImmediateDangerToTheMission.WordText} emergency won't last long.",
                scene => $"Hey, did you hear that noise outside?",
                scene => $"I'm worried about {scene.VictimsOfTheEnemy.WordText}.",
                scene => $"I hope it's not something dangerous.",
                scene => $"Be careful, {scene.AnEnemyOfTheMission.WordText} can be {scene.ASkillOfTheEnemy.WordText}.",
                scene => $"We need to take action immediately.",
                scene => $"We can't afford to lose {scene.ASuccessFactorOfTheMission}.",
                scene => $"I hope we can {scene.ActionThatContributesToTheMission.WordText} soon.",
                scene => $"I hope we can {scene.ActionThatContributesToTheMission.WordText} soon, or we'll be {scene.AFateIfTheMissionFails.WordText}.",
                scene => $"I'm deeply concerned about the {scene.ANegativeFactorThatNecessitatedTheMission.WordText} in {scene.LocationOfTheMission.WordText}.",
                scene => $"We must remember the {scene.WhatHingesOnTheSuccessOfTheMission.WordText} at stake here, and that should drive us forward.",
                scene => $"We've got a serious problem here. Reports indicate {scene.TheImmediateEffectsOfTheProblem} in {scene.LocationOfTheMission}.",
                scene => $"What's our plan for {scene.ASuccessFactorOfTheMission}?",
                scene => $"The situation is {scene.StatusOfTheMission}, but together, we can {scene.ActionThatContributesToSafety}.",
                scene => $"We've received a tip that someone is planning to {scene.AThreatOfTheEnemy}",
                scene => $"I've been noticing some {scene.TheDeedsOrActionsOfTheEnemy} lately.",
                scene => $"But what if the {scene.TheEnemy} {scene.HowTheEnemyCouldTriggerFailureOfTheMission}?",
            };
            this.expositions.Add(SentencePurposeType.ExpressConcern, expressConcern);

            var expressUrgency = new List<Func<Scene, string>>
            {
                scene => $"But we must act swiftly.",
                scene => $"Gather around, everyone! We need to act fast.",
                scene => $"We need to act fast, or we'll be {scene.AFateIfTheMissionFails.WordText}!",
                scene => $"We must act quicky to {scene.ActionThatContributesToTheMission} the {scene.ActionObjectThatContributesToTheMission}.",
            };
            this.expositions.Add(SentencePurposeType.ExpressUrgency, expressUrgency);

            var seekClarification = new List<Func<Scene, string>>
            {
                scene => $"That's risky. Are you sure?",
                scene => $"I don't understand. What's going on?",
                scene => $"How's the situation with the {scene.ActionObjectThatContributesToTheMission}? Any risk of {scene.AnImmediateDangerToTheMission}?",
            };
            this.expositions.Add(SentencePurposeType.SeekClarification, seekClarification);

            var analyze = new List<Func<Scene, string>>
            {
                scene => $"We need to {scene.ActionThatContributesToTheMission.WordText} the {scene.ActionObjectThatContributesToTheMission.WordText} and check for any {scene.PossibleProblemToAvoid.WordText}.",
                scene => $"We need to {scene.ActionThatContributesToTheMission.WordText} the {scene.ActionObjectThatContributesToTheMission.WordText} and check for any {scene.PossibleProblemToAvoid.WordText}. We don't want another {scene.ARelatedNegativePastEvent.WordText}.",
                scene => $"We're assessing it now.",
            };
            this.expositions.Add(SentencePurposeType.Analyze, analyze);

            var accuse = new List<Func<Scene, string>>
            {
                scene => $"You're the reason we're in this mess!",
                scene => $"This is all your fault!",
                scene => $"You're the one who caused this!",
            };
            this.expositions.Add(SentencePurposeType.Accuse, accuse);

            var apologize = new List<Func<Scene, string>>
            {
                scene => $"I'm sorry, I didn't mean to {scene.ActionThatDetractsFromTheMission.WordText}.",
            };
            this.expositions.Add(SentencePurposeType.Apologize, apologize);

            var reassure = new List<Func<Scene, string>>
            {
                scene => $"Don't worry, we'll get through this.",
                scene => $"We'll be okay.",
                scene => $"We'll be okay. We've been through worse.",
                scene => $"Don't worry, we'll be careful.",
                scene => $"No problem, we did the right thing.",
            };
            this.expositions.Add(SentencePurposeType.Reassure, reassure);

            var askAQuestion = new List<Func<Scene, string>>
            {
                scene => $"What's going on?",
                scene => $"What's happening?",
                scene => $"What's the plan?",
                scene => $"What's the situation?",
                scene => $"What's the status?",
                scene => $"What's the status of {scene.ActionObjectThatContributesToTheMission}?",
            };
            this.expositions.Add(SentencePurposeType.AskAQuestion, askAQuestion);

            var giveADirective = new List<Func<Scene, string>>
            {
                scene => $"We need to {scene.ActionThatContributesToTheMission.WordText} now!",
                scene => $"We need to {scene.ActionThatContributesToTheMission.WordText} now, or we'll be {scene.AFateIfTheMissionFails.WordText}!",
                scene => $"Get down! Stay quiet!",
                scene => $"We need to move fast. Let's grab the {scene.ObjectYouAreLookingFor.WordText} and {scene.AWayToEscape.WordText}!",
                scene => $"Do it quickly, and keep us updated.",
            };
            this.expositions.Add(SentencePurposeType.GiveADirective, giveADirective);

            var expressAgreement = new List<Func<Scene, string>>
            {
                scene => $"I agree.",
                scene => $"I think you're right.",
                scene => $"I think that's a good idea.",
                scene => $"I think that's a good idea. We should {scene.ActionThatContributesToTheMission.WordText}.",
                scene => $"I think that's a good idea. We should {scene.ActionThatContributesToTheMission.WordText} a {scene.ActionObjectThatContributesToTheMission.WordText} for the {scene.TimeOfDay.WordText}.",
                scene => $"I agree, {scene.ActionThatContributesToTheMission.WordText} is crucial.",
            };
            this.expositions.Add(SentencePurposeType.ExpressAgreement, expressAgreement);

            var offerAssistance = new List<Func<Scene, string>>
            {
                scene => $"I can help with that.",
                scene => $"I can help with that. I'm good at {scene.ASkillOfTheProtagonists.WordText}.",
                scene => $"I can help with that. I'm good at {scene.ASkillOfTheProtagonists.WordText}. I can {scene.ActionThatContributesToTheMission.WordText}.",
                scene => $"I'll {scene.ActionThatContributesToTheMission.WordText} the {scene.ActionObjectThatContributesToTheMission.WordText}.",
            };
            this.expositions.Add(SentencePurposeType.OfferAssistance, offerAssistance);

            var expressGratitude = new List<Func<Scene, string>>
            {
                scene => $"Thank you for your help.",
                scene => $"I appreciate your help.",
                scene => $"I'm grateful for your help.",
                scene => $"Thank you for your support.",
                scene => $"I'm grateful for your support.",
            };
            this.expositions.Add(SentencePurposeType.ExpressGratitude, expressGratitude);
        }
    }
}
