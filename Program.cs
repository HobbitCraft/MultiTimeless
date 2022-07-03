using System;
using System.Collections.Generic;
using System.Linq;
using Spectre.Console;
using TimelessEmulator.Data;
using TimelessEmulator.Data.Models;
using TimelessEmulator.Game;

namespace TimelessEmulator;

public static class Program
{
    struct SeedResult
    {
        public int seed;
        public int[] amounts;
        public int amount;
        public SeedResult(int seed, int[] amounts, int amount)
        {
            this.seed = seed;
            this.amounts = new int[amounts.Length];
            amounts.CopyTo(this.amounts, 0);
            this.amount = amount;
        }
    }

    class PassiveHolder
    {
        public string around;
        public string nearbyPoint;
        public List<PassiveSkill> ps;

        public PassiveHolder(string around, string nearbyPoint, params string[] passives)
        {
            this.around = around;
            this.nearbyPoint = nearbyPoint;

            ps = new List<PassiveSkill>();
            for (int i = 0; i < passives.Length; i++)
            {
                ps.Add(DataManager.GetPassiveSkillByFuzzyValue(passives[i]));
                if (DataManager.GetPassiveSkillByFuzzyValue(passives[i]) == null)
                {
                    AnsiConsole.MarkupLine(passives[i]);
                }
            }

        }
    }
    static Program()
    {

    }

    public static void Main(string[] arguments)
    {
        Console.Title = $"{Settings.ApplicationName} Ver. {Settings.ApplicationVersion}";

        AnsiConsole.MarkupLine("Hello, [green]exile[/]!");
        AnsiConsole.MarkupLine("Loading [green]data files[/]...");

        if (!DataManager.Initialize())
            ExitWithError("Failed to initialize the [yellow]data manager[/].");

        //PassiveSkill passiveSkill = GetPassiveSkillFromInput();

        //if (passiveSkill == null)
        //    ExitWithError("Failed to get the [yellow]passive skill[/] from input.");

        //TimelessJewel timelessJewel = GetTimelessJewelFromInputSimple();

        //if (timelessJewel == null)
        //    ExitWithError("Failed to get the [yellow]timeless jewel[/] from input.");

        AnsiConsole.WriteLine();

        //PassiveSkill[] ps = new PassiveSkill[2] {
        //DataManager.GetPassiveSkillByFuzzyValue("Prismatic Skin"),
        //DataManager.GetPassiveSkillByFuzzyValue("Eagle Eye"),
        ////DataManager.GetPassiveSkillByFuzzyValue("Admonisher"),
        ////DataManager.GetPassiveSkillByFuzzyValue("Command of Steel"),
        ////DataManager.GetPassiveSkillByFuzzyValue("Martial Experience"),
        ////DataManager.GetPassiveSkillByFuzzyValue("Berserking")
        //};

        PassiveHolder vigour = new PassiveHolder("Vigour", "Measured Fury",
            "Art of the Gladiator", "Bravery", "Master of the Arena",
            "Fury Bolts", "Defiance", "Dervish", "Destroyer",
            "Ribcage Crusher", "Titanic Impacts", "Revelry", "Savagery", "Vigour", "Cloth and Chain", "Golem's Blood", "Measured Fury",
            "Assured Strike", "Dirty Techniques", "Adamant",
            "Testudo", "Surveillance"
            );
        PassiveHolder stamina = new PassiveHolder("Stamina", "Cleaving",
            "Disemboweling",
            "Hearty",
            "Barbarism",
            "Stamina",
            "Juggernaut",
            "Cannibalistic Rite",
            "Savage Wounds",
            "Harpooner",
            "Cleaving",
            "Slaughter",
            "Aggressive Bastion",
            "Lust for Carnage",
            "Robust",
            "Diamond Skin",
            "Spiked Bulwark",
            "Strong Arm",
            "Warrior Training"
            );

        PassiveHolder irongrip = new PassiveHolder("Iron Grip", "south of Scion",
            "Hired Killer", "Malicious Intent", "Path of the Hunter", "Path of the Warrior", "Window of Opportunity", "Exceptional Performance",
            "Sentinel", "Totemic Zeal", "Constitution", "Arcane Chemistry", "Battle Rouse");

        PassiveHolder theagnostic = new PassiveHolder("Endurance", "The Agnostic",
            "Light of Divinity", "Holy Dominion", "Divine Fervour", "Runesmith", "Faith and Steel", "Overcharge",
            "Endurance", "Devotion", "Sanctum of Thought", "Divine Wrath", "Divine Judgement", "Divine Fury", "Smashing Strikes");

        PassiveHolder solipsism = new PassiveHolder("Solipsism", "east of Scion",
            "Destructive Apparatus", "Thrill Killer", "Foresight", "Leadership", "Inspiring Bond", "Path of the Savant",
            "Potency of Will", "Harrier", "True Strike", "Hired Killer", "Path of the Hunter", "Window of Opportunity", "Exceptional Performance");

        PassiveHolder necromanticaegis = new PassiveHolder("Necromantic Aegis", "west of Scion",
            "Foresight", "Decay Ward", "Dreamer", "Inspiring Bond", "Path of the Savant", "Potency of Will", "Ash, Frost and Storm",
            "Totemic Zeal", "Path of the Warrior", "Constitution", "Malicious Intent", "Veteran Soldier", "Relentless");

        PassiveHolder acrobatics = new PassiveHolder("Fervour", "Acrobatics",
            "Trick Shot", "Careful Conservationist", "Inveterate", "Silent Steps", "Survivalist", "Aspect of the Lynx",
            "Acuity", "Fervour", "Weapon Artistry", "Herbalism", "Intuition", "Quickstep", "Swift Venoms", "Flash Freeze", "Winter Spirit", "King of the Hill",
            "Master Fletcher", "Heartseeker");

        PassiveHolder acrobaticsTornadoLoose = new PassiveHolder("Fervour", "Acrobatics",
            "Careful Conservationist", "Inveterate", "Survivalist", "Aspect of the Lynx",
            "Acuity", "Fervour", "Weapon Artistry", "Herbalism", "Intuition", "Quickstep", "Flash Freeze", "Winter Spirit", "King of the Hill",
            "Master Fletcher", "Heartseeker");

        PassiveHolder acrobaticsTornadoStrict = new PassiveHolder("Fervour", "Acrobatics",
        "Inveterate", "Survivalist",
        "Acuity", "Fervour", "Weapon Artistry", "Herbalism", "Intuition", "Quickstep", "King of the Hill",
        "Master Fletcher", "Heartseeker");

        PassiveHolder ghostdance = new PassiveHolder("Frenetic", "Ghost Dance",
            "Soul Thief", "Flaying", "Backstabbing", "One with Evil", "Mind Drinker", "Coldhearted Calculation", "Saboteur",
            "Elemental Focus", "Claws of the Hawk", "Claws of the Magpie", "Infused", "Resourcefulness", "Will of Blades", "Frenetic",
            "Depth Perception", "Blood Drinker", "From the Shadows", "Clever Thief", "Master of Blades", "Fangs of the Viper", "Sleight of Hand");

        PassiveHolder doomsday = new PassiveHolder("Instability", "Doomsday",
            "Heart of Ice", "Breath of Rime", "Breath of Lightning", "Heart of Thunder", "Breath of Flames", "Golem Commander", "Skittering Runes", "Presage",
            "Discord Artisan", "Instability", "Infused Flesh", "Deep Thoughts", "Cruel Preparation", "Essence Surge", "Wandslinger", "Prodigal Perfection",
            "Mystic Bulwark", "Enigmatic Defence", "Mental Rapidity", "Arcane Will", "Lord of the Dead", "Frost Walker");

        PassiveHolder mindovermatter = new PassiveHolder("Mind Over Matter", "west of Witch",
            "Fire Walker", "Annihilation", "Arcanist's Dominion", "Enduring Bond", "Essence Infusion", "Essence Extraction", "Asylum", "Quick Recovery", "Anointed Flesh");

        PassiveHolder supremeego = new PassiveHolder("Supreme Ego", "north of Ranger",
            "Overcharged", "Charisma", "Dire Torment", "Wasting", "Ballistics", "Adder's Touch", "Taste for Blood", "Master Sapper", "Flask Mastery",
            "Revenge of the Hunted", "Void Barrier"
            );

        PassiveHolder elementalequilibrium = new PassiveHolder("Elemental Equilibrium", "east of Duelist",
            "Crystal Skin", "Weathered Hunter", "Burning Brutality", "Heavy Draw", "Deadly Draw", "Art of the Gladiator", "Gladiator's Perseverance", "Avatar of the Hunt", "Profane Chemistry");

        PassiveHolder eternalyouth = new PassiveHolder("Eternal Youth", "between Marauder and Templar",
            "Expertise", "Ancestral Knowledge", "Sanctity", "Dynamo", "Deep Breaths", "Blacksmith's Clout", "Gravepact", "Combat Stamina", "Powerful Bond",
            "Steelwood Stance", "Sanctuary");

        PassiveHolder clusterResoluteTechnique = new PassiveHolder("Cluster Socket", "Resolute Technique",
            "Smashing Strikes", "Counterweight", "Whirling Barrier", "Bone Breaker", "Skull Cracking", "Disemboweling", "Vanquisher", "Shamanistic Fury", "Sanctum of Thought");

       
        //PassiveHolder FlyingV = new PassiveHolder("", "Solipsism")
        PassiveHolder Hobbit = new PassiveHolder("Divine Fury, Divine Judgement, Endurance, Devotion, Sanctum of Thought", "The Agnostic", "Divine Fury", "Divine Judgement", "Endurance", "Devotion", "Sanctum of Thought");
        PassiveHolder Kurosaki = new PassiveHolder("Heartseeker, Survivalist, Inveterate, Fervour, Herbalism, Winter Spirit, Quickstep", "Acrobatics", "Heartseeker", "Survivalist", "Inveterate", "Fervour", "Herbalism", "Winter Spirit", "Quickstep");
        PassiveHolder Rasmus = new PassiveHolder("Master of Blades, Fangs of the Viper, Soul Thief", "Shadow", "Master of Blades", "Fangs of the Viper", "Soul Thief", "Infused", "Frenetic", "Mind Drinker", "Blood Drinker", "Clever Thief", "Resourcefulness", "Will of Blades", "Sleight of Hand");
        PassiveHolder Drake = new PassiveHolder("Drakes Ass", "Iron Grip","Sentinel", "Battle Rouse", "Window of Opportunity", "Constitution");
        PassiveHolder philsu = new PassiveHolder("", "Ghost Dance", "Soul Thief", "Mind Drinker", "One with Evil", "Infused", "Frenetic", "Depth Perception", "Blood Drinker", "clever thief", "from the shadows");
        PassiveHolder abvt = new PassiveHolder("Harrier, Foresight, Leadership", "Solipsism", "Harrier", "Foresight", "Leadership", "True Strike");
        PassiveHolder redsameri = new PassiveHolder("Overcharge, Endurance", "The Agnostic", "Overcharge","Endurance","Devotion","Faith and Steel","Holy Dominion","Divine Fervour");

        List <SeedResult> seeds = new List<SeedResult>();
        Dictionary<uint, (uint minimumSeed, uint maximumSeed)> timelessJewelSeedRanges = new Dictionary<uint, (uint minimumSeed, uint maximumSeed)>()
        {
            { 1, (100, 8000) },
            { 2, (10000, 18000) }, //Lethal Pride
            { 3, (500, 8000) }, //Brutal Restraint
            { 4, (2000, 10000) },
            { 5, (2000, 160000) }
        };

        //string searchFor = "non_curse_aura_effect_+%";
        //string searchFor = "chance_to_deal_double_damage_%";
        //string searchFor = "physical_damage_taken_%_as_fire";
        List<string> searchFor = new List<string>() {
           //"base_dex"
           //"chance_to_deal_double_damage_%",
           //"strength_+%",
           //"life",
           //"intimidate"
           //"frenzy_charge_on_skill_hit",
           //"power_charge_on_critical",
           //"critical_strike_multiplier",
           //"spell_damage",
           //"onslaught"
           //"rarity",
           //"minion_damage",
           //"frenzy",
           //"aura",
           //"base_str",
           //"physical_damage_taken_%_as_fire"
           //"charges"
           //"resistance"
           //"maximum_mana",
           //"suppress",
           "avoid_elemental"
        };
        List<int> totals = new List<int>();

        //string jewelType = "Lethal Pride";
        //string conqueror = "Kaom";
        //int minSeed = 10000;
        //int maxSeed = 18000;
        //string jewelType = "Brutal Restraint";
        //String conqueror = "Nasima";
        //int minSeed = 500;
        //int maxSeed = 8000;
        //string jewelType = "Glorious Vanity";
        //string conqueror = "Ahuana";
        //int minSeed = 100;
        //int maxSeed = 8000;
        string jewelType = "Elegant Hubris";
        string conqueror = "Caspiro";
        int minSeed = 2000;
        int maxSeed = 160000;

        PassiveHolder choice = doomsday;
        bool mustContainOneOfEach = false;
        bool print = false;

        string searches = "";
        for (int i = 0; i < searchFor.Count; i++)
        {
            searches += searchFor[i];
            if (i != searchFor.Count - 1)
            {
                searches += ", ";
            }
        }

        AnsiConsole.MarkupLine("Searching for " + searches + " around " + choice.around + " near " + choice.nearbyPoint);
        if (mustContainOneOfEach)
        {
            AnsiConsole.MarkupLine("Must contain at least one of each.");
        }
        for (int i = minSeed; i < maxSeed; i++)
        {
            if (jewelType == "Elegant Hubris")
            {
                if (i % 20 != 0)
                {
                    continue;
                }
            }
            int total = 0;
            totals.Clear();
            for (int j = 0; j < searchFor.Count; j++)
            {
                totals.Add(0);
            }

            for (int j = 0; j < choice.ps.Count; j++)
            {
                AlternateTreeManager alternateTreeManager = new AlternateTreeManager(choice.ps[j], GetTimelessJewelFromInput((uint)i, jewelType, conqueror));
                bool isPassiveSkillReplaced = alternateTreeManager.IsPassiveSkillReplaced();
                if (isPassiveSkillReplaced)
                {
                    AlternatePassiveSkillInformation alternatePassiveSkillInformation = alternateTreeManager.ReplacePassiveSkill();

                    for (int k = 0; k < alternatePassiveSkillInformation.AlternatePassiveSkill.StatIndices.Count; k++)
                    {
                        uint statIndex = alternatePassiveSkillInformation.AlternatePassiveSkill.StatIndices.ElementAt(k);

                        for (int ii = 0; ii < searchFor.Count; ii++)
                        {
                            if (DataManager.GetStatIdentifierByIndex(statIndex).Contains(searchFor[ii], StringComparison.InvariantCultureIgnoreCase))
                            {
                                if (print) { AnsiConsole.MarkupLine(DataManager.GetStatIdentifierByIndex(statIndex)); }
                                totals[ii]++;
                                total++;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    IReadOnlyCollection<AlternatePassiveAdditionInformation> alternatePassiveAdditionInformations = alternateTreeManager.AugmentPassiveSkill();

                    foreach (AlternatePassiveAdditionInformation alternatePassiveAdditionInformation in alternatePassiveAdditionInformations)
                    {

                        for (int k = 0; k < alternatePassiveAdditionInformation.AlternatePassiveAddition.StatIndices.Count; k++)
                        {
                            uint statIndex = alternatePassiveAdditionInformation.AlternatePassiveAddition.StatIndices.ElementAt(k);
                            uint statRoll = alternatePassiveAdditionInformation.StatRolls.ElementAt(k).Value;
                            for (int ii = 0; ii < searchFor.Count; ii++)
                            {
                                if (DataManager.GetStatIdentifierByIndex(statIndex).Contains(searchFor[ii], StringComparison.InvariantCultureIgnoreCase))
                                {
                                    if (print) { AnsiConsole.MarkupLine(DataManager.GetStatIdentifierByIndex(statIndex)); }
                                    totals[ii]++;
                                    total++;
                                }
                            }
                        }
                    }

                }
            }
            int[] newArray = new int[totals.Count];
            for (int j = 0; j < totals.Count; j++)
            {
                newArray[j] = totals[j];
            }
            if (total > 0)
            {
                bool proceed = true;
                if (mustContainOneOfEach)
                {
                    for (int j = 0; j < newArray.Length; j++)
                    {
                        if (newArray[j] == 0)
                        {
                            proceed = false;
                        }
                    }
                }
                if (proceed)
                {
                    seeds.Add(new SeedResult(i, newArray, total));
                }
            }
        }
        //AnsiConsole.MarkupLine(seeds.Count.ToString());
        seeds = seeds.OrderByDescending(x => x.amount).ToList();

        string totalResult = "";
        for (int i = 0; i < Math.Min(100, seeds.Count); i++)
        {
            totalResult = "";
            for (int j = 0; j < seeds[i].amounts.Length; j++)
            {
                totalResult += seeds[i].amounts[j];
                if (j != seeds[i].amounts.Length - 1)
                {
                    totalResult += ", ";
                }
            }
            AnsiConsole.MarkupLine(seeds[i].seed + ": " + seeds[i].amount + " (" + totalResult + ")");
        }


        //AlternateTreeManager alternateTreeManager = new AlternateTreeManager(passiveSkill, timelessJewel);
        //bool isPassiveSkillReplaced = alternateTreeManager.IsPassiveSkillReplaced();

        //AnsiConsole.MarkupLine($"[green]Is Passive Skill Replaced[/]: {isPassiveSkillReplaced}");

        //if (isPassiveSkillReplaced)
        //{
        //    AlternatePassiveSkillInformation alternatePassiveSkillInformation = alternateTreeManager.ReplacePassiveSkill();

        //    AnsiConsole.MarkupLine($"[green]Alternate Passive Skill[/]: [yellow]{alternatePassiveSkillInformation.AlternatePassiveSkill.Name}[/] ([yellow]{alternatePassiveSkillInformation.AlternatePassiveSkill.Identifier}[/])");

        //    for (int i = 0; i < alternatePassiveSkillInformation.AlternatePassiveSkill.StatIndices.Count; i++)
        //    {
        //        uint statIndex = alternatePassiveSkillInformation.AlternatePassiveSkill.StatIndices.ElementAt(i);
        //        uint statRoll = alternatePassiveSkillInformation.StatRolls.ElementAt(i).Value;

        //        AnsiConsole.MarkupLine(statIndex.ToString() + " _ " + $"\t\tStat [yellow]{i}[/] | [yellow]{DataManager.GetStatTextByIndex(statIndex)}[/] (Identifier: [yellow]{DataManager.GetStatIdentifierByIndex(statIndex)}[/], Index: [yellow]{statIndex}[/]), Roll: [yellow]{statRoll}[/]");
        //    }

        //    PrintAlternatePassiveAdditionInformations(alternatePassiveSkillInformation.AlternatePassiveAdditionInformations);
        //}
        //else
        //{
        //    IReadOnlyCollection<AlternatePassiveAdditionInformation> alternatePassiveAdditionInformations = alternateTreeManager.AugmentPassiveSkill();

        //    PrintAlternatePassiveAdditionInformations(alternatePassiveAdditionInformations);
        //}

        WaitForExit();
    }

    private static PassiveSkill GetPassiveSkillFromInput()
    {
        TextPrompt<string> passiveSkillTextPrompt = new TextPrompt<string>("[green]Passive Skill[/]:")
            .Validate((string input) =>
            {
                PassiveSkill passiveSkill = DataManager.GetPassiveSkillByFuzzyValue(input);

                if (passiveSkill == null)
                    return ValidationResult.Error($"[red]Error[/]: Unable to find [yellow]passive skill[/] `{input}`.");

                if (!DataManager.IsPassiveSkillValidForAlteration(passiveSkill))
                    return ValidationResult.Error($"[red]Error[/]: The [yellow]passive skill[/] `{input}` is not valid for alteration.");

                return ValidationResult.Success();
            });

        string passiveSkillInput = AnsiConsole.Prompt(passiveSkillTextPrompt);

        PassiveSkill passiveSkill = DataManager.GetPassiveSkillByFuzzyValue(passiveSkillInput);

        AnsiConsole.MarkupLine($"[green]Found Passive Skill[/]: [yellow]{passiveSkill.Name}[/] ([yellow]{passiveSkill.Identifier}[/])");

        return passiveSkill;
    }

    private static TimelessJewel GetTimelessJewelFromInputSimple()
    {
        Dictionary<uint, string> timelessJewelTypes = new Dictionary<uint, string>()
        {
            { 1, "Glorious Vanity" },
            { 2, "Lethal Pride" },
            { 3, "Brutal Restraint" },
            { 4, "Militant Faith" },
            { 5, "Elegant Hubris" }
        };

        Dictionary<uint, Dictionary<string, TimelessJewelConqueror>> timelessJewelConquerors = new Dictionary<uint, Dictionary<string, TimelessJewelConqueror>>()
        {
            {
                1, new Dictionary<string, TimelessJewelConqueror>()
                {
                    { "Xibaqua", new TimelessJewelConqueror(1, 0) },
                    { "[springgreen3]Zerphi (Legacy)[/]", new TimelessJewelConqueror(2, 0) },
                    { "Ahuana", new TimelessJewelConqueror(2, 1) },
                    { "Doryani", new TimelessJewelConqueror(3, 0) }
                }
            },
            {
                2, new Dictionary<string, TimelessJewelConqueror>()
                {
                    { "Kaom", new TimelessJewelConqueror(1, 0) },
                    { "Rakiata", new TimelessJewelConqueror(2, 0) },
                    { "[springgreen3]Kiloava (Legacy)[/]", new TimelessJewelConqueror(3, 0) },
                    { "Akoya", new TimelessJewelConqueror(3, 1) }
                }
            },
            {
                3, new Dictionary<string, TimelessJewelConqueror>()
                {
                    { "[springgreen3]Deshret (Legacy)[/]", new TimelessJewelConqueror(1, 0) },
                    { "Balbala", new TimelessJewelConqueror(1, 1) },
                    { "Asenath", new TimelessJewelConqueror(2, 0) },
                    { "Nasima", new TimelessJewelConqueror(3, 0) }
                }
            },
            {
                4, new Dictionary<string, TimelessJewelConqueror>()
                {
                    { "[springgreen3]Venarius (Legacy)[/]", new TimelessJewelConqueror(1, 0) },
                    { "Maxarius", new TimelessJewelConqueror(1, 1) },
                    { "Dominus", new TimelessJewelConqueror(2, 0) },
                    { "Avarius", new TimelessJewelConqueror(3, 0) }
                }
            },
            {
                5, new Dictionary<string, TimelessJewelConqueror>()
                {
                    { "Cadiro", new TimelessJewelConqueror(1, 0) },
                    { "Victario", new TimelessJewelConqueror(2, 0) },
                    { "[springgreen3]Chitus (Legacy)[/]", new TimelessJewelConqueror(3, 0) },
                    { "Caspiro", new TimelessJewelConqueror(3, 1) }
                }
            }
        };

        Dictionary<uint, (uint minimumSeed, uint maximumSeed)> timelessJewelSeedRanges = new Dictionary<uint, (uint minimumSeed, uint maximumSeed)>()
        {
            { 1, (100, 8000) },
            { 2, (10000, 18000) },
            { 3, (500, 8000) },
            { 4, (2000, 10000) },
            { 5, (2000, 160000) }
        };

        SelectionPrompt<string> timelessJewelTypeSelectionPrompt = new SelectionPrompt<string>()
            .Title("[green]Timeless Jewel Type[/]:")
            .AddChoices(timelessJewelTypes.Values.ToArray());

        string timelessJewelTypeInput = AnsiConsole.Prompt(timelessJewelTypeSelectionPrompt);

        AnsiConsole.MarkupLine($"[green]Timeless Jewel Type[/]: {timelessJewelTypeInput}");

        uint alternateTreeVersionIndex = timelessJewelTypes
            .First(q => (q.Value == timelessJewelTypeInput))
            .Key;

        AlternateTreeVersion alternateTreeVersion = DataManager.AlternateTreeVersions
            .First(q => (q.Index == alternateTreeVersionIndex));

        SelectionPrompt<string> timelessJewelConquerorSelectionPrompt = new SelectionPrompt<string>()
            .Title("[green] Timeless Jewel Conqueror[/]:")
            .AddChoices(timelessJewelConquerors[alternateTreeVersionIndex].Keys.ToArray());

        string timelessJewelConquerorInput = AnsiConsole.Prompt(timelessJewelConquerorSelectionPrompt);

        AnsiConsole.MarkupLine($"[green]Timeless Jewel Conqueror[/]: {timelessJewelConquerorInput}");

        TimelessJewelConqueror timelessJewelConqueror = timelessJewelConquerors[alternateTreeVersionIndex]
            .First(q => (q.Key == timelessJewelConquerorInput))
            .Value;

        TextPrompt<uint> timelessJewelSeedTextPrompt = new TextPrompt<uint>($"[green]Timeless Jewel Seed ({timelessJewelSeedRanges[alternateTreeVersionIndex].minimumSeed} - {timelessJewelSeedRanges[alternateTreeVersionIndex].maximumSeed})[/]:")
            .Validate((uint input) =>
            {
                if ((input >= timelessJewelSeedRanges[alternateTreeVersionIndex].minimumSeed) &&
                    (input <= timelessJewelSeedRanges[alternateTreeVersionIndex].maximumSeed))
                {
                    return ValidationResult.Success();
                }

                return ValidationResult.Error($"[red]Error[/]: The [yellow]timeless jewel seed[/] must be between {timelessJewelSeedRanges[alternateTreeVersionIndex].minimumSeed} and {timelessJewelSeedRanges[alternateTreeVersionIndex].maximumSeed}.");
            });

        uint timelessJewelSeed = AnsiConsole.Prompt(timelessJewelSeedTextPrompt);

        return new TimelessJewel(alternateTreeVersion, timelessJewelConqueror, timelessJewelSeed);
    }

    private static TimelessJewel GetTimelessJewelFromInput(uint seed, string typeOfJewel, string conqueror)
    {
        Dictionary<uint, string> timelessJewelTypes = new Dictionary<uint, string>()
        {
            { 1, "Glorious Vanity" },
            { 2, "Lethal Pride" },
            { 3, "Brutal Restraint" },
            { 4, "Militant Faith" },
            { 5, "Elegant Hubris" }
        };

        Dictionary<uint, Dictionary<string, TimelessJewelConqueror>> timelessJewelConquerors = new Dictionary<uint, Dictionary<string, TimelessJewelConqueror>>()
        {
            {
                1, new Dictionary<string, TimelessJewelConqueror>()
                {
                    { "Xibaqua", new TimelessJewelConqueror(1, 0) },
                    { "[springgreen3]Zerphi (Legacy)[/]", new TimelessJewelConqueror(2, 0) },
                    { "Ahuana", new TimelessJewelConqueror(2, 1) },
                    { "Doryani", new TimelessJewelConqueror(3, 0) }
                }
            },
            {
                2, new Dictionary<string, TimelessJewelConqueror>()
                {
                    { "Kaom", new TimelessJewelConqueror(1, 0) },
                    { "Rakiata", new TimelessJewelConqueror(2, 0) },
                    { "[springgreen3]Kiloava (Legacy)[/]", new TimelessJewelConqueror(3, 0) },
                    { "Akoya", new TimelessJewelConqueror(3, 1) }
                }
            },
            {
                3, new Dictionary<string, TimelessJewelConqueror>()
                {
                    { "[springgreen3]Deshret (Legacy)[/]", new TimelessJewelConqueror(1, 0) },
                    { "Balbala", new TimelessJewelConqueror(1, 1) },
                    { "Asenath", new TimelessJewelConqueror(2, 0) },
                    { "Nasima", new TimelessJewelConqueror(3, 0) }
                }
            },
            {
                4, new Dictionary<string, TimelessJewelConqueror>()
                {
                    { "[springgreen3]Venarius (Legacy)[/]", new TimelessJewelConqueror(1, 0) },
                    { "Maxarius", new TimelessJewelConqueror(1, 1) },
                    { "Dominus", new TimelessJewelConqueror(2, 0) },
                    { "Avarius", new TimelessJewelConqueror(3, 0) }
                }
            },
            {
                5, new Dictionary<string, TimelessJewelConqueror>()
                {
                    { "Cadiro", new TimelessJewelConqueror(1, 0) },
                    { "Victario", new TimelessJewelConqueror(2, 0) },
                    { "[springgreen3]Chitus (Legacy)[/]", new TimelessJewelConqueror(3, 0) },
                    { "Caspiro", new TimelessJewelConqueror(3, 1) }
                }
            }
        };

        Dictionary<uint, (uint minimumSeed, uint maximumSeed)> timelessJewelSeedRanges = new Dictionary<uint, (uint minimumSeed, uint maximumSeed)>()
        {
            { 1, (100, 8000) },
            { 2, (10000, 18000) },
            { 3, (500, 8000) },
            { 4, (2000, 10000) },
            { 5, (2000, 160000) }
        };

        //SelectionPrompt<string> timelessJewelTypeSelectionPrompt = new SelectionPrompt<string>()
        //    .Title("[green]Timeless Jewel Type[/]:")
        //    .AddChoices(timelessJewelTypes.Values.ToArray());

        //string timelessJewelTypeInput = AnsiConsole.Prompt(timelessJewelTypeSelectionPrompt);

        //AnsiConsole.MarkupLine($"[green]Timeless Jewel Type[/]: {timelessJewelTypeInput}");

        uint alternateTreeVersionIndex = timelessJewelTypes
            .First(q => (q.Value == typeOfJewel))
            .Key;

        AlternateTreeVersion alternateTreeVersion = DataManager.AlternateTreeVersions
            .First(q => (q.Index == alternateTreeVersionIndex));

        TimelessJewelConqueror timelessJewelConqueror = timelessJewelConquerors[alternateTreeVersionIndex]
            .First(q => (q.Key == conqueror))
            .Value;

        uint timelessJewelSeed = seed;

        return new TimelessJewel(alternateTreeVersion, timelessJewelConqueror, timelessJewelSeed);
    }

    private static void PrintAlternatePassiveAdditionInformations(IReadOnlyCollection<AlternatePassiveAdditionInformation> alternatePassiveAdditionInformations)
    {
        ArgumentNullException.ThrowIfNull(alternatePassiveAdditionInformations, nameof(alternatePassiveAdditionInformations));

        foreach (AlternatePassiveAdditionInformation alternatePassiveAdditionInformation in alternatePassiveAdditionInformations)
        {
            AnsiConsole.MarkupLine($"\t[green]Addition[/]: [yellow]{alternatePassiveAdditionInformation.AlternatePassiveAddition.Identifier}[/]");

            for (int i = 0; i < alternatePassiveAdditionInformation.AlternatePassiveAddition.StatIndices.Count; i++)
            {
                uint statIndex = alternatePassiveAdditionInformation.AlternatePassiveAddition.StatIndices.ElementAt(i);
                uint statRoll = alternatePassiveAdditionInformation.StatRolls.ElementAt(i).Value;

                AnsiConsole.MarkupLine($"\t\tStat [yellow]{i}[/] | [yellow]{DataManager.GetStatTextByIndex(statIndex)}[/] (Identifier: [yellow]{DataManager.GetStatIdentifierByIndex(statIndex)}[/], Index: [yellow]{statIndex}[/]), Roll: [yellow]{statRoll}[/]");
            }
        }
    }

    private static void WaitForExit()
    {
        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine("Press [yellow]any key[/] to exit.");

        try
        {
            Console.ReadKey();
        }
        catch { }

        Environment.Exit(0);
    }

    private static void PrintError(string error)
    {
        AnsiConsole.MarkupLine($"[red]Error[/]: {error}");
    }

    private static void ExitWithError(string error)
    {
        PrintError(error);
        WaitForExit();
    }

}
