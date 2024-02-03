﻿namespace NaturalLanguageProcess
{
    public class ExpositionCollection
    {
        private Dictionary<SentencePurposeType, List<Func<Scene, string>>> expositions;
        private Dictionary<SentencePurposeType, List<Func<MagicalScene, string>>> magicalExpositions;
        private Dictionary<SentencePurposeType, List<Func<Scene, Character, string>>> characterExpositions;
        private List<(SentencePurposeType, SentencePurposeType)> purposePairs;

        public Dictionary<SentencePurposeType, List<Func<Scene, string>>> Expositions { get => expositions; }
        public Dictionary<SentencePurposeType, List<Func<MagicalScene, string>>> MagicalExpositions { get => magicalExpositions; }
        public Dictionary<SentencePurposeType, List<Func<Scene, Character, string>>> CharacterExpositions { get => characterExpositions; }
        public List<(SentencePurposeType, SentencePurposeType)> PurposePairs { get => purposePairs; }

        public ExpositionCollection()
        {
            expositions = new Dictionary<SentencePurposeType, List<Func<Scene, string>>>();
            magicalExpositions = new Dictionary<SentencePurposeType, List<Func<MagicalScene, string>>>();
            characterExpositions = new Dictionary<SentencePurposeType, List<Func<Scene, Character, string>>>();
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
            purposePairs.Add((SentencePurposeType.ProvideInformation, SentencePurposeType.Hypothesize));
            purposePairs.Add((SentencePurposeType.ProvideInformation, SentencePurposeType.Irony));
            purposePairs.Add((SentencePurposeType.ProvideInformation, SentencePurposeType.Sarcasm));
            purposePairs.Add((SentencePurposeType.ProvideInformation, SentencePurposeType.InternalDialogue));
            purposePairs.Add((SentencePurposeType.OfferOpinion, SentencePurposeType.Motivate));
            purposePairs.Add((SentencePurposeType.OfferOpinion, SentencePurposeType.ExpressAgreement));
            purposePairs.Add((SentencePurposeType.OfferOpinion, SentencePurposeType.Criticize));
            purposePairs.Add((SentencePurposeType.Motivate, SentencePurposeType.ExpressUncertainty));
            purposePairs.Add((SentencePurposeType.Motivate, SentencePurposeType.ExpressDedication));
            purposePairs.Add((SentencePurposeType.ExpressUncertainty, SentencePurposeType.Reassure));
            purposePairs.Add((SentencePurposeType.Reassure, SentencePurposeType.AcceptAChallenge));
            purposePairs.Add((SentencePurposeType.Reassure, SentencePurposeType.ProvideInformation));
            purposePairs.Add((SentencePurposeType.AcceptAChallenge, SentencePurposeType.ExpressSolidarity));
            purposePairs.Add((SentencePurposeType.GiveADirective, SentencePurposeType.ExpressConcern));
            purposePairs.Add((SentencePurposeType.GiveADirective, SentencePurposeType.AskAQuestion));
            purposePairs.Add((SentencePurposeType.GiveADirective, SentencePurposeType.ExpressDetermination));
            purposePairs.Add((SentencePurposeType.ExpressConcern, SentencePurposeType.OfferAssistance));
            purposePairs.Add((SentencePurposeType.ExpressConcern, SentencePurposeType.ProvideInformation));
            purposePairs.Add((SentencePurposeType.ExpressConcern, SentencePurposeType.Reassure));
            purposePairs.Add((SentencePurposeType.OfferAssistance, SentencePurposeType.ExpressConfusion));
            purposePairs.Add((SentencePurposeType.OfferAssistance, SentencePurposeType.ExpressDisbelief));
            purposePairs.Add((SentencePurposeType.ExpressConfusion, SentencePurposeType.GiveGuidance));
            purposePairs.Add((SentencePurposeType.GiveGuidance, SentencePurposeType.ExpressSolidarity));
            purposePairs.Add((SentencePurposeType.ExpressSolidarity, SentencePurposeType.WarnOfImpendingDanger));
            purposePairs.Add((SentencePurposeType.ExpressSolidarity, SentencePurposeType.ProvideInformation));
            purposePairs.Add((SentencePurposeType.WarnOfImpendingDanger, SentencePurposeType.MakeAPromise));
            purposePairs.Add((SentencePurposeType.WarnOfImpendingDanger, SentencePurposeType.DescribeASituation));
            purposePairs.Add((SentencePurposeType.WarnOfImpendingDanger, SentencePurposeType.ExpressSolidarity));
            purposePairs.Add((SentencePurposeType.WarnOfImpendingDanger, SentencePurposeType.ExpressCertainty));
            purposePairs.Add((SentencePurposeType.WarnOfImpendingDanger, SentencePurposeType.OfferAssistance));
            purposePairs.Add((SentencePurposeType.WarnOfImpendingDanger, SentencePurposeType.AskAQuestion));
            purposePairs.Add((SentencePurposeType.WarnOfImpendingDanger, SentencePurposeType.ExpressConcern));
            purposePairs.Add((SentencePurposeType.WarnOfImpendingDanger, SentencePurposeType.GiveADirective));
            purposePairs.Add((SentencePurposeType.WarnOfImpendingDanger, SentencePurposeType.SeekClarification));
            purposePairs.Add((SentencePurposeType.WarnOfImpendingDanger, SentencePurposeType.ElicitInformation));
            purposePairs.Add((SentencePurposeType.WarnOfImpendingDanger, SentencePurposeType.SeekAdvice));
            purposePairs.Add((SentencePurposeType.WarnOfImpendingDanger, SentencePurposeType.Hypothesize));
            purposePairs.Add((SentencePurposeType.WarnOfImpendingDanger, SentencePurposeType.ExpressRealization));
            purposePairs.Add((SentencePurposeType.MakeAPromise, SentencePurposeType.ExpressCertainty));
            purposePairs.Add((SentencePurposeType.MakeAPromise, SentencePurposeType.ExpressEmotion));
            purposePairs.Add((SentencePurposeType.MakeAPromise, SentencePurposeType.AskAQuestion));
            purposePairs.Add((SentencePurposeType.ExpressEmotion, SentencePurposeType.Reassure));
            purposePairs.Add((SentencePurposeType.ExpressCertainty, SentencePurposeType.IssueAChallenge));
            purposePairs.Add((SentencePurposeType.ExpressCertainty, SentencePurposeType.NarrateAnEvent));
            purposePairs.Add((SentencePurposeType.IssueAChallenge, SentencePurposeType.RejectAnIdea));
            purposePairs.Add((SentencePurposeType.RejectAnIdea, SentencePurposeType.NarrateAnEvent));
            purposePairs.Add((SentencePurposeType.NarrateAnEvent, SentencePurposeType.ExpressJoy));
            purposePairs.Add((SentencePurposeType.NarrateAnEvent, SentencePurposeType.ExpressEmotion));
            purposePairs.Add((SentencePurposeType.NarrateAnEvent, SentencePurposeType.AskAQuestion));
            purposePairs.Add((SentencePurposeType.ExpressJoy, SentencePurposeType.ExpressGratitude));
            purposePairs.Add((SentencePurposeType.DescribeASituation, SentencePurposeType.GiveADirective));
            purposePairs.Add((SentencePurposeType.DescribeASituation, SentencePurposeType.ExpressUrgency));
            purposePairs.Add((SentencePurposeType.DescribeASituation, SentencePurposeType.ExpressConcern));
            purposePairs.Add((SentencePurposeType.AskAQuestion, SentencePurposeType.MakeAPromise));
            purposePairs.Add((SentencePurposeType.AskAQuestion, SentencePurposeType.ProvideInformation));
            purposePairs.Add((SentencePurposeType.AskAQuestion, SentencePurposeType.AdmitIgnorance));
            purposePairs.Add((SentencePurposeType.ExpressDisdain, SentencePurposeType.ExpressRegret));
            purposePairs.Add((SentencePurposeType.ExpressDisdain, SentencePurposeType.ArgueAPoint));
            purposePairs.Add((SentencePurposeType.ExpressDisdain, SentencePurposeType.Criticize));
            purposePairs.Add((SentencePurposeType.IntroduceYourself, SentencePurposeType.AskAQuestion));
            purposePairs.Add((SentencePurposeType.IntroduceYourself, SentencePurposeType.EngageInSmallTalk));
            purposePairs.Add((SentencePurposeType.IntroduceYourself, SentencePurposeType.OfferAssistance));
            purposePairs.Add((SentencePurposeType.TellAJoke, SentencePurposeType.ExpressAmazement));
            purposePairs.Add((SentencePurposeType.TellAJoke, SentencePurposeType.ExpressJoy));
            purposePairs.Add((SentencePurposeType.TellAJoke, SentencePurposeType.Quip));
            purposePairs.Add((SentencePurposeType.ClarifyAStatement, SentencePurposeType.Acknowledge));
            purposePairs.Add((SentencePurposeType.ClarifyAStatement, SentencePurposeType.ExpressConfusion));
            purposePairs.Add((SentencePurposeType.Apologize, SentencePurposeType.ExpressGratitude));
            purposePairs.Add((SentencePurposeType.Apologize, SentencePurposeType.Reassure));
            purposePairs.Add((SentencePurposeType.Suggest, SentencePurposeType.RejectAnIdea));
            purposePairs.Add((SentencePurposeType.Suggest, SentencePurposeType.ExpressAgreement));
            purposePairs.Add((SentencePurposeType.ArgueAPoint, SentencePurposeType.ExpressAgreement));
            purposePairs.Add((SentencePurposeType.ArgueAPoint, SentencePurposeType.RefuteAnArgument));
            purposePairs.Add((SentencePurposeType.ExpressAgreement, SentencePurposeType.NarrateAnEvent));
            purposePairs.Add((SentencePurposeType.NarrateAnEvent, SentencePurposeType.ProvideGoodNews));
            purposePairs.Add((SentencePurposeType.ProvideGoodNews, SentencePurposeType.ExpressGratitude));
            purposePairs.Add((SentencePurposeType.ProvideGoodNews, SentencePurposeType.ExpressAmazement));
            purposePairs.Add((SentencePurposeType.MakeAnObservation, SentencePurposeType.DescribeASituation));
            purposePairs.Add((SentencePurposeType.MakeARequest, SentencePurposeType.OfferAssistance));
            purposePairs.Add((SentencePurposeType.Hypothesize, SentencePurposeType.RejectAnIdea));
            purposePairs.Add((SentencePurposeType.Hypothesize, SentencePurposeType.ExpressUncertainty));
            purposePairs.Add((SentencePurposeType.Hypothesize, SentencePurposeType.ExpressAgreement));
            purposePairs.Add((SentencePurposeType.Hypothesize, SentencePurposeType.ExpressRealization));
            purposePairs.Add((SentencePurposeType.Irony, SentencePurposeType.ExpressAgreement));
            purposePairs.Add((SentencePurposeType.Sarcasm, SentencePurposeType.ExpressAgreement));
            purposePairs.Add((SentencePurposeType.Irony, SentencePurposeType.TellAJoke));
            purposePairs.Add((SentencePurposeType.Sarcasm, SentencePurposeType.TellAJoke));
            purposePairs.Add((SentencePurposeType.InternalDialogue, SentencePurposeType.NarrateAnEvent));
            purposePairs.Add((SentencePurposeType.ExpressRealization, SentencePurposeType.GiveADirective));
            purposePairs.Add((SentencePurposeType.ExpressConcern, SentencePurposeType.ShareAnExperience));
            purposePairs.Add((SentencePurposeType.ExpressUncertainty, SentencePurposeType.ShareAnExperience));
            purposePairs.Add((SentencePurposeType.WarnOfImpendingDanger, SentencePurposeType.ShareAnExperience));
            purposePairs.Add((SentencePurposeType.ShareAnExperience, SentencePurposeType.Suggest));
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
                scene => $"Once, I barely escaped from {scene.AnImmediateDangerToTheMission.WordText}. That experience taught me to always be prepared.",
                scene => $"During {scene.APastEventMirroringTheCurrentMission.WordText}, I discovered that {scene.APositiveTurnOfEvents.WordText} can emerge from the darkest moments.",
                scene => $"I remember finding {scene.ObjectThatAssistsTheMission.WordText} under similar circumstances once. It proved indispensable against {scene.AnEnemyOfTheMission.WordText}.",
                scene => $"There was a time when {scene.TheLossesWeHaveSuffered.WordText} seemed insurmountable. Yet, here we are, continuing the fight.",
                scene => $"I've seen {scene.TheEnemy.WordText} use {scene.AWeaponOfTheEnemy.WordText} before. Knowing its weakness could turn the tide in our favor.",
                scene => $"Reflecting on {scene.ARelatedNegativePastEvent.WordText}, I realize how far we've come and how much we've learned.",
                scene => $"Encountering {scene.TheMysteryUnfolding.WordText} isn't new to me. Similar mysteries in the past have led to unexpected allies.",
                scene => $"The last time I was in {scene.LocationOfTheMission.WordText}, I never imagined we'd face {scene.AnOverwhelmingChallenge.WordText}. Yet, we must overcome.",
                scene => $"I recall training for moments like this, but facing {scene.AnImmediateDangerToTheMission.WordText} in reality is a whole different challenge.",
                scene => $"There was a time when {scene.ActionThatContributesToSafety.WordText} saved us from what seemed like certain defeat. It taught us the importance of vigilance.",
                scene => $"I recall a moment when {scene.ActionThatDetractsFromTheMission.WordText} nearly cost us everything. It was a harsh lesson in focus and discipline.",
                scene => $"We once faced {scene.AnImmediateDangerToTheProtagonists.WordText} head-on. That experience forged our resolve like nothing else could.",
                scene => $"Overcoming {scene.AnObstacleToTheMission.WordText} wasn't just a challenge; it was a turning point for us, showing us what we were truly capable of.",
                scene => $"Finding {scene.AnUnexpectedAlly.WordText} in our darkest hour was a reminder that hope can come from the most unexpected places.",
                scene => $"Making {scene.APriorityForTheMission.WordText} our main focus was a decision that paid off more than we could have imagined. It steered us towards our objectives more effectively.",
                scene => $"In our journey, {scene.ASaferLocation.WordText} became our haven, a stark contrast to the grim reality of {scene.AFateIfTheMissionFails.WordText}.",
                scene => $"Our success hinged on {scene.ASkillOfTheProtagonists.WordText}, but it was the discovery of {scene.ACriticalClue.WordText} that truly turned the tides in our favor.",
                scene => $"One key to our progress has been understanding and leveraging {scene.ASuccessFactorOfTheMission.WordText}. It's what sets us apart.",
                scene => $"Facing {scene.AThreatOfTheEnemy.WordText} while knowing {scene.TheNeedsOfTheEnemy.WordText} gave us unique insight into our adversary's motives.",
                scene => $"The revelation of {scene.ATraitorInTheRanks.WordText} amongst us was a bitter pill to swallow, teaching us the value of trust and vigilance.",
                scene => $"Navigating {scene.ATrapForTheProtagonists.WordText} was a trial by fire, one that tested our ingenuity and determination in ways we hadn't anticipated.",
                scene => $"The support from {scene.FriendsOfTheProtagonists.WordText} has been invaluable, reminding us that we're not in this fight alone.",
                scene => $"The guidance we received from {scene.HelpfulEntitiesForTheMission.WordText} was a beacon in our time of need, highlighting paths we hadn't considered.",
                scene => $"The quest for {scene.ObjectYouAreLookingFor.WordText} led us through peril, but it was {scene.AWayToEscape.WordText} that truly saved us from despair.",
                scene => $"Our bond as {scene.ProtagonistsForTheMission.WordText}, strengthened in {scene.ASaferLocation.WordText}, has been our fortress against the storms we've faced.",
                scene => $"As {scene.ProtagonistsForTheMission.WordText}, reaching {scene.TheGoalOfTheMission.WordText} wasn't just an objective; it was our destiny, one we pursued with every fiber of our being.",
                scene => $"Reflecting on our journey, the {scene.StatusOfTheMission.WordText} has truly been a rollercoaster, filled with unexpected turns.",
                scene => $"We've faced {scene.StatusOfTheObstacleToTheMission.WordText}, each one a test of our resolve and ingenuity. Overcoming them was no small feat.",
                scene => $"Looking at {scene.TheBeforeAndAfter.WordText}, it's astonishing how much has changed, and yet, how some things remain the same.",
                scene => $"Carrying {scene.TheBurdenCarriedByTheProtagonists.WordText} has not been easy. It's a weight that's shaped us in ways I never anticipated.",
                scene => $"The chaos {scene.TheChaosCausedByTheEnemy.WordText} unleashed was unlike anything I've ever seen. It was a true test of our spirit.",
                scene => $"In recounting our encounters, it became clear that {scene.TheEnemyActions.WordText} had a pattern, revealing {scene.AWeakness.WordText} we could exploit.",
                scene => $"Achieving {scene.TheGoalOfTheMission.WordText} has been our driving force, pushing us beyond our limits, guiding every decision.",
                scene => $"Dreaming of {scene.TheIdealFutureStateOfTheMission.WordText} keeps me going. It's a vision of peace and prosperity that feels within reach.",
                scene => $"Striving for {scene.TheIdealMentalStateForTheMission.WordText} amidst turmoil has been our collective anchor, keeping us focused and driven.",
                scene => $"The immediate effects, {scene.TheImmediateEffectsOfTheProblem.WordText}, were a harsh wake-up call, forcing us to confront the reality of our situation head-on.",
                scene => $"Understanding {scene.TheMainCauseOfTheProblem.WordText} was pivotal. It turned the tide, giving us a clear target to address.",
                scene => $"Facing {scene.TheMentalStateOfTheEnemy.WordText} was chilling. It's a mindset that's alien and all too familiar at the same time.",
                scene => $"Our true north has always been {scene.TheMissionObjective.WordText}. It's what defines us and our actions in this conflict.",
                scene => $"With {scene.TheTimeLeftToCompleteTheMission.WordText} ticking away, the pressure mounts, making every decision critical.",
                scene => $"As {scene.TheTimeLeftToCompleteTheMission.WordText} dwindles and {scene.AnObstacleToTheMission.WordText} looms large, our resolve is tested like never before.",
                scene => $"During the {scene.TimeOfDay.WordText}, the reality of {scene.TheImmediateEffectsOfTheProblem.WordText} settled in, marking a moment of truth for us all.",
                scene => $"Seeing {scene.VictimsOfTheEnemy.WordText} firsthand changed everything. It personalized the conflict, making it not just a mission, but a moral imperative.",
                scene => $"What hinges on the success of this mission, {scene.WhatHingesOnTheSuccessOfTheMission.WordText}, is something I hold close. It's the reason we fight, the reason we endure."
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
                scene => $"Remember, staying calm is key. Let's focus on {scene.ActionThatContributesToTheMission.WordText} as our first step.",
                scene => $"It's crucial to avoid {scene.AnImmediateDangerToTheMission.WordText} at all costs. Perhaps trying {scene.ASafeApproach.WordText} would be wiser.",
                scene => $"I suggest we take a moment to assess {scene.TheImmediateEffectsOfTheProblem.WordText}. Understanding the problem is half the solution.",
                scene => $"Considering {scene.TheMainCauseOfTheProblem.WordText}, it might be beneficial to {scene.APlanToSucceedAtMission.WordText}. It's all about strategy.",
                scene => $"In situations like this, {scene.ASkillOfTheProtagonists.WordText} can make all the difference. Have you thought about applying it to {scene.ACriticalClue.WordText}?",
                scene => $"Facing {scene.TheEnemy.WordText} requires more than strength. Sometimes, {scene.TheIdealStrategyForTheMission.WordText} is our best weapon.",
                scene => $"If {scene.AFateIfTheMissionFails.WordText} is what we fear, then focusing on {scene.ASuccessFactorOfTheMission.WordText} might offer us the best chance of avoiding it.",
                scene => $"{scene.ATrapForTheProtagonists.WordText} seems daunting, but there's always a way out. Looking for {scene.AWeakness.WordText} could be our first step.",
                scene => $"Drawing from {scene.APastEventMirroringTheCurrentMission.WordText}, it's clear that {scene.AnActionThatLedToSuccess.WordText} might be effective again under these circumstances.",
                scene => $"Sometimes, the best action is to temporarily retreat and regroup. Have we considered {scene.ASaferLocation.WordText} as a rendezvous point?",
                scene => $"Leveraging {scene.HelpfulEntitiesForTheMission.WordText} might provide the support we need to overcome {scene.AnImmediateDangerToTheMission.WordText}.",
                scene => $"In light of {scene.TheMysteryUnfolding.WordText}, it's imperative we {scene.AnActionToUncoverSecrets.WordText}. Secrets can lead to breakthroughs.",
                scene => $"Your ability to {scene.ASkillOfTheProtagonists.WordText} is a potent tool against {scene.TheChaosCausedByTheEnemy.WordText}. It's time to put that skill to use.",
                scene => $"{scene.TheEnemyActions.WordText} are predictable if you know what to look for. Observing their patterns might reveal {scene.AWeakness.WordText}.",
                scene => $"The key to navigating {scene.ATrapForTheProtagonists.WordText} might lie in understanding its design. Let's think about who set it and why.",
                scene => $"{scene.ARejectedPlanOfTheMission.WordText} is not a good idea; some {scene.VictimsOfTheEnemy.WordText} are excellent {scene.ASkillOfTheEnemy.WordText}.",
                scene => $"Remember, {scene.AnUnexpectedAlly.WordText} could provide us with the support we desperately need. Let's not overlook potential allies, no matter how unlikely they seem.",
                scene => $"Reflecting on {scene.TheBeforeAndAfter.WordText} can teach us valuable lessons. Understanding our journey helps us appreciate how far we've come and where we need to go.",
                scene => $"We must avoid {scene.ActionThatDetractsFromTheMission.WordText} at all costs. Such actions could undermine our efforts and set us back significantly.",
                scene => $"In light of {scene.TheLossesWeHaveSuffered.WordText}, it's vital to regroup and reassess our strategy. We honor their memory by continuing our mission with renewed determination.",
                scene => $"Understanding {scene.AnUmbrellaTermThatDescribesTheNatureOfTheEnemy.WordText} is crucial. It allows us to anticipate their moves and develop counter-strategies effectively.",
                scene => $"Maintaining {scene.TheIdealMentalStateForTheMission.WordText} is essential. Our mindset can be our greatest asset or our biggest liability.",
                scene => $"We all feel the weight of {scene.TheBurdenCarriedByTheProtagonists.WordText}, but remember, it's our shared responsibility. We can lighten the load by working together and supporting each other.",
                scene => $"With {scene.TheTimeLeftToCompleteTheMission.WordText} dwindling, it's imperative to prioritize our objectives and focus on the most critical tasks.",
                scene => $"Let's capitalize on {scene.APositiveTurnOfEvents.WordText}. This is our chance to push forward and gain the upper hand."
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
                scene => $"We must not lose sight of {scene.TheGoalOfTheMission.WordText}. Ignoring the signs could lead us directly into the path of unforeseen peril.",
                scene => $"Beware, {scene.TheChaosCausedByTheEnemy.WordText} is only the beginning. If we're not careful, it will engulf everything we've worked for.",
                scene => $"We're approaching {scene.AnObstacleToTheMission.WordText}, and it's unlike any challenge we've faced. Caution and strategy are our best allies now.",
                scene => $"Our vision for {scene.TheIdealFutureStateOfTheMission.WordText} is at risk. We must act swiftly to prevent our hopes from being dashed.",
                scene => $"I fear for {scene.FriendsOfTheProtagonists.WordText}. Without our immediate intervention, they'll be walking into a trap set by our adversaries.",
                scene => $"The root of our problem, {scene.TheMainCauseOfTheProblem.WordText}, is evolving. We must adapt quickly to avert a crisis that could derail our mission.",
                scene => $"Let's not forget our {scene.TheMissionObjective.WordText}. Overlooking this detail could lead us into a situation from which there is no return.",
                scene => $"We're on the brink of facing {scene.AnOverwhelmingChallenge.WordText}. Without proper preparation, we might not make it through unscathed.",
                scene => $"We must act quickly; the {scene.VictimsOfTheEnemy.WordText} are in immediate danger, and every moment we delay increases their peril.",
                scene => $"Remember, {scene.APriorityForTheMission.WordText} cannot be compromised. Any deviation could jeopardize everything we've worked towards.",
                scene => $"Let's coordinate with {scene.HelpfulEntitiesForTheMission.WordText}. Their support is crucial now more than ever, given the escalating threat.",
                scene => $"The {scene.TheImmediateEffectsOfTheProblem.WordText} are beginning to manifest. We're running out of time to counteract the spreading danger.",
                scene => $"Our {scene.ASkillOfTheProtagonists.WordText} and the discovery of {scene.ACriticalClue.WordText} might be the only things standing between us and disaster. We must proceed with utmost caution.",
                scene => $"Beware, {scene.ATrapForTheProtagonists.WordText} lies ahead. We've fallen into similar snares before; let's not repeat those mistakes.",
                scene => $"History is repeating itself. {scene.APastEventMirroringTheCurrentMission.WordText} showed us {scene.AnActionThatLedToSuccess.WordText}. We must heed those lessons now.",
                scene => $"This situation, {scene.TheMysteryUnfolding.WordText}, demands {scene.AnActionToUncoverSecrets.WordText}. Without unraveling these secrets, we're blind to the dangers ahead.",
                scene => $"Caution! {scene.TheEnemyActions.WordText} suggest they've discovered {scene.AWeakness.WordText}. We must fortify our defenses immediately.",
                scene => $"The scenario has changed. {scene.AnUnexpectedAlly.WordText} warns us of a new threat that could alter the course of our mission.",
                scene => $"Reflect on {scene.TheBeforeAndAfter.WordText}. Our actions now will determine which side of history we'll stand on.",
                scene => $"Any {scene.ActionThatDetractsFromTheMission.WordText} could lead us directly into the enemy's hands. We can't afford to be reckless.",
                scene => $"The {scene.TheLossesWeHaveSuffered.WordText} weigh heavily on us all, reminding us of the stakes and the cost of failure.",
                scene => $"We're up against {scene.AnUmbrellaTermThatDescribesTheNatureOfTheEnemy.WordText}. Underestimating them could be our undoing.",
                scene => $"Maintaining {scene.TheIdealMentalStateForTheMission.WordText} is critical. Panic or fear could cloud our judgment at this crucial juncture.",
                scene => $"The {scene.TheBurdenCarriedByTheProtagonists.WordText} grows heavier with each passing moment. We must find a way to lighten the load or risk being crushed under its weight.",
                scene => $"With only {scene.TheTimeLeftToCompleteTheMission.WordText} remaining, every decision, every action, becomes pivotal to our success or failure.",
                scene => $"Though {scene.APositiveTurnOfEvents.WordText} offers a glimmer of hope, we must remain vigilant. Danger often lurks behind the guise of fortune."
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
                scene => $"I'm worried about the {scene.StatusOfTheMission.WordText}. Are we moving in the right direction, or are we losing ground?",
                scene => $"Given the {scene.TimeOfDay.WordText} and {scene.TheImmediateEffectsOfTheProblem.WordText}, I'm concerned we might not be fully prepared for what's to come.",
                scene => $"The {scene.TheMentalStateOfTheEnemy.WordText} worries me. It's unpredictable and could escalate the situation beyond our control.",
                scene => $"With only {scene.TheTimeLeftToCompleteTheMission.WordText} left and facing {scene.AnObstacleToTheMission.WordText}, how can we ensure success under such pressure?",
                scene => $"The {scene.StatusOfTheObstacleToTheMission.WordText} is troubling. It seems to be getting worse, not better. What can we do?",
                scene => $"I'm concerned for {scene.ProtagonistsForTheMission.WordText}. Achieving {scene.TheGoalOfTheMission.WordText} won't be easy, and the risk is high.",
                scene => $"The before and after of this mission could not be more different. It's hard not to worry about the long-term impacts on everyone involved.",
                scene => $"Our unsung heroes, those who've silently supported us, are in my thoughts. Their efforts and sacrifices shouldn't go unnoticed.",
                scene => $"What concerns me is the {scene.TheIdealFutureStateOfTheMission.WordText}. Are we doing enough now to make that future a reality?",
                scene => $"Discovering {scene.ATraitorInTheRanks.WordText} among us has shaken my trust. How can we protect our mission under such betrayal?",
                scene => $"The loss of {scene.ObjectYouAreLookingFor.WordText} and the need for {scene.AWayToEscape.WordText} puts us in a precarious position. How will we navigate this?",
                scene => $"I'm deeply concerned about the {scene.AnImmediateDangerToTheProtagonists.WordText}. We need to find a way to shield ourselves.",
                scene => $"The {scene.AThreatOfTheEnemy.WordText} combined with {scene.TheNeedsOfTheEnemy.WordText} presents a complex challenge. How do we address this without escalating the conflict?",
                scene => $"Our {scene.ActionThatContributesToSafety.WordText} must be our top priority. I'm concerned that without a solid plan, we're vulnerable.",
                scene => $"Did anyone else hear {scene.TheSoundOfTheEnemy.WordText}? It's unsettling and reminds us of the constant threat posed by {scene.TheEnemy.WordText}.",
                scene => $"The {scene.TheChaosCausedByTheEnemy.WordText} is spiraling out of control. How can we restore order and safeguard our future?",
                scene => $"I'm worried about {scene.FriendsOfTheProtagonists.WordText}. They're directly in the line of fire, and we need to ensure their safety.",
                scene => $"The root of our problems, {scene.TheMainCauseOfTheProblem.WordText}, still looms large. We need a solid plan to address this.",
                scene => $"Our mission objective, {scene.TheMissionObjective.WordText}, is at risk. We must reassess our strategy to ensure success.",
                scene => $"Facing {scene.AnOverwhelmingChallenge.WordText} feels insurmountable. Do we have the resources and willpower to overcome this?",
                scene => $"Maintaining {scene.APriorityForTheMission.WordText} is crucial, yet I fear we're losing focus. We need to realign our efforts.",
                scene => $"How can we better utilize {scene.HelpfulEntitiesForTheMission.WordText} in our mission? Their support could be decisive.",
                scene => $"Our strength lies in {scene.ASkillOfTheProtagonists.WordText}, but without {scene.ACriticalClue.WordText}, are we just groping in the dark?",
                scene => $"The discovery of {scene.ATrapForTheProtagonists.WordText} raises alarms. We must tread carefully to avoid ensnarement.",
                scene => $"Remembering {scene.APastEventMirroringTheCurrentMission.WordText} and how {scene.AnActionThatLedToSuccess.WordText} turned the tide, can we find a similar breakthrough now?",
                scene => $"As {scene.TheMysteryUnfolding.WordText} deepens, {scene.AnActionToUncoverSecrets.WordText} becomes not just a task but a necessity.",
                scene => $"With every move of {scene.TheEnemyActions.WordText}, their {scene.AWeakness.WordText} becomes more apparent. We must exploit this.",
                scene => $"The arrival of {scene.AnUnexpectedAlly.WordText} was unforeseen. Can we trust this new element in our midst?",
                scene => $"Considering {scene.TheBeforeAndAfter.WordText}, how far have we come, and at what cost? Reflection is crucial for moving forward.",
                scene => $"Any {scene.ActionThatDetractsFromTheMission.WordText} is a setback we can't afford. We need to stay vigilant and united.",
                scene => $"The toll of {scene.TheLossesWeHaveSuffered.WordText} weighs heavily on us all. How do we honor their sacrifice and keep fighting?",
                scene => $"Confronting {scene.AnUmbrellaTermThatDescribesTheNatureOfTheEnemy.WordText} has never been more critical. It's the essence of our struggle.",
                scene => $"Achieving {scene.TheIdealMentalStateForTheMission.WordText} amidst this turmoil is challenging, yet it's what will carry us through.",
                scene => $"The weight of {scene.TheBurdenCarriedByTheProtagonists.WordText} is a constant reminder of what's at stake. We must find a way to lighten this load.",
                scene => $"While {scene.APositiveTurnOfEvents.WordText} offers hope, we mustn't let our guard down. The path ahead remains fraught with danger."
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
                scene => $"Let's pick up the pace. {scene.TheEnemy.WordText} won't wait for us to make our move.",
                scene => $"We can't ignore the {scene.StatusOfTheMission.WordText}. Every moment we delay only brings us closer to failure. We must act now!",
                scene => $"Given {scene.TheMentalStateOfTheEnemy.WordText}, we don't have the luxury of time. Their unpredictability could escalate the situation at any moment.",
                scene => $"We must reach {scene.ASaferLocation.WordText} before {scene.AnImmediateDangerToTheMission.WordText} overtakes us. There's no time to waste; let's move!",
                scene => $"The {scene.StatusOfTheObstacleToTheMission.WordText} is worsening. If we don't find a solution soon, it might become insurmountable.",
                scene => $"Can't you hear {scene.TheSoundOfTheEnemy.WordText}? It's a reminder of what hinges on the success of our mission. {scene.WhatHingesOnTheSuccessOfTheMission.WordText} demands our immediate response.",
                scene => $"Consider {scene.TheBeforeAndAfter.WordText}. We've come too far to falter now. The future we're fighting for is within reach, but only if we act with urgency.",
                scene => $"The efforts of {scene.TheUnsungHeroes.WordText} must not be in vain. We owe it to them to press forward, with no hesitation.",
                scene => $"Our vision for {scene.TheIdealFutureStateOfTheMission.WordText} is only achievable if we address the challenges head-on, without delay.",
                scene => $"The revelation of {scene.ATraitorInTheRanks.WordText} changes everything. We must move quickly to counteract the betrayal and secure our mission."
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
                scene => $"Geronimo!",
                scene => $"Remember why we're here. {scene.TheGoalOfTheMission.WordText} is within our grasp.",
                scene => $"We've got each other's backs. Together, there's nothing we can't overcome.",
                scene => $"Keep pushing forward. For every challenge we face, remember {scene.TheAchievementsOfTheGroup.WordText}.",
                scene => $"This is our time to shine. Let's show {scene.TheEnemy.WordText} what we're made of.",
                scene => $"Our resolve will be our weapon against {scene.TheChaosCausedByTheEnemy.WordText}. Stand strong!",
                scene => $"Each step forward is a step closer to victory. Let's make every action count.",
                scene => $"Believe in our cause. Believe in each other. That's how we'll achieve {scene.TheIdealFutureStateOfTheMission.WordText}.",
                scene => $"Our courage is our strength. Let's harness it and face {scene.AnObstacleToTheMission.WordText} head-on.",
                scene => $"For {scene.VictimsOfTheEnemy.WordText}, for {scene.LocationOfTheMission.WordText}, we cannot falter now.",
                scene => $"Eyes on the prize, team. {scene.TheGoalOfTheMission.WordText} is closer than it appears.",
                scene => $"Every step we take towards {scene.ActionThatContributesToTheMission.WordText} brings us closer to our goal. Let's keep pushing forward.",
                scene => $"By focusing our efforts on {scene.ActionThatContributesToTheMission.WordText} the {scene.ActionObjectThatContributesToTheMission.WordText}, we're making real progress. Your contributions are invaluable.",
                scene => $"Not only does {scene.ActionThatContributesToTheMission.WordText} the {scene.ActionObjectThatContributesToTheMission.WordText} advance our mission, but it also ensures our safety. We're stronger together.",
                scene => $"Remember when {scene.ARelatedNegativePastEvent.WordText} happened? Our current efforts, especially {scene.ActionThatContributesToTheMission.WordText} the {scene.ActionObjectThatContributesToTheMission.WordText} for our safety, will prevent history from repeating itself.",
                scene => $"As {scene.TimeOfDay.WordText} approaches, let's focus on {scene.ActionThatContributesToTheMission.WordText} the {scene.ActionObjectThatContributesToTheMission.WordText}. It's crucial for today's success.",
                scene => $"Even though {scene.ActionThatDetractsFromTheMission.WordText} set us back, it's only a temporary hurdle. We learn and grow stronger from every challenge.",
                scene => $"While the threat of {scene.AFateIfTheMissionFails.WordText} looms over us, remember, {scene.ASuccessFactorOfTheMission.WordText} is within our grasp. We can change our fate.",
                scene => $"Let's hold onto {scene.AMomentOfJoy.WordText} as a beacon of what we're fighting for. Joy amidst adversity fuels our resilience.",
                scene => $"Despite the shadow of {scene.AnImmediateDangerToTheProtagonists.WordText}, we stand undaunted. Together, we're invincible.",
                scene => $"Facing {scene.AnOverwhelmingChallenge.WordText} might seem daunting, but it's our courage in these moments that defines us. We'll overcome this, as we have everything else.",
                scene => $"Our fight against {scene.AnUmbrellaTermThatDescribesTheNatureOfTheEnemy.WordText} is tough, but it's our spirit and unity that will see us through. We've got this.",
                scene => $"The arrival of {scene.AnUnexpectedAlly.WordText} is a reminder that hope comes from unexpected places. Let's welcome this new strength to our ranks.",
                scene => $"Remember what happened during {scene.APastEvent.WordText}? It's like {scene.TheMystery.WordText} all over again. We can use what we learned to navigate this challenge.",
                scene => $"Just like {scene.APastEventMirroringTheCurrentMission.WordText}, where {scene.AnActionThatLedToSuccess.WordText} was our turning point, we have a clear path with {scene.APlanToSucceedAtMission.WordText}.",
                scene => $"Seeing {scene.APositiveTurnOfEvents.WordText} unfold has been a beacon of hope for us all. It reaffirms that our strategy is working.",
                scene => $"{scene.APriorityForTheMission.WordText} must remain our focus. Everything we're fighting for hinges on this.",
                scene => $"Our mastery of {scene.ASkillOfTheProtagonists.WordText} and the discovery of {scene.ACriticalClue.WordText} are key to our success. We're closer than ever.",
                scene => $"We've found {scene.ASolution.WordText} to {scene.TheProblem.WordText}, and now {scene.ASaferLocation.WordText} is within our reach. Let's make this count.",
                scene => $"Facing {scene.AThreatOfTheEnemy.WordText} requires us to understand {scene.TheNeedsOfTheEnemy.WordText}. This knowledge is our advantage.",
                scene => $"Knowing there's {scene.ATraitorInTheRanks.WordText} among us is disheartening, but it's also a call to strengthen our resolve and unity.",
                scene => $"We've encountered {scene.ATrapForTheProtagonists.WordText} before. Each time, it's our camaraderie and quick thinking that have seen us through.",
                scene => $"Let's not forget, {scene.FriendsOfTheProtagonists.WordText} are counting on us. Their support has been unwavering, and we owe it to them to persevere.",
                scene => $"The guidance from {scene.HelpfulEntitiesForTheMission.WordText} has been invaluable. Their assistance is a testament to the strength of our cause.",
                scene => $"The discovery of {scene.ObjectYouAreLookingFor.WordText} and a viable {scene.AWayToEscape.WordText} means we're on the brink of turning the tide.",
                scene => $"{scene.PreparationForTheMission.WordText} has prepared us for this moment. Our readiness is our strongest asset.",
                scene => $"With {scene.ProtagonistsForTheMission.WordText} facing {scene.AnImmediateDangerToTheMission.WordText}, it's our unity and courage that will carry us through.",
                scene => $"Given {scene.StatusOfTheMission.WordText}, it's clear we're making progress. Let's keep this momentum going.",
                scene => $"Looking at {scene.TheBeforeAndAfter.WordText} reminds us of how far we've come and the future we're fighting for.",
                scene => $"Carrying {scene.TheBurdenCarriedByTheProtagonists.WordText} hasn't been easy, but it's our duty and our honor. We will see this through.",
                scene => $"Facing {scene.TheCurrentSituation.WordText} head-on, remember, we've overcome great odds before. This time will be no different.",
                scene => $"With {scene.TheEnemyActions.WordText} escalating, it's {scene.TheHeroesOfTheStory.WordText} who will define the outcome of this conflict.",
                scene => $"Maintaining {scene.TheIdealMentalStateForTheMission.WordText} is crucial. Our mindset can be as powerful a weapon as any.",
                scene => $"The impact of {scene.TheImmediateEffectsOfTheProblem.WordText} is undeniable, but not insurmountable. We've faced tough challenges before.",
                scene => $"The injustice of {scene.TheInjusticeFaced.WordText} fuels our determination. We're not just fighting for ourselves, but for those without a voice.",
                scene => $"Despite {scene.TheLossesWeHaveSuffered.WordText}, we stand strong. Each loss is a reminder of the stakes and the importance of our mission.",
                scene => $"Understanding {scene.TheMentalStateOfTheEnemy.WordText} gives us insight into their actions and potential weaknesses.",
                scene => $"Our focus on {scene.TheMissionObjective.WordText} has never been sharper. Every step we take is a step towards victory.",
                scene => $"The unraveling of {scene.TheMysteryUnfolding.WordText} brings us closer to the truth, inching us towards our ultimate goal.",
                scene => $"The resilience shown by {scene.ThePhysicalStateOfTheProtagonists.WordText} in the face of adversity is nothing short of heroic.",
                scene => $"The echo of {scene.TheSoundOfTheEnemy.WordText} will not deter us. It only strengthens our resolve to end this conflict.",
                scene => $"Updates on {scene.TheStatusOfTheMainCauseOfTheProblem.WordText} are promising. It's a clear indicator that our efforts are paying off.",
                scene => $"The stories of {scene.TheSurvivors.WordText} inspire us all. Their resilience in the face of adversity fuels our commitment.",
                scene => $"With {scene.TheTimeLeftToCompleteTheMission.WordText} ticking, our focus and actions now are more critical than ever.",
                scene => $"Facing {scene.TheUnknownFactors.WordText} can be daunting, but every challenge is an opportunity to demonstrate our strength.",
                scene => $"Let's remember {scene.TheUnsungHeroes.WordText}. Their sacrifices have paved the way for our current efforts and future victories."
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
                scene => $"Weather forecasts predict {scene.ANaturalPhenomenon.WordText} in {scene.LocationOfTheMission.WordText}, which could impact our mission timelines.",
                scene => $"The {scene.ActionObjectThatContributesToTheMission.WordText} is key to our strategy and could significantly boost our efforts.",
                scene => $"Our primary goal, {scene.TheGoalOfTheMission.WordText}, remains within reach, provided we stay focused and coordinated.",
                scene => $"We've devised {scene.APlanToSucceedAtMission.WordText} to navigate the obstacles and secure a victory.",
                scene => $"Currently, {scene.TheStatusOfTheMainCauseOfTheProblem.WordText} is exacerbating the situation, demanding our immediate attention.",
                scene => $"We've identified {scene.AnEnemyOfTheMission.WordText} as a significant threat due to their strategic maneuvers against us.",
                scene => $"Both {scene.ProtagonistsForTheMission.WordText} and {scene.AnImmediateDangerToTheMission.WordText} are at the forefront of this conflict, requiring our vigilance.",
                scene => $"The {scene.TheMentalStateOfTheEnemy.WordText} suggests they might be planning a more aggressive approach soon.",
                scene => $"We're witnessing {scene.TheImmediateEffectsOfTheProblem.WordText}, which underscores the urgency of addressing the root causes.",
                scene => $"Revisiting {scene.APlanToSucceedAtMission.WordText}, it's clear we need to adapt our tactics to the evolving situation.",
                scene => $"{scene.AnImmediateDangerToTheProtagonists.WordText} has emerged as a new threat, one that could jeopardize our entire operation.",
                scene => $"Time is a luxury we don't have, with only {scene.TheTimeLeftToCompleteTheMission.WordText} to enact our strategy.",
                scene => $"{scene.HelpfulEntitiesForTheMission.WordText} have offered their support, which could prove pivotal in the coming days.",
                scene => $"The unfolding of {scene.TheMysteryUnfolding.WordText} may provide us with the leverage needed to turn the tide.",
                scene => $"It's crucial we remember {scene.TheSurvivors.WordText}; their experiences and resilience could inspire our path forward.",
                scene => $"Reflecting on {scene.TheAchievementsOfTheGroup.WordText} provides a beacon of hope and a reminder of what we're capable of achieving together.",
                scene => $"Our preparation for the mission, including {scene.PreparationForTheMission.WordText}, has set us up for success, even in the face of unexpected challenges.",
                scene => $"We're facing an overwhelming challenge: {scene.AnOverwhelmingChallenge.WordText}. It's going to test us in ways we've never been before.",
                scene => $"The physical state of the protagonists, {scene.ThePhysicalStateOfTheProtagonists.WordText}, could significantly impact our next moves.",
                scene => $"Recent enemy actions, {scene.TheEnemyActions.WordText}, have brought the heroes of the story, {scene.TheHeroesOfTheStory.WordText}, into direct conflict.",
                scene => $"We're still grappling with the unknown factors, {scene.TheUnknownFactors.WordText}, which could alter the course of our mission.",
                scene => $"The current situation, {scene.TheCurrentSituation.WordText}, demands our immediate attention and adaptation.",
                scene => $"A moment of joy, {scene.AMomentOfJoy.WordText}, has given us a much-needed respite amidst the turmoil.",
                scene => $"The burden carried by the protagonists, {scene.TheBurdenCarriedByTheProtagonists.WordText}, is a heavy one, shaped by the weight of expectations and the cost of failure.",
                scene => $"Our mission objective, {scene.TheMissionObjective.WordText}, is clear, guiding our actions and strategies.",
                scene => $"There's talk of a traitor in the ranks, {scene.ATraitorInTheRanks.WordText}, which could undermine our efforts from within.",
                scene => $"A positive turn of events, {scene.APositiveTurnOfEvents.WordText}, has unexpectedly shifted the tide in our favor.",
                scene => $"The unsung heroes, {scene.TheUnsungHeroes.WordText}, have played a pivotal role behind the scenes, often without recognition.",
                scene => $"The losses we have suffered, {scene.TheLossesWeHaveSuffered.WordText}, remind us of the stakes and the cost of this conflict.",
                scene => $"We've faced injustice, {scene.TheInjusticeFaced.WordText}, which has fueled our determination and resolve.",
                scene => $"The before and after, {scene.TheBeforeAndAfter.WordText}, starkly illustrates the impact of our journey and the changes we've undergone.",
                scene => $"Certain actions detract from the mission, specifically {scene.ActionThatDetractsFromTheMission.WordText}, and must be addressed.",
                scene => $"A related negative past event, {scene.ARelatedNegativePastEvent.WordText}, has had lasting effects on our strategy and morale.",
                scene => $"A key success factor of the mission is {scene.ASuccessFactorOfTheMission.WordText}, upon which much of our hope is pinned.",
                scene => $"Actions that contribute to the mission, such as {scene.ActionThatContributesToTheMission.WordText}, are vital for our progress and eventual success.",
                scene => $"The action that contributes to the mission, {scene.ActionThatContributesToTheMission.WordText}, juxtaposed with the dire consequence of failure, {scene.AFateIfTheMissionFails.WordText}, highlights our precarious position.",
                scene => $"What hinges on the success of the mission, {scene.WhatHingesOnTheSuccessOfTheMission.WordText}, cannot be overstated; it's the essence of our fight.",
                scene => $"The status of the mission, {scene.StatusOfTheMission.WordText}, provides us with a clear indicator of our progress and challenges.",
                scene => $"The ideal future state of the mission, {scene.TheIdealFutureStateOfTheMission.WordText}, is a vision that drives us forward, against all odds.",
                scene => $"Our quest for the object we are looking for, {scene.ObjectYouAreLookingFor.WordText}, alongside a way to escape, {scene.AWayToEscape.WordText}, remains our focus amidst the chaos.",
                scene => $"Intelligence reports indicate that {scene.AThreatOfTheEnemy.WordText} is escalating, driven by {scene.TheNeedsOfTheEnemy.WordText}. We must adapt our strategy accordingly.",
                scene => $"Our latest tactic, {scene.ActionThatContributesToSafety.WordText}, has been implemented to enhance our defenses and ensure everyone's safety.",
                scene => $"It's heartening to know that {scene.FriendsOfTheProtagonists.WordText} are standing by us, ready to lend their support in facing our challenges.",
                scene => $"We're currently up against {scene.AnOverwhelmingChallenge.WordText}, which requires a unified and strategic response from our entire team.",
                scene => $"{scene.APriorityForTheMission.WordText} has been identified as crucial for our next steps, guiding our focus and resources.",
                scene => $"Leveraging {scene.ASkillOfTheProtagonists.WordText} has led us to discover {scene.ACriticalClue.WordText}, which could be the breakthrough we need.",
                scene => $"Be wary of {scene.ATrapForTheProtagonists.WordText}; it's been cleverly designed to exploit our vulnerabilities.",
                scene => $"Reflecting on {scene.APastEventMirroringTheCurrentMission.WordText} shows us that {scene.AnActionThatLedToSuccess.WordText} can inspire our current strategy.",
                scene => $"We've found an unexpected ally in {scene.AnUnexpectedAlly.WordText}, whose assistance could prove invaluable.",
                scene => $"We must avoid {scene.ActionThatDetractsFromTheMission.WordText} at all costs, as it could undermine our efforts and put us at a disadvantage.",
                scene => $"The losses we've suffered, {scene.TheLossesWeHaveSuffered.WordText}, weigh heavily on us, reminding us of the stakes involved.",
                scene => $"Understanding {scene.AnUmbrellaTermThatDescribesTheNatureOfTheEnemy.WordText} is key to anticipating their moves and countering their strategies.",
                scene => $"Maintaining {scene.TheIdealMentalStateForTheMission.WordText} is essential for navigating the challenges ahead and keeping morale high.",
                scene => $"The burden carried by the protagonists, {scene.TheBurdenCarriedByTheProtagonists.WordText}, underscores the personal costs of our mission.",
                scene => $"The eerie silence was broken by {scene.TheSoundOfTheEnemy.WordText}, a reminder of the ever-present threat lurking in the shadows.",
                scene => $"Our vision for {scene.TheIdealFutureStateOfTheMission.WordText} keeps us motivated, pushing us to strive for a better outcome despite the odds.",
                scene => $"Focusing on {scene.TheMissionObjective.WordText} helps to streamline our efforts and ensure that every action is aligned with our ultimate goal.",
                scene => $"The key to our success lies in {scene.ASkillOfTheProtagonists.WordText}, which, combined with {scene.ACriticalClue.WordText}, could lead us to victory.",
                scene => $"Facing {scene.AFateIfTheMissionFails.WordText} motivates us to harness every {scene.ASuccessFactorOfTheMission.WordText} at our disposal, ensuring we overcome the obstacles before us."
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
                scene => $"Can {scene.FriendsOfTheProtagonists.WordText} provide more insight into the current situation?",
                scene => $"How exactly does {scene.ASkillOfTheProtagonists.WordText} play a role in our current strategy?",
                scene => $"In what way can {scene.ASkillOfTheProtagonists.WordText} aid in {scene.ActionThatContributesToTheMission.WordText}?",
                scene => $"Can someone explain how {scene.ActionThatContributesToTheMission.WordText} involves {scene.ActionObjectThatContributesToTheMission.WordText}?",
                scene => $"What's the nature of {scene.ATrapForTheProtagonists.WordText}, and how can we avoid it?",
                scene => $"Could you elaborate on {scene.AnObstacleToTheMission.WordText} and how it affects our mission?",
                scene => $"How is {scene.TheChaosCausedByTheEnemy.WordText} impacting our operations? What's the best course of action?",
                scene => $"What can we do to better understand {scene.TheEnemy.WordText} and their tactics?",
                scene => $"How does {scene.ASkillOfTheProtagonists.WordText} equip us to deal with {scene.AnImmediateDangerToTheMission.WordText}?",
                scene => $"Is there any further information on {scene.ACriticalClue.WordText} that we should be aware of?",
                scene => $"What strategies are we considering to overcome {scene.AnOverwhelmingChallenge.WordText}?",
                scene => $"How imminent is {scene.AnImmediateDangerToTheMission.WordText}, and what are our options for mitigation?",
                scene => $"Can someone update me on the condition of {scene.VictimsOfTheEnemy.WordText} and their current location?",
                scene => $"How exactly does {scene.AnEnemyOfTheMission.WordText}'s {scene.ASkillOfTheEnemy.WordText} impact our strategy?",
                scene => $"What makes {scene.ASuccessFactorOfTheMission.WordText} so critical to our mission's outcome?",
                scene => $"Given {scene.ANegativeFactorThatNecessitatedTheMission.WordText}, how does our position in {scene.LocationOfTheMission.WordText} affect our plans?",
                scene => $"Can you clarify what exactly hinges on the success of our mission? What is at stake with {scene.WhatHingesOnTheSuccessOfTheMission.WordText}?",
                scene => $"What's the current status and location of {scene.VictimsOfTheEnemy.WordText}? Are they safe in {scene.LocationOfTheVictim.WordText}?",
                scene => $"How is {scene.TheMainCauseOfTheProblem.WordText} linked to our operations in {scene.LocationOfTheMission.WordText}?",
                scene => $"Can you explain how {scene.TheProblem.WordText} impacts our safety in {scene.ASaferLocation.WordText}?",
                scene => $"In light of {scene.APastEvent.WordText}, how does this relate to the mystery we're currently facing?",
                scene => $"How is {scene.ANaturalPhenomenon.WordText} affecting our mission in {scene.LocationOfTheMission.WordText}?",
                scene => $"What exactly is our goal with {scene.TheGoalOfTheMission.WordText}? How does it align with our overall objectives?",
                scene => $"Could you go over the details of {scene.APlanToSucceedAtMission.WordText} once more? I want to ensure I fully understand our approach.",
                scene => $"What is the current status of {scene.TheMainCauseOfTheProblem.WordText}? Have there been any changes or developments?",
                scene => $"How is {scene.TheMentalStateOfTheEnemy.WordText} influencing their decisions and actions against us?",
                scene => $"What are the immediate effects of {scene.TheProblem.WordText} we're observing, and how are we addressing them?",
                scene => $"Can we revisit {scene.APlanToSucceedAtMission.WordText}? I'm looking for clarity on some of its components.",
                scene => $"What kind of immediate danger do {scene.AnImmediateDangerToTheProtagonists.WordText} pose to us right now?",
                scene => $"How much time do we have left to complete the mission? What does {scene.TheTimeLeftToCompleteTheMission.WordText} mean for our urgency?",
                scene => $"Who are the {scene.HelpfulEntitiesForTheMission.WordText}, and how can they assist us in achieving our objectives?",
                scene => $"Could someone elaborate on {scene.TheMysteryUnfolding.WordText}? How does it connect to our current situation?",
                scene => $"What's the current situation regarding {scene.TheSurvivors.WordText}? How are they coping with recent events?",
                scene => $"How do {scene.TheAchievementsOfTheGroup.WordText} influence our standing and morale among allies and adversaries?"
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
                scene => $"Emergency handled; we can't let this happen again.",
                scene => $"In my opinion, facing {scene.TheEnemy.WordText} with {scene.AWeaponOfTheEnemy.WordText} in {scene.LocationOfTheEnemy.WordText} requires a careful approach. We must not underestimate them.",
                scene => $"I believe that the situation of {scene.VictimsOfTheEnemy.WordText} in {scene.LocationOfTheVictim.WordText} demands our immediate attention. We can't just stand by.",
                scene => $"Considering {scene.AnObstacleToTheMission.WordText} and its {scene.StatusOfTheObstacleToTheMission.WordText}, I'd say a reassessment of our current strategy is in order.",
                scene => $"The chaos {scene.TheEnemy.WordText} has caused in {scene.LocationOfTheEnemy.WordText} makes me think; their unpredictability is both a strength and a potential weakness we can exploit.",
                scene => $"{scene.TheMainCauseOfTheProblem.WordText} being at the heart of {scene.LocationOfTheMission.WordText} is no coincidence. It's a strategic point we need to focus on more.",
                scene => $"From what I've seen, {scene.TheEnemy.WordText}'s presence in {scene.LocationOfTheMission.WordText} exposes a weakness — {scene.AWeakness.WordText}. It's something we could use to our advantage.",
                scene => $"My take is, {scene.ASolution.WordText} could be the key to solving {scene.TheProblem.WordText}, especially if we can execute it from {scene.ASaferLocation.WordText}. It seems like the most logical step forward.",
                scene => $"Reflecting on {scene.APastEvent.WordText}, it's clear to me that the underlying mystery {scene.TheMystery.WordText} still influences our current predicament more than we realize.",
                scene => $"The impact of {scene.ANaturalPhenomenon.WordText} on {scene.LocationOfTheMission.WordText} shouldn't be underestimated. It could change the dynamics of our mission significantly.",
                scene => $"In my view, achieving {scene.TheGoalOfTheMission.WordText} should be our top priority. Everything else is secondary.",
                scene => $"I believe {scene.APlanToSucceedAtMission.WordText} is our best shot. It's well thought out and addresses the core issues we're facing.",
                scene => $"Given {scene.TheStatusOfTheMainCauseOfTheProblem.WordText}, I'd say we need to adjust our strategy. Ignoring this could lead to failure.",
                scene => $"Facing {scene.AnEnemyOfTheMission.WordText} will be challenging. We must understand their motives and strategies to outmaneuver them.",
                scene => $"Considering the dedication of {scene.ProtagonistsForTheMission.WordText} and the looming {scene.AnImmediateDangerToTheMission.WordText}, I believe unity and vigilance are our greatest assets.",
                scene => $"The {scene.TheMentalStateOfTheEnemy.WordText} is a variable we can't ignore. It could dictate their next move, making predictability our advantage.",
                scene => $"The {scene.TheImmediateEffectsOfTheProblem.WordText} are concerning. They highlight the urgency of our mission and the need for immediate action.",
                scene => $"We can't underestimate {scene.AnImmediateDangerToTheProtagonists.WordText}. It poses a significant risk that could derail our efforts.",
                scene => $"With {scene.TheTimeLeftToCompleteTheMission.WordText} dwindling, every decision counts. We must act with precision and purpose.",
                scene => $"Leveraging support from {scene.HelpfulEntitiesForTheMission.WordText} could turn the tide in our favor. Their expertise is invaluable.",
                scene => $"The unfolding of {scene.TheMysteryUnfolding.WordText} adds layers of complexity to our mission. We need to stay adaptable and observant.",
                scene => $"We owe it to {scene.TheSurvivors.WordText} to not only succeed but to ensure such tragedies are prevented in the future.",
                scene => $"Reflecting on {scene.TheAchievementsOfTheGroup.WordText}, I'm convinced that our collective experiences have prepared us for this moment.",
                scene => $"Considering {scene.AFateIfTheMissionFails.WordText}, I believe focusing on {scene.ASuccessFactorOfTheMission.WordText} is our best bet for success.",
                scene => $"Every {scene.AMomentOfJoy.WordText} reminds us why we're fighting this battle. It's these moments that give us strength.",
                scene => $"Facing {scene.AnOverwhelmingChallenge.WordText} has taught us resilience. I think it's an opportunity to grow stronger.",
                scene => $"In my opinion, {scene.AnUmbrellaTermThatDescribesTheNatureOfTheEnemy.WordText} perfectly captures the essence of our struggle.",
                scene => $"Having {scene.AnUnexpectedAlly.WordText} on our side is a game-changer. It's an advantage we didn't anticipate.",
                scene => $"Reflecting on {scene.APastEventMirroringTheCurrentMission.WordText}, it's clear that {scene.AnActionThatLedToSuccess.WordText} was a turning point. We should consider a similar strategy.",
                scene => $"The arrival of {scene.APositiveTurnOfEvents.WordText} couldn't have come at a better time. It's exactly what we needed to boost morale.",
                scene => $"Prioritizing {scene.APriorityForTheMission.WordText} aligns with our goals. It's a focus that cannot be overlooked.",
                scene => $"Our {scene.ASkillOfTheProtagonists.WordText}, combined with the discovery of {scene.ACriticalClue.WordText}, is pivotal. It could very well dictate the mission's outcome.",
                scene => $"Emphasizing {scene.ASuccessFactorOfTheMission.WordText} again, I believe it's essential for navigating the challenges ahead.",
                scene => $"The dynamic between {scene.AThreatOfTheEnemy.WordText} and {scene.TheNeedsOfTheEnemy.WordText} is complex. Understanding it could be key to our strategy.",
                scene => $"Having {scene.ATraitorInTheRanks.WordText} among us changes everything. It's a betrayal that calls for immediate reassessment of our plans.",
                scene => $"Falling into {scene.ATrapForTheProtagonists.WordText} was a setback, but it's also a learning opportunity. We must be more vigilant.",
                scene => $"Our strength lies in the unity of {scene.FriendsOfTheProtagonists.WordText}. It's this camaraderie that will see us through.",
                scene => $"The {scene.ObjectYouAreLookingFor.WordText} coupled with {scene.AWayToEscape.WordText} presents a clear path forward. We must seize this opportunity.",
                scene => $"Our {scene.PreparationForTheMission.WordText} has been thorough. I believe we're well-equipped to face what comes next.",
                scene => $"Given {scene.StatusOfTheMission.WordText}, it's crucial we adapt our tactics to the evolving situation.",
                scene => $"The transition from {scene.TheBeforeAndAfter.WordText} illustrates our journey's impact. It's a stark reminder of what's at stake.",
                scene => $"Carrying {scene.TheBurdenCarriedByTheProtagonists.WordText} has not been easy. It's a weight we all share, each in our own way.",
                scene => $"Looking at {scene.TheCurrentSituation.WordText}, it's evident that our actions now will define the future of this mission.",
                scene => $"The contrast between {scene.TheEnemyActions.WordText} and {scene.TheHeroesOfTheStory.WordText} couldn't be more pronounced. It highlights the essence of our struggle.",
                scene => $"Aiming for {scene.TheIdealFutureStateOfTheMission.WordText} keeps us grounded. It's a vision that we must work tirelessly towards.",
                scene => $"Maintaining {scene.TheIdealMentalStateForTheMission.WordText} is essential. It's not just about physical readiness but mental resilience.",
                scene => $"The {scene.TheInjusticeFaced.WordText} we've encountered fuels our determination. It's injustices like these that we aim to rectify.",
                scene => $"Reflecting on {scene.TheLossesWeHaveSuffered.WordText}, it's clear that each loss shapes our resolve. We carry these memories as a reminder of why we fight.",
                scene => $"Our focus on {scene.TheMissionObjective.WordText} is unwavering. It's the beacon that guides our every decision.",
                scene => $"The {scene.ThePhysicalStateOfTheProtagonists.WordText} underscores the toll this mission has taken on us. Yet, we persist.",
                scene => $"Every {scene.TheSoundOfTheEnemy.WordText} is a reminder of what we're up against. It's a sound that motivates us to push harder.",
                scene => $"Confronting {scene.TheUnknownFactors.WordText} requires flexibility. Our ability to adapt will be tested.",
                scene => $"The stories of {scene.TheUnsungHeroes.WordText} inspire us. Their contributions, though often overlooked, are the foundation of our progress.",
                scene => $"What hinges on the success of this mission is {scene.WhatHingesOnTheSuccessOfTheMission.WordText}. It's a responsibility we cannot take lightly."
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
                scene => $"I promise we won't {scene.ActionThatDetractsFromTheMission.WordText} again.",
                scene => $"I promise to always stand by {scene.ProtagonistsForTheMission.WordText}, no matter the {scene.TheChaosCausedByTheEnemy.WordText} we face.",
                scene => $"I promise to protect {scene.VictimsOfTheEnemy.WordText} from {scene.AnEnemyOfTheMission.WordText}, ensuring their safety at all costs.",
                scene => $"I vow to never let {scene.TheMainCauseOfTheProblem.WordText} defeat us. We will overcome it together.",
                scene => $"I commit to finding a solution to {scene.TheImmediateEffectsOfTheProblem.WordText}. Failure is not an option.",
                scene => $"I assure you, we will reach {scene.ASaferLocation.WordText} before {scene.TheTimeLeftToCompleteTheMission.WordText} runs out. Trust in our resolve.",
                scene => $"I pledge to honor the legacy of {scene.TheUnsungHeroes.WordText} by completing {scene.TheMissionObjective.WordText}, no matter what stands in our way.",
                scene => $"I guarantee we'll uncover the truth behind {scene.TheMysteryUnfolding.WordText}. The answers lie just ahead.",
                scene => $"I promise to always remember the lessons learned from {scene.ARelatedNegativePastEvent.WordText} and use them to guide our actions.",
                scene => $"I swear that {scene.TheLossesWeHaveSuffered.WordText} will not be in vain. We'll make things right, for them and for us.",
                scene => $"I commit to using every resource at our disposal, including {scene.ASecretWeapon.WordText}, to ensure our victory against {scene.TheEnemy.WordText}.",
                scene => $"I vow to stay true to our cause, even when faced with {scene.AnOverwhelmingChallenge.WordText}. Together, we are unstoppable.",
                scene => $"I promise we'll overcome {scene.AnObstacleToTheMission.WordText}. No matter what stands in our way, we'll find a path through it.",
                scene => $"I vow to not rest until we've reached {scene.TheGoalOfTheMission.WordText}. It's more than just a mission; it's our destiny.",
                scene => $"Trust me, {scene.APlanToSucceedAtMission.WordText} will lead us to victory. I've thought this through, and I won't let us fail.",
                scene => $"I assure you, we'll address {scene.TheStatusOfTheMainCauseOfTheProblem.WordText}. I'm committed to turning the tide in our favor.",
                scene => $"You have my word that we'll counter {scene.TheMentalStateOfTheEnemy.WordText}. Understanding their mindset is the key to our success.",
                scene => $"I guarantee we'll navigate through {scene.AnObstacleToTheMission.WordText} unscathed. Our resilience is unmatched.",
                scene => $"I promise to keep us informed of any movements at {scene.LocationOfTheEnemy.WordText}. Staying one step ahead is crucial.",
                scene => $"Rely on me to refine {scene.APlanToSucceedAtMission.WordText}. It's our blueprint to success, and I'll ensure it's foolproof.",
                scene => $"I pledge to protect us from {scene.AnImmediateDangerToTheProtagonists.WordText}. Our safety is my top priority.",
                scene => $"Count on me to coordinate with {scene.HelpfulEntitiesForTheMission.WordText}. Together, we'll strengthen our efforts.",
                scene => $"I promise to honor the memory of {scene.TheSurvivors.WordText} by completing this mission. Their courage fuels our determination.",
                scene => $"Our actions will add to {scene.TheAchievementsOfTheGroup.WordText}. I promise our names will be remembered for our bravery and solidarity."
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
                scene => $"Remember, we have {scene.HelpfulEntitiesForTheMission.WordText} on our side. Together, there's nothing we can't overcome.",
                scene => $"This is just another challenge. Like all the others before, we'll meet it head-on and come out stronger.",
                scene => $"Trust in our preparation. {scene.PreparationForTheMission.WordText} has equipped us well for moments like these.",
                scene => $"Look how far we've come already. This is but one more hurdle on our path to {scene.TheGoalOfTheMission.WordText}.",
                scene => $"Take a moment, breathe. We've navigated through {scene.AnOverwhelmingChallenge.WordText} before. This will be no different.",
                scene => $"Our resolve has seen us through darker times than this. {scene.TheEnemy.WordText} won't change that.",
                scene => $"We've got a plan, remember? {scene.APlanToSucceedAtMission.WordText} hasn't failed us yet.",
                scene => $"There's strength in our unity. As long as we stand together, {scene.AnImmediateDangerToTheMission.WordText} can't break us.",
                scene => $"Despite {scene.ThePhysicalStateOfTheProtagonists.WordText}, remember our resilience. We've faced tough times before and emerged stronger.",
                scene => $"Even amidst {scene.TheChaosCausedByTheEnemy.WordText}, let's not lose sight of our ability to restore order. We've overcome similar chaos before.",
                scene => $"Here in {scene.LocationOfTheMission.WordText}, our resolve is tested, but it's also where we'll make our stand and triumph.",
                scene => $"Despite {scene.TheEnemyActions.WordText}, we have {scene.TheHeroesOfTheStory.WordText} among us. Their courage and wisdom will guide us through.",
                scene => $"The presence of {scene.TheUnknownFactors.WordText} might unsettle us, but our adaptability has always been our greatest strength.",
                scene => $"Looking at {scene.TheCurrentSituation.WordText}, it's easy to feel overwhelmed. Yet, it's just another chapter in our story—one we'll overcome together.",
                scene => $"In {scene.AMomentOfJoy.WordText}, let's remember why we fight. These moments remind us there's light even in the darkest times.",
                scene => $"Though {scene.TheBurdenCarriedByTheProtagonists.WordText} is heavy, it's our shared commitment that will see us through to the end.",
                scene => $"Our focus remains on {scene.TheMissionObjective.WordText}. Every step we take is a step towards that goal, no matter the obstacles.",
                scene => $"Learning of {scene.ATraitorInTheRanks.WordText} was a shock, but it has only strengthened our resolve. We'll move forward, more united than ever.",
                scene => $"Every {scene.APositiveTurnOfEvents.WordText} is a testament to our perseverance. It's these victories that pave our path to success.",
                scene => $"We may not all be in the limelight, but every effort, including those of {scene.TheUnsungHeroes.WordText}, brings us closer to our goal.",
                scene => $"Despite {scene.TheLossesWeHaveSuffered.WordText}, we carry on, for our resolve is fortified by memories and the will to see justice prevail.",
                scene => $"Facing {scene.TheInjusticeFaced.WordText} has never been easy, but it's our fight against such wrongs that defines us.",
                scene => $"The unveiling of {scene.TheMysteryUnfolding.WordText} may bring new challenges, but together, we're more than capable of solving them.",
                scene => $"Let's not forget {scene.TheAchievementsOfTheGroup.WordText}. Each victory, no matter how small, is a step towards our ultimate goal.",
                scene => $"As we reflect on {scene.TheBeforeAndAfter.WordText}, let's take pride in our journey. We've grown, and we'll continue to face what comes with strength and unity.",
                scene => $"Remember, every action we take, including {scene.ActionThatContributesToTheMission.WordText}, moves us closer to our goal. We're on the right path.",
                scene => $"Even at this {scene.TimeOfDay.WordText}, working with {scene.ActionObjectThatContributesToTheMission.WordText} ensures we're prepared for what's ahead. Trust in our efforts.",
                scene => $"Combining {scene.ActionThatContributesToTheMission.WordText} with {scene.ActionObjectThatContributesToTheMission.WordText} has always steered us in the right direction. We'll continue to make progress.",
                scene => $"Despite {scene.ARelatedNegativePastEvent.WordText}, our commitment to {scene.ActionThatContributesToTheMission.WordText} through {scene.ActionObjectThatContributesToTheMission.WordText} and ensuring {scene.ActionThatContributesToSafety.WordText} will prevent history from repeating itself.",
                scene => $"Our focus on {scene.ActionThatContributesToTheMission.WordText} is our strength. It's what will see us through these challenges.",
                scene => $"We've learned from {scene.ActionThatDetractsFromTheMission.WordText}. It's informed our strategy and will not hinder us again.",
                scene => $"The {scene.VictimsOfTheEnemy.WordText} need not fear {scene.AnEnemyOfTheMission.WordText} any longer. We're making strides to ensure their safety and security.",
                scene => $"Understanding {scene.TheMainCauseOfTheProblem.WordText} is the first step to overcoming it. We're closer to a solution than we think.",
                scene => $"The impact of {scene.TheImmediateEffectsOfTheProblem.WordText} won't last forever. We're working to mitigate it as we speak.",
                scene => $"Our base at {scene.ASaferLocation.WordText} remains secure, and with {scene.TheTimeLeftToCompleteTheMission.WordText} we have, I'm confident in our plan.",
                scene => $"Though we're reminded of {scene.ARelatedNegativePastEvent.WordText}, it's important to remember how far we've come since then.",
                scene => $"Yes, {scene.AnObstacleToTheMission.WordText} is daunting, but not insurmountable. We have strategies in place to overcome it.",
                scene => $"The status of {scene.TheMainCauseOfTheProblem.WordText} may seem dire, but we're making progress every day towards resolving it.",
                scene => $"Despite {scene.TheMentalStateOfTheEnemy.WordText}, remember that we have our own strengths and strategies. We are not powerless.",
                scene => $"Knowing the {scene.LocationOfTheEnemy.WordText} gives us the advantage. We can anticipate their moves and plan accordingly.",
                scene => $"Even with {scene.AnImmediateDangerToTheProtagonists.WordText} looming, we've prepared measures to protect ourselves and counteract the threat."
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
                scene => $"Duly noted, we'll adjust our plans accordingly.",
                scene => $"I recognize that {scene.ActionThatDetractsFromTheMission.WordText} wasn't ideal, but let's focus on moving forward.",
                scene => $"It's clear now that {scene.TheMainCauseOfTheProblem.WordText} is at the heart of our challenges. We must address this head-on.",
                scene => $"Your efforts to {scene.ActionThatContributesToTheMission.WordText} and {scene.AnotherActionThatContributesToTheMission.WordText} have been pivotal to our progress.",
                scene => $"Finding {scene.ACriticalClue.WordText} has shed light on {scene.TheImmediateEffectsOfTheProblem.WordText}, bringing us closer to a solution.",
                scene => $"We've all witnessed {scene.TheEnemyActions.WordText}. It's crucial we learn from these encounters to better counter our adversary.",
                scene => $"The revelation of {scene.TheMysteryUnfolding.WordText} has been a turning point for us all, offering new insights and directions.",
                scene => $"The chaos caused by {scene.TheChaosCausedByTheEnemy.WordText} has tested us, yet here we stand, more united than ever.",
                scene => $"We must never forget {scene.TheLossesWeHaveSuffered.WordText}. It fuels our resolve to push forward and honor their memory.",
                scene => $"Understanding {scene.AnUmbrellaTermThatDescribesTheNatureOfTheEnemy.WordText} gives us a clearer perspective on our enemy's motives and tactics.",
                scene => $"Let's not underestimate the safety {scene.ASaferLocation.WordText} provides us. It's a haven that allows us to regroup and strategize.",
                scene => $"Maintaining {scene.TheIdealMentalStateForTheMission.WordText} amidst these trials speaks volumes of our resilience and determination.",
                scene => $"The weight of {scene.TheBurdenCarriedByTheProtagonists.WordText} is something we all share. It's what makes this team so formidable.",
                scene => $"With {scene.TheTimeLeftToCompleteTheMission.WordText} against us, every moment counts. Let's make them all matter.",
                scene => $"The recent {scene.APositiveTurnOfEvents.WordText} has been a much-needed boost for our morale. Let's build on this momentum."
            };
            this.expositions.Add(SentencePurposeType.Acknowledge, acknowledge);

            var expressDisdain = new List<Func<Scene, string>>
            {
                scene => $"I can't believe this!",
                scene => $"I can't believe this! We're in this mess because of you!",
                scene => $"I can't believe this! You're the reason we're in this mess!",
                scene => $"I can't believe you did that!",
                scene => $"This is unfathomable! To think {scene.AnImmediateDangerToTheMission.WordText} could have been avoided with a bit of foresight.",
                scene => $"How could you overlook {scene.APossibleProblemToAvoid.WordText}? It was right in front of us!",
                scene => $"After everything, to be thwarted by {scene.AnObstacleToTheMission.WordText}? It's inexcusable!",
                scene => $"To think that {scene.AMistakeMadeByTheProtagonists.WordText} could lead us here. What were we thinking?",
                scene => $"All this effort, for what? To be caught unprepared by {scene.TheChaosCausedByTheEnemy.WordText}?",
                scene => $"It's hard to believe {scene.TheEnemy.WordText} got the better of us. We should have seen this coming.",
                scene => $"The oversight on {scene.ACriticalDetailMissed.WordText} is astounding. We're paying the price now.",
                scene => $"Your decision to {scene.AControversialDecisionMade.WordText} has brought us nothing but trouble. I hope it was worth it."
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
                scene => $"What do we know about {scene.TheEnemy.WordText}'s intentions?",
                scene => $"Can someone explain why {scene.TheMainCauseOfTheProblem.WordText} is critical to our mission?",
                scene => $"How close are we to achieving {scene.TheGoalOfTheMission.WordText}?",
                scene => $"What risks are associated with {scene.APlanToSucceedAtMission.WordText}?",
                scene => $"Are there any updates on {scene.TheStatusOfTheMainCauseOfTheProblem.WordText}?",
                scene => $"How can we counter {scene.AnEnemyOfTheMission.WordText}'s strategy?",
                scene => $"What measures are in place to protect {scene.ProtagonistsForTheMission.WordText} from {scene.AnImmediateDangerToTheMission.WordText}?",
                scene => $"How has {scene.TheMentalStateOfTheEnemy.WordText} influenced their tactics?",
                scene => $"Is there a way to turn {scene.AnObstacleToTheMission.WordText} into an advantage?",
                scene => $"What's the impact of {scene.TheImmediateEffectsOfTheProblem.WordText} on our current strategy?",
                scene => $"How reliable is the information about {scene.LocationOfTheEnemy.WordText}?",
                scene => $"What alternatives do we have if {scene.APlanToSucceedAtMission.WordText} fails?",
                scene => $"How can we better understand {scene.VictimsOfTheEnemy.WordText}'s needs?",
                scene => $"What's our contingency plan for dealing with {scene.AnImmediateDangerToTheProtagonists.WordText}?",
                scene => $"How will {scene.TheTimeLeftToCompleteTheMission.WordText} affect our decision-making?",
                scene => $"Can {scene.HelpfulEntitiesForTheMission.WordText} provide the support we need right now?",
                scene => $"What's the significance of {scene.TheMysteryUnfolding.WordText} to our mission's success?",
                scene => $"How can we mitigate the effects of {scene.TheChaosCausedByTheEnemy.WordText}?",
                scene => $"What's the best way to approach {scene.TheSurvivors.WordText} for information?",
                scene => $"How can we use {scene.TheAchievementsOfTheGroup.WordText} to inspire confidence in our team?",
                scene => $"How do we ensure {scene.ActionThatContributesToSafety.WordText} without compromising our position?",
                scene => $"What's our next step to {scene.ActionThatContributesToTheMission.WordText}, and how can we execute it effectively?",
                scene => $"Considering our plan to {scene.ActionThatContributesToTheMission.WordText}, what happens if we fail and face {scene.AFateIfTheMissionFails.WordText}?",
                scene => $"Can someone clarify how {scene.ActionThatDetractsFromTheMission.WordText} could impact our mission?",
                scene => $"In light of {scene.ActionThatDetractsFromTheMission.WordText}, how do we adjust to maintain {scene.TheIdealStrategyForTheMission.WordText}?",
                scene => $"How do we overcome {scene.AnOverwhelmingChallenge.WordText} with our current resources?",
                scene => $"What strategies can we employ against {scene.AnUmbrellaTermThatDescribesTheNatureOfTheEnemy.WordText} to gain an upper hand?",
                scene => $"Has anyone assessed how {scene.AnUnexpectedAlly.WordText} could change the dynamics of our mission?",
                scene => $"With {scene.AnUnexpectedAlly.WordText} appearing in {scene.LocationOfTheMission.WordText}, how does this alter our approach?",
                scene => $"How did {scene.APastEventMirroringTheCurrentMission.WordText} influence {scene.AnActionThatLedToSuccess.WordText}, and can we apply similar tactics?",
                scene => $"What steps should we take to ensure {scene.APositiveTurnOfEvents.WordText} continues in our favor?",
                scene => $"What actions are critical to maintaining {scene.APriorityForTheMission.WordText} as we progress?",
                scene => $"How has {scene.ARelatedNegativePastEvent.WordText} shaped our current strategy?",
                scene => $"Given {scene.ARelatedNegativePastEvent.WordText}, how should we adjust to avoid {scene.ActionThatDetractsFromTheMission.WordText}?",
                scene => $"If we retreat to {scene.ASaferLocation.WordText}, what are the chances we'll encounter {scene.AFateIfTheMissionFails.WordText}?",
                scene => $"How can {scene.ASkillOfTheProtagonists.WordText} help us uncover {scene.ACriticalClue.WordText}?",
                scene => $"How do we address {scene.AThreatOfTheEnemy.WordText} while also considering {scene.TheNeedsOfTheEnemy.WordText}?",
                scene => $"Has anyone else suspected {scene.ATraitorInTheRanks.WordText}, and how do we confirm their identity without causing panic?",
                scene => $"How do we avoid {scene.ATrapForTheProtagonists.WordText} that's been set for us?",
                scene => $"What's the best way to utilize {scene.AWeaponAgainstTheEnemy.WordText} to ensure our victory?",
                scene => $"Can {scene.FriendsOfTheProtagonists.WordText} provide the support we need at this critical moment?",
                scene => $"How can {scene.ObjectThatAssistsTheMission.WordText} be used to further our mission?",
                scene => $"Where can we find {scene.ObjectYouAreLookingFor.WordText}, and how does it relate to {scene.AWayToEscape.WordText}?",
                scene => $"What is the current {scene.StatusOfTheMission.WordText}, and how do we improve it?",
                scene => $"How has {scene.StatusOfTheObstacleToTheMission.WordText} changed our approach to the mission?",
                scene => $"In light of {scene.TheBattle.WordText}, how has {scene.LocationOfTheMission.WordText} been affected?",
                scene => $"Can someone explain {scene.TheBeforeAndAfter.WordText} and its impact on us?",
                scene => $"What does {scene.TheBurdenCarriedByTheProtagonists.WordText} mean for our team?",
                scene => $"Given {scene.TheEnemyActions.WordText}, have we identified {scene.AWeakness.WordText} that we can exploit?",
                scene => $"What steps are we taking toward achieving {scene.TheIdealFutureStateOfTheMission.WordText}?",
                scene => $"How close are we to maintaining {scene.TheIdealMentalStateForTheMission.WordText} under these pressures?",
                scene => $"How do we honor {scene.TheLossesWeHaveSuffered.WordText} and move forward?",
                scene => $"What's our strategy for accomplishing {scene.TheMissionObjective.WordText}?",
                scene => $"Has anyone else heard {scene.TheSoundOfTheEnemy.WordText}, and what do you think it means?",
                scene => $"Who are {scene.TheUnsungHeroes.WordText}, and how can we acknowledge their contributions?",
                scene => $"How do {scene.TheUnsungHeroes.WordText} and {scene.TheMissionObjective.WordText} align with our current priorities?",
                scene => $"During {scene.TimeOfDay.WordText}, how does {scene.TheSoundOfTheEnemy.WordText} affect our operations?",
                scene => $"Considering what hinges on the success of our mission, how do we address {scene.ActionThatDetractsFromTheMission.WordText}?"
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
                scene => $"Given {scene.TheMainCauseOfTheProblem.WordText}, how can we mitigate the effects and move forward?",
                scene => $"Considering {scene.TheEnemy.WordText}'s recent actions, how should we adapt our strategy?",
                scene => $"How do we address the issue of {scene.AnObstacleToTheMission.WordText} effectively?",
                scene => $"In light of {scene.TheImmediateEffectsOfTheProblem.WordText}, what are our priorities?",
                scene => $"How can we leverage {scene.ObjectThatAssistsTheMission.WordText} to our advantage in this scenario?",
                scene => $"What's our contingency plan if {scene.AnImmediateDangerToTheMission.WordText} materializes?",
                scene => $"How should we approach {scene.TheEnemy.WordText} to avoid escalating the conflict?",
                scene => $"Given our current resources, what's the most effective way to {scene.ActionThatContributesToTheMission.WordText}?",
                scene => $"How can we ensure the safety of {scene.ProtagonistsForTheMission.WordText} while dealing with {scene.AnImmediateDangerToTheProtagonists.WordText}?",
                scene => $"Is there a way to turn {scene.AnUnexpectedEvent.WordText} to our advantage?",
                scene => $"With {scene.TheTimeLeftToCompleteTheMission.WordText} running out, how can we accelerate our efforts?",
                scene => $"Considering {scene.TheChaosCausedByTheEnemy.WordText}, how can we restore order to {scene.LocationOfTheMission.WordText}?",
                scene => $"How do we best utilize {scene.HelpfulEntitiesForTheMission.WordText} in our current situation?",
                scene => $"Should we reconsider our stance on {scene.ARejectedPlanOfTheMission.WordText} given the new developments?",
                scene => $"What measures can we take to better understand {scene.TheUnknownFactors.WordText} affecting our mission?",
                scene => $"Given our goal to {scene.ActionThatContributesToSafety.WordText}, what's the best approach to ensure everyone's safety without compromising our mission?",
                scene => $"How can we avoid actions that {scene.ActionThatDetractsFromTheMission.WordText}, ensuring we remain focused on our objectives?",
                scene => $"Facing {scene.AnEnemyOfTheMission.WordText} in {scene.LocationOfTheEnemy.WordText}, what strategies should we consider to counter their movements effectively?",
                scene => $"Considering {scene.AnEnemyOfTheMission.WordText}'s current {scene.TheMentalStateOfTheEnemy.WordText}, what advice do you have for engaging them without escalating the conflict?",
                scene => $"How can we best tackle {scene.AnOverwhelmingChallenge.WordText}, given its scale and impact on our mission?",
                scene => $"In dealing with {scene.AnUmbrellaTermThatDescribesTheNatureOfTheEnemy.WordText}, what insights can you offer to help us understand and overcome this threat?",
                scene => $"How should we integrate {scene.AnUnexpectedAlly.WordText} into our plans, leveraging their support without exposing vulnerabilities?",
                scene => $"Reflecting on {scene.APastEventMirroringTheCurrentMission.WordText} and {scene.AnActionThatLedToSuccess.WordText}, what lessons can we apply to our current situation?",
                scene => $"With {scene.APositiveTurnOfEvents.WordText} unfolding, how can we capitalize on this momentum?",
                scene => $"What should be our focus, considering {scene.APriorityForTheMission.WordText} is at stake?",
                scene => $"Between choosing {scene.ASaferLocation.WordText} and facing {scene.AFateIfTheMissionFails.WordText}, what's the wisest course of action?",
                scene => $"Given our {scene.ASkillOfTheProtagonists.WordText} and this {scene.ACriticalClue.WordText}, how should we proceed to leverage these effectively?",
                scene => $"How do we address {scene.AThreatOfTheEnemy.WordText} while also considering {scene.TheNeedsOfTheEnemy.WordText} to find a peaceful resolution?",
                scene => $"What's the best way to navigate or dismantle {scene.ATrapForTheProtagonists.WordText}, minimizing risks to our team?",
                scene => $"How can {scene.FriendsOfTheProtagonists.WordText} provide support in our current predicament?",
                scene => $"In seeking {scene.ObjectYouAreLookingFor.WordText}, how might we also find {scene.AWayToEscape.WordText}, ensuring a safe retreat?",
                scene => $"Can you help us understand the implications of {scene.TheBeforeAndAfter.WordText} for our mission's strategy?",
                scene => $"How do we carry {scene.TheBurdenCarriedByTheProtagonists.WordText} while keeping morale high and staying focused on our goals?",
                scene => $"With {scene.TheEnemyActions.WordText} revealing {scene.AWeakness.WordText}, how can we exploit this without exposing ourselves to greater danger?",
                scene => $"What steps should we take to achieve {scene.TheGoalOfTheMission.WordText} while ensuring the wellbeing of our team?",
                scene => $"What vision do we have for {scene.TheIdealFutureStateOfTheMission.WordText}, and how can we make it a reality?",
                scene => $"How can we maintain {scene.TheIdealMentalStateForTheMission.WordText} amidst the challenges we're facing?",
                scene => $"In light of {scene.TheLossesWeHaveSuffered.WordText}, how can we find strength and continue our mission?",
                scene => $"What are the key actions we must take to fulfill {scene.TheMissionObjective.WordText}?",
                scene => $"Faced with {scene.TheMysteryUnfolding.WordText}, what {scene.AnActionToUncoverSecrets.WordText} should we undertake to reveal the truth?",
                scene => $"How can we best assist {scene.VictimsOfTheEnemy.WordText}, ensuring they're not forgotten in our mission's objectives?"
            };
            this.expositions.Add(SentencePurposeType.SeekAdvice, seekAdvice);


            var hypothesize = new List<Func<Scene, string>>
            {
                scene => $"What if we could {scene.ActionThatContributesToTheMission.WordText}?",
                scene => $"Imagine if {scene.ACriticalClue.WordText} led us to a way to {scene.ActionThatContributesToTheMission.WordText} without {scene.AnObstacleToTheMission.WordText}.",
                scene => $"Could we potentially {scene.ActionThatContributesToTheMission.WordText} by leveraging {scene.TheUnknownFactors.WordText}?",
                scene => $"What if {scene.TheEnemy.WordText}’s weakness is actually {scene.AHiddenActionOfTheProtagonists.WordText}? How can we exploit this?",
                scene => $"Is it possible that {scene.APositiveTurnOfEvents.WordText} could help us {scene.ActionThatContributesToTheMission.WordText} sooner than expected?",
                scene => $"What if our approach to {scene.TheChaosCausedByTheEnemy.WordText} is all wrong? Could {scene.APlanToSucceedAtMission.WordText} offer a better solution?",
                scene => $"Could we use {scene.AWeaponOfTheEnemy.WordText} against them, turning their strength into their downfall?",
                scene => $"What if the key to {scene.TheGoalOfTheMission.WordText} lies hidden in {scene.LocationOfTheMission.WordText}, waiting to be discovered?",
                scene => $"If we reassess {scene.TheMainCauseOfTheProblem.WordText}, might we find a more effective way to {scene.ActionThatContributesToTheMission.WordText}?",
                scene => $"What if the secret to overcoming {scene.AnObstacleToTheMission.WordText} is not in direct confrontation, but in {scene.PossibleSolutionToConsider.WordText}?",
                scene => $"Could {scene.TheIdealMentalStateForTheMission.WordText} be the missing piece in our strategy to {scene.ActionThatContributesToTheMission.WordText}?",
                scene => $"What if {scene.TheUnsungHeroes.WordText} hold the answer to {scene.TheMysteryUnfolding.WordText} that we've overlooked?",
                scene => $"Might {scene.TheBurdenCarriedByTheProtagonists.WordText} be lessened if we find a way to {scene.AnotherActionThatContributesToTheMission.WordText}?",
                scene => $"What if the true path to {scene.TheIdealFutureStateOfTheMission.WordText} is through {scene.APlanToSucceedAtMission.WordText}, previously considered too risky?",
                scene => $"Is it conceivable that {scene.TheLossesWeHaveSuffered.WordText} could motivate us to find a novel solution, like {scene.PossibleSolutionToConsider.WordText}?",
                scene => $"What if using {scene.ActionObjectThatContributesToTheMission.WordText} could also enhance our safety measures?",
                scene => $"Could {scene.ActionThatContributesToSafety.WordText} inadvertently lead us away from our main objective?",
                scene => $"Imagine if {scene.ActionThatDetractsFromTheMission.WordText} was actually a diversion, steering us away from realizing {scene.AFateIfTheMissionFails.WordText}.",
                scene => $"What if the key to avoiding {scene.AFateIfTheMissionFails.WordText} lies in focusing on {scene.ASuccessFactorOfTheMission.WordText}?",
                scene => $"Could there be a moment, amidst our struggles, where {scene.AMomentOfJoy.WordText} signals a turning point?",
                scene => $"What if {scene.AnEnemyOfTheMission.WordText} is not our true adversary but a distraction from a larger threat?",
                scene => $"Suppose {scene.AnEnemyOfTheMission.WordText} is using {scene.LocationOfTheEnemy.WordText} as a strategic point for something unexpected?",
                scene => $"Could the erratic behavior of {scene.AnEnemyOfTheMission.WordText} be due to {scene.TheMentalStateOfTheEnemy.WordText}, affecting their decisions?",
                scene => $"What if the real danger to us isn't the enemy upfront but {scene.AnImmediateDangerToTheProtagonists.WordText} lurking in the shadows?",
                scene => $"Is it possible that {scene.AnOverwhelmingChallenge.WordText} is exactly what we need to bring us together and push us forward?",
                scene => $"What if our understanding of {scene.AnUmbrellaTermThatDescribesTheNatureOfTheEnemy.WordText} is flawed, and we're missing the true nature of our foe?",
                scene => $"Could {scene.AnUnexpectedAlly.WordText} emerge from a place we least expect, turning the tides in our favor?",
                scene => $"What if the events of {scene.APastEvent.WordText} and the unfolding {scene.TheMystery.WordText} are closely connected, leading us to an overlooked truth?",
                scene => $"Suppose {scene.APastEventMirroringTheCurrentMission.WordText} holds the clue to {scene.AnActionThatLedToSuccess.WordText} now?",
                scene => $"What if our entire approach should be reevaluated to prioritize {scene.APriorityForTheMission.WordText} above all else?",
                scene => $"Could the events of {scene.ARelatedNegativePastEvent.WordText} be repeating themselves, but with a chance for us to alter the outcome this time?",
                scene => $"What if retreating to {scene.ASaferLocation.WordText} doesn't save us from {scene.AFateIfTheMissionFails.WordText}, but instead, seals our doom?",
                scene => $"Could the solution to {scene.TheProblem.WordText} be hidden in plain sight, and somehow involve finding refuge in {scene.ASaferLocation.WordText}?",
                scene => $"What if the true success factor of our mission isn't what we've been focusing on, but something more fundamental?",
                scene => $"Is it possible that understanding {scene.AThreatOfTheEnemy.WordText} and {scene.TheNeedsOfTheEnemy.WordText} could offer us an unexpected advantage?",
                scene => $"What if {scene.ATraitorInTheRanks.WordText} is right among us, subtly undermining our efforts?",
                scene => $"Could {scene.ATrapForTheProtagonists.WordText} actually be a test, meant to strengthen our resolve and unity?",
                scene => $"What if the key to overcoming our current predicament involves rallying {scene.FriendsOfTheProtagonists.WordText} in a way we haven't before?",
                scene => $"Suppose the assistance we've been overlooking from {scene.HelpfulEntitiesForTheMission.WordText} is the missing piece of our puzzle?",
                scene => $"What if the {scene.ObjectYouAreLookingFor.WordText} isn't just crucial for our mission but also holds the secret to {scene.AWayToEscape.WordText}?",
                scene => $"What if our {scene.PreparationForTheMission.WordText} is the key to anticipating {scene.AnImmediateDangerToTheMission.WordText}?",
                scene => $"Could {scene.ProtagonistsForTheMission.WordText} use {scene.ASaferLocation.WordText} as leverage against potential threats?",
                scene => $"Might the current {scene.StatusOfTheMission.WordText} suggest a pivot in our strategy to capitalize on unforeseen opportunities?",
                scene => $"What if {scene.TheAchievementsOfTheGroup.WordText} set a precedent that could influence our next steps?",
                scene => $"Is it possible that understanding {scene.TheBeforeAndAfter.WordText} could offer insights into overcoming our current challenges?",
                scene => $"Could our interpretation of {scene.TheCurrentSituation.WordText} be missing a critical perspective?",
                scene => $"What if {scene.TheEnemyActions.WordText} reveal a {scene.AWeakness.WordText} we haven't yet exploited?",
                scene => $"Suppose {scene.TheEnemyActions.WordText} are actually misdirecting us from recognizing the true {scene.TheHeroesOfTheStory.WordText} among us.",
                scene => $"What if the {scene.TheImmediateEffectsOfTheProblem.WordText} are misleading, diverting us from a more significant underlying issue?",
                scene => $"Could our struggle against {scene.TheInjusticeFaced.WordText} be the catalyst for a greater transformation within our ranks?",
                scene => $"What if {scene.TheMentalStateOfTheEnemy.WordText} is their undoing, leading to rash decisions we can anticipate?",
                scene => $"Might focusing solely on {scene.TheMissionObjective.WordText} blind us to alternative paths to victory?",
                scene => $"Could the {scene.ThePhysicalStateOfTheProtagonists.WordText} be a barometer for our chances of success, signaling when to advance or retreat?",
                scene => $"What if {scene.TheSoundOfTheEnemy.WordText} is a clue, hinting at their next move or current weakness?",
                scene => $"Suppose the {scene.TheStatusOfTheMainCauseOfTheProblem.WordText} isn't as stable as we thought. Could there be a way to turn this to our advantage?",
                scene => $"Is it possible that {scene.TheSurvivors.WordText} hold the key to unraveling the enemy's plans?",
                scene => $"What if our perception of {scene.TheTimeLeftToCompleteTheMission.WordText} is flawed, and we have more—or less—time than we think?",
                scene => $"Could understanding the plight of {scene.VictimsOfTheEnemy.WordText} offer us a new perspective on how to approach the mission?",
                scene => $"What if the location of {scene.VictimsOfTheEnemy.WordText} in {scene.LocationOfTheVictim.WordText} is strategic, revealing something vital about our enemy's intentions?",
                scene => $"Might what hinges on the success of our mission be different from what we've assumed, requiring a reassessment of our priorities?"
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
                scene => $"Given the {scene.StatusOfTheMission.WordText}, it's crucial we act now to maintain our momentum.",
                scene => $"At {scene.LocationOfTheMission.WordText}, where {scene.TheMainCauseOfTheProblem.WordText} has taken root, our efforts must be focused and deliberate.",
                scene => $"In {scene.LocationOfTheMission.WordText}, facing {scene.TheEnemy.WordText} amidst {scene.TheChaosCausedByTheEnemy.WordText}, our priority is to establish order and safety.",
                scene => $"As {scene.TimeOfDay.WordText} approaches, addressing {scene.TheImmediateEffectsOfTheProblem.WordText} cannot wait. Immediate action is required.",
                scene => $"Considering {scene.TheMentalStateOfTheEnemy.WordText}, it's imperative we adjust our strategies to outmaneuver them effectively.",
                scene => $"To {scene.ASaferLocation.WordText}, everyone. {scene.AnImmediateDangerToTheMission.WordText} is too great to ignore at our current position.",
                scene => $"With only {scene.TheTimeLeftToCompleteTheMission.WordText} left and facing {scene.AnObstacleToTheMission.WordText}, we must intensify our efforts.",
                scene => $"The {scene.StatusOfTheObstacleToTheMission.WordText} demands our immediate attention. Let's strategize our next steps carefully.",
                scene => $"{scene.ProtagonistsForTheMission.WordText}, our focus must remain on achieving {scene.TheGoalOfTheMission.WordText}. Let's reassess our approach to ensure success.",
                scene => $"The moment we hear {scene.TheSoundOfTheEnemy.WordText}, we must act, knowing what hinges on the success of our mission.",
                scene => $"At {scene.TimeOfDay.WordText} in {scene.LocationOfTheMission.WordText}, we'll confront {scene.TheMysteryUnfolding.WordText}. Prepare yourselves.",
                scene => $"Reflect on {scene.TheBeforeAndAfter.WordText}. Understanding our journey will guide our future actions.",
                scene => $"Let's honor {scene.TheUnsungHeroes.WordText} by embodying their spirit and dedication in every task we undertake.",
                scene => $"Our actions today will shape {scene.TheIdealFutureStateOfTheMission.WordText}. Let's proceed with that vision clearly in our minds.",
                scene => $"Be vigilant. {scene.ATraitorInTheRanks.WordText} among us means trust must be earned, and precautions taken.",
                scene => $"Secure the perimeter around {scene.LocationOfTheEnemy.WordText} to contain {scene.AnEnemyOfTheMission.WordText}. We can't let them advance.",
                scene => $"Evacuate everyone from the area immediately. {scene.AnImmediateDangerToTheProtagonists.WordText} is too great to ignore.",
                scene => $"Intercept any communications about {scene.AThreatOfTheEnemy.WordText}. Understanding {scene.TheNeedsOfTheEnemy.WordText} is key to anticipating their next move.",
                scene => $"Implement {scene.ActionThatContributesToSafety.WordText} protocols at once. We need to safeguard our position.",
                scene => $"Rally {scene.FriendsOfTheProtagonists.WordText} for backup. We're going to need all the help we can get.",
                scene => $"Focus all efforts on achieving {scene.TheMissionObjective.WordText}. It's imperative for our success.",
                scene => $"Prepare to face {scene.AnOverwhelmingChallenge.WordText}. This will test our limits, but we must overcome.",
                scene => $"Prioritize the rescue of {scene.VictimsOfTheEnemy.WordText}. Their safety is non-negotiable.",
                scene => $"Keep {scene.APriorityForTheMission.WordText} at the forefront of all decisions. It's what will guide us through.",
                scene => $"Coordinate with {scene.HelpfulEntitiesForTheMission.WordText} for logistical support. Their expertise is invaluable.",
                scene => $"Utilize {scene.ASkillOfTheProtagonists.WordText} to uncover {scene.ACriticalClue.WordText}. It's our best shot at getting ahead.",
                scene => $"Be vigilant for {scene.ATrapForTheProtagonists.WordText}. It's crucial we avoid any entanglements.",
                scene => $"Reflect on {scene.APastEventMirroringTheCurrentMission.WordText} and replicate {scene.AnActionThatLedToSuccess.WordText}. History has valuable lessons for us.",
                scene => $"Counter {scene.TheEnemyActions.WordText} by exploiting their {scene.AWeakness.WordText}. It's time to turn the tables.",
                scene => $"Engage {scene.AnUnexpectedAlly.WordText} in our efforts. Their unexpected support could be decisive.",
                scene => $"Cease any {scene.ActionThatDetractsFromTheMission.WordText}. It's counterproductive and jeopardizes our objectives.",
                scene => $"Honor {scene.TheLossesWeHaveSuffered.WordText} by doubling our efforts. Their sacrifices cannot be in vain.",
                scene => $"Adapt our strategy to counter {scene.AnUmbrellaTermThatDescribesTheNatureOfTheEnemy.WordText}. It's essential for navigating this conflict.",
                scene => $"Foster {scene.TheIdealMentalStateForTheMission.WordText} within the team. A focused mind is our greatest asset.",
                scene => $"Acknowledge {scene.TheBurdenCarriedByTheProtagonists.WordText}. Offering support where needed strengthens us all.",
                scene => $"Leverage {scene.APositiveTurnOfEvents.WordText} to our advantage. Momentum is on our side; let's use it."
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
                scene => $"Absolutely, that's the course we need to take.",
                scene => $"Your insight is spot on; it aligns perfectly with our goals.",
                scene => $"That strategy aligns with our mission's objectives. Let's proceed.",
                scene => $"Indeed, focusing on {scene.APriorityForTheMission.WordText} is essential for our success.",
                scene => $"You've nailed it. {scene.TheGoalOfTheMission.WordText} is exactly what we should be aiming for.",
                scene => $"Yes, that aligns with everything we've been working towards. {scene.ActionThatContributesToTheMission.WordText} will get us there.",
                scene => $"Your perspective brings clarity. We should definitely incorporate {scene.ACriticalClue.WordText} into our plan.",
                scene => $"Concur. Leveraging {scene.ActionObjectThatContributesToTheMission.WordText} could be our best move yet.",
                scene => $"Right, taking action now is imperative. {scene.ActionThatContributesToTheMission.WordText} is our best next step.",
                scene => $"Agreed, our priority should be to {scene.ActionThatContributesToTheMission.WordText}. It's crucial for navigating {scene.TheChaosCausedByTheEnemy.WordText}.",
                scene => $"I agree, pursuing {scene.ActionThatDetractsFromTheMission.WordText} would only set us back. We need to stay focused.",
                scene => $"Exactly, facing {scene.TheEnemy.WordText} without considering {scene.AWeaponOfTheEnemy.WordText} and their presence in {scene.LocationOfTheEnemy.WordText} would be unwise.",
                scene => $"You're right. We must prioritize the safety of {scene.VictimsOfTheEnemy.WordText}, especially considering their current location at {scene.LocationOfTheVictim.WordText}.",
                scene => $"Indeed, {scene.AnObstacleToTheMission.WordText} and its {scene.StatusOfTheObstacleToTheMission.WordText} cannot be ignored. We need a solid plan to overcome it.",
                scene => $"I concur. Understanding the enemy's movements, especially in {scene.LocationOfTheEnemy.WordText}, is crucial for our success.",
                scene => $"Absolutely, {scene.TheMainCauseOfTheProblem.WordText} and its manifestation in {scene.LocationOfTheMission.WordText} are at the heart of our mission.",
                scene => $"Precisely. Our strategy must exploit {scene.AWeakness.WordText} of {scene.TheEnemy.WordText} in {scene.LocationOfTheMission.WordText} for us to succeed.",
                scene => $"Agreed. {scene.ASolution.WordText} to {scene.TheProblem.WordText} must lead us to {scene.ASaferLocation.WordText}, ensuring our victory.",
                scene => $"Indeed, reflecting on {scene.APastEvent.WordText} sheds light on {scene.TheMystery.WordText}, guiding our current decisions.",
                scene => $"Yes, the occurrence of {scene.ANaturalPhenomenon.WordText} in {scene.LocationOfTheMission.WordText} cannot be overlooked; it's pivotal to our planning.",
                scene => $"Exactly, {scene.APlanToSucceedAtMission.WordText} is our best course of action. It's essential for our mission's success.",
                scene => $"I couldn't agree more. {scene.TheStatusOfTheMainCauseOfTheProblem.WordText} necessitates immediate action from us all.",
                scene => $"Undoubtedly, confronting {scene.AnEnemyOfTheMission.WordText} is a critical step. We're aligned on the threat they pose.",
                scene => $"Certainly, the well-being of {scene.ProtagonistsForTheMission.WordText} amidst {scene.AnImmediateDangerToTheMission.WordText} is our top priority.",
                scene => $"Indeed, recognizing {scene.TheMentalStateOfTheEnemy.WordText} offers us insight into their potential actions.",
                scene => $"Absolutely, {scene.TheImmediateEffectsOfTheProblem.WordText} underscore the urgency of our mission.",
                scene => $"Right, we must protect ourselves against {scene.AnImmediateDangerToTheProtagonists.WordText}. It's imperative for our survival.",
                scene => $"Indeed, with {scene.TheTimeLeftToCompleteTheMission.WordText} dwindling, our actions must be swift and decisive.",
                scene => $"Correct, the support from {scene.HelpfulEntitiesForTheMission.WordText} is invaluable to us, especially now.",
                scene => $"Yes, unraveling {scene.TheMysteryUnfolding.WordText} is key to understanding the bigger picture of our mission.",
                scene => $"I agree, the resilience of {scene.TheSurvivors.WordText} inspires us all, reminding us of what we're fighting for.",
                scene => $"Absolutely, drawing on {scene.TheAchievementsOfTheGroup.WordText} fuels our determination and guides our path forward."
            };
            this.expositions.Add(SentencePurposeType.ExpressAgreement, expressAgreement);

            var offerAssistance = new List<Func<Scene, string>>
            {
                scene => $"I can help with that.",
                scene => $"We can send {scene.FriendsOfTheProtagonists.WordText} to help.",
                scene => $"I can help with that. I'm good at {scene.ASkillOfTheProtagonists.WordText}.",
                scene => $"I can help with that. I'm good at {scene.ASkillOfTheProtagonists.WordText}. I can {scene.ActionThatContributesToTheMission.WordText}.",
                scene => $"I'll {scene.ActionThatContributesToTheMission.WordText} the {scene.ActionObjectThatContributesToTheMission.WordText}.",
                scene => $"Hang tight! I've got a plan to get you out from {scene.ATrapForTheProtagonists.WordText}. Let's work together on this.",
                scene => $"Don't worry, I've faced {scene.AnObstacleToTheMission.WordText} before. I know exactly what we need to do.",
                scene => $"This looks like a job for someone with my skills. Let me take care of {scene.TheChaosCausedByTheEnemy.WordText} for you.",
                scene => $"I see you're in a tight spot with {scene.ATrapForTheProtagonists.WordText}. Let me help; I've learned a few tricks that might come in handy.",
                scene => $"We're not leaving anyone behind, especially not with {scene.TheEnemy.WordText} lurking around. I'll make sure of that.",
                scene => $"It sounds like you could use my expertise in {scene.ASkillOfTheProtagonists.WordText}. Let's tackle {scene.AnImmediateDangerToTheMission.WordText} together.",
                scene => $"I've been working on something that might just solve {scene.ACriticalClue.WordText}. Let me show you what I've got.",
                scene => $"Looks like you could use some backup. Consider me in. Together, we'll overcome {scene.AnOverwhelmingChallenge.WordText}.",
                scene => $"I've got some tools that are perfect for dealing with {scene.ATrapForTheProtagonists.WordText}. Let's put them to good use.",
                scene => $"Facing {scene.AnImmediateDangerToTheMission.WordText} alone is too risky. Let me add my strength to yours; we're stronger together.",
                scene => $"I can provide support for {scene.VictimsOfTheEnemy.WordText}. Let's ensure they have everything they need to recover and fight back.",
                scene => $"I've developed a strategy to counter {scene.AnEnemyOfTheMission.WordText} and their {scene.ASkillOfTheEnemy.WordText}. Let me share this with the team.",
                scene => $"Let me focus on enhancing {scene.ASuccessFactorOfTheMission.WordText}. It's crucial for our mission's success, and I have a few ideas that could make a significant difference.",
                scene => $"Considering {scene.ANegativeFactorThatNecessitatedTheMission.WordText} and our current location in {scene.LocationOfTheMission.WordText}, I can offer insights and resources to mitigate these challenges.",
                scene => $"I understand what hinges on the success of our mission. Allow me to contribute my skills and knowledge to ensure {scene.WhatHingesOnTheSuccessOfTheMission.WordText} is preserved and advanced.",
                scene => $"I've arranged for aid and shelter for {scene.VictimsOfTheEnemy.WordText} found at {scene.LocationOfTheVictim.WordText}. We'll ensure they're safe and supported through this ordeal.",
                scene => $"Given {scene.TheMainCauseOfTheProblem.WordText} affecting {scene.LocationOfTheMission.WordText}, I propose a coordinated effort to address this issue directly at its source.",
                scene => $"I have a potential solution for {scene.TheProblem.WordText}. Let's gather at {scene.ASaferLocation.WordText} to discuss how we can implement this effectively and ensure everyone's safety.",
                scene => $"Reflecting on {scene.APastEvent.WordText}, it's clear we're facing a similar mystery here. I believe I can offer insights that might help us unravel {scene.TheMystery.WordText}.",
                scene => $"With the impending {scene.ANaturalPhenomenon.WordText} threatening {scene.LocationOfTheMission.WordText}, I've begun coordinating emergency measures to mitigate the impact and protect our team.",
                scene => $"Let me help us reach {scene.TheGoalOfTheMission.WordText}. I've got some ideas that could propel us forward.",
                scene => $"I've been working on {scene.APlanToSucceedAtMission.WordText}. Allow me to fine-tune it with the team to ensure its success.",
                scene => $"Given {scene.TheStatusOfTheMainCauseOfTheProblem.WordText}, I can offer insights to better navigate our challenges.",
                scene => $"Understanding {scene.TheMentalStateOfTheEnemy.WordText} is key. I can help devise tactics that exploit their weaknesses.",
                scene => $"I've seen the {scene.TheImmediateEffectsOfTheProblem.WordText} first-hand. Let me assist in addressing these issues directly.",
                scene => $"I can refine {scene.APlanToSucceedAtMission.WordText} with a fresh perspective, focusing on efficiency and effectiveness.",
                scene => $"To combat {scene.AnImmediateDangerToTheProtagonists.WordText}, I propose a proactive approach that I'm ready to lead.",
                scene => $"With only {scene.TheTimeLeftToCompleteTheMission.WordText} remaining, I can help us prioritize tasks to maximize our efforts.",
                scene => $"{scene.HelpfulEntitiesForTheMission.WordText} have resources we haven't tapped into yet. I'll coordinate with them for support.",
                scene => $"I have some thoughts on {scene.TheMysteryUnfolding.WordText} that could shed light on our situation. Let's discuss this further.",
                scene => $"Supporting {scene.TheSurvivors.WordText} is something I can take on. Ensuring their well-being could offer us invaluable insights.",
                scene => $"Leveraging {scene.TheAchievementsOfTheGroup.WordText}, I can help highlight our strengths and apply them to our current strategy.",
                scene => $"Let me help by {scene.ActionThatContributesToSafety.WordText}. It's the best way to ensure everyone's safety.",
                scene => $"I have a plan to counteract {scene.ActionThatDetractsFromTheMission.WordText}. Let's discuss how we can adjust our strategy.",
                scene => $"I noticed {scene.AMomentOfJoy.WordText} amidst the chaos. Let's use this as a morale booster for our team.",
                scene => $"Understanding {scene.AnUmbrellaTermThatDescribesTheNatureOfTheEnemy.WordText} is key. I can offer insights to better prepare us for what's ahead.",
                scene => $"I've been in contact with {scene.AnUnexpectedAlly.WordText}. They're willing to offer assistance. Let's see how they can help us.",
                scene => $"Remember {scene.APastEventMirroringTheCurrentMission.WordText}? I believe it's crucial for our current situation. Let's learn from it.",
                scene => $"Reflecting on {scene.APastEventMirroringTheCurrentMission.WordText} and {scene.AnActionThatLedToSuccess.WordText}, I see a clear path forward for us.",
                scene => $"With {scene.APositiveTurnOfEvents.WordText} on the horizon, I'm here to help steer us towards it. Let's work together on this.",
                scene => $"Focusing on {scene.APriorityForTheMission.WordText} is essential. I'll take the lead on this to ensure we remain aligned with our goals.",
                scene => $"I've reconsidered {scene.ARejectedPlanOfTheMission.WordText}. Let's collaborate to find a better approach.",
                scene => $"In light of {scene.ARelatedNegativePastEvent.WordText}, I offer my expertise to prevent a recurrence.",
                scene => $"Given {scene.AThreatOfTheEnemy.WordText} and understanding {scene.TheNeedsOfTheEnemy.WordText}, I can devise a plan to safeguard us.",
                scene => $"We must address {scene.ATraitorInTheRanks.WordText}. I propose a strategy to uncover and deal with the betrayal.",
                scene => $"I know where to find {scene.ObjectYouAreLookingFor.WordText}. Allow me to guide us there.",
                scene => $"Finding {scene.ObjectYouAreLookingFor.WordText} and identifying {scene.AWayToEscape.WordText} are my top priorities. Let's focus on these.",
                scene => $"Considering our {scene.PreparationForTheMission.WordText}, I suggest a review to ensure we're fully prepared.",
                scene => $"Given the {scene.StatusOfTheMission.WordText}, I'm ready to adjust our tactics as needed. Let's discuss.",
                scene => $"The {scene.StatusOfTheObstacleToTheMission.WordText} is concerning. I have ideas for overcoming this hurdle.",
                scene => $"Reflecting on {scene.TheBeforeAndAfter.WordText} offers valuable lessons. Let's use them to our advantage.",
                scene => $"Carrying {scene.TheBurdenCarriedByTheProtagonists.WordText} is not your alone. I'm here to share the weight.",
                scene => $"Facing {scene.TheCurrentSituation.WordText}, I'm committed to navigating us through these challenges.",
                scene => $"Analyzing {scene.TheEnemyActions.WordText}, I've pinpointed a weakness. Let's exploit it together.",
                scene => $"Combining our knowledge of {scene.TheEnemyActions.WordText} with the valor of {scene.TheHeroesOfTheStory.WordText}, we can turn the tide.",
                scene => $"Aiming for {scene.TheIdealFutureStateOfTheMission.WordText}, I'll contribute all I can to make this vision a reality.",
                scene => $"Maintaining {scene.TheIdealMentalStateForTheMission.WordText} is vital. I'll help keep our focus and spirits high.",
                scene => $"To combat {scene.TheInjusticeFaced.WordText}, my assistance is unwavering. Let's fight this together.",
                scene => $"In dealing with {scene.TheLossesWeHaveSuffered.WordText}, I offer my support to heal and rebuild stronger than before.",
                scene => $"Achieving {scene.TheMissionObjective.WordText} is within our reach. I'll ensure we have the resources to succeed.",
                scene => $"Understanding {scene.TheNeedsOfTheEnemy.WordText} gives us leverage. I'll help us use this knowledge effectively.",
                scene => $"Improving {scene.ThePhysicalStateOfTheProtagonists.WordText} is crucial. I have strategies to keep us in peak condition.",
                scene => $"The {scene.TheSoundOfTheEnemy.WordText} signals their approach. Let's prepare a defense based on this intel.",
                scene => $"Confronting {scene.TheUnknownFactors.WordText} demands creativity. I'm here to brainstorm solutions.",
                scene => $"Honoring {scene.TheUnsungHeroes.WordText}, let's draw inspiration from their courage and sacrifice."
            };
            this.expositions.Add(SentencePurposeType.OfferAssistance, offerAssistance);

            var issueAChallenge = new List<Func<Scene, string>>
            {
                scene => $"We have to stay strong and organized.",
                scene => $"We have to stay strong and organized. We can't let the {scene.AnEnemyOfTheMission.WordText} win.",
                scene => $"We have to stay strong and organized. We can't let the {scene.AnEnemyOfTheMission.WordText} win. We need to {scene.ActionThatContributesToTheMission.WordText}.",
                scene => $"We must succeed.",
                scene => $"We must succeed. We can't let the {scene.AnEnemyOfTheMission.WordText} win.",
                scene => $"The time to act is now. We cannot falter in the face of {scene.AnEnemyOfTheMission.WordText}.",
                scene => $"This is our moment to stand up against {scene.TheChaosCausedByTheEnemy.WordText}. We must rise to the occasion.",
                scene => $"Let's prove to {scene.AnEnemyOfTheMission.WordText} that our resolve is unbreakable.",
                scene => $"We face a critical point in our mission. It's do or die, and I choose to do.",
                scene => $"Our backs are against the wall. It's time to show {scene.TheEnemy.WordText} what we're made of.",
                scene => $"This challenge before us is not insurmountable. With unity, {scene.TheGoalOfTheMission.WordText} is within reach.",
                scene => $"We've been underestimating our own strength. Let's take the fight to {scene.TheEnemy.WordText} and shift the tide.",
                scene => $"The only way out is through. Let's confront {scene.AnImmediateDangerToTheMission.WordText} head-on.",
                scene => $"It's a pivotal time for {scene.LocationOfTheMission.WordText}. Our actions now will define the future.",
                scene => $"No more hesitations. It's time to challenge the status quo and make our mark.",
                scene => $"Can anyone here utilize {scene.ObjectThatAssistsTheMission.WordText} more innovatively? I challenge you to prove its worth.",
                scene => $"Who can stop {scene.ActionThatDetractsFromTheMission.WordText} in its tracks? It's a challenge that demands immediate attention.",
                scene => $"Facing {scene.TheMainCauseOfTheProblem.WordText} head-on is our only option. Who's brave enough to lead this charge?",
                scene => $"The effects of {scene.TheImmediateEffectsOfTheProblem.WordText} are evident. I challenge each of you to find a solution before it's too late.",
                scene => $"With only {scene.TheTimeLeftToCompleteTheMission.WordText} left and our safety in {scene.ASaferLocation.WordText} uncertain, who will step up to ensure we succeed?",
                scene => $"To {scene.TheUnsungHeroes.WordText}, achieving {scene.TheMissionObjective.WordText} might seem impossible. But I challenge you to defy the odds.",
                scene => $"The truth behind {scene.TheMysteryUnfolding.WordText} remains elusive. Who here dares to unravel it?",
                scene => $"Given our history with {scene.ARelatedNegativePastEvent.WordText}, I challenge this team to learn from the past and forge a new path.",
                scene => $"In light of {scene.TheLossesWeHaveSuffered.WordText}, my challenge to you all is to rise stronger in memory of what we've lost.",
                scene => $"Confronting {scene.AnOverwhelmingChallenge.WordText} will test us all. Who's ready to face it head-on?",
                scene => $"Navigating {scene.AnObstacleToTheMission.WordText} will not be easy. I challenge you to find a way through it or around it.",
                scene => $"Our success hinges on {scene.APlanToSucceedAtMission.WordText}. I challenge someone to perfect it, to ensure our victory.",
                scene => $"With {scene.TheStatusOfTheMainCauseOfTheProblem.WordText} as it stands, I challenge our strategists to think two steps ahead of the enemy.",
                scene => $"Understanding {scene.TheMentalStateOfTheEnemy.WordText} could be our key to victory. Who will take on the challenge of getting inside the enemy's mind?",
                scene => $"The enemy's stronghold in {scene.LocationOfTheEnemy.WordText} is formidable. I challenge our scouts to find a vulnerability.",
                scene => $"The threat of {scene.AnImmediateDangerToTheProtagonists.WordText} looms large. I challenge our defenders to fortify our protections.",
                scene => $"We've had great support from {scene.HelpfulEntitiesForTheMission.WordText}, but now I challenge us to stand on our own.",
                scene => $"The resilience of {scene.TheSurvivors.WordText} inspires us all. I challenge you to harness that spirit and push forward.",
                scene => $"Reflecting on {scene.TheAchievementsOfTheGroup.WordText}, I challenge us to surpass our past triumphs and set new records."
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
                scene => $"In appreciation of your unwavering support, thank you.",
                scene => $"Thank you for uncovering {scene.ACriticalClue.WordText}. It's been the breakthrough we needed to understand {scene.TheMainCauseOfTheProblem.WordText}.",
                scene => $"Your work with {scene.ActionObjectThatContributesToTheMission.WordText} has been invaluable. Thank you for your dedication.",
                scene => $"I'm truly grateful for your efforts to {scene.ActionThatContributesToTheMission.WordText}. It's made all the difference.",
                scene => $"Even though {scene.ActionThatDetractsFromTheMission.WordText} was a setback, your response has been admirable. Thank you for standing strong.",
                scene => $"Despite the challenges posed by {scene.ActionThatDetractsFromTheMission.WordText}, you've kept us focused on {scene.TheGoalOfTheMission.WordText}. Your resilience is appreciated.",
                scene => $"Your ability to navigate {scene.ActionThatDetractsFromTheMission.WordText} while keeping {scene.TheIdealStrategyForTheMission.WordText} in sight has been crucial. Thank you.",
                scene => $"Facing {scene.AnEnemyOfTheMission.WordText} was daunting, but your courage has been a source of strength for us all. Thank you.",
                scene => $"For standing firm in the face of {scene.AnImmediateDangerToTheProtagonists.WordText}, I can't thank you enough.",
                scene => $"Your protection from {scene.AnImmediateDangerToTheProtagonists.WordText}, with the aid of {scene.HelpfulEntitiesForTheMission.WordText}, has been our safeguard. My deepest thanks.",
                scene => $"Overcoming {scene.AnObstacleToTheMission.WordText} seemed impossible. Your efforts have not gone unnoticed. Thank you.",
                scene => $"Tackling {scene.AnObstacleToTheMission.WordText} and changing {scene.StatusOfTheObstacleToTheMission.WordText} was a monumental task. Your success is deeply appreciated.",
                scene => $"Understanding {scene.AnUmbrellaTermThatDescribesTheNatureOfTheEnemy.WordText} was key, and your insights have been invaluable. Thank you.",
                scene => $"The arrival of {scene.AnUnexpectedAlly.WordText} was a turning point for us. We're grateful for the support.",
                scene => $"Reflecting on {scene.APastEventMirroringTheCurrentMission.WordText} and seeing {scene.TheMysteryUnfolding.WordText} come to light has been pivotal. Thank you for guiding us through this revelation.",
                scene => $"Your execution of {scene.APlanToSucceedAtMission.WordText} has put us on the path to success. Thank you for your strategic acumen.",
                scene => $"After everything, witnessing {scene.APositiveTurnOfEvents.WordText} has been uplifting. Your role in this cannot be overstated. Thank you.",
                scene => $"Keeping {scene.APriorityForTheMission.WordText} at the forefront has ensured our progress. For that, I'm grateful.",
                scene => $"Remembering {scene.ARelatedNegativePastEvent.WordText} has been hard, but your actions have helped us avoid repeating history. Thank you.",
                scene => $"In the face of {scene.ARelatedNegativePastEvent.WordText}, and despite {scene.ActionThatDetractsFromTheMission.WordText}, your perseverance has been a beacon of hope. Thank you.",
                scene => $"Finding sanctuary in {scene.ASaferLocation.WordText} while facing threats from {scene.AnEnemyOfTheMission.WordText} and {scene.TheEnemy.WordText} has been our salvation. Thank you for securing it.",
                scene => $"The discovery of {scene.ASecretWeapon.WordText} at {scene.TimeOfDay.WordText}, turning the tide against {scene.TheEnemy.WordText}, was a critical moment. Thank you for your bravery.",
                scene => $"Identifying {scene.ATraitorInTheRanks.WordText} was difficult, but necessary. Your vigilance has protected us. Thank you.",
                scene => $"The support from {scene.HelpfulEntitiesForTheMission.WordText} has been unwavering. To all involved, thank you for everything.",
                scene => $"Gaining insight into {scene.LocationOfTheEnemy.WordText} has given us the upper hand. Your reconnaissance efforts are greatly appreciated."
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
                scene => $"Let my actions reflect the depth of my commitment.",
                scene => $"I'm committed to {scene.ActionThatContributesToTheMission.WordText}, no matter the cost.",
                scene => $"My focus is on {scene.ActionThatContributesToTheMission.WordText} with {scene.ActionObjectThatContributesToTheMission.WordText}, ensuring our success.",
                scene => $"Even {scene.ActionThatDetractsFromTheMission.WordText} won't sway my dedication. I'll find a way to overcome it.",
                scene => $"Facing {scene.AFateIfTheMissionFails.WordText}, I know that {scene.ASuccessFactorOfTheMission.WordText} is what will see us through.",
                scene => $"In every {scene.AMomentOfJoy.WordText}, I see a reason to keep fighting, to stay dedicated.",
                scene => $"Against {scene.AnEnemyOfTheMission.WordText}, my resolve only strengthens. I won't back down.",
                scene => $"Knowing the {scene.AnImmediateDangerToTheProtagonists.WordText}, my dedication to our cause has never been stronger.",
                scene => $"No {scene.AnObstacleToTheMission.WordText} can deter me. My commitment is unwavering.",
                scene => $"Faced with {scene.AnOverwhelmingChallenge.WordText}, my dedication is my shield.",
                scene => $"Against every form of {scene.AnUmbrellaTermThatDescribesTheNatureOfTheEnemy.WordText}, I stand resolute and dedicated.",
                scene => $"The arrival of {scene.AnUnexpectedAlly.WordText} has reinforced my commitment to our mission.",
                scene => $"Remembering {scene.APastEvent.WordText}, I see patterns in {scene.TheMystery.WordText} that strengthen my resolve.",
                scene => $"Echoing {scene.APastEventMirroringTheCurrentMission.WordText}, I know that {scene.AnActionThatLedToSuccess.WordText} and {scene.APlanToSucceedAtMission.WordText} are key to our success.",
                scene => $"Every {scene.APositiveTurnOfEvents.WordText} reaffirms my dedication to our cause.",
                scene => $"{scene.APriorityForTheMission.WordText} is my guiding star, keeping my dedication firm.",
                scene => $"Despite {scene.ARelatedNegativePastEvent.WordText}, my commitment to {scene.ActionThatContributesToTheMission.WordText} with {scene.ActionObjectThatContributesToTheMission.WordText} remains.",
                scene => $"With {scene.ASkillOfTheProtagonists.WordText} and {scene.ACriticalClue.WordText} in hand, my dedication to our mission has never been clearer.",
                scene => $"Finding {scene.ASolution.WordText} to {scene.TheProblem.WordText} will bring us to {scene.ASaferLocation.WordText}, and I'm dedicated to making that happen.",
                scene => $"Facing {scene.AThreatOfTheEnemy.WordText}, understanding {scene.TheNeedsOfTheEnemy.WordText} has only sharpened my focus.",
                scene => $"Even knowing there's {scene.ATraitorInTheRanks.WordText}, my dedication to our mission is unwavering.",
                scene => $"Trapped by {scene.ATrapForTheProtagonists.WordText}, my resolve to escape and succeed is only hardened.",
                scene => $"I'll work alongside {scene.FriendsOfTheProtagonists.WordText}, ensuring our combined efforts lead to victory.",
                scene => $"With the aid of {scene.HelpfulEntitiesForTheMission.WordText}, our dedication to the mission will see us through.",
                scene => $"Seeking {scene.ObjectYouAreLookingFor.WordText} while finding {scene.AWayToEscape.WordText} shows our unwavering commitment.",
                scene => $"Our {scene.PreparationForTheMission.WordText} has prepared us for this moment, and I'm dedicated to seeing it through."
            };
            this.expositions.Add(SentencePurposeType.ExpressDedication, expressDedication);


            var revealSecrets = new List<Func<Scene, string>>
            {
                scene => $"I've been keeping this from you, but I think it's time you knew.",
                scene => $"I've been keeping this from you, but I think it's time you knew. I've been {scene.AHiddenActionOfTheProtagonists.WordText}.",
                scene => $"The truth is, I know more about {scene.TheMainCauseOfTheProblem.WordText} than I've let on. It's a secret that could change everything.",
                scene => $"There's something you should know about {scene.TheEnemy.WordText}. They're not what they seem. In fact, {scene.AnOverwhelmingChallenge.WordText} has been misleading us all along.",
                scene => $"I never told anyone, but I witnessed {scene.APastEventMirroringTheCurrentMission.WordText}. It's the reason why I've been so involved in this mission.",
                scene => $"I must confess, the real reason we're here isn't just for {scene.TheGoalOfTheMission.WordText}. There's more at stake, including {scene.TheMysteryUnfolding.WordText}.",
                scene => $"This might come as a shock, but {scene.ATraitorInTheRanks.WordText} is among us. I've had my suspicions, and now I have proof.",
                scene => $"It's time I revealed my true identity. I am not just {scene.ARoleOfTheProtagonist.WordText}; I am also {scene.TheUnsungHeroes.WordText}, responsible for {scene.ACriticalClue.WordText}.",
                scene => $"You deserve to know the truth about {scene.TheBurdenCarriedByTheProtagonists.WordText}. It's been a secret, but it's time it came to light.",
                scene => $"I've discovered something about {scene.LocationOfTheMission.WordText} that changes everything. It's not just a place; it's {scene.ASecretHidingSpot.WordText}.",
                scene => $"I need to tell you about {scene.TheEnemyActions.WordText}. What we thought was random chaos is actually {scene.AStrategicMoveByTheEnemy.WordText}.",
                scene => $"There's a reason why {scene.TheChaosCausedByTheEnemy.WordText} always seems one step ahead. I've found {scene.ASecretWeapon.WordText}, and it explains everything.",
                scene => $"I've been silently battling {scene.TheInjusticeFaced.WordText}. It's why I've been so distant. I believe it's time you knew the full extent of my struggles.",
                scene => $"The mission's success hinges on a secret I've kept: {scene.TheIdealStrategyForTheMission.WordText}. Without it, we're walking into {scene.AnImmediateDangerToTheMission.WordText} blind.",
                scene => $"I've uncovered a hidden truth that could turn the tide in our favor: {scene.TheUnknownFactors.WordText}. It's been the key to {scene.TheEnemy.WordText}'s power all along."
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
                scene => $"I have no doubt that {scene.ProtagonistsForTheMission.WordText} will navigate through {scene.TheChaosCausedByTheEnemy.WordText} with resilience and determination.",
                scene => $"It's clear to me that despite the hardships faced by {scene.VictimsOfTheEnemy.WordText}, with {scene.AnEnemyOfTheMission.WordText} as our focus, victory is within our reach.",
                scene => $"There's no question that understanding {scene.TheMainCauseOfTheProblem.WordText} is the key to our success. I'm certain of it.",
                scene => $"I'm convinced that the actions we take today will directly address {scene.TheImmediateEffectsOfTheProblem.WordText}, mitigating the crisis at hand.",
                scene => $"Given {scene.TheTimeLeftToCompleteTheMission.WordText}, I'm positive that {scene.ASaferLocation.WordText} will serve as our stronghold until the end.",
                scene => $"The courage shown by {scene.TheUnsungHeroes.WordText} underscores our commitment to {scene.TheMissionObjective.WordText}. Their efforts will not be in vain.",
                scene => $"The unfolding of {scene.TheMysteryUnfolding.WordText} leaves no room for doubt. We're on the right path.",
                scene => $"Remembering {scene.ARelatedNegativePastEvent.WordText} strengthens my conviction that we will not repeat the same mistakes.",
                scene => $"The pain of {scene.TheLossesWeHaveSuffered.WordText} only solidifies our resolve. We cannot—and will not—falter.",
                scene => $"With {scene.ASecretWeapon.WordText} at our disposal, the threat posed by {scene.TheEnemy.WordText} is not just manageable but surmountable.",
                scene => $"Facing {scene.AnOverwhelmingChallenge.WordText} might seem daunting, yet I'm confident in our ability to overcome it.",
                scene => $"Despite {scene.AnObstacleToTheMission.WordText} lying in our path, my belief in our mission's success has never been stronger.",
                scene => $"Achieving {scene.TheGoalOfTheMission.WordText} is not just a possibility; it's a certainty, given our planning and dedication.",
                scene => $"The strategy laid out in {scene.APlanToSucceedAtMission.WordText} is foolproof. I trust in its efficacy completely.",
                scene => $"The state of {scene.TheStatusOfTheMainCauseOfTheProblem.WordText} might worry some, but I see it as an opportunity for us to shine.",
                scene => $"Understanding {scene.TheMentalStateOfTheEnemy.WordText} gives us a unique advantage, ensuring our readiness for what lies ahead.",
                scene => $"Our knowledge of {scene.LocationOfTheEnemy.WordText} isn't just comprehensive; it's our trump card in this intricate game of chess.",
                scene => $"The notion of {scene.AnImmediateDangerToTheProtagonists.WordText} doesn't deter us; rather, it galvanizes our will to succeed.",
                scene => $"{scene.HelpfulEntitiesForTheMission.WordText} have proven their worth time and again. Their support is unwavering and indispensable.",
                scene => $"The stories of {scene.TheSurvivors.WordText} will be told for generations, highlighting the indomitable spirit of those who dare to dream.",
                scene => $"Let us not forget {scene.TheAchievementsOfTheGroup.WordText}. They remind us of what we're capable of when we stand united."
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
                scene => $"Is it possible that we're underestimating {scene.TheMentalStateOfTheEnemy.WordText}?",
                scene => $"Are we sure using {scene.ActionObjectThatContributesToTheMission.WordText} is the best move for us right now?",
                scene => $"I'm not certain if {scene.ActionThatContributesToSafety.WordText} will be enough to protect us.",
                scene => $"Is {scene.ActionThatContributesToTheMission.WordText} really going to lead us to victory, or are we just fooling ourselves?",
                scene => $"Combining {scene.ActionThatContributesToTheMission.WordText} with {scene.ActionObjectThatContributesToTheMission.WordText} sounds good, but can we pull it off?",
                scene => $"With {scene.ActionThatContributesToTheMission.WordText}, considering {scene.TheUnknownFactors.WordText}, are we prepared for all possible outcomes?",
                scene => $"I fear that {scene.ActionThatDetractsFromTheMission.WordText} might be our undoing. Are we being too rash?",
                scene => $"If {scene.ActionThatDetractsFromTheMission.WordText} leads to {scene.AFateIfTheMissionFails.WordText}, can we ever forgive ourselves?",
                scene => $"Facing {scene.AFateIfTheMissionFails.WordText} without securing {scene.ASuccessFactorOfTheMission.WordText} fills me with dread. Are we missing something?",
                scene => $"Can we truly find a moment of joy in all this chaos, or is it just a fleeting dream?",
                scene => $"How do we prepare for {scene.AnImmediateDangerToTheProtagonists.WordText} when every step forward feels like a guess?",
                scene => $"Facing {scene.AnOverwhelmingChallenge.WordText}, can anyone be really sure of the path ahead?",
                scene => $"Dealing with {scene.AnUmbrellaTermThatDescribesTheNatureOfTheEnemy.WordText}, how can we be sure of our strategy?",
                scene => $"Reflecting on {scene.APastEvent.WordText}, does the mystery still hold us back from seeing the truth?",
                scene => $"Considering {scene.APastEventMirroringTheCurrentMission.WordText}, will repeating {scene.AnActionThatLedToSuccess.WordText} guarantee our success again?",
                scene => $"With {scene.APastEventMirroringTheCurrentMission.WordText} in mind, can we rely on {scene.AnActionThatLedToSuccess.WordText} and our {scene.APlanToSucceedAtMission.WordText} to navigate these troubled waters?",
                scene => $"Even if {scene.APositiveTurnOfEvents.WordText} occurs, can we ensure {scene.ActionThatContributesToTheMission.WordText} will lead us to our goal?",
                scene => $"How pivotal is {scene.APriorityForTheMission.WordText} when so much remains uncertain?",
                scene => $"After {scene.ARelatedNegativePastEvent.WordText}, how can we be certain that {scene.ActionThatContributesToTheMission.WordText} with {scene.ActionObjectThatContributesToTheMission.WordText} is the right course?",
                scene => $"If we retreat to {scene.ASaferLocation.WordText} and face {scene.AFateIfTheMissionFails.WordText}, what then?",
                scene => $"Can {scene.ASkillOfTheProtagonists.WordText} and {scene.ACriticalClue.WordText} truly guide us through the fog of uncertainty?",
                scene => $"With a solution in mind for {scene.TheProblem.WordText}, can we ensure {scene.ASaferLocation.WordText} remains our haven?",
                scene => $"How do we balance {scene.AThreatOfTheEnemy.WordText} against {scene.TheNeedsOfTheEnemy.WordText}, especially when so much is at stake?",
                scene => $"The notion of {scene.ATraitorInTheRanks.WordText} amongst us has sown seeds of doubt. How do we move forward?",
                scene => $"Is it just me, or does {scene.ATrapForTheProtagonists.WordText} seem too obvious? What if we're missing something?",
                scene => $"How effective can {scene.AWeaponOfTheEnemy.WordText} really be? Do we have anything to counteract it?",
                scene => $"Can we truly rely on {scene.FriendsOfTheProtagonists.WordText} in times like these? Their intentions seem murky at best.",
                scene => $"How helpful can {scene.HelpfulEntitiesForTheMission.WordText} be in our current predicament? Are their resources adequate?",
                scene => $"I'm starting to wonder if {scene.ObjectYouAreLookingFor.WordText} is really out there, and if there's truly {scene.AWayToEscape.WordText} from this situation.",
                scene => $"Did we do enough {scene.PreparationForTheMission.WordText}? I can't shake the feeling we've overlooked something crucial.",
                scene => $"Even with our {scene.PreparationForTheMission.WordText}, how can we be ready for {scene.AnImmediateDangerToTheMission.WordText}? It feels like we're stepping into the unknown.",
                scene => $"With {scene.ProtagonistsForTheMission.WordText} facing {scene.AnImmediateDangerToTheMission.WordText}, are we truly prepared, or are we kidding ourselves?",
                scene => $"How safe is {scene.ASaferLocation.WordText} for {scene.ProtagonistsForTheMission.WordText}? Is it really a haven, or just another illusion of security?",
                scene => $"What's the real {scene.StatusOfTheMission.WordText}? Are we making progress, or are we caught in a standstill?",
                scene => $"Do {scene.TheAchievementsOfTheGroup.WordText} hold any weight in our current crisis? Sometimes, it feels like we're back to square one.",
                scene => $"Looking at {scene.TheBeforeAndAfter.WordText}, have we really changed anything, or are we just circling back to where we started?",
                scene => $"Carrying {scene.TheBurdenCarriedByTheProtagonists.WordText} is getting heavier by the day. Are we strong enough to bear it till the end?",
                scene => $"With {scene.TheBurdenCarriedByTheProtagonists.WordText} on our shoulders, how can we effectively execute {scene.AnotherActionThatContributesToTheMission.WordText}?",
                scene => $"Given {scene.TheCurrentSituation.WordText}, can anyone say with certainty what our next step should be?",
                scene => $"With {scene.TheEnemyActions.WordText} and their apparent {scene.AWeakness.WordText}, what's our best course of action? Do we have the upper hand, or is it a ruse?",
                scene => $"Considering {scene.TheEnemyActions.WordText}, how do we ensure {scene.TheHeroesOfTheStory.WordText} stay one step ahead without falling into complacency?",
                scene => $"Are we any closer to {scene.TheGoalOfTheMission.WordText}, or are we losing ground without realizing it?",
                scene => $"What does {scene.TheIdealFutureStateOfTheMission.WordText} even look like now? And how does {scene.APlanToSucceedAtMission.WordText} fit into that vision?",
                scene => $"Is maintaining {scene.TheIdealMentalStateForTheMission.WordText} realistic, especially when we're constantly called to {scene.ActionThatContributesToTheMission.WordText}?",
                scene => $"After seeing {scene.TheImmediateEffectsOfTheProblem.WordText}, can anyone feel truly prepared for what's next?",
                scene => $"How do we face {scene.TheInjusticeFaced.WordText} and still keep faith in our mission? It feels like we're walking a tightrope without a net."
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
                scene => $"We've finally overcome {scene.AnEnemyOfTheMission.WordText}! This victory brings us one step closer to peace and security.",
                scene => $"Discovering {scene.ObjectThatAssistsTheMission.WordText} has been a game-changer for us. It's exactly what we needed to turn the tide!",
                scene => $"Seeing the downfall of {scene.AnUmbrellaTermThatDescribesTheNatureOfTheEnemy.WordText} fills my heart with joy. It's a sign that justice and peace will prevail.",
                scene => $"Finding refuge in {scene.ASaferLocation.WordText}, away from {scene.AnEnemyOfTheMission.WordText}, has brought us all a much-needed sense of joy and safety.",
                scene => $"Being here in {scene.LocationOfTheMission.WordText}, after everything we've been through, and still standing strong—it's a reason to celebrate!",
                scene => $"Watching {scene.ProtagonistsForTheMission.WordText} come together like this, overcoming every challenge—it's incredibly uplifting and fills me with joy.",
                scene => $"As {scene.TimeOfDay.WordText} breaks, the silence replaces {scene.TheSoundOfTheEnemy.WordText}, signaling the end of {scene.TheMainCauseOfTheProblem.WordText}.",
                scene => $"The {scene.TimeOfDay.WordText} shines brighter today, lifting the shadows cast by {scene.TheImmediateEffectsOfTheProblem.WordText}.",
                scene => $"Finally, {scene.TheMentalStateOfTheEnemy.WordText} shifts towards defeat, filling our hearts with unexpected joy.",
                scene => $"With {scene.TheTimeLeftToCompleteTheMission.WordText} dwindling, the sudden retreat of {scene.TheEnemy.WordText} sparks a celebration among us.",
                scene => $"The {scene.TimeOfDay.WordText} was made glorious by the fading {scene.TheSoundOfTheEnemy.WordText}, a symphony of victory.",
                scene => $"Discovering {scene.ASecretWeapon.WordText} as {scene.TimeOfDay.WordText} falls gives us an edge over {scene.TheEnemy.WordText} and a reason to rejoice.",
                scene => $"By {scene.TimeOfDay.WordText}, we gather with {scene.TheSurvivors.WordText}, envisioning {scene.TheIdealFutureStateOfTheMission.WordText} with hope in our hearts.",
                scene => $"Every {scene.ActionThatDetractsFromTheMission.WordText} turns into a stepping stone towards {scene.TheGoalOfTheMission.WordText}, fueling our joy.",
                scene => $"Each {scene.ActionThatDetractsFromTheMission.WordText} inadvertently aligns us closer to {scene.TheIdealStrategyForTheMission.WordText}.",
                scene => $"What truly matters, {scene.WhatHingesOnTheSuccessOfTheMission.WordText}, becomes clearer with every {scene.ActionThatDetractsFromTheMission.WordText}.",
                scene => $"Even {scene.ARelatedNegativePastEvent.WordText} becomes a source of strength as we learn and grow, turning {scene.ActionThatDetractsFromTheMission.WordText} into milestones.",
                scene => $"Today, {scene.TheUnsungHeroes.WordText} are celebrated, their deeds aligning perfectly with {scene.TheMissionObjective.WordText}.",
                scene => $"The shadow of {scene.ARelatedNegativePastEvent.WordText} lifts, ushering in a moment of collective relief and happiness.",
                scene => $"Amidst {scene.TheLossesWeHaveSuffered.WordText}, finding reasons to smile shows our resilience and strength.",
                scene => $"Overcoming {scene.AnObstacleToTheMission.WordText} fills us with a sense of achievement and jubilation.",
                scene => $"Achieving {scene.TheGoalOfTheMission.WordText} brings an indescribable feeling of joy and fulfillment.",
                scene => $"The successful execution of {scene.APlanToSucceedAtMission.WordText} ignites a firework of emotions within us.",
                scene => $"The moment we turn the tide against {scene.AnImmediateDangerToTheProtagonists.WordText}, our spirits soar.",
                scene => $"The arrival of {scene.HelpfulEntitiesForTheMission.WordText} turns despair into joy, reminding us we're not alone.",
                scene => $"Securing {scene.APriorityForTheMission.WordText} brings a wave of relief and happiness, marking a pivotal moment of success.",
                scene => $"Utilizing {scene.ActionObjectThatContributesToTheMission.WordText} effectively becomes a cause for celebration, a testament to our ingenuity.",
                scene => $"Rescuing {scene.VictimsOfTheEnemy.WordText} from {scene.LocationOfTheVictim.WordText} fills our hearts with joy, reaffirming our mission's purpose.",
                scene => $"Dismantling {scene.AnObstacleToTheMission.WordText} and seeing {scene.StatusOfTheObstacleToTheMission.WordText} change to 'overcome' is a moment of pure elation.",
                scene => $"Learning {scene.LocationOfTheEnemy.WordText} no longer poses a threat brings cheers and relief to all.",
                scene => $"Reflecting on {scene.APastEventMirroringTheCurrentMission.WordText} and seeing {scene.TheMysteryUnfolding.WordText} resolved fills us with a profound sense of accomplishment.",
                scene => $"Witnessing the positive shift in {scene.TheStatusOfTheMainCauseOfTheProblem.WordText} brings smiles and laughter, a rare but cherished moment.",
                scene => $"Unraveling {scene.TheMysteryUnfolding.WordText} and understanding its implications turns anxiety into astonishment and joy.",
                scene => $"The day we celebrate {scene.TheAchievementsOfTheGroup.WordText} is filled with laughter, stories, and a shared sense of pride.",
                scene => $"The combined effort to overcome {scene.AnImmediateDangerToTheProtagonists.WordText}, with the help of {scene.HelpfulEntitiesForTheMission.WordText}, sparks a celebration of unity and gratitude.",
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
                scene => $"The strength of our alliance against {scene.TheEnemy.WordText} is unbreakable; we are bound by more than just duty.",
                scene => $"Together, we'll {scene.ActionThatContributesToTheMission.WordText}, using every resource at our disposal.",
                scene => $"As we {scene.ActionThatContributesToTheMission.WordText} the {scene.ActionObjectThatContributesToTheMission.WordText} at {scene.TimeOfDay.WordText}, remember, we're in this together.",
                scene => $"Our joint effort to {scene.ActionThatContributesToTheMission.WordText} the {scene.ActionObjectThatContributesToTheMission.WordText} is the cornerstone of our mission.",
                scene => $"We stand with {scene.VictimsOfTheEnemy.WordText}, ensuring their safety and recovery at {scene.ASaferLocation.WordText}.",
                scene => $"We're united in our support for {scene.VictimsOfTheEnemy.WordText}, demonstrating our unwavering commitment to their well-being.",
                scene => $"Let's rally at {scene.ASaferLocation.WordText}, a beacon of hope and unity for us all.",
                scene => $"By focusing on {scene.ActionThatContributesToTheMission.WordText} with the {scene.ActionObjectThatContributesToTheMission.WordText}, while avoiding {scene.PossibleProblemToAvoid.WordText}, we honor the lessons learned from {scene.ARelatedNegativePastEvent.WordText}.",
                scene => $"Our preparation for the mission, prioritizing {scene.APriorityForTheMission.WordText}, is a testament to our collective resolve.",
                scene => $"We owe a debt of gratitude to {scene.HelpfulEntitiesForTheMission.WordText} for their indispensable support in our endeavors.",
                scene => $"Every action we take to {scene.ActionThatContributesToTheMission.WordText} strengthens our bonds and our resolve.",
                scene => $"Facing {scene.TheImmediateEffectsOfTheProblem.WordText} head-on, we're reminded of the strength found in unity.",
                scene => $"Our {scene.ASkillOfTheProtagonists.WordText} and the discovery of {scene.ACriticalClue.WordText} exemplify the power of working together.",
                scene => $"In the face of {scene.AFateIfTheMissionFails.WordText}, it's our collective {scene.ASuccessFactorOfTheMission.WordText} that will see us through.",
                scene => $"Navigating {scene.ATrapForTheProtagonists.WordText} reveals not just our vulnerabilities, but our strength in overcoming them together.",
                scene => $"Reflecting on {scene.APastEventMirroringTheCurrentMission.WordText}, it's clear that {scene.AnActionThatLedToSuccess.WordText} was our unified spirit.",
                scene => $"At {scene.ASaferLocation.WordText}, we find not just refuge, but a shared purpose that binds us.",
                scene => $"The unfolding of {scene.TheMysteryUnfolding.WordText} through {scene.AnActionToUncoverSecrets.WordText} has brought us closer, revealing our shared determination.",
                scene => $"In analyzing {scene.TheEnemyActions.WordText}, we recognize our unity as our greatest asset against their {scene.AWeakness.WordText}.",
                scene => $"The presence of {scene.ATrapForTheProtagonists.WordText} only strengthens our resolve to stand united, turning obstacles into opportunities.",
                scene => $"Facing the fallout of {scene.ARejectedPlanOfTheMission.WordText}, our solidarity in supporting {scene.VictimsOfTheEnemy.WordText} and exploiting {scene.ASkillOfTheEnemy.WordText} is unwavering.",
                scene => $"The arrival of {scene.AnUnexpectedAlly.WordText} underscores the value of unity in unexpected forms, enriching our collective journey.",
                scene => $"In contemplating {scene.TheBeforeAndAfter.WordText}, our shared experiences forge a bond that transcends the mission itself.",
                scene => $"Our united front is crucial, especially when confronting actions that {scene.ActionThatDetractsFromTheMission.WordText}, ensuring we remain focused on our shared objectives.",
                scene => $"Together, we mourn {scene.TheLossesWeHaveSuffered.WordText}, a solemn reminder of the cost of our struggle and the strength found in mutual support.",
                scene => $"Facing {scene.AnUmbrellaTermThatDescribesTheNatureOfTheEnemy.WordText}, our solidarity is our shield, our collective resolve an unbeatable force.",
                scene => $"In striving for {scene.TheIdealMentalStateForTheMission.WordText}, our shared optimism and support are our greatest assets.",
                scene => $"The {scene.TheBurdenCarriedByTheProtagonists.WordText} becomes lighter when shared among us all, a symbol of our unwavering support for one another.",
                scene => $"With {scene.TheTimeLeftToCompleteTheMission.WordText} ticking away, our unity becomes not just our strategy, but our sanctuary.",
                scene => $"{scene.APositiveTurnOfEvents.WordText} is not just a stroke of luck; it's a testament to what we can achieve when we stand together."
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
                scene => $"Why did the mission planner get lost? Because the roadmap was full of loops!",
                scene => $"Ever heard about the time we thought the 'critical clue' was {scene.ACriticalClue.WordText}? Turns out, it was just the chef's way of telling us he was out of thyme.",
                scene => $"You know, our 'hidden action' was so secretive, even {scene.AHiddenActionOfTheProtagonists.WordText} didn't know about it. Talk about being undercover!",
                scene => $"The 'immediate danger' to our mission? Turns out, {scene.AnImmediateDangerToTheMission.WordText} was just a mislabeled danger sign. Who knew?",
                scene => $"Faced with {scene.AnObstacleToTheMission.WordText} as our obstacle, we decided the best approach was to... rename it. It's now called 'a minor inconvenience.'",
                scene => $"Our 'unexpected ally' {scene.AnUnexpectedAlly.WordText} turned out to be a cat. Its strategy? Distraction by cuteness.",
                scene => $"So, the enemy's weapon, {scene.AWeaponOfTheEnemy.WordText}, was feared across the land. Little did they know, its only power was the ability to make a loud 'bang' sound.",
                scene => $"Before {scene.TheBeforeAndAfter.WordText}, we were lost. After? We found ourselves... in the cafeteria, plotting our next move over pie.",
                scene => $"The chaos caused by {scene.TheEnemy.WordText}? {scene.TheChaosCausedByTheEnemy.WordText} was actually just them trying to assemble IKEA furniture.",
                scene => $"We expected a fierce battle with {scene.TheEnemy.WordText}, but all they wanted was to challenge us to a dance-off. 'Thriller' has never been the same.",
                scene => $"The 'immediate effects of the problem'? Well, {scene.TheImmediateEffectsOfTheProblem.WordText} made us realize we should have paid more attention in yoga class.",
                scene => $"Turns out, the main cause of the problem, {scene.TheMainCauseOfTheProblem.WordText}, was just a typo in the ancient prophecy. Should've used spellcheck.",
                scene => $"The mental state of {scene.TheEnemy.WordText}? After seeing {scene.TheMentalStateOfTheEnemy.WordText}, we think they might just need a hug.",
                scene => $"As for {scene.TheMysteryUnfolding.WordText}, who knew the real mystery was where we left the remote?",
                scene => $"Our physical state after the mission? According to {scene.ThePhysicalStateOfTheProtagonists.WordText}, we're considering a new career as professional couch potatoes.",
                scene => $"When we heard {scene.TheSoundOfTheEnemy.WordText}, we were terrified. Until we realized it was just their attempt at karaoke.",
                scene => $"With {scene.TheTimeLeftToCompleteTheMission.WordText} left, we knew what had to be done: prioritize. So, we took a nap."
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
                scene => $"The stark contrast between {scene.TheBeforeAndAfter.WordText} is jarring.",
                scene => $"I feel a deep sense of pride every time we {scene.ActionThatContributesToTheMission.WordText}. It's what keeps me going.",
                scene => $"Seeing the {scene.ActionObjectThatContributesToTheMission.WordText} in action at {scene.TimeOfDay.WordText} fills me with hope. We're really making a difference.",
                scene => $"The way we {scene.ActionThatContributesToTheMission.WordText} the {scene.ActionObjectThatContributesToTheMission.WordText}... It's inspiring. It makes all the hardships worth it.",
                scene => $"Every time we {scene.ActionThatContributesToTheMission.WordText} with the {scene.ActionObjectThatContributesToTheMission.WordText}, I feel safer. It's like we're building a better future with our own hands.",
                scene => $"The memory of {scene.ARelatedNegativePastEvent.WordText} haunts me, but when we {scene.ActionThatContributesToTheMission.WordText} with the {scene.ActionObjectThatContributesToTheMission.WordText} and ensure {scene.ActionThatContributesToSafety.WordText}, I find a bit of solace.",
                scene => $"Whenever we {scene.ActionThatContributesToTheMission.WordText}, I can't help but feel an overwhelming sense of purpose.",
                scene => $"It's heartbreaking, knowing that every {scene.ActionThatDetractsFromTheMission.WordText} pushes us further from our goal.",
                scene => $"The anguish I feel when seeing {scene.VictimsOfTheEnemy.WordText} suffering at the hands of {scene.AnEnemyOfTheMission.WordText} is unbearable.",
                scene => $"The revelation of {scene.TheMainCauseOfTheProblem.WordText} stirred a mix of anger and determination within me.",
                scene => $"Witnessing the {scene.TheImmediateEffectsOfTheProblem.WordText} firsthand has left a deep scar on my soul.",
                scene => $"The thought of {scene.ASaferLocation.WordText} being so close, yet with only {scene.TheTimeLeftToCompleteTheMission.WordText} left, fills me with anxiety.",
                scene => $"The echo of {scene.ARelatedNegativePastEvent.WordText} in my mind serves as a grim reminder of what's at stake.",
                scene => $"Knowing we have {scene.ASecretWeapon.WordText} to use against {scene.TheEnemy.WordText} brings a rare feeling of triumph.",
                scene => $"Facing {scene.AnObstacleToTheMission.WordText} fills me with frustration. It's like we're being tested at every turn.",
                scene => $"The vision of achieving {scene.TheGoalOfTheMission.WordText} fills me with such longing and motivation.",
                scene => $"The complexity of {scene.APlanToSucceedAtMission.WordText} weighs heavily on me, but I'm committed to seeing it through.",
                scene => $"The uncertainty surrounding {scene.TheStatusOfTheMainCauseOfTheProblem.WordText} leaves me feeling helpless and desperate for answers.",
                scene => $"Knowing {scene.TheMentalStateOfTheEnemy.WordText} gives me an eerie sense of foreboding about what's to come.",
                scene => $"Discovering {scene.LocationOfTheEnemy.WordText} brings a mix of fear and strategic opportunity.",
                scene => $"Realizing the extent of {scene.AnImmediateDangerToTheProtagonists.WordText} sends shivers down my spine. We must be vigilant.",
                scene => $"The support from {scene.HelpfulEntitiesForTheMission.WordText} is the only thing keeping my spirits up amidst this chaos."
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
                scene => $"In the shadows, {scene.ATraitorInTheRanks.WordText} looms as a stark reminder that not all battles are fought on the outside.",
                scene => $"Our current focus is on {scene.ActionThatContributesToTheMission.WordText}. It's a vital step toward our ultimate goal, ensuring we stay on course.",
                scene => $"Implementing {scene.ActionThatContributesToTheMission.WordText} is crucial. Without it, we're looking at {scene.AFateIfTheMissionFails.WordText}, a scenario we can't afford to face.",
                scene => $"We've identified {scene.ObjectYouAreLookingFor.WordText} as essential for our progress. Discovering it could lead to {scene.AWayToEscape.WordText}, offering us a much-needed advantage.",
                scene => $"We've encountered {scene.AnEnemyOfTheMission.WordText} near {scene.LocationOfTheEnemy.WordText}. Their presence complicates our efforts and requires immediate attention.",
                scene => $"We're currently facing {scene.AnImmediateDangerToTheProtagonists.WordText}. It's a critical situation that demands swift action to ensure our safety.",
                scene => $"The main issue now is {scene.AThreatOfTheEnemy.WordText}, which aligns with {scene.TheNeedsOfTheEnemy.WordText}. Understanding this dynamic is key to anticipating their moves.",
                scene => $"A significant part of our strategy involves {scene.ActionThatContributesToSafety.WordText}. This measure is indispensable for maintaining the wellbeing of our team."
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
                scene => $"In the aftermath of {scene.TheBattle.WordText}, {scene.LocationOfTheMission.WordText} lay in silence, a stark reminder of the cost of war and the fragile hope for peace.",
                scene => $"Just when progress seemed within reach, {scene.ActionThatDetractsFromTheMission.WordText} threatened to undermine our efforts, pulling us away from {scene.TheGoalOfTheMission.WordText}.",
                scene => $"Amidst our planning, {scene.ActionThatDetractsFromTheMission.WordText} emerged as a stark reminder of the fragility of {scene.TheIdealStrategyForTheMission.WordText}.",
                scene => $"As we stood on the brink of success, {scene.WhatHingesOnTheSuccessOfTheMission.WordText} became jeopardized by {scene.ActionThatDetractsFromTheMission.WordText}, casting a shadow over our hopes.",
                scene => $"The echoes of {scene.ARelatedNegativePastEvent.WordText} resurfaced when {scene.ActionThatDetractsFromTheMission.WordText} reared its head, setting us back once more.",
                scene => $"In a moment of serendipity, {scene.ObjectThatAssistsTheMission.WordText} was discovered, offering a glimmer of hope against the encroaching darkness.",
                scene => $"Every step forward was countered by a setback, yet {scene.ActionThatContributesToTheMission.WordText} kept the flame of our determination alive.",
                scene => $"The clash between {scene.VictimsOfTheEnemy.WordText} and {scene.AnEnemyOfTheMission.WordText} underscored the escalating stakes of our mission.",
                scene => $"Unsung heroes, those like {scene.TheUnsungHeroes.WordText}, emerged, steering us closer to achieving {scene.TheMissionObjective.WordText} against all odds.",
                scene => $"Reminders of {scene.ARelatedNegativePastEvent.WordText} served as a somber backdrop to our current trials, urging us to push forward lest history repeat itself.",
                scene => $"The toll was evident in {scene.TheLossesWeHaveSuffered.WordText}, each loss a stark testament to the cost of our struggle.",
                scene => $"Facing {scene.AnObstacleToTheMission.WordText}, our resolve was tested, challenging us to find the strength to persevere.",
                scene => $"With our eyes firmly set on {scene.TheGoalOfTheMission.WordText}, every decision, every action, took on new weight and urgency.",
                scene => $"Our strategy, {scene.APlanToSucceedAtMission.WordText}, was our beacon, guiding us through uncertainty towards a hopeful victory.",
                scene => $"The shadows of {scene.LocationOfTheEnemy.WordText} hid not just {scene.AnEnemyOfTheMission.WordText} but the seeds of a plan that could turn the tide.",
                scene => $"Amidst the chaos, {scene.AnImmediateDangerToTheProtagonists.WordText} loomed, a constant threat that tested our courage and resolve.",
                scene => $"In our darkest hour, {scene.HelpfulEntitiesForTheMission.WordText} emerged as bearers of light, offering aid and hope.",
                scene => $"Our mission's success was not defined by a single act but by prioritizing {scene.APriorityForTheMission.WordText}, a principle that guided our every decision.",
                scene => $"The role of {scene.ActionObjectThatContributesToTheMission.WordText} became undeniably crucial, embodying our efforts to forge ahead despite adversity.",
                scene => $"The plight of {scene.VictimsOfTheEnemy.WordText} at {scene.LocationOfTheVictim.WordText} painted a harrowing picture of the enemy's cruelty.",
                scene => $"Confronted with {scene.AnObstacleToTheMission.WordText}, its {scene.StatusOfTheObstacleToTheMission.WordText} became a puzzle we were determined to solve.",
                scene => $"The air was thick with tension as we neared {scene.LocationOfTheEnemy.WordText}, the epicenter of our foe's power.",
                scene => $"Memories of {scene.APastEventMirroringTheCurrentMission.WordText} mingled with the unfolding mystery of {scene.TheMysteryUnfolding.WordText}, deepening the intrigue of our quest.",
                scene => $"The status of {scene.TheStatusOfTheMainCauseOfTheProblem.WordText} was a constant concern, a riddle wrapped in the enigma of our mission.",
                scene => $"Facing {scene.AnImmediateDangerToTheProtagonists.WordText}, we found strength in {scene.HelpfulEntitiesForTheMission.WordText}, allies in the truest sense.",
                scene => $"As the mystery of {scene.TheMysteryUnfolding.WordText} unraveled, we stood at the precipice of understanding, ready to confront the unknown.",
                scene => $"Our collective efforts, {scene.TheAchievementsOfTheGroup.WordText}, became the bedrock upon which our hopes were built, a testament to what we could accomplish together."
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
                scene => $"With eyes wide open to {scene.AnImmediateDangerToTheMission.WordText}, we step forward. This challenge will not define us; our response will.",
                scene => $"With {scene.HelpfulEntitiesForTheMission.WordText} by our side, we're more than ready to accept this challenge. Their support is invaluable.",
                scene => $"After all the {scene.PreparationForTheMission.WordText} we've done, I say we're ready to face what comes next. Let's accept the challenge.",
                scene => $"Facing {scene.AnOverwhelmingChallenge.WordText} head-on won't be easy, but we're prepared for anything. We accept the challenge.",
                scene => $"With {scene.APlanToSucceedAtMission.WordText} in place, we're set to tackle this head-on. Challenge accepted.",
                scene => $"Despite our {scene.ThePhysicalStateOfTheProtagonists.WordText}, we're determined to persevere. We accept the challenge before us.",
                scene => $"Right here in {scene.LocationOfTheMission.WordText}, we stand firm and accept the challenge. This is where we make our stand.",
                scene => $"In response to {scene.TheEnemyActions.WordText}, it's up to {scene.TheHeroesOfTheStory.WordText} like us to step up. We accept this challenge.",
                scene => $"Despite {scene.TheUnknownFactors.WordText}, we're ready to face the unknown. Challenge accepted.",
                scene => $"Given {scene.TheCurrentSituation.WordText}, our only option is to rise to the occasion. We're accepting this challenge.",
                scene => $"Even in hard times, {scene.AMomentOfJoy.WordText} reminds us what we're fighting for. We happily accept this challenge.",
                scene => $"Carrying {scene.TheBurdenCarriedByTheProtagonists.WordText} only strengthens our resolve. We're ready for this challenge.",
                scene => $"Our eyes are set on {scene.TheMissionObjective.WordText}. With that goal in mind, we accept any challenge that comes our way.",
                scene => $"Even with {scene.ATraitorInTheRanks.WordText} among us, we won't be deterred. We accept the challenge, traitors and all.",
                scene => $"{scene.APositiveTurnOfEvents.WordText} has given us new hope. Energized by this, we accept the looming challenge.",
                scene => $"It's time for {scene.TheUnsungHeroes.WordText} to step into the light. We accept this challenge with honor.",
                scene => $"In honor of {scene.TheLossesWeHaveSuffered.WordText}, we accept this challenge to ensure their sacrifices were not in vain.",
                scene => $"Facing {scene.TheInjusticeFaced.WordText} has only hardened our will. We accept this challenge to right those wrongs.",
                scene => $"As {scene.TheMysteryUnfolding.WordText} reveals itself, we're intrigued and ready. Challenge accepted.",
                scene => $"Let {scene.TheAchievementsOfTheGroup.WordText} be our guide. Motivated by our past victories, we accept the challenge ahead.",
                scene => $"Seeing {scene.TheBeforeAndAfter.WordText}, we understand the stakes. We're committed to this fight. Challenge accepted.",
                scene => $"Let's use {scene.ActionThatContributesToTheMission.WordText} with {scene.ActionObjectThatContributesToTheMission.WordText} to our advantage. We accept the challenge and move forward.",
                scene => $"Even though {scene.ActionThatDetractsFromTheMission.WordText} has set us back, we remain undaunted. Challenge accepted.",
                scene => $"Understanding {scene.TheMainCauseOfTheProblem.WordText} has prepared us for this moment. We're ready to accept the challenge.",
                scene => $"Learning from {scene.ARelatedNegativePastEvent.WordText}, we'll apply {scene.ActionThatContributesToTheMission.WordText} using {scene.ActionObjectThatContributesToTheMission.WordText} to ensure {scene.ActionThatContributesToSafety.WordText}. Challenge accepted.",
                scene => $"Aware of {scene.TheMentalStateOfTheEnemy.WordText}, we're psychologically prepared. We accept the challenge with clear minds.",
                scene => $"Knowing {scene.LocationOfTheEnemy.WordText} gives us an edge. We accept the challenge, ready to confront them.",
                scene => $"Facing {scene.AnImmediateDangerToTheProtagonists.WordText} head-on, we accept this challenge with courage and determination."
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
                scene => $"Our latest initiative, {scene.APlanToSucceedAtMission.WordText}, has been a resounding success, exceeding all expectations.",
                scene => $"It turns out that {scene.TheMentalStateOfTheEnemy.WordText} is wavering, giving us a clear advantage moving forward.",
                scene => $"As of {scene.TimeOfDay.WordText}, not only have {scene.TheSurvivors.WordText} been safely relocated, but we're also a step closer to {scene.TheIdealFutureStateOfTheMission.WordText}.",
                scene => $"Despite {scene.ActionThatDetractsFromTheMission.WordText}, we've refined {scene.TheIdealStrategyForTheMission.WordText}, turning potential setbacks into a strategic advantage.",
                scene => $"The silver lining? What hinges on the success of our mission has become clearer, guiding us away from {scene.ActionThatDetractsFromTheMission.WordText} and towards victory.",
                scene => $"We've learned from {scene.ARelatedNegativePastEvent.WordText} and avoided {scene.ActionThatDetractsFromTheMission.WordText}, setting us on a path to success.",
                scene => $"Good news! We've secured {scene.ObjectThatAssistsTheMission.WordText}, which is exactly what we needed to push our advantage.",
                scene => $"I'm pleased to report that {scene.ActionThatContributesToTheMission.WordText} is paying off, advancing us towards our goals faster than anticipated.",
                scene => $"There's hope for {scene.VictimsOfTheEnemy.WordText}. We've managed to outmaneuver {scene.AnEnemyOfTheMission.WordText}, securing a significant victory.",
                scene => $"Our efforts have been recognized. {scene.TheUnsungHeroes.WordText} are now key to achieving {scene.TheMissionObjective.WordText}, marking a turning point in our mission.",
                scene => $"Reflecting on {scene.ARelatedNegativePastEvent.WordText}, it's heartening to see how far we've come, turning past setbacks into strength.",
                scene => $"Despite {scene.TheLossesWeHaveSuffered.WordText}, there's a wave of new resolve amongst us, propelling the mission forward.",
                scene => $"Intelligence reports a shift in {scene.LocationOfTheEnemy.WordText}, suggesting {scene.AnEnemyOfTheMission.WordText} is retreating. This is our chance to strike.",
                scene => $"The tide is turning. {scene.AnImmediateDangerToTheProtagonists.WordText} has been neutralized, thanks to the timely intervention of {scene.HelpfulEntitiesForTheMission.WordText}.",
                scene => $"Our top priority, {scene.APriorityForTheMission.WordText}, is now within reach, setting the stage for a decisive victory.",
                scene => $"The acquisition of {scene.ActionObjectThatContributesToTheMission.WordText} has significantly boosted our operational capacity.",
                scene => $"There's a breakthrough regarding {scene.VictimsOfTheEnemy.WordText} at {scene.LocationOfTheVictim.WordText}. Efforts to rescue them have been successful.",
                scene => $"Reconnaissance has confirmed that {scene.LocationOfTheEnemy.WordText} is no longer a threat, giving us strategic leverage.",
                scene => $"Echoing {scene.APastEventMirroringTheCurrentMission.WordText}, {scene.TheMysteryUnfolding.WordText} has finally been solved, paving the way for future successes.",
                scene => $"Significant progress has been made concerning {scene.TheStatusOfTheMainCauseOfTheProblem.WordText}, bringing us one step closer to resolution.",
                scene => $"Amidst {scene.AnImmediateDangerToTheProtagonists.WordText}, {scene.HelpfulEntitiesForTheMission.WordText} have emerged as invaluable allies, ensuring our safety.",
                scene => $"The unraveling of {scene.TheMysteryUnfolding.WordText} has revealed unexpected allies and resources, bolstering our mission.",
                scene => $"Celebrating {scene.TheAchievementsOfTheGroup.WordText}, we're reminded of our resilience and the impact of our collective efforts."
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
                scene => $"The significance of {scene.TheBeforeAndAfter.WordText} escapes me. How does it change our perspective?",
                scene => $"I'm puzzled. How could {scene.ActionThatDetractsFromTheMission.WordText} possibly serve our goals? It seems counterintuitive.",
                scene => $"I'm trying to wrap my head around this. We're supposed to {scene.ActionThatContributesToTheMission.WordText} and then {scene.AnotherActionThatContributesToTheMission.WordText}? How do these fit together?",
                scene => $"The scale of {scene.TheLossesWeHaveSuffered.WordText} is overwhelming. How did we get to this point? What went wrong?",
                scene => $"I'm struggling to understand {scene.AnUmbrellaTermThatDescribesTheNatureOfTheEnemy.WordText}. What exactly are we up against?",
                scene => $"Why are we heading towards {scene.ASaferLocation.WordText} when it feels like we're moving further from our mission? I'm lost.",
                scene => $"Maintaining {scene.TheIdealMentalStateForTheMission.WordText} is easier said than done. How can we stay focused amid so much chaos?",
                scene => $"I can't grasp the full weight of {scene.TheBurdenCarriedByTheProtagonists.WordText}. How are we expected to carry this and not falter?",
                scene => $"With only {scene.TheTimeLeftToCompleteTheMission.WordText} left, the pressure is mounting. Are we sure about our current pace and direction?",
                scene => $"After everything, {scene.APositiveTurnOfEvents.WordText} seems almost surreal. Is this really happening, or have we overlooked something?",
                scene => $"Why are {scene.FriendsOfTheProtagonists.WordText} reacting this way? I thought they understood our goals.",
                scene => $"I'm puzzled about how to use our {scene.ASkillOfTheProtagonists.WordText} effectively here. Isn't it supposed to be straightforward?",
                scene => $"How did we end up trapped by {scene.ATrapForTheProtagonists.WordText}? Weren't we prepared for this?",
                scene => $"What exactly is {scene.AnObstacleToTheMission.WordText}? I thought we had a clear path forward.",
                scene => $"I can't figure out how to apply our {scene.ASkillOfTheProtagonists.WordText} with {scene.AnImmediateDangerToTheMission.WordText} looming over us. What are we missing?",
                scene => $"Is {scene.AnOverwhelmingChallenge.WordText} really as insurmountable as it seems, or are we just not seeing the solution?",
                scene => $"I'm lost. How did {scene.AnImmediateDangerToTheMission.WordText} catch us off guard like this?",
                scene => $"Why can't we reach {scene.VictimsOfTheEnemy.WordText} more effectively? Where's the disconnect?",
                scene => $"How is {scene.AnEnemyOfTheMission.WordText} using their {scene.ASkillOfTheEnemy.WordText} to stay one step ahead? I can't wrap my head around it.",
                scene => $"What makes {scene.ASuccessFactorOfTheMission.WordText} so crucial? I'm trying to understand its significance.",
                scene => $"Given {scene.ANegativeFactorThatNecessitatedTheMission.WordText} and our location in {scene.LocationOfTheMission.WordText}, how did we end up in this situation?",
                scene => $"I'm struggling to grasp what truly hinges on the success of our mission. What makes {scene.WhatHingesOnTheSuccessOfTheMission.WordText} so vital?",
                scene => $"How are {scene.VictimsOfTheEnemy.WordText} and their location at {scene.LocationOfTheVictim.WordText} connected? It's not adding up.",
                scene => $"Can someone explain how {scene.APastEvent.WordText} ties into {scene.TheMystery.WordText}? I'm completely lost.",
                scene => $"Why is {scene.ANaturalPhenomenon.WordText} happening now, right here at {scene.LocationOfTheMission.WordText}? It seems too coincidental.",
                scene => $"What's our real plan with {scene.APlanToSucceedAtMission.WordText}? It seems like we're just guessing at this point.",
                scene => $"Does anyone understand the current status of {scene.TheStatusOfTheMainCauseOfTheProblem.WordText}? I'm finding it hard to follow.",
                scene => $"What's going on with {scene.TheMentalStateOfTheEnemy.WordText}? It's like we're missing a piece of the puzzle.",
                scene => $"How are {scene.HelpfulEntitiesForTheMission.WordText} supposed to aid us? Their role is still unclear to me.",
                scene => $"I'm confused about how we're addressing the needs of {scene.TheSurvivors.WordText}. Are we doing enough?",
                scene => $"What did our {scene.TheAchievementsOfTheGroup.WordText} actually accomplish? I'm struggling to see the impact."
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
                scene => $"I'm bewildered by how quickly {scene.TheCurrentSituation.WordText} has escalated. It seemed unthinkable before.",
                scene => $"I can't believe that {scene.FriendsOfTheProtagonists.WordText} didn't see this coming. Weren't they paying attention?",
                scene => $"Are you telling me that with all our {scene.ASkillOfTheProtagonists.WordText}, we didn't anticipate this?",
                scene => $"Despite our {scene.ASkillOfTheProtagonists.WordText}, how did our {scene.ActionThatContributesToTheMission.WordText} not make a dent?",
                scene => $"So, you're saying despite our best efforts to {scene.ActionThatContributesToTheMission.WordText} with the {scene.ActionObjectThatContributesToTheMission.WordText}, we're back to square one?",
                scene => $"We fell right into {scene.ATrapForTheProtagonists.WordText}? How could we have been so blind?",
                scene => $"This {scene.ACriticalClue.WordText} was in front of us the whole time? Unbelievable.",
                scene => $"Facing {scene.AnOverwhelmingChallenge.WordText} was beyond anyone's expectation. How are we supposed to overcome this?",
                scene => $"That {scene.VictimsOfTheEnemy.WordText} were overlooked is shocking. How did we miss them?",
                scene => $"Our entire operation hinged on {scene.ASuccessFactorOfTheMission.WordText}, and now it's compromised?",
                scene => $"I never would have thought {scene.ANegativeFactorThatNecessitatedTheMission.WordText} in {scene.LocationOfTheMission.WordText} could lead to this mess.",
                scene => $"Everything we've done was for {scene.WhatHingesOnTheSuccessOfTheMission.WordText}, and now it's all at risk?",
                scene => $"You're saying {scene.VictimsOfTheEnemy.WordText} were found in {scene.LocationOfTheVictim.WordText}? How did we not know sooner?",
                scene => $"After all this time, {scene.APastEvent.WordText} ties back to {scene.TheMystery.WordText}? That's hard to swallow.",
                scene => $"A {scene.ANaturalPhenomenon.WordText} in {scene.LocationOfTheMission.WordText} now? What are the odds?",
                scene => $"We've been aiming for {scene.TheGoalOfTheMission.WordText} all along, and now you're saying it was a wild goose chase?",
                scene => $"Our {scene.APlanToSucceedAtMission.WordText} falls apart at the last minute? This can't be happening.",
                scene => $"So, {scene.TheStatusOfTheMainCauseOfTheProblem.WordText} has changed overnight? That's inconceivable.",
                scene => $"To think {scene.TheMentalStateOfTheEnemy.WordText} would play such a role... I'm at a loss.",
                scene => $"{scene.AnImmediateDangerToTheProtagonists.WordText} is what we're facing now? This escalates things beyond belief.",
                scene => $"With only {scene.TheTimeLeftToCompleteTheMission.WordText} left, our options are shrinking. This is dire.",
                scene => $"That {scene.HelpfulEntitiesForTheMission.WordText} would come to our aid was expected, but their timing is unbelievable.",
                scene => $"The fact that {scene.TheSurvivors.WordText} made it through is nothing short of a miracle.",
                scene => $"Considering {scene.TheAchievementsOfTheGroup.WordText}, to be in this position is staggering. Didn't we learn anything?"
            };
            this.expositions.Add(SentencePurposeType.ExpressDisbelief, expressDisbelief);

            var expressPersonalPeril = new List<Func<Scene, string>>
            {
                scene => $"I feel like I'm walking on a tightrope with no safety net. The {scene.TheEnemy.WordText}'s presence here has made every moment a gamble.",
                scene => $"There's a knot in my stomach that won't go away. Ever since {scene.TheMainCauseOfTheProblem.WordText} started, I've felt like I'm in constant danger.",
                scene => $"I've never admitted this, but I'm scared. Facing {scene.AnEnemyOfTheMission.WordText} has brought me face to face with my own mortality.",
                scene => $"Every shadow feels like it could be hiding {scene.AnEnemyOfTheMission.WordText}. I can't shake the feeling of being watched, hunted.",
                scene => $"The weight of {scene.WhatHingesOnTheSuccessOfTheMission.WordText} is crushing. It's like carrying a burden that's too heavy, knowing that slipping up could mean disaster.",
                scene => $"The closer we get to {scene.LocationOfTheMission.WordText}, the more I feel like we're walking into a trap. It's as if {scene.AnImmediateDangerToTheMission.WordText} is waiting for us at every turn.",
                scene => $"I've seen what happens when {scene.AFateIfTheMissionFails.WordText} comes to pass. The thought of it happening to me, to us, is terrifying.",
                scene => $"There's a sense of dread that comes with {scene.TheTimeLeftToCompleteTheMission.WordText}. Each tick of the clock is a reminder of the peril we're in.",
                scene => $"I thought I knew what fear was, but staring down {scene.TheChaosCausedByTheEnemy.WordText} has given it a whole new meaning.",
                scene => $"The silence of {scene.LocationOfTheMission.WordText} is unnerving. It feels like the calm before the storm, where {scene.AnImmediateDangerToTheMission.WordText} could strike at any moment.",
                scene => $"Sometimes, in the dead of {scene.TimeOfDay.WordText}, I wonder if we'll make it out alive. The uncertainty is the hardest part.",
                scene => $"Knowing that {scene.TheEnemy.WordText} could be just around the corner, waiting for a moment of weakness, keeps me up at night.",
                scene => $"The scars I carry aren't just physical; the mental toll of {scene.TheMainCauseOfTheProblem.WordText} has left me questioning if I'll ever find peace again.",
                scene => $"There's a part of me that's still trapped in {scene.LocationOfTheMission.WordText}, facing {scene.AnOverwhelmingChallenge.WordText} over and over in my mind.",
                scene => $"As much as I try to hide it, the prospect of facing {scene.TheEnemy.WordText} again fills me with a paralyzing fear. It's a battle not just for survival, but for sanity.",
                scene => $"I'm trapped beneath {scene.ATrapForTheProtagonists.WordText}, and every attempt to free myself only seems to tighten its grip.",
                scene => $"The walls of {scene.LocationOfTheMission.WordText} are closing in on me, like {scene.AnImmediateDangerToTheMission.WordText} made manifest.",
                scene => $"I find myself caught in {scene.ATrapForTheProtagonists.WordText}, a situation more dire than any I've faced before.",
                scene => $"It's like I'm ensnared in {scene.ATrapForTheProtagonists.WordText}, with each movement drawing me deeper into despair.",
                scene => $"The realization hits me hard; I'm not just facing {scene.TheEnemy.WordText}, I'm battling {scene.ATrapForTheProtagonists.WordText} designed to be my undoing.",
                scene => $"Every path seems to lead to {scene.ATrapForTheProtagonists.WordText}, a labyrinth designed with no escape, only endless circles of peril.",
                scene => $"Caught in the grip of {scene.ATrapForTheProtagonists.WordText}, I feel the weight of {scene.WhatHingesOnTheSuccessOfTheMission.WordText} bearing down, a burden too heavy to bear alone.",
                scene => $"The shadow of {scene.TheEnemy.WordText} looms large, but it's the snare of {scene.ATrapForTheProtagonists.WordText} that truly terrifies me, a trap set with cruel precision.",
                scene => $"As I navigate the treacherous terrain of {scene.LocationOfTheMission.WordText}, I can't shake the feeling that {scene.ATrapForTheProtagonists.WordText} lies in wait, ready to spring at the slightest misstep."
            };
            this.expositions.Add(SentencePurposeType.ExpressPersonalPeril, expressPersonalPeril);

            var expressDetermination = new List<Func<Scene, string>>
            {
                scene => $"No matter what {scene.TheEnemy.WordText} throws at us, we will not falter. Our resolve is stronger than their malice.",
                scene => $"We've come too far to give up now. {scene.TheGoalOfTheMission.WordText} is within our reach, and I'll see it through to the end.",
                scene => $"The path ahead is fraught with {scene.AnObstacleToTheMission.WordText}, but I am undeterred. We will overcome.",
                scene => $"I refuse to be intimidated by {scene.TheChaosCausedByTheEnemy.WordText}. Our cause is just, and our spirits are unbreakable.",
                scene => $"Let {scene.TheEnemy.WordText} underestimate us. It will be their downfall. Our determination is our greatest weapon.",
                scene => $"This mission, {scene.TheGoalOfTheMission.WordText}, it's more than a goal; it's a promise I intend to keep, no matter the cost.",
                scene => $"Every challenge, every setback, has only strengthened my resolve. {scene.AnObstacleToTheMission.WordText} will not stop us.",
                scene => $"We stand at the brink of {scene.TheIdealFutureStateOfTheMission.WordText}. I vow to lead us there, through every difficulty.",
                scene => $"I am committed to {scene.ActionThatContributesToTheMission.WordText}, in the face of {scene.AnImmediateDangerToTheMission.WordText} or any threat. Our mission is too important.",
                scene => $"Though {scene.AnImmediateDangerToTheMission.WordText} looms large, my determination is unwavering. We will secure {scene.TheGoalOfTheMission.WordText}, come what may.",
                scene => $"I've seen what happens if we fail, and I refuse to let {scene.AFateIfTheMissionFails.WordText} become our reality. We will succeed.",
                scene => $"Our journey has been marked by {scene.TheChaosCausedByTheEnemy.WordText}, but our resolve remains stronger than ever. We will prevail.",
                scene => $"Let the history books show that when faced with {scene.AnOverwhelmingChallenge.WordText}, we did not back down. We stood tall and faced it head-on.",
                scene => $"The stakes, {scene.WhatHingesOnTheSuccessOfTheMission.WordText}, have never been higher. But so too is our determination to triumph.",
                scene => $"We won't stop until we find {scene.ObjectYouAreLookingFor.WordText} and discover {scene.AWayToEscape.WordText}. Our resolve is unwavering.",
                scene => $"With {scene.AWeaponAgainstTheEnemy.WordText} in our hands, we have more than just hope—we have a plan. Let's turn the tide.",
                scene => $"Despite the {scene.StatusOfTheMission.WordText}, our determination remains strong. We'll see this through to the end.",
                scene => $"We're in {scene.LocationOfTheMission.WordText}, facing {scene.TheMainCauseOfTheProblem.WordText} head-on. This is our fight, and we're not backing down.",
                scene => $"Even as {scene.TimeOfDay.WordText} falls and we see {scene.TheImmediateEffectsOfTheProblem.WordText}, our spirits don't waver. We're committed to overcoming this.",
                scene => $"Understanding {scene.TheMentalStateOfTheEnemy.WordText} gives us an edge. We're prepared to counter every move they make.",
                scene => $"The {scene.StatusOfTheObstacleToTheMission.WordText} won't deter us. We're determined to find a way around every hurdle.",
                scene => $"Each {scene.TheSoundOfTheEnemy.WordText} only strengthens our resolve. We stand united, ready to face whatever comes our way.",
                scene => $"As {scene.TimeOfDay.WordText} dawns over {scene.LocationOfTheMission.WordText}, we're reminded of {scene.TheMysteryUnfolding.WordText}. Our determination grows with each passing moment.",
                scene => $"We remember the world as it was {scene.TheBeforeAndAfter.WordText}, and it fuels our determination to restore what was lost.",
                scene => $"We draw strength from {scene.TheUnsungHeroes.WordText}, whose silent sacrifices pave the way for our victory.",
                scene => $"Even if we face {scene.ATraitorInTheRanks.WordText}, our determination remains unshaken. Betrayal will not break our spirit."
            };
            this.expositions.Add(SentencePurposeType.ExpressDetermination, expressDetermination);

            var sing = new List<Func<Scene, string>>
            {
                scene => $"Beneath the {scene.TimeOfDay.WordText}, we stand united, our voices one,\n'Sing for the dawn, sing for the light, for {scene.TheGoalOfTheMission.WordText} we fight.'",
                scene => $"In the shadow of {scene.AnObstacleToTheMission.WordText}, alone I stand,\n'A whisper in the dark, a flame from a spark, I hold {scene.TheIdealFutureStateOfTheMission.WordText} in my heart.'",
                scene => $"Around the fire's glow, {scene.FriendsOfTheProtagonists.WordText} side by side,\n'Through trials and fears, through laughter and tears, on the wings of hope we ride.'",
                scene => $"Facing {scene.TheEnemy.WordText}, with courage bold and true,\n'No night too dark, no path too stark, to {scene.ActionThatContributesToTheMission.WordText} we remain true.'",
                scene => $"A solemn vow to {scene.TheLossesWeHaveSuffered.WordText}, a promise to keep,\n'For those we've lost, no matter the cost, their memories we'll always keep.'",
                scene => $"With every step in {scene.LocationOfTheMission.WordText}, our journey sings,\n'A road untraveled, a mystery unraveled, to our dreams we spread our wings.'",
                scene => $"In the heart of peril, {scene.TheSurvivors.WordText} raise a defiant tune,\n'Against the tide, together we ride, beneath the silver moon.'",
                scene => $"As dawn breaks over {scene.LocationOfTheMission.WordText}, a new day's song,\n'From dusk till dawn, our hope reborn, in unity we're strong.'",
                scene => $"A ballad for {scene.TheUnsungHeroes.WordText}, silent guardians brave and true,\n'In shadows deep, their watch they keep, unseen, unheard, they guide us through.'",
                scene => $"A lullaby for peace, in the midst of {scene.TheChaosCausedByTheEnemy.WordText},\n'Softly we tread, with hope ahead, in our hearts a tranquil beat.'"
            };
            this.expositions.Add(SentencePurposeType.Sing, sing);

            var quip = new List<Func<Scene, string>>
            {
                scene => $"I've seen {scene.TheEnemy.WordText} pull off better tricks than that. They'll have to do better to catch us off guard.",
                scene => $"I've faced {scene.AnEnemyOfTheMission.WordText} before, and trust me, they're not as scary as they think they are.",
                scene => $"I've seen {scene.TheEnemy.WordText} try to intimidate us with their tactics. It's like watching a child throw a tantrum.",
                scene => $"I've been through worse than {scene.TheChaosCausedByTheEnemy.WordText}. It'll take more than that to rattle me.",
                scene => $"Oh, {scene.TheEnemy.WordText} thinks they're clever? I've seen more cunning in a game of hide-and-seek with a toddler.",
                scene => $"So, {scene.AnEnemyOfTheMission.WordText} is trying to outsmart us again? I guess it's hard to teach an old dog new tricks.",
                scene => $"Watching {scene.TheEnemy.WordText} attempt strategy is like watching a fish climb a tree. Amusing, but ultimately futile.",
                scene => $"Ah, the old {scene.TheEnemy.WordText} playbook. I was hoping for a challenge, but I suppose nostalgia has its charms.",
                scene => $"I've seen scarier faces on a plate of {scene.TheEnemy.WordText}'s cuisine. At least that had the potential to upset my stomach.",
                scene => $"Their plan has all the subtlety of a sledgehammer. But then, what do you expect from {scene.TheEnemy.WordText}?",
                scene => $"The only thing predictable about {scene.TheEnemy.WordText} is their predictability. Time for something new, perhaps?",
                scene => $"So, we're in {scene.LocationOfTheMission.WordText}. I always wanted to visit, but under slightly less... life-threatening conditions.",
                scene => $"Ah, {scene.ProtagonistsForTheMission.WordText}, always showing up just in time to save the day. Or is it fashionably late?",
                scene => $"Facing {scene.AnUmbrellaTermThatDescribesTheNatureOfTheEnemy.WordText} again, huh? I was hoping for something a bit more original this time. Sequels are never as good as the original.",
                scene => $"Ah, the {scene.ObjectThatAssistsTheMission.WordText}, our ticket to success. Or as I like to call it, 'The thing that better work or we're all doomed.'"
            };
            this.expositions.Add(SentencePurposeType.Quip, quip);

            var admitIgnorance = new List<Func<Scene, string>>
            {
                scene => $"I'm not sure what to make of {scene.TheEnemy.WordText}'s latest move. It's unlike anything I've seen before.",
                scene => $"I'm at a loss when it comes to understanding the motives behind {scene.TheEnemy.WordText}'s actions. It's a mystery to me.",
                scene => $"I'm not sure how to interpret the significance of {scene.TheMainCauseOfTheProblem.WordText} in relation to our mission. It's a puzzle I can't solve.",
                scene => $"Despite all my experience, {scene.TheEnemy.WordText}'s strategies leave me scratching my head. They're playing a different game.",
                scene => $"I'd be lying if I said I understood {scene.TheEnemy.WordText}'s endgame. It's as if they're reading from a script we don't have.",
                scene => $"The meaning behind {scene.TheMainCauseOfTheProblem.WordText} eludes me. It's like trying to read a book in the dark.",
                scene => $"I must confess, the latest developments from {scene.TheEnemy.WordText} are beyond my comprehension. We're in uncharted waters now.",
                scene => $"For the life of me, I can't decipher {scene.TheEnemy.WordText}'s motives. It's like they're speaking a language without words.",
                scene => $"Facing {scene.TheEnemy.WordText}, I've come to realize how much I don't know. It's a humbling, if not frightening, admission.",
                scene => $"The intricacies of {scene.TheMainCauseOfTheProblem.WordText} escape me. It seems we're dealing with forces more complex than anticipated.",
                scene => $"I must confess, I'm at a loss on how to overcome {scene.AnObstacleToTheMission.WordText}. I'm open to suggestions.",
                scene => $"Honestly, I'm not entirely sure how {scene.ActionObjectThatContributesToTheMission.WordText} fits into our plan. Can someone enlighten me?",
                scene => $"I admit, I'm unclear about the specifics of {scene.TheGoalOfTheMission.WordText}. Could we go over it once more?",
                scene => $"As for {scene.APlanToSucceedAtMission.WordText}, I'm not sure I grasp all its nuances. A little help?",
                scene => $"The truth is, I don't fully understand {scene.TheStatusOfTheMainCauseOfTheProblem.WordText}. What exactly are we dealing with?",
                scene => $"Regarding {scene.AnEnemyOfTheMission.WordText}, I'm embarrassed to say I know less than I should. What's their deal?",
                scene => $"When it comes to {scene.ProtagonistsForTheMission.WordText} and {scene.AnImmediateDangerToTheMission.WordText}, I feel out of my depth. What are we facing?",
                scene => $"I'm struggling to comprehend {scene.TheMentalStateOfTheEnemy.WordText}. Does anyone have insights?",
                scene => $"The effects of {scene.TheImmediateEffectsOfTheProblem.WordText} are beyond me. Can someone explain the implications?",
                scene => $"Where exactly is {scene.LocationOfTheEnemy.WordText}? I realize I don't have that information.",
                scene => $"I'm ashamed to admit, I don't know how best to assist {scene.VictimsOfTheEnemy.WordText}. What's the best course of action?",
                scene => $"Facing {scene.AnImmediateDangerToTheProtagonists.WordText}, I find myself unsure of the right approach. Thoughts?",
                scene => $"With {scene.TheTimeLeftToCompleteTheMission.WordText} ticking away, I'm not sure of our best move. Guidance, please?",
                scene => $"I'm not familiar with how {scene.HelpfulEntitiesForTheMission.WordText} could aid us. Can someone fill me in?",
                scene => $"The unfolding of {scene.TheMysteryUnfolding.WordText} is something I haven't grasped yet. Can we discuss?",
                scene => $"I have to admit, the scale of {scene.TheChaosCausedByTheEnemy.WordText} escapes me. How severe is it?",
                scene => $"I'm not well-informed about {scene.TheSurvivors.WordText}. What should we know?",
                scene => $"I'm ignorant of {scene.TheAchievementsOfTheGroup.WordText}. What have we accomplished so far?"
            };
            this.expositions.Add(SentencePurposeType.AdmitIgnorance, admitIgnorance);

            var internalDialogue = new List<Func<Scene, string>>
            {
                scene => $"I can't shake the feeling that something is amiss. {scene.TheEnemy.WordText} is up to something, and I need to figure out what.",
                scene => $"I've been turning over the events of the day in my mind. There's a pattern here, a connection I'm missing.",
                scene => $"I can't help but wonder if {scene.TheEnemy.WordText} is one step ahead of us. I need to anticipate their next move.",
                scene => $"The pieces of the puzzle are scattered, but I know they fit together somehow. I just need to find the right arrangement.",
                scene => $"I've been mulling over the implications of {scene.TheMainCauseOfTheProblem.WordText}. There's a hidden truth waiting to be uncovered.",
                scene => $"I can't ignore the sense of urgency that comes with {scene.TheImmediateEffectsOfTheProblem.WordText}. We need to act, and soon.",
                scene => $"The weight of {scene.WhatHingesOnTheSuccessOfTheMission.WordText} is heavy on my mind. I can't afford to let it slip through our fingers.",
                scene => $"I've been wrestling with the best approach to {scene.ActionThatContributesToTheMission.WordText}. There's a strategy here, if I can just find it.",
                scene => $"The thought of {scene.AnImmediateDangerToTheMission.WordText} keeps me awake at night. I need to find a way to protect us.",
                scene => $"I've been contemplating the significance of {scene.ACriticalClue.WordText}. There's a message here, if only I can decipher it.",
                scene => $"I can't shake the feeling that {scene.TheMysteryUnfolding.WordText} holds the key to our success. I need to unravel its secrets.",
                scene => $"The implications of {scene.TheLossesWeHaveSuffered.WordText} weigh heavily on my heart. I need to find a way to honor their sacrifice.",
                scene => $"I've been reflecting on the role of {scene.APlanToSucceedAtMission.WordText}. There's a path forward, if I can just see it.",
                scene => $"The thought of {scene.AnOverwhelmingChallenge.WordText} looms large in my mind. I need to find a way to overcome it.",
                scene => $"Every step feels like a move in a grand chess game with {scene.TheEnemy.WordText}. But what's their endgame?",
                scene => $"I keep replaying {scene.APastEventMirroringTheCurrentMission.WordText} in my mind, searching for lessons that might guide our current path.",
                scene => $"The echo of {scene.TheSoundOfTheEnemy.WordText} haunts me. What aren't we seeing?",
                scene => $"As I consider {scene.ActionObjectThatContributesToTheMission.WordText}, I can't help but think there's more we can do. What's the missing piece?",
                scene => $"The silence of {scene.LocationOfTheMission.WordText} speaks volumes. Are we walking into a trap?",
                scene => $"The notion of {scene.ATraitorInTheRanks.WordText} chills me to the bone. Trust is a luxury we may no longer afford.",
                scene => $"I ponder the wisdom of {scene.PreparationForTheMission.WordText}. Did we overlook something crucial?",
                scene => $"The resilience of {scene.FriendsOfTheProtagonists.WordText} gives me strength. How can I ensure their safety?",
                scene => $"Contemplating {scene.ASolution.WordText} to {scene.TheProblem.WordText}, I wonder, are we thinking too narrowly?",
                scene => $"The prospect of {scene.APositiveTurnOfEvents.WordText} offers a glimmer of hope. How can we make it a reality?",
                scene => $"I'm haunted by the what-ifs. What if {scene.ActionThatDetractsFromTheMission.WordText} is the mistake that undoes us?",
                scene => $"As I think about {scene.APriorityForTheMission.WordText}, clarity begins to dawn. It's all about focus.",
                scene => $"Reflecting on {scene.AnEnemyOfTheMission.WordText}'s last move, I sense a vulnerability. How can we turn this to our advantage?",
                scene => $"The memory of {scene.ARelatedNegativePastEvent.WordText} lingers, a stark reminder of what we stand to lose.",
                scene => $"In the quiet moments, I find myself thinking about {scene.AMomentOfJoy.WordText}. It's these memories that keep me grounded.",
                scene => $"Pondering {scene.HelpfulEntitiesForTheMission.WordText}'s role, I realize we're not alone in this. How can we leverage this alliance more effectively?",
                scene => $"The stakes of {scene.WhatHingesOnTheSuccessOfTheMission.WordText} press on me. We must find a path to victory, for failure is not an option.",
                scene => $"I keep thinking about {scene.ActionThatContributesToSafety.WordText}. It's crucial, yet I wonder if it's enough to keep us safe.",
                scene => $"The thought of {scene.AFateIfTheMissionFails.WordText} keeps me awake at night, but I cling to {scene.ASuccessFactorOfTheMission.WordText} as our beacon of hope.",
                scene => $"Every shadow seems to whisper of {scene.AnImmediateDangerToTheProtagonists.WordText}. How did we become the hunted?",
                scene => $"Facing {scene.AnObstacleToTheMission.WordText} is daunting, especially now that its {scene.StatusOfTheObstacleToTheMission.WordText} is becoming clear.",
                scene => $"Sometimes, I can't help but marvel at the {scene.AnUmbrellaTermThatDescribesTheNatureOfTheEnemy.WordText}. It's a reminder of what we're up against.",
                scene => $"Never would I have imagined {scene.AnUnexpectedAlly.WordText} in this narrative. The universe really has a sense of irony.",
                scene => $"Memories of {scene.APastEvent.WordText} haunt me, weaving into {scene.TheMystery.WordText} that now unfolds before us.",
                scene => $"Our path is lit by {scene.ASuccessFactorOfTheMission.WordText}, yet the darkness of uncertainty looms ever close.",
                scene => $"The {scene.AThreatOfTheEnemy.WordText}, alongside their {scene.TheNeedsOfTheEnemy.WordText}, paints a complex antagonist. What drives them, I wonder?",
                scene => $"Caught in {scene.ATrapForTheProtagonists.WordText}, I ponder our escape, our next move. It feels like a game of chess with fate.",
                scene => $"In my hands, {scene.ObjectYouAreLookingFor.WordText} feels like both a burden and a key. {scene.AWayToEscape.WordText} lies just beyond reach, yet so far away.",
                scene => $"As I reflect on {scene.StatusOfTheMission.WordText}, I realize how far we've come and yet how much further we must go.",
                scene => $"The weight of {scene.TheAchievementsOfTheGroup.WordText} bears down on me, a testament to our journey and the battles we've faced.",
                scene => $"Thinking about {scene.TheBeforeAndAfter.WordText} sends a shiver down my spine. We've changed, all of us, transformed by the crucible of conflict.",
                scene => $"The {scene.TheBurdenCarriedByTheProtagonists.WordText} feels heavier by the day, a constant reminder of the stakes at hand and the price of failure.",
                scene => $"As I ponder over {scene.TheCurrentSituation.WordText}, I can't help but feel the weight of what's at stake. How did things get so complicated?",
                scene => $"Watching {scene.TheEnemyActions.WordText} unfold, I wonder about {scene.TheHeroesOfTheStory.WordText}. What drives us to stand against such overwhelming odds?",
                scene => $"The goal of our mission, {scene.TheGoalOfTheMission.WordText}, seems both close and distant at the same time. Can we truly achieve it, or is it just a distant dream?",
                scene => $"Imagining {scene.TheIdealFutureStateOfTheMission.WordText} gives me hope. A world where our efforts have made a difference. Is that future within reach?",
                scene => $"Striving for {scene.TheIdealMentalStateForTheMission.WordText} amidst chaos is challenging. How do I find peace in a storm?",
                scene => $"The injustice we've faced, {scene.TheInjusticeFaced.WordText}, burns in my memory. How do we fight something so deeply entrenched?",
                scene => $"Trying to understand {scene.TheMentalStateOfTheEnemy.WordText} is like navigating a labyrinth. What drives their actions? Fear? Desperation?",
                scene => $"Our mission objective, {scene.TheMissionObjective.WordText}, looms over us. It's the beacon guiding our every decision, but also the shadow that darkens our path.",
                scene => $"Feeling the toll on {scene.ThePhysicalStateOfTheProtagonists.WordText}, I realize this journey has changed us all, in ways seen and unseen.",
                scene => $"Contemplating {scene.TheStatusOfTheMainCauseOfTheProblem.WordText} leaves me with more questions than answers. How do we tackle a problem when its roots run so deep?",
                scene => $"The survivors, {scene.TheSurvivors.WordText}, carry stories of loss and hope. Their resilience in the face of despair inspires me.",
                scene => $"With {scene.TheTimeLeftToCompleteTheMission.WordText} ticking away, the pressure mounts. Every moment is precious, every action critical.",
                scene => $"The unknown factors, {scene.TheUnknownFactors.WordText}, loom large in my mind. What unforeseen challenges still lie in wait for us?",
                scene => $"Reflecting on {scene.TheUnsungHeroes.WordText}, I'm reminded that not all heroes are in the spotlight. Some battles are fought in the silence of sacrifice.",
                scene => $"Thinking of the {scene.VictimsOfTheEnemy.WordText} and their location at {scene.LocationOfTheVictim.WordText}, I'm filled with a resolve to do whatever it takes to bring them to safety."
            };
            this.expositions.Add(SentencePurposeType.InternalDialogue, internalDialogue);

            var expressRealization = new List<Func<Scene, string>>
            {
                scene => $"It's all coming together now. {scene.TheEnemy.WordText}'s plan is clear, and we need to act fast.",
                scene => $"I see it now. The significance of {scene.TheMainCauseOfTheProblem.WordText} is undeniable. It's the key to everything.",
                scene => $"The pieces of the puzzle are falling into place. {scene.TheEnemy.WordText}'s strategy is becoming clear, and we need to counter it.",
                scene => $"I've had an epiphany. The implications of {scene.TheMainCauseOfTheProblem.WordText} are far-reaching, and we need to adjust our approach.",
                scene => $"It's like a lightbulb went off in my head. The connection between {scene.TheEnemy.WordText}'s actions and our mission is crystal clear.",
                scene => $"I've had a revelation. The significance of {scene.TheMainCauseOfTheProblem.WordText} is profound, and we need to adapt our strategy.",
                scene => $"I've had a breakthrough. The implications of {scene.TheMainCauseOfTheProblem.WordText} are staggering, and we need to rethink our approach.",
                scene => $"It's all falling into place. The significance of {scene.TheMainCauseOfTheProblem.WordText} is undeniable, and we need to act on this new understanding.",
                scene => $"I've connected the dots. The significance of {scene.TheMainCauseOfTheProblem.WordText} is clear, and we need to adjust our course accordingly.",
                scene => $"I've had a moment of clarity. The implications of {scene.TheMainCauseOfTheProblem.WordText} are profound, and we need to adapt our strategy.",
                scene => $"It's like a fog has lifted. The connection between {scene.TheEnemy.WordText}'s actions and our mission is crystal clear, and we need to act on this new understanding.",
                scene => $"I've had an epiphany. The significance of {scene.TheMainCauseOfTheProblem.WordText} is undeniable, and we need to adjust our approach.",
                scene => $"I've had a revelation. The implications of {scene.TheMainCauseOfTheProblem.WordText} are staggering, and we need to rethink our approach.",
                scene => $"It's all falling into place. The significance of {scene.TheMainCauseOfTheProblem.WordText} is undeniable, and we need to act on this new understanding.",
                scene => $"Suddenly, it all makes sense. {scene.TheTimeLeftToCompleteTheMission.WordText} isn't just a countdown; it's a window of opportunity we must seize.",
                scene => $"A realization strikes me like lightning. Our underestimation of {scene.TheEnemy.WordText} could be our downfall unless we pivot now.",
                scene => $"The truth dawns on me. {scene.TheGoalOfTheMission.WordText} isn’t just a distant dream; it's a tangible reality within our grasp, if only we dare to reach.",
                scene => $"An insight emerges from the fog of war. The true power of {scene.TheHeroesOfTheStory.WordText} lies not in our strength, but in our unity.",
                scene => $"I understand now. The path to {scene.TheIdealFutureStateOfTheMission.WordText} is fraught with peril, yet illuminated by the courage of {scene.TheUnsungHeroes.WordText}.",
                scene => $"It hits me. The enigma of {scene.TheMentalStateOfTheEnemy.WordText} isn't just a barrier; it's a key to predicting their next move.",
                scene => $"Clarity washes over me. The battle scars of {scene.ThePhysicalStateOfTheProtagonists.WordText} are not just wounds; they are badges of resilience.",
                scene => $"An epiphany unfolds. The essence of {scene.TheMissionObjective.WordText} is not in the achievement, but in the journey and the lives we touch along the way.",
                scene => $"I see the light. {scene.TheStatusOfTheMainCauseOfTheProblem.WordText} is not an obstacle; it's a catalyst for innovation and change.",
                scene => $"A moment of clarity. The resilience of {scene.TheSurvivors.WordText} teaches us that hope is not just a feeling; it's our most powerful weapon.",
                scene => $"I've uncovered a truth. The maze of {scene.TheUnknownFactors.WordText} doesn't confine us; it guides us towards paths we never considered.",
                scene => $"An awakening occurs. The tales of {scene.TheUnsungHeroes.WordText} are not forgotten whispers; they are the foundation upon which we build our future.",
                scene => $"A sudden understanding. The plight of {scene.VictimsOfTheEnemy.WordText} at {scene.LocationOfTheVictim.WordText} isn't just a call to action; it's a mandate for justice.",
                scene => $"It dawned on me when I found {scene.ACriticalClue.WordText}; our {scene.ActionThatContributesToTheMission.WordText} might be the key to overcoming {scene.AnObstacleToTheMission.WordText}.",
                scene => $"I just realized, {scene.ActionObjectThatContributesToTheMission.WordText} is exactly what we need right now.",
                scene => $"Suddenly, it's clear to me; our {scene.ActionThatContributesToSafety.WordText} is more vital than we thought.",
                scene => $"I've come to understand that {scene.ActionThatContributesToTheMission.WordText} isn't just a task; it's our lifeline.",
                scene => $"The epiphany hit me; without {scene.ActionThatContributesToTheMission.WordText}, {scene.AFateIfTheMissionFails.WordText} becomes inevitable.",
                scene => $"I realized too late that {scene.ActionThatDetractsFromTheMission.WordText} has been holding us back all along.",
                scene => $"The harsh truth is, {scene.ActionThatDetractsFromTheMission.WordText} could lead us straight to {scene.AFateIfTheMissionFails.WordText} if we're not careful.",
                scene => $"It's become clear that {scene.AFateIfTheMissionFails.WordText} and {scene.ASuccessFactorOfTheMission.WordText} are two sides of the same coin.",
                scene => $"In that moment of {scene.AMomentOfJoy.WordText}, I understood what we're fighting for.",
                scene => $"The realization about {scene.AnEnemyOfTheMission.WordText} changed everything for me.",
                scene => $"Knowing {scene.AnEnemyOfTheMission.WordText} is in {scene.LocationOfTheEnemy.WordText} puts everything into perspective.",
                scene => $"The danger we face in {scene.LocationOfTheMission.WordText} has made me see {scene.AnImmediateDangerToTheMission.WordText} in a new light.",
                scene => $"Now I see the full picture; {scene.AnImmediateDangerToTheProtagonists.WordText} is closer than we thought.",
                scene => $"It hit me; {scene.AnObstacleToTheMission.WordText} isn't just a barrier, it's a lesson.",
                scene => $"I've figured it out; {scene.AnObstacleToTheMission.WordText} might actually have a {scene.PossibleSolutionToConsider.WordText}.",
                scene => $"Facing {scene.AnOverwhelmingChallenge.WordText} has opened my eyes to what we're truly capable of.",
                scene => $"I never fully understood {scene.AnUmbrellaTermThatDescribesTheNatureOfTheEnemy.WordText} until now.",
                scene => $"Meeting {scene.AnUnexpectedAlly.WordText} was the moment everything changed for me.",
                scene => $"Reflecting on {scene.APastEvent.WordText}, I see how it connects to {scene.TheMystery.WordText}.",
                scene => $"Looking back at {scene.APastEventMirroringTheCurrentMission.WordText}, it's clear {scene.AnActionThatLedToSuccess.WordText} was the turning point.",
                scene => $"This {scene.APositiveTurnOfEvents.WordText} has shown me just how crucial {scene.ActionThatContributesToTheMission.WordText} is.",
                scene => $"Now I know, {scene.APriorityForTheMission.WordText} is what matters most.",
                scene => $"The memory of {scene.ARelatedNegativePastEvent.WordText} serves as a stark reminder of what's at stake.",
                scene => $"The realization hit me hard: our current location, once a haven, is no longer safe. The necessity of reaching {scene.ASaferLocation.WordText} has never been more urgent."
            };
            this.expositions.Add(SentencePurposeType.ExpressRealization, expressRealization);

            var endConversation = new List<Func<Scene, string>>
            {
                scene => $"I think we've covered everything for now. Let's regroup and continue this discussion later.",
                scene => $"I need some time to process everything we've discussed. Let's reconvene when we have more information.",
                scene => $"I think it's best if we take a break for now. We can resume our conversation when we have a clearer picture of the situation.",
                scene => $"This has been productive, but let's pause here. We'll have fresh ideas after some rest.",
                scene => $"Given the complexities we're facing, it might be wise to reflect on our discussion before proceeding further.",
                scene => $"Let's call it a day and gather more insights. We can approach this with new perspectives tomorrow.",
                scene => $"Our discussion has raised important points, but I suggest we halt here and consult with others before deciding our next move.",
                scene => $"It seems we've reached a natural stopping point. Let's continue this dialogue once we've all had a chance to think things over.",
                scene => $"We've delved deep into this matter. Let's reconvene once we've had time to consider the best path forward.",
                scene => $"I believe we've touched on all pressing issues. Let's resume after we've each had time to evaluate our priorities."
            };
            this.expositions.Add(SentencePurposeType.EndConversation, endConversation);


            var startConversation = new List<Func<Scene, string>>
            {
                scene => $"I think it's time we discussed our next steps. There's a lot to consider, and we need to be prepared for anything.",
                scene => $"We need to address the challenges ahead. Let's talk about how we can overcome them and achieve our goal.",
                scene => $"I believe it's important for us to have an open dialogue about the current situation. We need to be on the same page to move forward effectively.",
                scene => $"Let's dive into the heart of the matter. We have critical decisions to make, and time isn't on our side.",
                scene => $"The situation demands our immediate attention. Let's outline our strategy and assign responsibilities.",
                scene => $"There are new developments that we need to discuss. Our approach must evolve with the changing circumstances.",
                scene => $"I've gathered us here to brainstorm potential solutions to the obstacles we're facing. Every perspective is valuable.",
                scene => $"It's crucial we align our efforts now more than ever. Let's discuss our collective strategy and ensure no effort is duplicated.",
                scene => $"With recent events, it's imperative we reassess our position. Let's examine our options moving forward.",
                scene => $"Our journey ahead is filled with uncertainty. Let's navigate these challenges together, starting with this conversation."
            };
            this.expositions.Add(SentencePurposeType.StartConversation, startConversation);


            var castASpell = new List<Func<MagicalScene, string>>
            {
                scene => $"With a whispered incantation, I summon {scene.AMagicalElement.WordText}, weaving the energies to {scene.ActionThatContributesToTheMission.WordText}.",
                scene => $"Hands outstretched, I call upon {scene.ASourceOfMagic.WordText}, channeling its power to {scene.AMagicalOutcome.WordText} against {scene.TheEnemy.WordText}.",
                scene => $"Eyes closed, I focus deeply, invoking {scene.ASpell.WordText} to reveal the secrets of {scene.AMystery.WordText}.",
                scene => $"The air crackles with energy as I cast {scene.ASpell.WordText}, a protective barrier forming around {scene.ProtectedEntities.WordText}.",
                scene => $"Chanting the ancient words, I harness {scene.ASourceOfMagic.WordText} to heal {scene.AfflictedEntities.WordText}, their wounds mending before our eyes.",
                scene => $"With a forceful gesture, I unleash {scene.AMagicalElement.WordText}, the spell colliding with {scene.AnObstacleToTheMission.WordText} and dissolving it into nothing.",
                scene => $"Drawing symbols in the air, I conjure {scene.ASummonedCreature.WordText}, bidding it to aid us in our quest to {scene.ActionThatContributesToTheMission.WordText}.",
                scene => $"Murmuring an eldritch verse, I manipulate the fabric of reality, bending {scene.ANaturalElement.WordText} to our will, clearing the path towards {scene.TheGoalOfTheMission.WordText}.",
                scene => $"I focus my will, tapping into {scene.AMagicalArtifact.WordText}, its glow intensifying as I direct its power to {scene.AMagicalEffect.WordText}.",
                scene => $"The ground trembles as I invoke {scene.ASpell.WordText}, summoning forces that lay dormant, to rise and {scene.ActionThatContributesToTheMission.WordText}.",
                scene => $"In the language of the ancients, I speak {scene.ASpell.WordText}, shadows coalescing to whisper secrets of {scene.AMystery.WordText} to us.",
                scene => $"I trace the runes of {scene.ASpell.WordText} in the air, a flash of light signifying the sealing of {scene.AnEnemyOfTheMission.WordText}, their power waning under the spell's might."
            };
            this.magicalExpositions.Add(SentencePurposeType.CastASpell, castASpell);

        }
    }
}
