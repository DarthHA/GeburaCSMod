
using GeburaCSMod.Structure;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace GeburaCSMod.NPCs
{
    //[AutoloadBossHead]
    public class GeburaBoss : ModNPC
    {
        public Spines spines;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gebura");
            DisplayName.AddTranslation(GameCulture.Chinese, "Gebura");
        }
        public override void SetDefaults()
        {
            npc.width = 100;
            npc.height = 200;
            npc.damage = 0;
            npc.defense = 0;
            npc.lifeMax = 15000;
            npc.boss = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;
            npc.aiStyle = -1;
            npc.netAlways = true;
            //musicPriority = MusicPriority.BossHigh;
            //music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/DreamBattle");
            for (int i = 0; i < npc.buffImmune.Length; i++)
            {
                npc.buffImmune[i] = true;
            }
            spines = new Spines(npc.Center);
            SetSpines();
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.damage /= 2;
            npc.lifeMax /= 2;
        }
        public override void AI()
        {
            Player target = Main.player[npc.FindClosestPlayer()];
            npc.direction = Math.Sign(target.Center.X - npc.Center.X + 0.01);
            spines.SourceNodePos = npc.Center;
        }


       
        public override bool CheckDead()
        {
            return true;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            for (int i = 0; i < spines.spines.Length; i++)
            {
                if (spines.spines[i].Name.Contains("Hair")) continue;
                if (spines.spines[i].Name.Contains("Head")) continue;
                if (spines.spines[i].NodePos == Vector2.Zero && spines.spines[i].Name != "Body") continue;
                Texture2D tex = mod.GetTexture("Images/" + spines.spines[i].Name);
                float r = spines.spines[i].Rotation + MathHelper.Pi / 2;
                spriteBatch.Draw(tex, spines.GetSpineNodePos(i, 0.3f) + r.ToRotationVector2() * spines.spines[i].Length * 0.3f - Main.screenPosition, null, Color.White, spines.spines[i].Rotation, tex.Size() / 2, 0.3f, SpriteEffects.None, 0);
            }
            return false;
        }


        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.None;
        }
        public override void NPCLoot()
        {
        }
        public override bool CheckActive()
        {
            return false;
        }
        public void SetSpines()
        {
            spines.spines[0] = new Spine("Hair3", 522, 9, Vector2.Zero);         //242 522
            spines.spines[1] = new Spine("Hair2", 492, 9, Vector2.Zero);         //233 494
            spines.spines[2] = new Spine("Hair1", 492, 9, Vector2.Zero);         //219 490

            spines.spines[3] = new Spine("Arm2", 105, 8, new Vector2(-64, -49));      //72 136
            spines.spines[4] = new Spine("Hand2", 120, 3, Vector2.Zero);        //77 186
            spines.spines[5] = new Spine("Weapon2", 5, 4, Vector2.Zero);
            spines.spines[6] = new Spine("Leg2", 210, 8, new Vector2(-48, 96));     //106 304
            spines.spines[7] = new Spine("Foot2", 280, 6, Vector2.Zero);           //153 323

            spines.spines[8] = new Spine("Body", 5)        //164 285
            {
                IsSourceNode = true
            };
            spines.spines[9] = new Spine("Head", 10, 8, new Vector2(-9, -150));       //176 203

            spines.spines[10] = new Spine("Leg1", 210, 8, new Vector2(21, 96));     //122 303
            spines.spines[11] = new Spine("Foot1", 280, 10, Vector2.Zero);         //153 318
            spines.spines[12] = new Spine("Weapon1", 5, 14, Vector2.Zero);
            spines.spines[13] = new Spine("Arm1", 105, 8, new Vector2(52, -68));      //63 143
            spines.spines[14] = new Spine("Hand1", 120, 13, Vector2.Zero);          //71 185

            spines.spines[15] = new Spine("GoldRush", 5, 14, Vector2.Zero);
        }
    }
}