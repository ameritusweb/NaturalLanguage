namespace NaturalLanguageProcess
{
    public class ExpositionCollection
    {
        private Dictionary<SentencePurposeType, List<Func<Scene, string>>> expositions;
        private Dictionary<SentencePurposeType, List<Func<Scene, Character, string>>> characterExpositions;
        private List<Func<Scene, Character, (string, string)>> dialoguePairs;
        private List<(SentencePurposeType, SentencePurposeType)> purposePairs;

        public Dictionary<SentencePurposeType, List<Func<Scene, string>>> Expositions { get => expositions; }
        public Dictionary<SentencePurposeType, List<Func<Scene, Character, string>>> CharacterExpositions { get => characterExpositions; }

        public ExpositionCollection()
        {
            expositions = new Dictionary<SentencePurposeType, List<Func<Scene, string>>>();
            characterExpositions = new Dictionary<SentencePurposeType, List<Func<Scene, Character, string>>>();
            dialoguePairs = new List<Func<Scene, Character, (string, string)>>();
            purposePairs = new List<(SentencePurposeType, SentencePurposeType)>();
            Initialize();
            InitializePurposePairs();
        }

        private void InitializePurposePairs()
        {
            purposePairs.Add((SentencePurposeType.ExpressConcern, SentencePurposeType.OfferAssistance));
            purposePairs.Add((SentencePurposeType.OfferAssistance, SentencePurposeType.SeekClarification));
            purposePairs.Add((SentencePurposeType.SeekClarification, SentencePurposeType.ProvideInformation));
            purposePairs.Add((SentencePurposeType.ProvideInformation, SentencePurposeType.OfferOpinion));
            purposePairs.Add((SentencePurposeType.ProvideInformation, SentencePurposeType.OfferAssistance));
            purposePairs.Add((SentencePurposeType.OfferOpinion, SentencePurposeType.Motivate));
            purposePairs.Add((SentencePurposeType.Motivate, SentencePurposeType.ExpressUncertainty));
            purposePairs.Add((SentencePurposeType.ExpressUncertainty, SentencePurposeType.Reassure));
            purposePairs.Add((SentencePurposeType.Reassure, SentencePurposeType.AcceptAChallenge));
            purposePairs.Add((SentencePurposeType.Reassure, SentencePurposeType.ProvideInformation));
            purposePairs.Add((SentencePurposeType.AcceptAChallenge, SentencePurposeType.ExpressSolidarity));
            purposePairs.Add((SentencePurposeType.GiveADirective, SentencePurposeType.ExpressConcern));
            purposePairs.Add((SentencePurposeType.GiveADirective, SentencePurposeType.AskAQuestion));
            purposePairs.Add((SentencePurposeType.ExpressConcern, SentencePurposeType.OfferAssistance));
            purposePairs.Add((SentencePurposeType.OfferAssistance, SentencePurposeType.ExpressConfusion));
            purposePairs.Add((SentencePurposeType.OfferAssistance, SentencePurposeType.ExpressDisbelief));
            purposePairs.Add((SentencePurposeType.ExpressConfusion, SentencePurposeType.GiveGuidance));
            purposePairs.Add((SentencePurposeType.GiveGuidance, SentencePurposeType.ExpressSolidarity));
            purposePairs.Add((SentencePurposeType.ExpressSolidarity, SentencePurposeType.WarnOfImpendingDanger));
            purposePairs.Add((SentencePurposeType.WarnOfImpendingDanger, SentencePurposeType.MakeAPromise));
            purposePairs.Add((SentencePurposeType.WarnOfImpendingDanger, SentencePurposeType.DescribeASituation));
            purposePairs.Add((SentencePurposeType.MakeAPromise, SentencePurposeType.ExpressCertainty));
            purposePairs.Add((SentencePurposeType.MakeAPromise, SentencePurposeType.ExpressEmotion));
            purposePairs.Add((SentencePurposeType.ExpressEmotion, SentencePurposeType.Reassure));
            purposePairs.Add((SentencePurposeType.ExpressCertainty, SentencePurposeType.IssueAChallenge));
            purposePairs.Add((SentencePurposeType.IssueAChallenge, SentencePurposeType.RejectAnIdea));
            purposePairs.Add((SentencePurposeType.RejectAnIdea, SentencePurposeType.NarrateAnEvent));
            purposePairs.Add((SentencePurposeType.NarrateAnEvent, SentencePurposeType.ExpressJoy));
            purposePairs.Add((SentencePurposeType.ExpressJoy, SentencePurposeType.ExpressGratitude));
            purposePairs.Add((SentencePurposeType.DescribeASituation, SentencePurposeType.GiveADirective));
            purposePairs.Add((SentencePurposeType.AskAQuestion, SentencePurposeType.MakeAPromise));
        }

        private void InitializeDialogue()
        {
            var pairs = new List<Func<Scene, Character, (string, string)>>
            {
                (scene, character) => (this.expositions[SentencePurposeType.ShareAnExperience][0](scene), this.expositions[SentencePurposeType.ExpressGratitude][7](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.GiveGuidance][0](scene), this.expositions[SentencePurposeType.ExpressUrgency][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.WarnOfImpendingDanger][0](scene), this.expositions[SentencePurposeType.ExpressConcern][13](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.ExpressConcern][0](scene), this.expositions[SentencePurposeType.ShareAnExperience][5](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.ExpressUrgency][0](scene), this.expositions[SentencePurposeType.Motivate][4](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.Motivate][0](scene), this.expositions[SentencePurposeType.Persuade][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.Motivate][0](scene), this.expositions[SentencePurposeType.ExpressUrgency][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.Persuade][0](scene), this.expositions[SentencePurposeType.ExpressAgreement][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.ProvideInformation][0](scene), this.expositions[SentencePurposeType.AskAQuestion][7](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.SeekClarification][0](scene), this.expositions[SentencePurposeType.Reassure][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.OfferOpinion][0](scene), this.expositions[SentencePurposeType.ExpressAgreement][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.MakeAPromise][0](scene), this.expositions[SentencePurposeType.ExpressCertainty][5](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.Analyze][0](scene), this.expositions[SentencePurposeType.ProvokeThoughtOrProposeIdea][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.Accuse][0](scene), this.expositions[SentencePurposeType.Apologize][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.Apologize][0](scene), this.expositions[SentencePurposeType.Reassure][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.Reassure][0](scene), this.expositions[SentencePurposeType.Acknowledge][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.Acknowledge][0](scene), this.expositions[SentencePurposeType.ExpressAgreement][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.ExpressDisdain][0](scene), this.expositions[SentencePurposeType.ExpressAgreement][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.AskAQuestion][0](scene), this.expositions[SentencePurposeType.Suggest][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.Suggest][0](scene), this.expositions[SentencePurposeType.ExpressAgreement][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.GiveADirective][0](scene), this.expositions[SentencePurposeType.ExpressAgreement][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.Suggest][0](scene), this.expositions[SentencePurposeType.ExpressUncertainty][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.ExpressUncertainty][0](scene), this.expositions[SentencePurposeType.ExpressAgreement][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.ExpressAgreement][0](scene), this.expositions[SentencePurposeType.ExpressGratitude][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.ExpressGratitude][0](scene), this.expositions[SentencePurposeType.ExpressAgreement][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.ProvokeThoughtOrProposeIdea][0](scene), this.expositions[SentencePurposeType.ExpressAgreement][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.ConveyAppreciation][0](scene), this.expositions[SentencePurposeType.ConveyRespect][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.ConveyRespect][0](scene), this.expositions[SentencePurposeType.ChangeTheTopic][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.ChangeTheTopic][0](scene), this.expositions[SentencePurposeType.ExpressAgreement][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.AcceptResponsibility][0](scene), this.expositions[SentencePurposeType.ExpressAgreement][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.Criticize][0](scene), this.expositions[SentencePurposeType.AcceptResponsibility][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.Praise][0](scene), this.expositions[SentencePurposeType.ExpressAgreement][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.Praise][0](scene), this.expositions[SentencePurposeType.ExpressGratitude][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.InspireACrowd][0](scene), this.expositions[SentencePurposeType.ExpressAgreement][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.EngageInSmallTalk][0](scene), this.expositions[SentencePurposeType.ExpressAgreement][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.EngageInSmallTalk][0](scene), this.expositions[SentencePurposeType.ChangeTheTopic][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.Irony][0](scene), this.expositions[SentencePurposeType.ExpressAgreement][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.Irony][0](scene), this.expositions[SentencePurposeType.ChangeTheTopic][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.Sarcasm][0](scene), this.expositions[SentencePurposeType.ExpressAgreement][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.MakeAnObservation][0](scene), this.expositions[SentencePurposeType.ExpressAgreement][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.ProvideGoodNews][0](scene), this.expositions[SentencePurposeType.ExpressJoy][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.ExpressJoy][0](scene), this.expositions[SentencePurposeType.ExpressGratitude][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.TellAJoke][0](scene), this.expositions[SentencePurposeType.ExpressJoy][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.AcceptAChallenge][0](scene), this.expositions[SentencePurposeType.Acknowledge][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.ShowSympathy][0](scene), this.expositions[SentencePurposeType.ExpressGratitude][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.ElicitInformation][0](scene), this.expositions[SentencePurposeType.ExpressAgreement][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.ClarifyAStatement][0](scene), this.expositions[SentencePurposeType.ExpressAgreement][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.NarrateAnEvent][0](scene), this.expositions[SentencePurposeType.ExpressAgreement][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.DescribeASituation][0](scene), this.expositions[SentencePurposeType.ExpressAgreement][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.RefuteAnArgument][0](scene), this.expositions[SentencePurposeType.ExpressAgreement][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.Persuade][0](scene), this.expositions[SentencePurposeType.ExpressAgreement][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.MakeARequest][0](scene), this.expositions[SentencePurposeType.ExpressAgreement][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.ExpressEmotion][0](scene), this.expositions[SentencePurposeType.ExpressAgreement][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.IntroduceYourself][0](scene), this.expositions[SentencePurposeType.ExpressAgreement][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.ExpressSolidarity][0](scene), this.expositions[SentencePurposeType.ExpressAgreement][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.SeekAdvice][0](scene), this.expositions[SentencePurposeType.ExpressAgreement][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.Hypothesize][0](scene), this.expositions[SentencePurposeType.ExpressAgreement][0](scene)),
                (scene, character) => (this.expositions[SentencePurposeType.ArgueAPoint][0](scene), this.expositions[SentencePurposeType.ExpressAgreement][0](scene)),
                // TODO: Add more dialogue pairs
            };
            this.dialoguePairs.AddRange(pairs);
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
                scene => $"Please, follow {scene.HelpfulEntitiesForTheMission.WordText} instructions calmly and orderly.",
                scene => $"We should head for {scene.ASaferLocation.WordText}, away from the {scene.AnImmediateDangerToTheMission.WordText}.",
                scene => $"{scene.ARejectedPlanOfTheMission.WordText} is not a good idea; some {scene.VictimsOfTheEnemy.WordText} are excellent {scene.ASkillOfTheEnemy.WordText}.",
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
                scene => $"I hear {scene.TheSoundOfTheEnemy.WordText}! {scene.TheEnemy.WordText} are closing in!",
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
                scene => $"We can't afford to lose {scene.ASuccessFactorOfTheMission.WordText}.",
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
                scene => $"We must act quickly to {scene.ActionThatContributesToTheMission.WordText} the {scene.ActionObjectThatContributesToTheMission.WordText}.",
                scene => $"Time is slipping away. Every moment we delay, {scene.TheEnemy.WordText} gets closer to their goal.",
                scene => $"The clock is ticking. We have only {scene.TheTimeLeftToCompleteTheMission.WordText} left to prevent {scene.AFateIfTheMissionFails.WordText}.",
                scene => $"This is our critical moment. Delay is not an option, or {scene.LocationOfTheMission.WordText} will face {scene.TheChaosCausedByTheEnemy.WordText}.",
                scene => $"Hurry! There isn't a second to waste. {scene.TheImmediateEffectsOfTheProblem.WordText} are already manifesting.",
                scene => $"We're running out of time. {scene.TheGoalOfTheMission.WordText} must be achieved before {scene.TimeOfDay.WordText} ends.",
                scene => $"Let's pick up the pace. {scene.TheEnemy.WordText} won't wait for us to make our move."
            };
            this.expositions.Add(SentencePurposeType.ExpressUrgency, expressUrgency);

            var motivating = new List<Func<Scene, string>>
            {
                scene => $"We can do this!",
                scene => $"We can do this! We've been through worse.",
                scene => $"Let's move everyone! {scene.WhatHingesOnTheSuccessOfTheMission.WordText} is at stake.",
                scene => $"We can't let the {scene.AnEnemyOfTheMission.WordText} win.",
                scene => $"We can do this! We can't let the {scene.AnEnemyOfTheMission.WordText} win.",
                scene => $"That's the spirit! Let's do this!",
                scene => $"Remember why we're here. {scene.TheGoalOfTheMission.WordText} is within our grasp.",
                scene => $"We've got each other's backs. Together, there's nothing we can't overcome.",
                scene => $"Keep pushing forward. For every challenge we face, remember {scene.TheAchievementsOfTheGroup.WordText}.",
                scene => $"This is our time to shine. Let's show {scene.TheEnemy.WordText} what we're made of.",
                scene => $"Our resolve will be our weapon against {scene.TheChaosCausedByTheEnemy.WordText}. Stand strong!",
                scene => $"Each step forward is a step closer to victory. Let's make every action count.",
                scene => $"Believe in our cause. Believe in each other. That's how we'll achieve {scene.TheIdealFutureStateOfTheMission.WordText}.",
                scene => $"Our courage is our strength. Let's harness it and face {scene.AnObstacleToTheMission.WordText} head-on.",
                scene => $"For {scene.VictimsOfTheEnemy.WordText}, for {scene.LocationOfTheMission.WordText}, we cannot falter now.",
                scene => $"Eyes on the prize, team. {scene.TheGoalOfTheMission.WordText} is closer than it appears."
            };
            this.expositions.Add(SentencePurposeType.Motivate, motivating);


            var provideInformation = new List<Func<Scene, string>>
            {
                scene => $"{scene.TheEnemy.WordText} has a {scene.AWeaponOfTheEnemy.WordText} at {scene.LocationOfTheEnemy.WordText}",
                scene => $"Our latest intel suggests {scene.TheEnemy.WordText} is planning to attack {scene.LocationOfTheMission.WordText} by {scene.TimeOfDay.WordText}.",
                scene => $"Reports indicate that {scene.VictimsOfTheEnemy.WordText} were last seen at {scene.LocationOfTheVictim.WordText}.",
                scene => $"According to our sources, {scene.AnObstacleToTheMission.WordText} is currently {scene.StatusOfTheObstacleToTheMission.WordText}.",
                scene => $"Surveillance footage shows a gathering of {scene.TheEnemy.WordText} near {scene.LocationOfTheEnemy.WordText}, possibly planning {scene.TheChaosCausedByTheEnemy.WordText}.",
                scene => $"The {scene.TheMainCauseOfTheProblem.WordText} has been traced back to {scene.LocationOfTheMission.WordText}, requiring immediate attention.",
                scene => $"An inside source revealed that {scene.TheEnemy.WordText}'s next target is {scene.LocationOfTheMission.WordText}, exploiting {scene.AWeakness.WordText}.",
                scene => $"Our analysis confirms that {scene.ASolution.WordText} to {scene.TheProblem.WordText} is feasible with the resources currently at {scene.ASaferLocation.WordText}.",
                scene => $"Historical records suggest that {scene.APastEvent.WordText} could shed light on {scene.TheMystery.WordText}, hinting at parallels with our current situation.",
                scene => $"Weather forecasts predict {scene.ANaturalPhenomenon.WordText} in {scene.LocationOfTheMission.WordText}, which could impact our mission timelines."
            };
            this.expositions.Add(SentencePurposeType.ProvideInformation, provideInformation);


            var seekClarification = new List<Func<Scene, string>>
            {
                scene => $"That's risky. Are you sure?",
                scene => $"I don't understand. What's going on?",
                scene => $"How's the situation with the {scene.ActionObjectThatContributesToTheMission}? Any risk of {scene.AnImmediateDangerToTheMission}?",
                scene => $"What's the plan?",
                scene => $"What's the status?",
                scene => $"What are the main issues causing this {scene.AnImmediateDangerToTheMission}?",
            };
            this.expositions.Add(SentencePurposeType.SeekClarification, seekClarification);

            var offerOpinion = new List<Func<Scene, string>>
            {
                scene => $"I think we should {scene.ActionThatContributesToTheMission.WordText}.",
                scene => $"I think we should {scene.ActionThatContributesToTheMission.WordText} a {scene.ActionObjectThatContributesToTheMission.WordText} for the {scene.TimeOfDay.WordText}.",
                scene => $"I think we should {scene.ActionThatContributesToTheMission.WordText} our {scene.ActionObjectThatContributesToTheMission.WordText}.",
                scene => $"I think we should {scene.ActionThatContributesToTheMission.WordText} our {scene.ActionObjectThatContributesToTheMission.WordText}. We need to {scene.ActionThatContributesToSafety.WordText}.",
                scene => $"I think we should {scene.ActionThatContributesToTheMission.WordText} our {scene.ActionObjectThatContributesToTheMission.WordText}. We need to {scene.ActionThatContributesToSafety.WordText}. We don't want another {scene.ARelatedNegativePastEvent.WordText}.",
                scene => $"Let's use the {scene.ActionThatContributesToTheMission.WordText} for {scene.ActionThatContributesToTheMission.WordText}",
                scene => $"Agreed, we don't want to {scene.ActionThatDetractsFromTheMission.WordText}.",
                scene => $"Emergency handled; we can't let this happen again."
            };
            this.expositions.Add(SentencePurposeType.OfferOpinion, offerOpinion);

            var makeAPromise = new List<Func<Scene, string>>
            {
                scene => $"I promise we'll {scene.ActionThatContributesToTheMission.WordText}.",
                scene => $"I promise we'll {scene.ActionThatContributesToTheMission.WordText} a {scene.ActionObjectThatContributesToTheMission.WordText} for the {scene.TimeOfDay.WordText}.",
                scene => $"I promise we'll {scene.ActionThatContributesToTheMission.WordText} our {scene.ActionObjectThatContributesToTheMission.WordText}.",
                scene => $"I promise we'll {scene.ActionThatContributesToTheMission.WordText} our {scene.ActionObjectThatContributesToTheMission.WordText}. We need to {scene.ActionThatContributesToSafety.WordText}.",
                scene => $"I promise we'll {scene.ActionThatContributesToTheMission.WordText} our {scene.ActionObjectThatContributesToTheMission.WordText}. We need to {scene.ActionThatContributesToSafety.WordText}. We don't want another {scene.ARelatedNegativePastEvent.WordText}.",
                scene => $"I promise we'll {scene.ActionThatContributesToTheMission.WordText} for {scene.ActionThatContributesToTheMission.WordText}",
                scene => $"I promise we won't {scene.ActionThatDetractsFromTheMission.WordText}.",
                scene => $"I promise we won't {scene.ActionThatDetractsFromTheMission.WordText} again."
            };
            this.expositions.Add(SentencePurposeType.MakeAPromise, makeAPromise);

            var analyze = new List<Func<Scene, string>>
            {
                scene => $"We need to {scene.ActionThatContributesToTheMission.WordText} the {scene.ActionObjectThatContributesToTheMission.WordText} and check for any {scene.PossibleProblemToAvoid.WordText}.",
                scene => $"We need to {scene.ActionThatContributesToTheMission.WordText} the {scene.ActionObjectThatContributesToTheMission.WordText} and check for any {scene.PossibleProblemToAvoid.WordText}. We don't want another {scene.ARelatedNegativePastEvent.WordText}.",
                scene => $"We're assessing it now.",
                scene => $"A thorough analysis suggests that {scene.TheMainCauseOfTheProblem.WordText} is our primary concern. Prioritizing this could lead to significant advancements.",
                scene => $"Considering the {scene.StatusOfTheMission.WordText}, our next steps should carefully address {scene.AnObstacleToTheMission.WordText}.",
                scene => $"Historical patterns, such as {scene.APastEventMirroringTheCurrentMission.WordText}, offer valuable insights into our current predicament.",
                scene => $"It's crucial we evaluate the {scene.TheMentalStateOfTheEnemy.WordText}. Understanding their motivations could reveal unexpected strategies.",
                scene => $"Our data points to a correlation between {scene.TheImmediateEffectsOfTheProblem.WordText} and {scene.TheChaosCausedByTheEnemy.WordText}. Further investigation is warranted.",
                scene => $"Reflection on {scene.ARelatedNegativePastEvent.WordText} has highlighted the importance of {scene.ASuccessFactorOfTheMission.WordText} in our strategic planning."
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
                scene => $"My apologies for {scene.ActionThatDetractsFromTheMission.WordText}. It was not my intention to hinder our progress.",
                scene => $"I regret my oversight in {scene.ActionThatDetractsFromTheMission.WordText}. It's clear now how it affected {scene.TheGoalOfTheMission.WordText}.",
                scene => $"Looking back, I realize how {scene.ActionThatDetractsFromTheMission.WordText} was a mistake. I'm truly sorry for the consequences.",
                scene => $"I'm sorry for any confusion caused by my actions. In the future, I'll ensure to better align with {scene.ActionThatContributesToTheMission.WordText}.",
                scene => $"I owe you an apology. My actions, specifically {scene.ActionThatDetractsFromTheMission.WordText}, were misguided.",
                scene => $"I didn't foresee how {scene.ActionThatDetractsFromTheMission.WordText} would unfold. My apologies for the oversight."
            };
            this.expositions.Add(SentencePurposeType.Apologize, apologize);

            var reassure = new List<Func<Scene, string>>
            {
                scene => $"Don't worry, we'll get through this.",
                scene => $"Don't worry, we'll be fine.",
                scene => $"We'll be okay.",
                scene => $"We'll be okay. We've been through worse.",
                scene => $"Don't worry, we'll be careful.",
                scene => $"No problem, we did the right thing.",
            };
            this.expositions.Add(SentencePurposeType.Reassure, reassure);

            var acknowledge = new List<Func<Scene, string>>
            {
                scene => $"I understand.",
                scene => $"Acknowledged.",
                scene => $"Understood.",
                scene => $"Thanks for considering my suggestion.",
                scene => $"Your point is well taken.",
                scene => $"I see what you mean.",
                scene => $"That's a good insight, thank you.",
                scene => $"I appreciate the update.",
                scene => $"Roger that. We'll proceed as advised.",
                scene => $"Got it, we'll take it from here.",
                scene => $"Your feedback is valuable, we'll act on it.",
                scene => $"That clarifies a lot, thanks for the info.",
                scene => $"Indeed, that's an interesting perspective.",
                scene => $"Acknowledging your contribution to our strategy.",
                scene => $"Duly noted, we'll adjust our plans accordingly."
            };
            this.expositions.Add(SentencePurposeType.Acknowledge, acknowledge);


            var expressDisdain = new List<Func<Scene, string>>
            {
                scene => $"I can't believe this!",
                scene => $"I can't believe this! We're in this mess because of you!",
                scene => $"I can't believe this! You're the reason we're in this mess!",
                scene => $"I can't believe you did that!",
            };
            this.expositions.Add(SentencePurposeType.ExpressDisdain, expressDisdain);

            var askAQuestion = new List<Func<Scene, string>>
            {
                scene => $"What's going on?",
                scene => $"How can we leverage our strengths to reach our goal?",
                scene => $"What's our next move?",
                scene => $"How can we support each other effectively?",
                scene => $"What's our approach to tackle {scene.AnObstacleToTheMission.WordText}?",
                scene => $"How can we ensure we stay on the right path?",
                scene => $"What's happening?",
                scene => $"What's the plan?",
                scene => $"What's the situation?",
                scene => $"What's the status?",
                scene => $"What's the status of {scene.ActionObjectThatContributesToTheMission.WordText}?",
            };
            this.expositions.Add(SentencePurposeType.AskAQuestion, askAQuestion);

            var seekAdvice = new List<Func<Scene, string>>
            {
                scene => $"What should we do?",
                scene => $"What do you think we should do?",
                scene => $"What's the best course of action?",
                scene => $"What's the best course of action for {scene.ActionObjectThatContributesToTheMission.WordText}?",
                scene => $"What's the best course of action for {scene.ActionObjectThatContributesToTheMission.WordText} in the {scene.LocationOfTheMission.WordText}?",
                scene => $"What's the best course of action for {scene.ActionObjectThatContributesToTheMission.WordText} in the {scene.LocationOfTheMission.WordText} at {scene.TimeOfDay.WordText}?",
                scene => $"What's the best course of action for {scene.ActionObjectThatContributesToTheMission.WordText} in the {scene.LocationOfTheMission.WordText} at {scene.TimeOfDay.WordText} to {scene.ActionThatContributesToTheMission.WordText}?",
            };
            this.expositions.Add(SentencePurposeType.SeekAdvice, seekAdvice);

            var hypothesize = new List<Func<Scene, string>>
            {
                scene => $"What if we could {scene.ActionThatContributesToTheMission.WordText}?",
            };
            this.expositions.Add(SentencePurposeType.Hypothesize, hypothesize);

            var giveADirective = new List<Func<Scene, string>>
            {
                scene => $"We need to {scene.ActionThatContributesToTheMission.WordText} now!",
                scene => $"We need to {scene.ActionThatContributesToTheMission.WordText} now, or we'll be {scene.AFateIfTheMissionFails.WordText}!",
                scene => $"Get down! Stay quiet!",
                scene => $"We need to move fast. Let's grab the {scene.ObjectYouAreLookingFor.WordText} and {scene.AWayToEscape.WordText}!",
                scene => $"Do it quickly, and keep us updated.",
                scene => $"Form {scene.AWeaponAgainstTheEnemy.WordText}!",
                scene => $"We need to {scene.ActionThatContributesToTheMission.WordText} the {scene.ActionObjectThatContributesToTheMission.WordText} and check for any {scene.PossibleProblemToAvoid.WordText}.",
                scene => $"We've trained for this; stay disciplined.",
                scene => $"Stay silent and avoid unnecessary risks.",
                scene => $"We're in this together; let's support each other.",
                scene => $"Stay united, and we'll emerge victorious.",
                scene => $"Prepare for the worst, hope for the best.",
                scene => $"We've faced tougher challenges before; stay determined.",
                scene => $"This is a critical moment; stay on your guard.",
                sceme => $"Stay sharp, everyone!",
                scene => $"Stay calm and composed, we can overcome this.",
                scene => $"Remember the plan and stick to it.",
                scene => $"Keep an eye out for any unexpected obstacles.",
                scene => $"Let's make sure we're well-prepared for any surprises.",
                scene => $"Stay focused!",
            };
            this.expositions.Add(SentencePurposeType.GiveADirective, giveADirective);

            var suggest = new List<Func<Scene, string>>
            {
                scene => $"We could {scene.ActionThatContributesToTheMission.WordText}.",
                scene => $"We could {scene.ActionThatDetractsFromTheMission.WordText}.",
                scene => $"Perhaps we should consider {scene.PossibleSolutionToConsider.WordText} as a viable option.",
                scene => $"What if we tried {scene.AnAlternativeStrategy.WordText}? It might offer us a new perspective.",
                scene => $"Could deploying {scene.ASecretWeapon.WordText} at {scene.LocationOfTheMission.WordText} turn the tide?",
                scene => $"Maybe we should {scene.ActionThatContributesToSafety.WordText} to ensure everyone's well-being.",
                scene => $"What about {scene.APlanToSucceedAtMission.WordText}? It could be our best shot.",
                scene => $"Have we thought about {scene.AnUnexpectedAlly.WordText}? Their assistance could be crucial.",
                scene => $"We might need to {scene.ActionThatContributesToTheMission.WordText} sooner rather than later.",
                scene => $"It could be beneficial to {scene.ActionObjectThatContributesToTheMission.WordText} for added support."
            };
            this.expositions.Add(SentencePurposeType.Suggest, suggest);

            var argueAPoint = new List<Func<Scene, string>>
            {
                scene => $"I don't think that's a good idea.",
                scene => $"I don't think that's a good idea. We should {scene.ActionThatContributesToTheMission.WordText}.",
                scene => $"I don't think that's a good idea. We should {scene.ActionThatContributesToTheMission.WordText} a {scene.ActionObjectThatContributesToTheMission.WordText} instead.",
                scene => $"That approach seems risky. Wouldn't it be safer to {scene.ActionThatContributesToSafety.WordText}?",
                scene => $"I'm not convinced. Have we considered the consequences of {scene.ActionThatDetractsFromTheMission.WordText}?",
                scene => $"But how does that align with our goal to {scene.TheGoalOfTheMission.WordText}? We might lose focus.",
                scene => $"Are we sure about this? It might lead to {scene.AFateIfTheMissionFails.WordText}, considering {scene.TheCurrentSituation.WordText}.",
                scene => $"This could backfire. Remember what happened when we {scene.ARelatedNegativePastEvent.WordText}?",
                scene => $"I see your point, but {scene.AnObstacleToTheMission.WordText} could complicate things. We need a plan B.",
                scene => $"Isn't that exactly what {scene.TheEnemy.WordText} would expect us to do? We need a more unpredictable approach."
            };
            this.expositions.Add(SentencePurposeType.ArgueAPoint, argueAPoint);


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
                scene => $"We can send {scene.FriendsOfTheProtagonists} to help.",
                scene => $"I can help with that. I'm good at {scene.ASkillOfTheProtagonists.WordText}.",
                scene => $"I can help with that. I'm good at {scene.ASkillOfTheProtagonists.WordText}. I can {scene.ActionThatContributesToTheMission.WordText}.",
                scene => $"I'll {scene.ActionThatContributesToTheMission.WordText} the {scene.ActionObjectThatContributesToTheMission.WordText}.",
            };
            this.expositions.Add(SentencePurposeType.OfferAssistance, offerAssistance);

            var issueAChallenge = new List<Func<Scene, string>>
            {
                scene => $"We have to stay strong and organized.",
                scene => $"We have to stay strong and organized. We can't let the {scene.AnEnemyOfTheMission.WordText} win.",
                scene => $"We have to stay strong and organized. We can't let the {scene.AnEnemyOfTheMission.WordText} win. We need to {scene.ActionThatContributesToTheMission.WordText}.",
                scene => $"We must succeed.",
                scene => $"We must succeed. We can't let the {scene.AnEnemyOfTheMission.WordText} win."
            };
            this.expositions.Add(SentencePurposeType.IssueAChallenge, issueAChallenge);

            var conveySurprise = new List<Func<Scene, string>>
            {
                scene => $"I can't believe it!",
                scene => $"I can't believe it! We actually did it!",
                scene => $"This is beyond my wildest dreams!",
                scene => $"Who would have thought? {scene.TheEnemy.WordText} defeated, against all odds!",
                scene => $"Astounding! {scene.AnUnexpectedAlly.WordText} came through when we least expected.",
                scene => $"Never in my life did I imagine we'd find {scene.ACriticalClue.WordText} here.",
                scene => $"What a twist! {scene.TheMainCauseOfTheProblem.WordText} was right before our eyes.",
                scene => $"Unbelievable! The {scene.AWeaponOfTheEnemy.WordText} was a decoy all along!",
                scene => $"Shocking! To think {scene.TheChaosCausedByTheEnemy.WordText} could lead us here.",
                scene => $"To see {scene.LocationOfTheMission.WordText} in peace again, it's nothing short of a miracle."
            };
            this.expositions.Add(SentencePurposeType.ConveySurprise, conveySurprise);

            var summarize = new List<Func<Scene, string>>
            {
                scene => $"So, we'll {scene.ActionThatContributesToTheMission.WordText}, and {scene.AnotherActionThatContributesToTheMission}.",
                scene => $"In summary, our next steps involve {scene.ActionThatContributesToTheMission.WordText} followed by {scene.AnotherActionThatContributesToTheMission}.",
                scene => $"To wrap up, we've decided to {scene.ActionThatContributesToTheMission.WordText} and then tackle {scene.AnObstacleToTheMission.WordText}.",
                scene => $"Quick recap: First {scene.ActionThatContributesToTheMission.WordText}, next {scene.AnotherActionThatContributesToTheMission}, and finally, ensure {scene.TheGoalOfTheMission.WordText}.",
                scene => $"Ultimately, our plan is to {scene.ActionThatContributesToTheMission.WordText}, securing {scene.ASaferLocation.WordText} against {scene.AnImmediateDangerToTheMission.WordText}.",
                scene => $"Summing up, we'll focus on {scene.ActionThatContributesToTheMission.WordText} to prevent {scene.TheChaosCausedByTheEnemy.WordText}, aiming for {scene.TheIdealFutureStateOfTheMission.WordText}.",
                scene => $"Here's the gist: {scene.ActionThatContributesToTheMission.WordText} as our primary objective, followed by a strategic move to {scene.LocationOfTheMission.WordText}.",
                scene => $"In essence, the mission boils down to {scene.ActionThatContributesToTheMission.WordText} and leveraging {scene.AnUnexpectedAlly.WordText} for our ultimate goal.",
                scene => $"Overall, our strategy involves {scene.ActionThatContributesToTheMission.WordText} to counteract {scene.TheMainCauseOfTheProblem.WordText}, ensuring {scene.TheIdealFutureStateOfTheMission.WordText}.",
                scene => $"To conclude, we're setting our sights on {scene.ActionThatContributesToTheMission.WordText}, with the aim of disrupting {scene.TheEnemy.WordText}'s plans."
            };
            this.expositions.Add(SentencePurposeType.Summarize, summarize);

            var expressGratitude = new List<Func<Scene, string>>
            {
                scene => $"Thank you for your help.",
                scene => $"I appreciate your help.",
                scene => $"I'm grateful for your help.",
                scene => $"Thank you for your support.",
                scene => $"I'm grateful for your support.",
                scene => $"Thanks for your swift response.",
                scene => $"Thanks for warning us.",
                scene => $"Your efforts have made a significant difference.",
                scene => $"I can't thank you enough for what you've done.",
                scene => $"Your contribution has been invaluable to our success.",
                scene => $"This wouldn't have been possible without you.",
                scene => $"Your bravery and selflessness will not be forgotten.",
                scene => $"We owe you a debt of gratitude for your courage.",
                scene => $"Thank you for standing with us during these times.",
                scene => $"Your actions have spoken louder than words. Thank you.",
                scene => $"In appreciation of your unwavering support, thank you."
            };
            this.expositions.Add(SentencePurposeType.ExpressGratitude, expressGratitude);


            var expressDedication = new List<Func<Scene, string>>
            {
                scene => $"I'm willing to take the risk.",
                scene => $"I'm dedicated to making this right.",
                scene => $"No matter the challenge, I'm here to stay.",
                scene => $"I pledge my unwavering commitment to our cause.",
                scene => $"My dedication to this mission is absolute.",
                scene => $"I'm committed to seeing this through to the end.",
                scene => $"Every step we take is a testament to our resolve.",
                scene => $"I'm here for the long haul, no matter what it takes.",
                scene => $"Our dedication is the key to overcoming these trials.",
                scene => $"Let my actions reflect the depth of my commitment."
            };
            this.expositions.Add(SentencePurposeType.ExpressDedication, expressDedication);


            var revealSecrets = new List<Func<Scene, string>>
            {
                scene => $"I've been keeping this from you, but I think it's time you knew.",
                scene => $"I've been keeping this from you, but I think it's time you knew. I've been {scene.AHiddenActionOfTheProtagonists.WordText}.",
            };
            this.expositions.Add(SentencePurposeType.RevealSecrets, revealSecrets);

            var expressCertainty = new List<Func<Scene, string>>
            {
                scene => $"I'm sure of it.",
                scene => $"I'm certain.",
                scene => $"I'm certain of it.",
                scene => $"You can count on us.",
                scene => $"I have no doubt we'll be able to utilize {scene.ObjectThatAssistsTheMission.WordText}.",
                scene => $"Our dedication to {scene.ActionThatContributesToTheMission.WordText} will prevail.",
                scene => $"I have no doubt we'll {scene.ActionThatContributesToTheMission.WordText}.",
                scene => $"We won't {scene.ActionThatDetractsFromTheMission.WordText}.",
                scene => $"I'm certain of it. We need to {scene.ActionThatContributesToTheMission.WordText}.",
                scene => $"I'm certain of it. We need to {scene.ActionThatContributesToTheMission.WordText} a {scene.ActionObjectThatContributesToTheMission.WordText} for the {scene.TimeOfDay.WordText}.",
            };
            this.expositions.Add(SentencePurposeType.ExpressCertainty, expressCertainty);

            var expressUncertainty = new List<Func<Scene, string>>
            {
                scene => $"I'm not sure.",
                scene => $"Do you think we can make it?",
                scene => $"Are we really prepared for what's coming?",
                scene => $"Is this the right path, or are we just walking into another trap?",
                scene => $"How can we be certain this will work?",
                scene => $"But what if {scene.TheEnemy.WordText} anticipates our every move?",
                scene => $"Can we really trust {scene.AnUnexpectedAlly.WordText} at a time like this?",
                scene => $"Is {scene.TheIdealStrategyForTheMission.WordText} enough to overcome {scene.AnObstacleToTheMission.WordText}?",
                scene => $"What if our efforts aren't enough to stem {scene.TheChaosCausedByTheEnemy.WordText}?",
                scene => $"Are we too late to make a difference for {scene.VictimsOfTheEnemy.WordText}?",
                scene => $"How much can we really change the outcome of {scene.TheMainCauseOfTheProblem.WordText}?",
                scene => $"Do we have what it takes to face {scene.AnEnemyOfTheMission.WordText} head-on?",
                scene => $"What are the chances that {scene.PossibleSolutionToConsider.WordText} will turn the tide?",
                scene => $"Could there be something we're overlooking in {scene.LocationOfTheMission.WordText}?",
                scene => $"Is it possible that we're underestimating {scene.TheMentalStateOfTheEnemy.WordText}?"
            };
            this.expositions.Add(SentencePurposeType.ExpressUncertainty, expressUncertainty);

            var expressAmazement = new List<Func<Scene, string>>
            {
                scene => $"This {scene.ObjectYouAreLookingFor} is amazing!",
                scene => $"I can't believe it!",
                scene => $"Wow, look at the size of {scene.AnObstacleToTheMission.WordText}!",
                scene => $"Incredible! How did {scene.AnUnexpectedAlly.WordText} do that?",
                scene => $"I've never seen anything like {scene.TheChaosCausedByTheEnemy.WordText} before.",
                scene => $"The beauty of {scene.LocationOfTheMission.WordText} is beyond words.",
                scene => $"Astounding! {scene.ASecretWeapon.WordText} could change everything!",
                scene => $"Unbelievable! {scene.TheEnemy.WordText} has never shown such tactics.",
                scene => $"This changes everything! {scene.PossibleSolutionToConsider.WordText} is a game-changer.",
                scene => $"I'm speechless. The courage of {scene.ProtagonistsForTheMission.WordText} is unparalleled.",
                scene => $"Remarkable! {scene.TheBeforeAndAfter.WordText} shows how far we've come.",
                scene => $"Can you believe the progress we've made? {scene.MissionProgress.WordText} is astonishing!",
                scene => $"Never in my wildest dreams did I imagine we'd find {scene.ACriticalClue.WordText}.",
                scene => $"To think, we were this close to overlooking {scene.TheMysteryUnfolding.WordText}.",
                scene => $"The transformation of {scene.LocationOfTheMission.WordText} is nothing short of miraculous."
            };
            this.expositions.Add(SentencePurposeType.ExpressAmazement, expressAmazement);

            var expressJoy = new List<Func<Scene, string>>
            {
                scene => $"I'm so happy!",
                scene => $"I'm so happy! We did it!",
                scene => $"I'm so happy! We did it! We {scene.ActionThatContributesToTheMission.WordText}!",
                scene => $"Great job!",
                scene => $"Great job! We {scene.ActionThatContributesToTheMission.WordText}!",
                scene => $"Mission accomplished!",
                scene => $"We did it!",
                scene => $"We saved the day!",
                scene => $"I'm feeling more optimistic now!",
            };
            this.expositions.Add(SentencePurposeType.ExpressJoy, expressJoy);

            var expressSolidarity = new List<Func<Scene, string>>
            {
                scene => $"We're grateful for each other's support.",
                scene => $"Together, we stand against {scene.AnEnemyOfTheMission.WordText}; divided, we fall.",
                scene => $"In the face of {scene.AnImmediateDangerToTheMission.WordText}, our unity is our strongest weapon.",
                scene => $"This mission, {scene.TheGoalOfTheMission.WordText}, it's not just mine; it's ours. We're in this together.",
                scene => $"Against the backdrop of {scene.TheChaosCausedByTheEnemy.WordText}, our solidarity shines the brightest.",
                scene => $"Remember, {scene.ProtagonistsForTheMission.WordText}, we share one heart, one goal.",
                scene => $"It's our shared struggles against {scene.TheEnemy.WordText} that bind us stronger than any chain could.",
                scene => $"Our bond, tested by {scene.AnObstacleToTheMission.WordText}, has only grown stronger.",
                scene => $"As {scene.TheSoundOfTheEnemy.WordText} echoes, let it be a reminder that we only survive together.",
                scene => $"We draw strength from each other, every step of the way towards {scene.TheIdealFutureStateOfTheMission.WordText}.",
                scene => $"In the darkest times, it's the thought of {scene.FriendsOfTheProtagonists.WordText} that lights the way.",
                scene => $"Our unity in the face of {scene.TheMainCauseOfTheProblem.WordText} is the true testament to our resolve.",
                scene => $"Each of us brings something unique to {scene.TheMissionObjective.WordText}, but it's together that we make it possible.",
                scene => $"Let's carry each other forward, past {scene.AnOverwhelmingChallenge.WordText}, towards a better tomorrow.",
                scene => $"The strength of our alliance against {scene.TheEnemy.WordText} is unbreakable; we are bound by more than just duty."
            };
            this.expositions.Add(SentencePurposeType.ExpressSolidarity, expressSolidarity);


            var introduceYourself = new List<Func<Scene, Character, string>>
            {
                (scene, character) => $"I'm {character.Name}.",
                (scene, character) => $"I'm {character.Name}. I'm good at {character.Skill.WordText}.",
                (scene, character) => $"Name's {character.Name}. I specialize in {character.Skill.WordText}, useful for dealing with {scene.AnEnemyOfTheMission.WordText}.",
                (scene, character) => $"The name is {character.Name}, and my role is {character.Role.WordText}. I'm here to ensure {scene.TheGoalOfTheMission.WordText} is achieved.",
                (scene, character) => $"Hello, I'm {character.Name}. You might say I'm a bit of an expert in {character.Skill.WordText}. Handy, given our current situation with {scene.TheMainCauseOfTheProblem.WordText}.",
                (scene, character) => $"I am {character.Name}, tasked with {scene.ActionThatContributesToTheMission.WordText}. My skills in {character.Skill.WordText} will be indispensable.",
                (scene, character) => $"Greetings, {character.Name} here. I've been navigating {scene.LocationOfTheMission.WordText} for years. My knowledge might just be the edge we need.",
                (scene, character) => $"They call me {character.Name}. If it's {character.Skill.WordText} you need, you're in luck. Especially now, with {scene.AnImmediateDangerToTheMission.WordText} looming.",
                (scene, character) => $"I'm {character.Name}, the one you've heard about. Yes, the {character.Role.WordText}. We have a lot to tackle, starting with {scene.TheMainCauseOfTheProblem.WordText}.",
                (scene, character) => $"Name's {character.Name}, and I've been dealing with {scene.AnEnemyOfTheMission.WordText} longer than I'd care to admit. My {character.Skill.WordText} might come in handy.",
                (scene, character) => $"Hey there, I'm {character.Name}. Not to brag, but my {character.Skill.WordText} skills have gotten us out of more than a few pinches like {scene.TheCurrentSituation.WordText}.",
                (scene, character) => $"I go by {character.Name}. In times like these, with {scene.TheChaosCausedByTheEnemy.WordText} everywhere, my {character.Skill.WordText} is more than just a party trick.",
                (scene, character) => $"It's {character.Name} speaking. With {scene.TheEnemy.WordText} at our doorstep, my experience in {character.Skill.WordText} is our secret weapon.",
                (scene, character) => $"Hello, everyone, {character.Name} here. I've been a {character.Role.WordText} through and through, especially now, as we face {scene.AnOverwhelmingChallenge.WordText}.",
                (scene, character) => $"I'm {character.Name}, your go-to for anything related to {character.Skill.WordText}. Given our quest to {scene.ActionThatContributesToTheMission.WordText}, you'll find me quite useful."
            };
            this.characterExpositions.Add(SentencePurposeType.IntroduceYourself, introduceYourself);


            var tellAJoke = new List<Func<Scene, string>>
            {
                scene => $"Why did the {scene.AnEnemyOfTheMission.WordText} cross the road? To get to the other side!",
                scene => $"What's a {scene.AnEnemyOfTheMission.WordText}'s favorite type of music? Heavy metal, because of all the iron-y!",
                scene => $"Why did the {scene.ObjectThatAssistsTheMission.WordText} go to school? To improve its skills!",
                scene => $"How do you make {scene.AnUmbrellaTermThatDescribesTheNatureOfTheEnemy.WordText} laugh? You press their funny bone!",
                scene => $"What did the {scene.ASaferLocation.WordText} say to the {scene.AnEnemyOfTheMission.WordText}? You can't breach this wall of humor!",
                scene => $"Why was the computer cold at the mission base? It left its Windows open in {scene.LocationOfTheMission.WordText}.",
                scene => $"Why did the {scene.ProtagonistsForTheMission.WordText} go to the party? To network and make connections!",
                scene => $"What's a {scene.AnEnemyOfTheMission.WordText}'s least favorite food? Spam, because it's too easy to filter out!",
                scene => $"How does a {scene.AnUmbrellaTermThatDescribesTheNatureOfTheEnemy.WordText} fix a broken lightbulb? They don't; they prefer working in the shadows!",
                scene => $"What did the {scene.ObjectThatAssistsTheMission.WordText} say after a workout? 'I'm feeling so charged up, I could power up the entire mission!'",
                scene => $"Why don't secrets last long in {scene.LocationOfTheMission.WordText}? Because even the walls are part of the network!",
                scene => $"What's the best way to communicate in a stealth mission? Use sign language, because eavesdroppers can't hear your hands!",
                scene => $"Why did the mission planner get lost? Because the roadmap was full of loops!"
            };
            this.expositions.Add(SentencePurposeType.TellAJoke, tellAJoke);

            var expressEmotion = new List<Func<Scene, string>>
            {
                scene => $"I'm feeling {scene.ThePhysicalStateOfTheProtagonists.WordText}.",
                scene => $"It's heartbreaking to see {scene.TheChaosCausedByTheEnemy.WordText} like this.",
                scene => $"Seeing the {scene.LocationOfTheMission.WordText} like this fills me with sorrow.",
                scene => $"I never thought I'd feel such rage, but seeing {scene.TheEnemyActions.WordText} does it.",
                scene => $"There's hope yet. {scene.TheHeroesOfTheStory.WordText} are making a difference.",
                scene => $"Fear grips me at the thought of {scene.TheUnknownFactors.WordText}.",
                scene => $"I'm surprisingly calm, considering {scene.TheCurrentSituation.WordText}.",
                scene => $"Joy is a rare commodity here, but {scene.AMomentOfJoy.WordText} was priceless.",
                scene => $"The weight of {scene.TheBurdenCarriedByTheProtagonists.WordText} is overwhelming.",
                scene => $"I'm filled with determination. We will {scene.TheMissionObjective.WordText}.",
                scene => $"The betrayal of {scene.ATraitorInTheRanks.WordText} left a bitter taste.",
                scene => $"I can't hide my excitement for {scene.APositiveTurnOfEvents.WordText}. Finally, some good news!",
                scene => $"The courage of {scene.TheUnsungHeroes.WordText} is truly inspiring.",
                scene => $"Anguish washes over me as I consider {scene.TheLossesWeHaveSuffered.WordText}.",
                scene => $"I'm seething with anger at {scene.TheInjusticeFaced.WordText}. It's unforgivable.",
                scene => $"The resilience of {scene.TheSurvivors.WordText} in the face of {scene.AnOverwhelmingChallenge.WordText} is astounding.",
                scene => $"I'm puzzled by {scene.TheMysteryUnfolding.WordText}. What could it mean?",
                scene => $"A sense of pride swells within me as I look at {scene.TheAchievementsOfTheGroup.WordText}.",
                scene => $"The stark contrast between {scene.TheBeforeAndAfter.WordText} is jarring."
            };
            this.expositions.Add(SentencePurposeType.ExpressEmotion, expressEmotion);

            var makeARequest = new List<Func<Scene, string>>
            {
                scene => $"Can you help me with this?",
                scene => $"Can you help me with this? I'm not sure what to do.",
                scene => $"Can someone contact the {scene.FriendsOfTheProtagonists} for assistance?",
                scene => $"Could you please look into the {scene.AnImmediateDangerToTheMission.WordText} situation?",
                scene => $"I need someone to {scene.ActionThatContributesToTheMission.WordText} immediately. Can you take care of it?",
                scene => $"Is it possible for you to {scene.ActionThatContributesToTheMission.WordText} by {scene.TimeOfDay.WordText}?",
                scene => $"We require immediate assistance at {scene.LocationOfTheMission.WordText}. Can anyone respond?",
                scene => $"Can anyone provide more information about the {scene.ANegativeFactorThatNecessitatedTheMission.WordText}?",
                scene => $"I'm looking for {scene.ObjectYouAreLookingFor.WordText}. Can anyone point me in the right direction?",
                scene => $"We're in need of {scene.ActionObjectThatContributesToTheMission.WordText}. Does anyone have any leads?",
                scene => $"Could someone please {scene.ActionThatContributesToSafety.WordText} as soon as possible?",
                scene => $"We could use some help with {scene.TheDeedsOrActionsOfTheEnemy}. Anyone available?",
                scene => $"I'm trying to understand {scene.APastEventMirroringTheCurrentMission.WordText}. Can someone explain it to me?",
                scene => $"Does anyone know how to {scene.ASkillOfTheEnemy.WordText}? We could use that knowledge.",
                scene => $"Can someone take over the {scene.AnImmediateDangerToTheMission.WordText} for a moment?",
                scene => $"I need advice on {scene.ASuccessFactorOfTheMission.WordText}. Can anyone offer guidance?",
                scene => $"We need to make a decision about {scene.ARejectedPlanOfTheMission.WordText}. Thoughts?",
                scene => $"Can someone verify the status of {scene.VictimsOfTheEnemy.WordText} at {scene.LocationOfTheMission.WordText}?",
                scene => $"I'm having trouble with {scene.TheImmediateEffectsOfTheProblem.WordText}. Can someone assist?",
                scene => $"We need more resources for {scene.ActionThatContributesToTheMission.WordText}. Who can contribute?",
                scene => $"Is there anyone experienced with {scene.ASkillOfTheProtagonists.WordText} who can lend a hand?",
                scene => $"Can someone double-check the {scene.TheNeedsOfTheEnemy.WordText}? We need to be certain.",
                scene => $"We're looking to {scene.ActionThatContributesToTheMission.WordText}. Any volunteers?",
                scene => $"Can anyone teach me how to {scene.ASkillOfTheProtagonists.WordText}? I think it's crucial for our mission.",
                scene => $"I need some help planning the {scene.PreparationForTheMission.WordText}. Any ideas?",
                scene => $"Can anyone share insights on {scene.TheEnemy.WordText}? Understanding them could be key.",
            };
            this.expositions.Add(SentencePurposeType.MakeARequest, makeARequest);

            var persuade = new List<Func<Scene, string>>
            {
                scene => $"Let's motivate each other. We're {scene.CohortToBeRescuedFromTheEnemy} only hope.",
                scene => $"Remember, the fate of {scene.LocationOfTheMission.WordText} rests on our shoulders. We can't afford to hesitate now.",
                scene => $"If we don't act now, {scene.TheMainCauseOfTheProblem.WordText} will only worsen. We have the power to change the outcome.",
                scene => $"Think of {scene.VictimsOfTheEnemy.WordText}. Our actions today could save lives and restore peace.",
                scene => $"Our mission is critical. {scene.ASaferLocation.WordText} depends on us to {scene.ActionThatContributesToTheMission.WordText}.",
                scene => $"We've overcome challenges before. This is our moment to turn the tide against {scene.AnEnemyOfTheMission.WordText}.",
                scene => $"Every small effort counts. By {scene.ActionThatContributesToTheMission.WordText}, we're one step closer to {scene.TheGoalOfTheMission.WordText}.",
                scene => $"This is about more than just us. It's about {scene.WhatHingesOnTheSuccessOfTheMission.WordText}. We have a duty to succeed.",
                scene => $"Consider the alternative. Failure means {scene.AFateIfTheMissionFails.WordText}. Are we willing to accept that?",
                scene => $"It's not just a mission; it's a promise to {scene.ProtagonistsForTheMission.WordText}. We owe it to them to see this through.",
                scene => $"We have a strategy, and {scene.TheIdealStrategyForTheMission.WordText} has never let us down before. Trust in our planning.",
                scene => $"Let's harness our collective strength. Together, we're more than capable of overcoming {scene.AnObstacleToTheMission.WordText}.",
                scene => $"Time is of the essence. The longer we wait, the stronger {scene.TheEnemy.WordText} becomes. Now is the moment to act.",
                scene => $"Our resolve today defines our legacy tomorrow. Let's ensure that history remembers us as heroes who stood up to {scene.AnEnemyOfTheMission.WordText}.",
                scene => $"Look around you, at the faces of our comrades. We're all in this together, fighting for {scene.TheIdealFutureStateOfTheMission.WordText}. Let's make it a reality."
            };
            this.expositions.Add(SentencePurposeType.Persuade, persuade);

            var refuteAnArgument = new List<Func<Scene, string>>
            {
                scene => $"I disagree.",
                scene => $"I disagree. We should {scene.ActionThatContributesToTheMission.WordText} instead.",
                scene => $"That's not going to work because {scene.TheMainCauseOfTheProblem.WordText} requires a different approach.",
                scene => $"No, that would only make {scene.TheMainCauseOfTheProblem.WordText} worse. Have we considered {scene.PossibleSolutionToConsider.WordText}?",
                scene => $"I understand your point, but {scene.AnImmediateDangerToTheMission.WordText} demands immediate action, not {scene.ActionThatDetractsFromTheMission.WordText}.",
                scene => $"Actually, {scene.TheStatusOfTheMainCauseOfTheProblem.WordText} suggests that {scene.AnObstacleToTheMission.WordText} is our real problem.",
                scene => $"But remember what happened last time we tried that? {scene.ARelatedNegativePastEvent.WordText} shows we need a new strategy.",
                scene => $"Considering {scene.TheImmediateEffectsOfTheProblem.WordText}, it's clear your idea won't address the root issue.",
                scene => $"Your idea overlooks {scene.AnObstacleToTheMission.WordText}, which is critical to our success.",
                scene => $"We can't afford to focus on {scene.ActionThatDetractsFromTheMission.WordText} when {scene.TheGoalOfTheMission.WordText} is still unachieved.",
                scene => $"{scene.ASaferLocation.WordText} might seem like a priority, but it's actually a distraction from {scene.TheGoalOfTheMission.WordText}.",
                scene => $"I see your point, but relying on {scene.TheEnemy.WordText} to make the next move could put us at a disadvantage.",
                scene => $"Contrary to what you suggest, {scene.TheChaosCausedByTheEnemy.WordText} indicates we need to be more proactive.",
                scene => $"While {scene.ActionThatContributesToTheMission.WordText} sounds appealing, it doesn't align with {scene.TheIdealStrategyForTheMission.WordText}.",
                scene => $"I'm wary of that approach. Past events, like {scene.ARelatedNegativePastEvent.WordText}, have shown it's not effective.",
                scene => $"Opting for {scene.ActionThatDetractsFromTheMission.WordText} ignores the lessons learned from {scene.ARelatedNegativePastEvent.WordText}. Let's not repeat our past mistakes."
            };
            this.expositions.Add(SentencePurposeType.RefuteAnArgument, refuteAnArgument);

            var describeASituation = new List<Func<Scene, string>>
            {
                scene => $"The situation is {scene.StatusOfTheMission.WordText}.",
                scene => $"As dawn breaks over {scene.LocationOfTheMission.WordText}, the air is thick with {scene.TheMainCauseOfTheProblem.WordText}.",
                scene => $"In the heart of {scene.LocationOfTheMission.WordText}, {scene.TheEnemy.WordText} lurk, casting a shadow of {scene.TheChaosCausedByTheEnemy.WordText}.",
                scene => $"The {scene.TimeOfDay.WordText} finds us with {scene.TheImmediateEffectsOfTheProblem.WordText}, a testament to the urgency of our mission.",
                scene => $"At this crucial juncture, {scene.TheMentalStateOfTheEnemy.WordText} could tilt the scales in our ongoing struggle.",
                scene => $"Our base at {scene.ASaferLocation.WordText} remains a beacon of hope, despite the looming threat of {scene.AnImmediateDangerToTheMission.WordText}.",
                scene => $"With {scene.TheTimeLeftToCompleteTheMission.WordText} dwindling, every second becomes a race against {scene.AnObstacleToTheMission.WordText}.",
                scene => $"The {scene.StatusOfTheObstacleToTheMission.WordText} poses a formidable challenge, yet our resolve remains unshaken.",
                scene => $"Amidst the turmoil, the {scene.ProtagonistsForTheMission.WordText} stand as pillars of strength, driven by {scene.TheGoalOfTheMission.WordText}.",
                scene => $"The echo of {scene.TheSoundOfTheEnemy.WordText} serves as a grim reminder of what's at stake: {scene.WhatHingesOnTheSuccessOfTheMission.WordText}.",
                scene => $"As {scene.TimeOfDay.WordText} turns to night, {scene.LocationOfTheMission.WordText} transforms, revealing {scene.TheMysteryUnfolding.WordText}.",
                scene => $"The narrative of {scene.TheBeforeAndAfter.WordText} encapsulates the journey thus far, a blend of hope and despair.",
                scene => $"The presence of {scene.TheUnsungHeroes.WordText} amidst us underscores the complexity of our endeavor and the hidden strengths we possess.",
                scene => $"Looking forward, {scene.TheIdealFutureStateOfTheMission.WordText} remains our guiding light, a vision we're determined to realize.",
                scene => $"In the shadows, {scene.ATraitorInTheRanks.WordText} looms as a stark reminder that not all battles are fought on the outside."
            };
            this.expositions.Add(SentencePurposeType.DescribeASituation, describeASituation);

            var narrateAnEvent = new List<Func<Scene, string>>
            {
                scene => $"The {scene.TimeOfDay.WordText} began with {scene.TheSoundOfTheEnemy.WordText}, a harbinger of {scene.TheMainCauseOfTheProblem.WordText}.",
                scene => $"As we ventured into {scene.LocationOfTheMission.WordText}, the {scene.TheEnemy.WordText} emerged, casting a shadow of {scene.TheChaosCausedByTheEnemy.WordText}.",
                scene => $"The {scene.TimeOfDay.WordText} found us with {scene.TheImmediateEffectsOfTheProblem.WordText}, a testament to the urgency of our mission.",
                scene => $"At this crucial juncture, {scene.TheMentalStateOfTheEnemy.WordText} could tilt the scales in our ongoing struggle.",
                scene => $"Our base at {scene.ASaferLocation.WordText} remains a beacon of hope, despite the looming threat of {scene.AnImmediateDangerToTheMission.WordText}.",
                scene => $"With {scene.TheTimeLeftToCompleteTheMission.WordText} dwindling, every second becomes a fight for survival against {scene.TheEnemy.WordText}.",
                scene => $"Under the {scene.TimeOfDay.WordText}, {scene.LocationOfTheMission.WordText} transformed into a battleground, where {scene.ProtagonistsForTheMission.WordText} clashed with {scene.TheEnemy.WordText}.",
                scene => $"The sudden appearance of {scene.AnUnexpectedAlly.WordText} at {scene.LocationOfTheMission.WordText} shifted the dynamics of the conflict, offering a glimmer of hope.",
                scene => $"As {scene.TimeOfDay.WordText} gave way to darkness, the silence was broken by {scene.TheSoundOfTheEnemy.WordText}, signaling the onset of another skirmish.",
                scene => $"In the heart of {scene.LocationOfTheMission.WordText}, amidst {scene.TheChaosCausedByTheEnemy.WordText}, stood {scene.ProtagonistsForTheMission.WordText}, undeterred and resolute.",
                scene => $"The revelation of {scene.ASecretWeapon.WordText} at the peak of the {scene.TimeOfDay.WordText} turned the tide, offering a new strategy against {scene.TheEnemy.WordText}.",
                scene => $"As the {scene.TimeOfDay.WordText} faded, {scene.TheSurvivors.WordText} gathered, recounting the day's events and the losses endured, yet hopeful for {scene.TheIdealFutureStateOfTheMission.WordText}.",
                scene => $"The discovery of {scene.ACriticalClue.WordText} within {scene.LocationOfTheMission.WordText} unveiled {scene.TheMainCauseOfTheProblem.WordText}, propelling our mission forward.",
                scene => $"The encounter with {scene.AnOverwhelmingChallenge.WordText} tested our resolve, but the unity shown by {scene.ProtagonistsForTheMission.WordText} proved stronger.",
                scene => $"In the aftermath of {scene.TheBattle.WordText}, {scene.LocationOfTheMission.WordText} lay in silence, a stark reminder of the cost of war and the fragile hope for peace."
            };
            this.expositions.Add(SentencePurposeType.NarrateAnEvent, narrateAnEvent);

            var clarifyAStatement = new List<Func<Scene, string>>
            {
                scene => $"I didn't mean to suggest that you should {scene.ActionThatDetractsFromTheMission.WordText}.",
                scene => $"Just to be clear, when I mentioned {scene.TheMainCauseOfTheProblem.WordText}, I was referring to its impact, not its origin.",
                scene => $"What I actually meant was that our focus should be on {scene.ActionThatContributesToTheMission.WordText}, rather than {scene.AnotherActionThatContributesToTheMission.WordText}.",
                scene => $"By saying '{scene.ACriticalClue.WordText}', I intended to highlight its importance for our strategy, not to undermine the {scene.TheImmediateEffectsOfTheProblem.WordText}.",
                scene => $"My comment on {scene.TheEnemyActions.WordText} was misunderstood. I meant we need to anticipate, not to directly confront them without a plan.",
                scene => $"To clarify, {scene.TheMysteryUnfolding.WordText} doesn't imply we're at a standstill. It means we're progressing, albeit in an unexpected direction.",
                scene => $"When I spoke of {scene.TheChaosCausedByTheEnemy.WordText}, it was to underscore the urgency, not to cause panic.",
                scene => $"In referencing {scene.TheLossesWeHaveSuffered.WordText}, my aim was to honor those we've lost, not to dwell on our setbacks.",
                scene => $"The term '{scene.AnUmbrellaTermThatDescribesTheNatureOfTheEnemy.WordText}' was meant to categorize our challenges, not to oversimplify the threat they pose.",
                scene => $"My mention of {scene.ASaferLocation.WordText} as our fallback was not to suggest retreat, but to emphasize it as part of our contingency planning.",
                scene => $"When I highlighted the {scene.TheIdealMentalStateForTheMission.WordText}, it was to motivate, not to imply any lack of resolve among us.",
                scene => $"Discussing {scene.TheBurdenCarriedByTheProtagonists.WordText} was meant to acknowledge our shared responsibility, not to assign blame.",
                scene => $"My reference to {scene.TheTimeLeftToCompleteTheMission.WordText} was to convey urgency, not to suggest we are running out of options.",
                scene => $"The phrase '{scene.APositiveTurnOfEvents.WordText}' was intended to boost morale, recognizing our small victories amidst challenges."
            };
            this.expositions.Add(SentencePurposeType.ClarifyAStatement, clarifyAStatement);

            var elicitInformation = new List<Func<Scene, string>>
            {
                scene => $"Can you provide more details about {scene.TheEnemy.WordText}?",
                scene => $"I need more information about {scene.TheEnemy.WordText}. What are their strengths and weaknesses?",
                scene => $"What do we know about {scene.TheEnemy.WordText}'s plans?",
                scene => $"Can anyone shed light on {scene.TheEnemy.WordText}'s recent activities?",
                scene => $"I'm looking for insights on {scene.TheEnemy.WordText}. What are their tactics?",
                scene => $"What's the status of {scene.TheEnemy.WordText}'s {scene.TheNeedsOfTheEnemy.WordText}?",
                scene => $"Can someone provide an update on {scene.TheEnemy.WordText}'s {scene.TheNeedsOfTheEnemy.WordText}?",
                scene => $"I need to understand more about {scene.TheEnemy.WordText}'s {scene.TheNeedsOfTheEnemy.WordText}. Can anyone help?",
                scene => $"What's the latest on {scene.TheEnemy.WordText}'s {scene.TheNeedsOfTheEnemy.WordText}? We need to be prepared.",
                scene => $"Can anyone share information about {scene.TheEnemy.WordText}'s {scene.TheNeedsOfTheEnemy.WordText}? It could be crucial to our strategy.",
                scene => $"I'm trying to gauge {scene.TheEnemy.WordText}'s {scene.TheNeedsOfTheEnemy.WordText}. Can anyone provide more details?",
                scene => $"What's the current status of {scene.TheEnemy.WordText}'s {scene.TheNeedsOfTheEnemy.WordText}? We need to be ready for anything.",
                scene => $"I need to know more about {scene.TheEnemy.WordText}'s {scene.TheNeedsOfTheEnemy.WordText}. Can anyone fill me in?",
                scene => $"Can someone update me on {scene.TheEnemy.WordText}'s {scene.TheNeedsOfTheEnemy.WordText}? It could be a game-changer for our mission.",
                scene => $"What's the latest on {scene.TheEnemy.WordText}'s {scene.TheNeedsOfTheEnemy.WordText}? We need to be prepared for any surprises.",
                scene => $"I'm looking for more information about {scene.TheEnemy.WordText}'s {scene.TheNeedsOfTheEnemy.WordText}. Can anyone provide details?",
                scene => $"Can anyone share insights on {scene.TheEnemy.WordText}'s {scene.TheNeedsOfTheEnemy.WordText}? It could be crucial to our strategy.",
            };
            this.expositions.Add(SentencePurposeType.ElicitInformation, elicitInformation);

            var showSympathy = new List<Func<Scene, string>>
            {
                scene => $"I'm sorry to hear that.",
                scene => $"I hope things get better soon.",
                scene => $"It must be really tough to deal with {scene.TheMainCauseOfTheProblem.WordText}.",
                scene => $"My thoughts are with {scene.VictimsOfTheEnemy.WordText} during this challenging time.",
                scene => $"It's heartbreaking to see the impact of {scene.TheChaosCausedByTheEnemy.WordText} on {scene.LocationOfTheMission.WordText}.",
                scene => $"I can only imagine how difficult this must be for you and {scene.FriendsOfTheProtagonists.WordText}.",
                scene => $"We're all here for you, especially in light of {scene.TheImmediateEffectsOfTheProblem.WordText}.",
                scene => $"This situation with {scene.AnEnemyOfTheMission.WordText} is truly distressing. I'm here if you need to talk.",
                scene => $"Seeing the struggle against {scene.TheEnemy.WordText} has been tough on all of us.",
                scene => $"Your strength in facing {scene.TheMentalStateOfTheEnemy.WordText} is admirable. I'm truly sorry for the challenges you're facing.",
                scene => $"The loss of {scene.TheLossesWeHaveSuffered.WordText} weighs heavily on us all. Your feelings are completely valid.",
                scene => $"I wish I could do more to ease the pain caused by {scene.AnImmediateDangerToTheMission.WordText}.",
                scene => $"Hearing about {scene.TheInjusticeFaced.WordText} is deeply upsetting. How can I support you during this time?",
                scene => $"The courage of {scene.TheSurvivors.WordText} in the face of {scene.TheEnemyActions.WordText} is inspiring, yet I know it's not easy.",
                scene => $"I can't begin to understand the burden of {scene.TheBurdenCarriedByTheProtagonists.WordText}, but I'm here to help in any way I can."
            };
            this.expositions.Add(SentencePurposeType.ShowSympathy, showSympathy);

            var acceptAChallenge = new List<Func<Scene, string>>
            {
                scene => $"We're up for it.",
                scene => $"We're up for it. We won't let {scene.AnEnemyOfTheMission.WordText} win.",
                scene => $"Challenge accepted. {scene.TheGoalOfTheMission.WordText} is too important to give up now.",
                scene => $"Let {scene.AnEnemyOfTheMission.WordText} come. We're ready for them, more united and determined than ever.",
                scene => $"This is our moment. Facing {scene.AnImmediateDangerToTheMission.WordText} head-on is our only option.",
                scene => $"We see the hurdle. We know the risks. Yet, we stand ready to conquer {scene.AnObstacleToTheMission.WordText}.",
                scene => $"Our resolve is stronger than any threat posed by {scene.AnEnemyOfTheMission.WordText}. We'll meet this challenge with everything we've got.",
                scene => $"The path ahead is fraught with {scene.TheChaosCausedByTheEnemy.WordText}, but we accept this challenge with open arms.",
                scene => $"Against {scene.AnImmediateDangerToTheMission.WordText}, our spirit remains unbroken. We accept, not just to survive, but to triumph.",
                scene => $"Let's turn {scene.TheImmediateEffectsOfTheProblem.WordText} into our stepping stones. Together, we accept this challenge.",
                scene => $"With {scene.TheTimeLeftToCompleteTheMission.WordText} on the clock, our choice is clear. We accept and rise to the occasion.",
                scene => $"In the face of {scene.TheChaosCausedByTheEnemy.WordText}, our answer is unanimous. We accept the challenge, determined to rewrite our fate.",
                scene => $"As {scene.TheEnemy.WordText} advances, our commitment deepens. We're not just accepting this challenge; we're embracing it.",
                scene => $"This isn't just about facing {scene.AnEnemyOfTheMission.WordText}; it's about proving to ourselves that we can overcome {scene.AnObstacleToTheMission.WordText}. We accept.",
                scene => $"With eyes wide open to {scene.AnImmediateDangerToTheMission.WordText}, we step forward. This challenge will not define us; our response will."
            };
            this.expositions.Add(SentencePurposeType.AcceptAChallenge, acceptAChallenge);

            var provideGoodNews = new List<Func<Scene, string>>
            {
                scene => $"We've made progress.",
                scene => $"We've made progress. We're one step closer to {scene.TheGoalOfTheMission.WordText}.",
                scene => $"Good news! The {scene.AnObstacleToTheMission.WordText} has been overcome, thanks to our efforts.",
                scene => $"Our strategies are paying off. {scene.TheEnemy.WordText} are retreating from {scene.LocationOfTheMission.WordText}.",
                scene => $"Remarkably, {scene.TheSoundOfTheEnemy.WordText} has quieted. We've secured a temporary peace in {scene.LocationOfTheMission.WordText}.",
                scene => $"Victory! {scene.ACriticalClue.WordText} led us to uncover {scene.TheMainCauseOfTheProblem.WordText}, shifting the tide in our favor.",
                scene => $"Cheers erupted as {scene.TheImmediateEffectsOfTheProblem.WordText} were finally reversed, marking a significant victory for us.",
                scene => $"The {scene.ASaferLocation.WordText} is now secured. We've established a strong foothold against {scene.TheEnemy.WordText}.",
                scene => $"Our collaborative efforts with {scene.AnUnexpectedAlly.WordText} have yielded fruitful results, enhancing our mission's success rate.",
                scene => $"The {scene.TheBurdenCarriedByTheProtagonists.WordText} has been lessened. Relief efforts in {scene.LocationOfTheMission.WordText} are showing positive changes.",
                scene => $"In a surprising turn of events, {scene.ATraitorInTheRanks.WordText} has been reconciled, bolstering our unity and strength.",
                scene => $"The {scene.TheHeroesOfTheStory.WordText} have gained recognition, inspiring hope and courage among {scene.ProtagonistsForTheMission.WordText}.",
                scene => $"With {scene.TheTimeLeftToCompleteTheMission.WordText} still on our side, we've managed to outpace {scene.TheEnemy.WordText} in our preparations.",
                scene => $"The discovery of {scene.APositiveTurnOfEvents.WordText} has invigorated our campaign, bringing us closer to our ultimate objective.",
                scene => $"Our latest initiative, {scene.APlanToSucceedAtMission.WordText}, has been a resounding success, exceeding all expectations."
            };
            this.expositions.Add(SentencePurposeType.ProvideGoodNews, provideGoodNews);

            var makeAnObservation = new List<Func<Scene, string>>
            {
                scene => $"It's clear that {scene.TheEnemy.WordText} are growing stronger.",
                scene => $"The {scene.TimeOfDay.WordText} has brought a new wave of {scene.TheSoundOfTheEnemy.WordText}, signaling {scene.TheEnemy.WordText}'s next move.",
                scene => $"Despite the chaos, {scene.LocationOfTheMission.WordText} remains a symbol of {scene.TheIdealFutureStateOfTheMission.WordText}.",
                scene => $"The resilience of {scene.ProtagonistsForTheMission.WordText} in the face of {scene.TheChaosCausedByTheEnemy.WordText} is truly remarkable.",
                scene => $"The silence in {scene.LocationOfTheMission.WordText} is deafening, a stark contrast to the usual {scene.TheSoundOfTheEnemy.WordText}.",
                scene => $"Observing the {scene.ThePhysicalStateOfTheProtagonists.WordText}, it's evident the toll this mission has taken on us.",
                scene => $"The {scene.TheEnemy.WordText}'s tactics have evolved; their use of {scene.AWeaponOfTheEnemy.WordText} is unlike anything we've seen before.",
                scene => $"The {scene.StatusOfTheMission.WordText} gives us a glimmer of hope, suggesting we're on the right path.",
                scene => $"You can feel the change in the air; {scene.TheTimeLeftToCompleteTheMission.WordText} is affecting everyone's morale.",
                scene => $"The {scene.TheEnemy.WordText} seem to anticipate our moves, hinting at a possible {scene.ATraitorInTheRanks.WordText} among us.",
                scene => $"The recent events at {scene.LocationOfTheMission.WordText} underscore the importance of {scene.TheGoalOfTheMission.WordText}.",
                scene => $"There's a palpable tension among {scene.ProtagonistsForTheMission.WordText}; the weight of {scene.WhatHingesOnTheSuccessOfTheMission.WordText} is undeniable.",
                scene => $"The complexity of {scene.TheMainCauseOfTheProblem.WordText} becomes more apparent with each passing {scene.TimeOfDay.WordText}.",
                scene => $"The dedication of {scene.ProtagonistsForTheMission.WordText} to {scene.TheIdealStrategyForTheMission.WordText} is unwavering, despite the odds.",
                scene => $"As {scene.TimeOfDay.WordText} shifts, so does the mood of {scene.LocationOfTheMission.WordText}, reflecting the ever-changing dynamics of our mission."
            };
            this.expositions.Add(SentencePurposeType.MakeAnObservation, makeAnObservation);

            var sarcasm = new List<Func<Scene, string>>
            {
                scene => $"Oh, great. Another {scene.AnEnemyOfTheMission.WordText} attack. Just what we needed.",
                scene => $"Sure, because what's a day without the looming threat of {scene.AnImmediateDangerToTheMission.WordText}? It keeps life interesting.",
                scene => $"Fantastic, {scene.TheChaosCausedByTheEnemy.WordText} again. Because we hadn't had enough excitement lately.",
                scene => $"Ah, {scene.TheMentalStateOfTheEnemy.WordText}. Because, of course, we needed more unpredictability in our lives.",
                scene => $"Look at that, {scene.ASaferLocation.WordText} is under threat. Well, there goes our vacation spot.",
                scene => $"Just when you thought {scene.TimeOfDay.WordText} couldn't get any better, we have {scene.TheEnemy.WordText} joining the party.",
                scene => $"Oh joy, {scene.TheImmediateEffectsOfTheProblem.WordText}. It's like the gift that keeps on giving.",
                scene => $"So, {scene.TheEnemy.WordText} decided to show up. And here I was, thinking we'd have a boring day.",
                scene => $"Wonderful, {scene.AnObstacleToTheMission.WordText} just what we needed to spice things up a bit.",
                scene => $"And there we have {scene.AWeaponOfTheEnemy.WordText}, because, obviously, what's a hero without a new challenge?",
                scene => $"Ah, the sweet sound of {scene.TheSoundOfTheEnemy.WordText} in the morning. Nothing says 'wake up' like impending doom.",
                scene => $"Brilliant, {scene.TheTimeLeftToCompleteTheMission.WordText} is running out. I love working under pressure.",
                scene => $"Oh look, {scene.TheChaosCausedByTheEnemy.WordText} has decided to escalate. Because we were getting too comfortable.",
                scene => $"Of course, {scene.ACriticalClue.WordText} was right under our noses. We're detectives on top of everything else.",
                scene => $"Here comes {scene.AnUnexpectedAlly.WordText}, to save the day. Because we were totally not handling it ourselves."
            };
            this.expositions.Add(SentencePurposeType.Sarcasm, sarcasm);

            var irony = new List<Func<Scene, string>>
            {
                scene => $"How convenient. {scene.AnEnemyOfTheMission.WordText} decided to show up just as we were getting bored.",
                scene => $"Perfect timing, as always. The {scene.TheMainCauseOfTheProblem.WordText} strikes right when we thought we had a moment's peace.",
                scene => $"Just what we needed, {scene.TheChaosCausedByTheEnemy.WordText}. It's not like we had anything better to do than save the world. Again.",
                scene => $"There's nothing like {scene.AnImmediateDangerToTheMission.WordText} to really bring the team together. Nothing bonds like mutual peril.",
                scene => $"Oh, the joy of {scene.TheTimeLeftToCompleteTheMission.WordText} ticking away. It's like the universe itself is telling us to hurry up.",
                scene => $"What a surprise, our safe haven {scene.ASaferLocation.WordText} is now a target. Because, of course, nowhere is safe.",
                scene => $"Ah, the {scene.AnObstacleToTheMission.WordText} appears right on schedule. Because what's a quest without a little extra challenge?",
                scene => $"Of course, {scene.TheSoundOfTheEnemy.WordText} is our wakeup call. Who needs alarm clocks when you have enemies?",
                scene => $"And now, {scene.AWeaponOfTheEnemy.WordText} has entered the chat. Because the situation wasn't complicated enough already.",
                scene => $"So, we're resorting to {scene.AHiddenActionOfTheProtagonists.WordText}. It's always the last resort that becomes the first choice.",
                scene => $"Ah, {scene.ThePhysicalStateOfTheProtagonists.WordText}. Nothing says 'adventure' like a few scrapes and the imminent threat of doom.",
                scene => $"Look, {scene.TheEnemy.WordText} brought friends. The more, the merrier, right? Especially when it comes to uninvited guests.",
                scene => $"Great, {scene.TheMysteryUnfolding.WordText}. Just when we thought we had all the answers, the questions changed.",
                scene => $"Here we stand, {scene.LocationOfTheMission.WordText}, the epicenter of irony. Where every solution uncovers more problems.",
                scene => $"And as the day closes, {scene.TheBeforeAndAfter.WordText} tells us everything and nothing. For every victory, a new challenge waits."
            };
            this.expositions.Add(SentencePurposeType.Irony, irony);

            var engageInSmallTalk = new List<Func<Scene, string>>
            {
                scene => $"How are you holding up?",
                scene => $"What's the latest on {scene.TheEnemy.WordText}?",
                scene => $"How's everyone doing? It's been a long day.",
                scene => $"What's the plan for {scene.TimeOfDay.WordText}? Any updates on our strategy?",
                scene => $"How's the {scene.StatusOfTheMainCauseOfTheProblem.WordText} looking? Any progress?",
                scene => $"Seen anything interesting at {scene.LocationOfTheMission.WordText} lately?",
                scene => $"How do you feel about {scene.TheGoalOfTheMission.WordText}? Think we're getting close?",
                scene => $"Any word from {scene.FriendsOfTheProtagonists.WordText}? Must be busy with the mission.",
                scene => $"Did you hear about {scene.AnUnexpectedEvent.WordText}? Can't believe it happened.",
                scene => $"What do you think of {scene.TheIdealStrategyForTheMission.WordText}? Any concerns?",
                scene => $"Heard any good news about {scene.APositiveTurnOfEvents.WordText}? We could use some.",
                scene => $"Any updates on {scene.TheSurvivors.WordText}? Must be tough for them.",
                scene => $"How's {scene.ThePhysicalStateOfTheProtagonists.WordText} holding up? This is quite the ordeal.",
                scene => $"Got any plans after we wrap up {scene.TheMissionObjective.WordText}? Looking forward to anything?",
                scene => $"How do you unwind after a day like today? Got any tips?",
                scene => $"Ever wonder what {scene.TheEnemy.WordText} are up to when they're not causing trouble?",
                scene => $"Do you think {scene.TheMysteryUnfolding.WordText} will ever get solved? It's all so bizarre.",
                scene => $"What's your take on {scene.TheBeforeAndAfter.WordText}? Feels like everything's changed.",
                scene => $"You've been quiet. What's on your mind about {scene.TheCurrentSituation.WordText}?",
                scene => $"How do you keep up with {scene.TheUnknownFactors.WordText}? Seems like a lot to track."
            };
            this.expositions.Add(SentencePurposeType.EngageInSmallTalk, engageInSmallTalk);

            var inspireACrowd = new List<Func<Scene, string>>
            {
                scene => $"We've come too far to give up now.",
                scene => $"We've come too far to give up now. We're closer to {scene.TheGoalOfTheMission.WordText} than ever before.",
                scene => $"Remember, we're not just fighting for ourselves. We're fighting for {scene.WhatHingesOnTheSuccessOfTheMission.WordText}.",
                scene => $"We've faced worse odds and emerged victorious. This is just another challenge to overcome.",
                scene => $"The strength of our unity is our greatest weapon against {scene.AnEnemyOfTheMission.WordText}. Let's show them what we're made of.",
                scene => $"We've faced {scene.TheEnemy.WordText} before, and we've always emerged stronger. This time will be no different.",
                scene => $"The journey has been long, but we're closer to {scene.TheIdealFutureStateOfTheMission.WordText} than ever before. Let's not lose hope now.",
                scene => $"The sacrifices we've made have brought us to this moment. Let's honor them by seeing this mission through to the end.",
                scene => $"We've been through so much together. Let's draw strength from our shared experiences and push forward.",
                scene => $"The road ahead is tough, but we've faced tougher challenges. We're ready to take on whatever comes our way.",
                scene => $"The courage we've shown in the face of {scene.TheChaosCausedByTheEnemy.WordText} is a testament to our resilience. Let's keep that spirit alive.",
                scene => $"The future we're fighting for is within our grasp. Let's not falter now, when we're so close to {scene.TheGoalOfTheMission.WordText}.",
                scene => $"The hope we carry in our hearts is our greatest strength. Let's hold onto it and press on, no matter what {scene.AnObstacleToTheMission.WordText} we face.",
                scene => $"The journey has been long and arduous, but we're still standing. Let's use that strength to keep moving forward.",
                scene => $"The challenges we face are daunting, but so is our determination. Let's use that determination to overcome every obstacle in our path.",
                scene => $"The spirit of resilience that has brought us this far will carry us through to the end. Let's keep that"
            };
            this.expositions.Add(SentencePurposeType.InspireACrowd, inspireACrowd);

            var changeTheTopic = new List<Func<Scene, string>>
            {
                scene => $"Let's shift our focus to {scene.ActionThatContributesToTheMission.WordText}.",
                scene => $"I think we should discuss {scene.TheIdealStrategyForTheMission.WordText} next.",
                scene => $"We've covered {scene.TheEnemy.WordText} enough. Let's talk about {scene.TheGoalOfTheMission.WordText} instead.",
                scene => $"I'd like to change the topic to {scene.TheIdealFutureStateOfTheMission.WordText}. It's crucial to our mission.",
                scene => $"I think we need to shift our attention to {scene.TheNeedsOfTheEnemy.WordText}. It's a key aspect of our strategy.",
                scene => $"Let's move on to {scene.TheEnemyActions.WordText}. We need to understand their tactics better.",
                scene => $"I'd like to steer the conversation toward {scene.TheImmediateEffectsOfTheProblem.WordText}. It's a pressing issue we need to address.",
                scene => $"I think we should change the topic to {scene.TheMainCauseOfTheProblem.WordText}. It's the root of our challenges.",
                scene => $"We've discussed {scene.TheEnemy.WordText} at length. Let's talk about {scene.TheIdealFutureStateOfTheMission.WordText} instead.",
                scene => $"I'd like to shift our focus to {scene.TheGoalOfTheMission.WordText}. It's the reason we're all here.",
                scene => $"I think we need to change the topic to {scene.TheIdealStrategyForTheMission.WordText}. It's a critical part of our plan.",
                scene => $"Let's move on to {scene.TheEnemyActions.WordText}. We need to understand their tactics better.",
                scene => $"I'd like to steer the conversation toward {scene.TheImmediateEffectsOfTheProblem.WordText}. It's a pressing issue we need to address.",
                scene => $"I think we should change the topic to {scene.TheMainCauseOfTheProblem.WordText}. It's the root of our challenges.",
                scene => $"We've discussed {scene.TheEnemy.WordText} at length. Let's talk about {scene.TheIdealFutureStateOfTheMission.WordText} instead.",
                scene => $"I'd like to shift our focus to {scene.TheGoalOfTheMission.WordText}. It's the reason we're all here.",
            };
            this.expositions.Add(SentencePurposeType.ChangeTheTopic, changeTheTopic);

            var praise = new List<Func<Scene, string>>
            {
                scene => $"I'm impressed by your dedication to {scene.TheIdealStrategyForTheMission.WordText}.",
                scene => $"Your insights into {scene.TheEnemy.WordText}'s tactics have been invaluable.",
                scene => $"Your leadership in the face of {scene.TheChaosCausedByTheEnemy.WordText} has been inspiring.",
                scene => $"Your resilience in the wake of {scene.TheImmediateEffectsOfTheProblem.WordText} is truly commendable.",
                scene => $"Your commitment to {scene.TheGoalOfTheMission.WordText} has been unwavering.",
                scene => $"Your resourcefulness in dealing with {scene.TheMainCauseOfTheProblem.WordText} has been remarkable.",
                scene => $"Your courage in the fight against {scene.AnEnemyOfTheMission.WordText} has been exemplary.",
                scene => $"Your strategic thinking in the midst of {scene.AnObstacleToTheMission.WordText} has been impressive.",
                scene => $"Your compassion for {scene.VictimsOfTheEnemy.WordText} has not gone unnoticed.",
                scene => $"Your dedication to {scene.TheIdealFutureStateOfTheMission.WordText} has been a driving force for us all.",
                scene => $"Your ability to navigate {scene.TheMysteryUnfolding.WordText} has been invaluable to our mission.",
                scene => $"Your quick thinking in the face of {scene.TheEnemyActions.WordText} has been crucial to our survival.",
                scene => $"Your unwavering support for {scene.TheSurvivors.WordText} has been a source of strength for us all.",
                scene => $"Your optimism in the face of {scene.TheBeforeAndAfter.WordText} has been a guiding light for us.",
                scene => $"Your dedication to {scene.TheIdealStrategyForTheMission.WordText} has been a driving force for us all.",
                scene => $"Your ability to navigate {scene.TheMysteryUnfolding.WordText} has been invaluable to our mission.",
                scene => $"Your quick thinking in the face of {scene.TheEnemyActions.WordText} has been crucial to our survival.",
                scene => $"Your unwavering support for {scene.TheSurvivors.WordText} has been a source of strength for us all.",
                scene => $"Your optimism in the face of {scene.TheBeforeAndAfter.WordText} has been a guiding light for us."
            };
            this.expositions.Add(SentencePurposeType.Praise, praise);

            var criticize = new List<Func<Scene, string>>
            {
                scene => $"I'm concerned about the impact of {scene.TheEnemy.WordText}'s actions on our mission.",
                scene => $"We need to address the shortcomings in our approach to {scene.TheIdealStrategyForTheMission.WordText}.",
                scene => $"I'm disappointed by the lack of progress in dealing with {scene.TheMainCauseOfTheProblem.WordText}.",
                scene => $"We can't afford to ignore the consequences of {scene.TheImmediateEffectsOfTheProblem.WordText}.",
                scene => $"We need to reevaluate our response to {scene.AnEnemyOfTheMission.WordText}'s tactics.",
                scene => $"I'm troubled by the lack of preparation for {scene.AnObstacleToTheMission.WordText}.",
                scene => $"We need to acknowledge the flaws in our handling of {scene.TheMysteryUnfolding.WordText}.",
                scene => $"I'm concerned about the impact of {scene.TheEnemy.WordText}'s actions on our mission.",
                scene => $"We need to address the shortcomings in our approach to {scene.TheIdealStrategyForTheMission.WordText}.",
                scene => $"I'm disappointed by the lack of progress in dealing with {scene.TheMainCauseOfTheProblem.WordText}.",
                scene => $"We can't afford to ignore the consequences of {scene.TheImmediateEffectsOfTheProblem.WordText}.",
                scene => $"We need to reevaluate our response to {scene.AnEnemyOfTheMission.WordText}'s tactics.",
                scene => $"I'm troubled by the lack of preparation for {scene.AnObstacleToTheMission.WordText}.",
                scene => $"We need to acknowledge the flaws in our handling of {scene.TheMysteryUnfolding.WordText}.",
                scene => $"I'm concerned about the impact of {scene.TheEnemy.WordText}'s actions on our mission.",
                scene => $"We need to address the shortcomings in our approach to {scene.TheIdealStrategyForTheMission.WordText}.",
                scene => $"I'm disappointed by the lack of progress in dealing with {scene.TheMainCauseOfTheProblem.WordText}.",
                scene => $"We can't afford to ignore the consequences of {scene.TheImmediateEffectsOfTheProblem.WordText}.",
                scene => $"We need to reevaluate our response to {scene.AnEnemyOfTheMission.WordText}'s tactics.",
            };
            this.expositions.Add(SentencePurposeType.Criticize, criticize);

            var acceptResponsibility = new List<Func<Scene, string>>
            {
                scene => $"I take full responsibility for the oversight in our approach to {scene.TheIdealStrategyForTheMission.WordText}.",
                scene => $"I acknowledge my role in the lack of progress in dealing with {scene.TheMainCauseOfTheProblem.WordText}.",
                scene => $"I'm aware of the impact of my actions on the consequences of {scene.TheImmediateEffectsOfTheProblem.WordText}.",
                scene => $"I recognize my part in the flaws in our handling of {scene.TheMysteryUnfolding.WordText}.",
                scene => $"I take full responsibility for the oversight in our approach to {scene.TheIdealStrategyForTheMission.WordText}.",
                scene => $"I acknowledge my role in the lack of progress in dealing with {scene.TheMainCauseOfTheProblem.WordText}.",
                scene => $"I'm aware of the impact of my actions on the consequences of {scene.TheImmediateEffectsOfTheProblem.WordText}.",
                scene => $"I recognize my part in the flaws in our handling of {scene.TheMysteryUnfolding.WordText}.",
                scene => $"I take full responsibility for the oversight in our approach to {scene.TheIdealStrategyForTheMission.WordText}.",
                scene => $"I acknowledge my role in the lack of progress in dealing with {scene.TheMainCauseOfTheProblem.WordText}.",
                scene => $"I'm aware of the impact of my actions on the consequences of {scene.TheImmediateEffectsOfTheProblem.WordText}.",
                scene => $"I recognize my part in the flaws in our handling of {scene.TheMysteryUnfolding.WordText}.",
                scene => $"I take full responsibility for the oversight in our approach to {scene.TheIdealStrategyForTheMission.WordText}.",
                scene => $"I acknowledge my role in the lack of progress in dealing with {scene.TheMainCauseOfTheProblem.WordText}.",
                scene => $"I'm aware of the impact of my actions on the consequences of {scene.TheImmediateEffectsOfTheProblem.WordText}.",
                scene => $"I recognize my part in the flaws in our handling of {scene.TheMysteryUnfolding.WordText}.",
                scene => $"I take full responsibility for the oversight in our approach to {scene.TheIdealStrategyForTheMission.WordText}.",
                scene => $"I acknowledge my role in the lack of progress in dealing with {scene.TheEnemy.WordText}."
            };
            this.expositions.Add(SentencePurposeType.AcceptResponsibility, acceptResponsibility);

            var conveyAppreciation = new List<Func<Scene, string>>
            {
                scene => $"I appreciate your dedication to {scene.TheIdealStrategyForTheMission.WordText}.",
                scene => $"Your insights into {scene.TheEnemy.WordText}'s tactics have been invaluable.",
                scene => $"Your leadership in the face of {scene.TheChaosCausedByTheEnemy.WordText} has been inspiring.",
                scene => $"Your resilience in the wake of {scene.TheImmediateEffectsOfTheProblem.WordText} is truly commendable.",
                scene => $"Your commitment to {scene.TheGoalOfTheMission.WordText} has been unwavering.",
                scene => $"Your resourcefulness in dealing with {scene.TheMainCauseOfTheProblem.WordText} has been remarkable.",
                scene => $"Your courage in the fight against {scene.AnEnemyOfTheMission.WordText} has been exemplary.",
                scene => $"Your strategic thinking in the midst of {scene.AnObstacleToTheMission.WordText} has been impressive.",
                scene => $"Your compassion for {scene.VictimsOfTheEnemy.WordText} has not gone unnoticed.",
                scene => $"Your dedication to {scene.TheIdealFutureStateOfTheMission.WordText} has been a driving force for us all.",
                scene => $"Your ability to navigate {scene.TheMysteryUnfolding.WordText} has been invaluable to our mission.",
                scene => $"Your quick thinking in the face of {scene.TheEnemyActions.WordText} has been crucial to our survival.",
                scene => $"Your unwavering support for {scene.TheSurvivors.WordText} has been a source of strength for us all.",
                scene => $"Your optimism in the face of {scene.TheBeforeAndAfter.WordText} has been a guiding light for us.",
                scene => $"Your dedication to {scene.TheIdealStrategyForTheMission.WordText} has been a driving force for us all.",
                scene => $"Your ability to navigate {scene.TheMysteryUnfolding.WordText} has been invaluable to our mission.",
                scene => $"Your quick thinking in the face of {scene.TheEnemyActions.WordText} has been crucial to our survival.",
                scene => $"Your unwavering support for {scene.TheSurvivors.WordText} has been a source of strength for us all.",
                scene => $"Your optimism in the face of {scene.TheBeforeAndAfter.WordText} has been a guiding light for us."
            };
            this.expositions.Add(SentencePurposeType.ConveyAppreciation, conveyAppreciation);

            var conveyRespect = new List<Func<Scene, string>>
            {
                scene => $"I respect your dedication to {scene.TheIdealStrategyForTheMission.WordText}.",
                scene => $"Your courage at {scene.LocationOfTheMission.WordText} has earned you the highest esteem among {scene.ProtagonistsForTheMission.WordText}.",
                scene => $"The wisdom you've shown in dealing with {scene.TheMainCauseOfTheProblem.WordText} commands respect from us all.",
                scene => $"I've never seen anyone handle {scene.AnObstacleToTheMission.WordText} with such grace and effectiveness.",
                scene => $"Your ability to remain calm in the face of {scene.AnImmediateDangerToTheMission.WordText} is truly admirable.",
                scene => $"The respect I have for your leadership, especially during {scene.TheTimeLeftToCompleteTheMission.WordText}, knows no bounds.",
                scene => $"Your insights into {scene.TheEnemy.WordText}'s tactics have been invaluable and have earned my deep respect.",
                scene => $"Navigating the challenges of {scene.LocationOfTheMission.WordText} with such determination is worthy of the highest respect.",
                scene => $"The compassion you've shown for {scene.VictimsOfTheEnemy.WordText} reflects the depth of your character.",
                scene => $"Your relentless pursuit of {scene.TheGoalOfTheMission.WordText} despite {scene.TheChaosCausedByTheEnemy.WordText} is commendable.",
                scene => $"I respect how you've always prioritized {scene.APriorityForTheMission.WordText} above personal gain.",
                scene => $"Your mentorship has shaped many among {scene.ProtagonistsForTheMission.WordText}, a testament to your wisdom and patience.",
                scene => $"Your tactical genius in orchestrating {scene.APlanToSucceedAtMission.WordText} has not gone unnoticed.",
                scene => $"For your sacrifices and unwavering commitment to {scene.TheIdealFutureStateOfTheMission.WordText}, you have my utmost respect.",
                scene => $"The way you rallied {scene.FriendsOfTheProtagonists.WordText} in our darkest hour was nothing short of inspiring."
            };
            this.expositions.Add(SentencePurposeType.ConveyRespect, conveyRespect);


            var provokeThought = new List<Func<Scene, string>>
            {
                scene => $"Considering the analysis, we should start by {scene.APlanToSucceedAtMission.WordText}. This could help us mitigate {scene.AnObstacleToTheMission.WordText} effectively.",
                scene => $"To avoid a repeat of {scene.ARelatedNegativePastEvent.WordText}, let's focus on {scene.ASuccessFactorOfTheMission.WordText}. Implementing this strategy could significantly improve our chances of success.",
                scene => $"Given the assessment, it might be beneficial to {scene.AnActionThatContributesToSafety.WordText} to ensure the safety of our team during the mission.",
                scene => $"The correlation between {scene.TheImmediateEffectsOfTheProblem.WordText} and {scene.TheChaosCausedByTheEnemy.WordText} suggests that we should consider {scene.PossibleSolutionToConsider.WordText} to address this issue proactively.",
                scene => $"Taking into account the analysis, we should prioritize {scene.StatusOfTheMainCauseOfTheProblem.WordText}. This will likely lead to more efficient mission progress.",
                scene => $"The evaluation of {scene.TheMentalStateOfTheEnemy.WordText} points to the need for a diplomatic approach. Let's explore options for negotiations or alliances.",
                scene => $"Based on historical patterns, such as {scene.APastEventMirroringTheCurrentMission.WordText}, we could learn from past mistakes and implement {scene.AnAlternativeStrategy.WordText} for a better outcome.",
                scene => $"The analysis highlights the importance of {scene.ASuccessFactorOfTheMission.WordText}. Let's develop a detailed plan to maximize its impact on our mission's success.",
                scene => $"Considering the current situation, it's essential to {scene.ActionThatContributesToTheMission.WordText} and {scene.ActionThatDetractsFromTheMission.WordText} simultaneously. This balance will be key to our progress.",
                scene => $"What if we approached {scene.TheIdealStrategyForTheMission.WordText} from a different angle?",
                scene => $"Have we considered the long-term implications of {scene.TheMainCauseOfTheProblem.WordText}?",
                scene => $"How can we address the root cause of {scene.TheImmediateEffectsOfTheProblem.WordText}?",
                scene => $"What if we explored the connection between {scene.TheEnemy.WordText}'s actions and {scene.TheChaosCausedByTheEnemy.WordText}?",
                scene => $"Is there a correlation between {scene.TheEnemy.WordText}'s tactics and {scene.TheNeedsOfTheEnemy.WordText}?",
                scene => $"What if we reevaluated our response to {scene.AnEnemyOfTheMission.WordText}'s tactics?",
                scene => $"Have we considered the long-term implications of {scene.TheMainCauseOfTheProblem.WordText}?",
                scene => $"How can we address the root cause of {scene.TheImmediateEffectsOfTheProblem.WordText}?",
                scene => $"What if we explored the connection between {scene.TheEnemy.WordText}'s actions and {scene.TheChaosCausedByTheEnemy.WordText}?",
                scene => $"Is there a correlation between {scene.TheEnemy.WordText}'s tactics and {scene.TheNeedsOfTheEnemy.WordText}?",
                scene => $"What if we reevaluated our response to {scene.AnEnemyOfTheMission.WordText}'s tactics?",
                scene => $"Have we considered the long-term implications of {scene.TheMainCauseOfTheProblem.WordText}?",
                scene => $"How can we address the root cause of {scene.TheImmediateEffectsOfTheProblem.WordText}?",
                scene => $"What if we explored the connection between {scene.TheEnemy.WordText}'s actions and {scene.TheChaosCausedByTheEnemy.WordText}?",
                scene => $"Is there a correlation between {scene.TheEnemy.WordText}'s tactics and {scene.TheNeedsOfTheEnemy.WordText}?",
                scene => $"What if we reevaluated our response to {scene.AnEnemyOfTheMission.WordText}'s tactics?",
                scene => $"Have we considered the long-term implications of {scene.TheMainCauseOfTheProblem.WordText}?",
                scene => $"How can we address the root cause of {scene.TheImmediateEffectsOfTheProblem.WordText}?",
            };
            this.expositions.Add(SentencePurposeType.ProvokeThoughtOrProposeIdea, provokeThought);

            var rejectAnIdea = new List<Func<Scene, string>>
            {
                scene => $"I'm not convinced that {scene.ActionThatDetractsFromTheMission.WordText} is the best course of action.",
                scene => $"I'm hesitant to support {scene.ActionThatDetractsFromTheMission.WordText} without further analysis.",
                scene => $"I have reservations about the potential risks of {scene.ActionThatDetractsFromTheMission.WordText}.",
                scene => $"Considering {scene.TheMainCauseOfTheProblem.WordText}, I doubt {scene.ActionThatDetractsFromTheMission.WordText} will lead us to success.",
                scene => $"Given the urgency of {scene.TheTimeLeftToCompleteTheMission.WordText}, {scene.ActionThatDetractsFromTheMission.WordText} seems like a distraction.",
                scene => $"{scene.ActionThatDetractsFromTheMission.WordText} contradicts our objective of {scene.TheGoalOfTheMission.WordText}. We should reconsider.",
                scene => $"In light of {scene.TheImmediateEffectsOfTheProblem.WordText}, pursuing {scene.ActionThatDetractsFromTheMission.WordText} could be detrimental.",
                scene => $"From my perspective, {scene.ActionThatDetractsFromTheMission.WordText} doesn't align with {scene.TheIdealStrategyForTheMission.WordText}.",
                scene => $"Given what's at stake with {scene.WhatHingesOnTheSuccessOfTheMission.WordText}, can we afford the risk of {scene.ActionThatDetractsFromTheMission.WordText}?",
                scene => $"{scene.ActionThatDetractsFromTheMission.WordText} might backfire, considering {scene.TheChaosCausedByTheEnemy.WordText}. We need a safer approach.",
                scene => $"Are we ignoring {scene.TheIdealFutureStateOfTheMission.WordText} by considering {scene.ActionThatDetractsFromTheMission.WordText}? It seems counterproductive.",
                scene => $"The potential for {scene.TheChaosCausedByTheEnemy.WordText} makes {scene.ActionThatDetractsFromTheMission.WordText} a risky gamble.",
                scene => $"Reflecting on {scene.ARelatedNegativePastEvent.WordText}, it's clear that {scene.ActionThatDetractsFromTheMission.WordText} could repeat past mistakes.",
                scene => $"{scene.ActionThatDetractsFromTheMission.WordText} overlooks the crucial factor of {scene.ACriticalClue.WordText}, which could lead us astray.",
                scene => $"Considering the complexity of {scene.TheMainCauseOfTheProblem.WordText}, jumping to {scene.ActionThatDetractsFromTheMission.WordText} seems premature."
            };
            this.expositions.Add(SentencePurposeType.RejectAnIdea, rejectAnIdea);

            var expressConfusion = new List<Func<Scene, string>>
            {
                scene => $"I'm not sure I understand the connection between {scene.TheEnemy.WordText}'s actions and {scene.TheChaosCausedByTheEnemy.WordText}.",
                scene => $"I'm having trouble grasping the implications of {scene.TheMainCauseOfTheProblem.WordText} on our mission.",
                scene => $"I'm struggling to see how {scene.TheImmediateEffectsOfTheProblem.WordText} will impact our strategy.",
                scene => $"I'm finding it hard to make sense of the relationship between {scene.TheEnemy.WordText}'s tactics and {scene.TheNeedsOfTheEnemy.WordText}.",
                scene => $"How does {scene.TheGoalOfTheMission.WordText} align with {scene.TheImmediateEffectsOfTheProblem.WordText}? It's puzzling.",
                scene => $"The strategy involving {scene.ACriticalClue.WordText} is baffling. How does it fit into our overall plan?",
                scene => $"I can't wrap my head around {scene.TheMysteryUnfolding.WordText}. What are we missing?",
                scene => $"The role of {scene.AnUnexpectedAlly.WordText} in this scenario is unclear. What's their endgame?",
                scene => $"Why would {scene.TheEnemy.WordText} choose now to {scene.TheEnemyActions.WordText}? It doesn't add up.",
                scene => $"The significance of {scene.TheBeforeAndAfter.WordText} escapes me. How does it change our perspective?"
            };
            this.expositions.Add(SentencePurposeType.ExpressConfusion, expressConfusion);

            var expressDisbelief = new List<Func<Scene, string>>
            {
                scene => $"I can't believe {scene.TheEnemy.WordText} would resort to such tactics.",
                scene => $"I'm shocked by the extent of {scene.TheChaosCausedByTheEnemy.WordText}.",
                scene => $"I'm astonished by the audacity of {scene.AnEnemyOfTheMission.WordText}.",
                scene => $"I'm appalled by the severity of {scene.TheImmediateEffectsOfTheProblem.WordText}.",
                scene => $"I'm taken aback by the scale of {scene.TheMainCauseOfTheProblem.WordText}.",
                scene => $"I'm stunned by the magnitude of {scene.TheEnemyActions.WordText}.",
                scene => $"I'm amazed by the resilience of {scene.ProtagonistsForTheMission.WordText} in the face of {scene.AnObstacleToTheMission.WordText}.",
                scene => $"I'm surprised by the complexity of {scene.TheMysteryUnfolding.WordText}.",
                scene => $"To think {scene.TheEnemy.WordText} had the foresight to {scene.TheEnemyActions.WordText}, it's beyond belief.",
                scene => $"That {scene.ASaferLocation.WordText} could be compromised by {scene.AnImmediateDangerToTheMission.WordText}, I never saw it coming.",
                scene => $"The sudden turn of events with {scene.ATraitorInTheRanks.WordText} is hard to digest. How could they?",
                scene => $"The idea that {scene.TheLossesWeHaveSuffered.WordText} could have been prevented is too much to bear.",
                scene => $"I'm bewildered by how quickly {scene.TheCurrentSituation.WordText} has escalated. It seemed unthinkable before."
            };
            this.expositions.Add(SentencePurposeType.ExpressDisbelief, expressDisbelief);

        }
    }
}
