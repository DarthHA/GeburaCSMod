using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection;
using Terraria.ModLoader;

namespace GeburaCSMod
{
	public class GeburaCSMod : Mod
	{
		public static GeburaCSMod Instance;

		public Texture2D Arm1;
		public Texture2D Arm2;
		public Texture2D Body;
		public Texture2D Foot1;
		public Texture2D Foot2;
		public Texture2D Hair1;
		public Texture2D Hair2;
		public Texture2D Hair3;
		public Texture2D Hand1;
		public Texture2D Hand2;
		public Texture2D Head1;
		public Texture2D Head2;
		public Texture2D Head3;
		public Texture2D Head4;
		public Texture2D Leg1;
		public Texture2D Leg2;

		public GeburaCSMod()
        {
			Instance = this;
        }

        public override void Load()
        {
			FieldInfo[] f = typeof(GeburaCSMod).GetFields(BindingFlags.Instance | BindingFlags.Public);
			foreach(FieldInfo info in f)
            {
				info.SetValue(this, GetTexture("Images/" + info.Name));
            }
		}

        public override void Unload()
        {
			Instance = null;
        }
    }
}