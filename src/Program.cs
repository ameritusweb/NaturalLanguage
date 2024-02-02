using Newtonsoft.Json;

namespace NaturalLanguageProcess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Scene missionScene = new Scene
            {
                // Already defined properties
                ObjectYouAreLookingFor = new StoryWord { WordText = "Seeds of Eden" },
                ObjectThatAssistsTheMission = new StoryWord { WordText = "Ancient farming manuals" },
                ActionObjectThatContributesToTheMission = new StoryWord { WordText = "Geo-engineering tools" },
                TypeOfMission = new StoryWord { WordText = "Recovery" },
                ImportanceLevelOfMission = new StoryWord { WordText = "Critical" },
                AnUmbrellaTermThatDescribesTheNatureOfTheEnemy = new StoryWord { WordText = "Scorchers" },
                PreparationForTheMission = new StoryWord { WordText = "Tactical training and resource stockpiling" },
                APriorityForTheMission = new StoryWord { WordText = "Securing the Green Zone's perimeter" },
                HelpfulEntitiesForTheMission = new StoryWord { WordText = "The Underground Network of Survivors" },
                TimeOfDay = new StoryWord { WordText = "Dawn" },
                LocationOfTheMission = new StoryWord { WordText = "Green Zone" },
                TheMainCauseOfTheProblem = new StoryWord { WordText = "Barren Earth" },
                ProtagonistsForTheMission = new StoryWord { WordText = "Group of skilled survivors" },
                AnEnemyOfTheMission = new StoryWord { WordText = "The Scorchers" },
                AnImmediateDangerToTheMission = new StoryWord { WordText = "Mutated creatures" },
                TheGoalOfTheMission = new StoryWord { WordText = "Restore the ecosystem" },
                TheIdealFutureStateOfTheMission = new StoryWord { WordText = "Revitalized Earth" },
                LocationOfTheObjectThatAssistsTheMission = new StoryWord { WordText = "Secure vault deep within the Green Zone" },
                FriendsOfTheProtagonists = new StoryWord { WordText = "Allied survivor factions" },
                VictimsOfTheEnemy = new StoryWord { WordText = "Innocent survivors" },
                ASaferLocation = new StoryWord { WordText = "Survivor encampment" },
                TheChaosCausedByTheEnemy = new StoryWord { WordText = "Control over the wasteland, hindering recovery efforts" },
                TheEnemy = new StoryWord { WordText = "Scorcher patrols" },
                TheSoundOfTheEnemy = new StoryWord { WordText = "Roar of engine-powered vehicles" },
                WhatHingesOnTheSuccessOfTheMission = new StoryWord { WordText = "The future of human settlements" },
                AWeaponAgainstTheEnemy = new StoryWord { WordText = "Stealth and knowledge of the land" },

                // Filling in the missing properties
                AWayToEscape = new StoryWord { WordText = "Secret tunnels beneath the Green Zone" },
                APlaceToCommunicate = new StoryWord { WordText = "Abandoned radio station" },
                TheStatusOfTheMainCauseOfTheProblem = new StoryWord { WordText = "Worsening" },
                SpectatorToOrAudienceOfTheMission = new StoryWord { WordText = "Global survivor networks" },
                InitialAssessmentOfMission = new StoryWord { WordText = "High risk, high reward" },
                AnIndicatorThatTheMissionStarted = new StoryWord { WordText = "First light of dawn" },
                StatusOfTheMission = new StoryWord { WordText = "Underway" },
                TheMentalStateOfTheEnemy = new StoryWord { WordText = "Aggressive and determined" },
                APlanToSucceedAtMission = new StoryWord { WordText = "Infiltrate at night, avoid detection" },
                TheImmediateEffectsOfTheProblem = new StoryWord { WordText = "Drought and famine" },
                ASuccessFactorOfTheMission = new StoryWord { WordText = "Stealth" },
                ANegativeFactorThatNecessitatedTheMission = new StoryWord { WordText = "Lack of food and water" },
                MissionComparison = new StoryWord { WordText = "Last hope for humanity" },
                AnObstacleToTheMission = new StoryWord { WordText = "Scorcher outposts" },
                StatusOfTheObstacleToTheMission = new StoryWord { WordText = "Heavily guarded" },
                MissionProgress = new StoryWord { WordText = "Approaching the Green Zone" },
                MissionOriginator = new StoryWord { WordText = "Council of Elders" },
                LengthOfTimeThePotentialSolutionWillLast = new StoryWord { WordText = "Generations" },
                TheTimeLeftToCompleteTheMission = new StoryWord { WordText = "48 hours before the enemy advances" },
                PossibleSolutionToConsider = new StoryWord { WordText = "Alliance with other factions" },
                PossibleProblemToAvoid = new StoryWord { WordText = "Triggering automated defenses" },
                TheIdealMentalStateForTheMission = new StoryWord { WordText = "Calm and focused" },
                TheStateOfTheObjectThatAssistsTheMission = new StoryWord { WordText = "Intact and functional" },
                TheIdealStrategyForTheMission = new StoryWord { WordText = "Divide and conquer" },
                LocationOfTheEnemy = new StoryWord { WordText = "Surrounding the Green Zone" },
                ThePhysicalStateOfTheProtagonists = new StoryWord { WordText = "Exhausted but determined" },
                ActionThatContributesToTheMission = new StoryWord { WordText = "Gathering intelligence" },
                AnotherActionThatContributesToTheMission = new StoryWord { WordText = "Sabotaging enemy resources" },
                ActionThatDetractsFromTheMission = new StoryWord { WordText = "Engaging in open combat" },
                ASkillOfTheProtagonists = new StoryWord { WordText = "Expert survival skills" },
                AHiddenActionOfTheProtagonists = new StoryWord { WordText = "Secret communication with insiders" },
                ActionThatContributesToSafety = new StoryWord { WordText = "Setting up decoys" },
                TheDeedsOrActionsOfTheEnemy = new StoryWord { WordText = "Patrolling the wasteland" },
                AThreatOfTheEnemy = new StoryWord { WordText = "Use of chemical weapons" },
                AWeaponOfTheEnemy = new StoryWord { WordText = "Armored vehicles" },
                TheNeedsOfTheEnemy = new StoryWord { WordText = "Control over resources" },
                CohortToBeRescuedFromTheEnemy = new StoryWord { WordText = "Kidnapped scientists" },
                AnImmediateDangerToTheProtagonists = new StoryWord { WordText = "Ambushes" },
                AFateIfTheMissionFails = new StoryWord { WordText = "Collapse of last human settlements" },
                ARejectedPlanOfTheMission = new StoryWord { WordText = "Direct assault on the Scorcher base" },
                ASkillOfTheEnemy = new StoryWord { WordText = "Advanced warfare tactics" },
                HowTheEnemyCouldTriggerFailureOfTheMission = new StoryWord { WordText = "Intercepting the Seeds of Eden" },
                LocationOfTheVictim = new StoryWord { WordText = "Scorcher prisons" },
                APastEventMirroringTheCurrentMission = new StoryWord { WordText = "The Last Water Convoy" },
                ARelatedNegativePastEvent = new StoryWord { WordText = "The Scorcher Siege" },
                TheBeforeAndAfter = new StoryWord { WordText = "From desolation to hope" },
                TheAchievementsOfTheGroup = new StoryWord { WordText = "Securing the Water Purifier" },
                TheMysteryUnfolding = new StoryWord { WordText = "The origin of the Green Zone's fertility" },
                TheSurvivors = new StoryWord { WordText = "Children of the Oasis" },
                AnOverwhelmingChallenge = new StoryWord { WordText = "Breaching the Green Zone defenses" },
                TheInjusticeFaced = new StoryWord { WordText = "Exploitation by the Scorchers" },
                TheLossesWeHaveSuffered = new StoryWord { WordText = "Fallen comrades in past missions" },
                TheUnsungHeroes = new StoryWord { WordText = "The Silent Scouts" },
                APositiveTurnOfEvents = new StoryWord { WordText = "Discovery of the Seeds' vault" },
                ATraitorInTheRanks = new StoryWord { WordText = "A Scorcher double agent" },
                TheMissionObjective = new StoryWord { WordText = "Reclaim the future of humanity" },
                TheBurdenCarriedByTheProtagonists = new StoryWord { WordText = "The weight of human survival" },
                AMomentOfJoy = new StoryWord { WordText = "Finding the first sprout in the wasteland" },
                TheCurrentSituation = new StoryWord { WordText = "Tense anticipation of the mission's outcome" },
                TheUnknownFactors = new StoryWord { WordText = "The true power of the Seeds of Eden" },
                TheHeroesOfTheStory = new StoryWord { WordText = "The Vanguard of Hope" },
                TheEnemyActions = new StoryWord { WordText = "Scorcher raids on settlements" },
                AnUnexpectedAlly = new StoryWord { WordText = "A rogue Scorcher scientist" },
                ASecretWeapon = new StoryWord { WordText = "An ancient water reclamation device" },
                ACriticalClue = new StoryWord { WordText = "A map to hidden water sources" },
                TheBattle = new StoryWord { WordText = "The Stand at Dawn's Light" },
                StatusOfTheMainCauseOfTheProblem = new StoryWord { WordText = "Critical" },
                AnUnexpectedEvent = new StoryWord { WordText = "The Scorcher's sudden retreat" },
                ANaturalPhenomenon = new StoryWord { WordText = "A rare rainfall rejuvenating the land" },
                APastEvent = new StoryWord { WordText = "The Great Collapse" },
                ASolution = new StoryWord { WordText = "Synthesizing a soil revitalizer" },
                TheProblem = new StoryWord { WordText = "Global desertification" },
                TheMystery = new StoryWord { WordText = "The origin of the Scorchers" },
                AWeakness = new StoryWord { WordText = "Scorcher dependency on fuel" },
                AnAlternativeStrategy = new StoryWord { WordText = "Underground guerrilla tactics" },
                AnActionThatContributesToSafety = new StoryWord { WordText = "Evacuation routes for non-combatants" },
            };

            Character leader = new Character
            {
                Name = "Commander Ava",
                MentalState = new StoryWord { WordText = "Determined" },
                Skill = new StoryWord { WordText = "Strategic planning" },
                Role = new StoryWord { WordText = "Leader of the mission" }
            };

            Character scientist = new Character
            {
                Name = "Dr. Eli",
                MentalState = new StoryWord { WordText = "Curious" },
                Skill = new StoryWord { WordText = "Botanical knowledge" },
                Role = new StoryWord { WordText = "Scientist specializing in plant genetics" }
            };

            Character scout = new Character
            {
                Name = "Jax",
                MentalState = new StoryWord { WordText = "Alert" },
                Skill = new StoryWord { WordText = "Reconnaissance" },
                Role = new StoryWord { WordText = "Scout and pathfinder" }
            };

            Character engineer = new Character
            {
                Name = "Tara",
                MentalState = new StoryWord { WordText = "Innovative" },
                Skill = new StoryWord { WordText = "Mechanical engineering" },
                Role = new StoryWord { WordText = "Engineer responsible for equipment" }
            };

            Character medic = new Character
            {
                Name = "Dr. Sam",
                MentalState = new StoryWord { WordText = "Compassionate" },
                Skill = new StoryWord { WordText = "Medical expertise" },
                Role = new StoryWord { WordText = "Field medic and health officer" }
            };

            Character negotiator = new Character
            {
                Name = "Leah",
                MentalState = new StoryWord { WordText = "Empathetic" },
                Skill = new StoryWord { WordText = "Diplomacy" },
                Role = new StoryWord { WordText = "Negotiator with factions and potential allies" }
            };

            Character survivalist = new Character
            {
                Name = "Rex",
                MentalState = new StoryWord { WordText = "Resilient" },
                Skill = new StoryWord { WordText = "Survival skills" },
                Role = new StoryWord { WordText = "Survival expert and resource scavenger" }
            };

            Character rogueScientist = new Character
            {
                Name = "Dr. Nina",
                MentalState = new StoryWord { WordText = "Defiant" },
                Skill = new StoryWord { WordText = "Genetic engineering" },
                Role = new StoryWord { WordText = "Former Scorcher scientist turned ally" }
            };


            ExpositionGenerator expositionGenerator = new ExpositionGenerator();
            expositionGenerator.GenerateSentencePairs(missionScene, leader);
            //StoryGenerator storyGenerator = new StoryGenerator();
            //storyGenerator.Generate();
            //GlyphGenerator glyphGenerator = new GlyphGenerator();
            //glyphGenerator.Generate();
            //var res = BinaryConverter.Convert(200);
            //var text = File.ReadAllText("E:\\alphabet\\wordsphere.json");
            //var words = JsonConvert.DeserializeObject<List<SerializableWord>>(text, new ListStringToSerializableWordConverter());
            //var customMap = new CustomDictionary();
            //customMap.Deserialize(words);
            //customMap.CreateGroups();
            //WordSpherePopulater wordSpherePopulater = new WordSpherePopulater();
            //wordSpherePopulater.Populate();
            //ProcessDictionary.GetPercentages();
            //ProcessDictionary.ConvertTextToJson("E:\\alphabet\\WebstersEnglishDictionary.txt", "E:\\alphabet\\syllables2.json");
        }
    }
}