using System;
using Server.Items;
using Server.Engines.Quests;

namespace Server.Mobiles
{
    public class Sean : HumilityQuestMobile
    {
        public override int Greeting { get { return 1075769; } }

        public override bool IsActiveVendor { get { return true; } }
        public override bool CanTeach { get { return true; } }

        [Constructable]
        public Sean()
            : base("Sean", "the Blacksmith")
        {
            SetSkill(SkillName.ArmsLore, 36.0, 68.0);
            SetSkill(SkillName.Blacksmith, 65.0, 88.0);
            SetSkill(SkillName.Fencing, 60.0, 83.0);
            SetSkill(SkillName.Macing, 61.0, 93.0);
            SetSkill(SkillName.Swords, 60.0, 83.0);
            SetSkill(SkillName.Tactics, 60.0, 83.0);
            SetSkill(SkillName.Parry, 61.0, 93.0);
        }

        public override void InitSBInfo()
        {
            SBInfos.Add(new SBBlacksmith());
        }

        public Sean(Serial serial)
            : base(serial)
        {
        }

        public override void InitBody()
        {
            this.InitStats(100, 100, 25);

            this.Female = false;
            this.Race = Race.Human;
            this.Body = 0x190;

            this.Hue = Race.RandomSkinHue();
            this.HairItemID = Race.RandomHair(false);
            this.HairHue = Race.RandomHairHue();
        }

        public override void InitOutfit()
        {
            base.InitOutfit();

            AddItem(new Server.Items.SmithHammer());
            AddItem(new Server.Items.FullApron());
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}