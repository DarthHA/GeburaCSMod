using Microsoft.Xna.Framework;

namespace GeburaCSMod.Structure
{
    /// <summary>
    /// 骨骼
    /// </summary>
    public class Spine
    {

        /// <summary>
        /// 标识名
        /// </summary>
        public string Name = "";

        /// <summary>
        /// 骨骼长度
        /// </summary>
        public float Length = 100;


        /// <summary>
        /// 骨骼链接的节点的旋转角度
        /// </summary>
        public float Rotation = 0;

        /// <summary>
        /// 骨骼链接的节点
        /// </summary>
        public int NodeSpine = 0;

        /// <summary>
        /// 骨骼链接的节点相对位置
        /// </summary>
        public Vector2 NodePos = Vector2.Zero;


        /// <summary>
        /// 是否为源节点
        /// </summary>
        public bool IsSourceNode = false;

        /// <summary>
        /// 动画
        /// </summary>
        public Animinator Animinator;

        public Spine(string name, float length)
        {
            Name = name;
            Length = length;
        }

        public Spine(string name, float length, int node, Vector2 nodepos, float noderot = 0)
        {
            Name = name;
            Length = length;
            NodeSpine = node;
            NodePos = nodepos;
            Rotation = noderot;
        }
    }
}