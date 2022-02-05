using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;

namespace GeburaCSMod.Structure
{
    public class Spines
    {
        public Spine[] spines = new Spine[16];

        /// <summary>
        /// 源节点坐标
        /// </summary>
        public Vector2 SourceNodePos = Vector2.Zero;

        /// <summary>
        /// 找到指定名称的骨骼
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public int FindSpine(string Name)
        {
            if (Name == "") return -1;
            for(int i = 0; i < spines.Length; i++)
            {
                if (spines[i].Name == Name)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// 找到指定
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int FindNodeSpine(int index)
        {
            if (index < 0 || index >= spines.Length) return -1;
            return spines[index].NodeSpine;
        }

        public Vector2 GetSpineNodePos(int index, float k = 1)
        {
            if (index < 0 || index >= spines.Length) return SourceNodePos;
            if (spines[index].IsSourceNode) return SourceNodePos;

            List<int> parents = new List<int>();
            int i = index;
            while (!spines[i].IsSourceNode)
            {
                parents.Add(i);
                i = spines[i].NodeSpine;
            }
            Vector2 Pos = SourceNodePos;
            for(int j = parents.Count - 1; j >= 0; j--)
            {
                float r = spines[spines[parents[j]].NodeSpine].Rotation;
                Pos += spines[parents[j]].NodePos * r.ToRotationVector2() * k;
            }
            return Pos;

        }

        public Spines(Vector2 Pos)
        {
            SourceNodePos = Pos;
        }

    }
}