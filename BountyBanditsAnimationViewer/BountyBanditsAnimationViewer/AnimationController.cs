using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BountyBanditsAnimationViewer
{
    public class AnimationController
    {
        public string name;
        public List<Texture2D> frames = new List<Texture2D>();
        public List<AnimationInfo> animations = new List<AnimationInfo>();
        public AnimationInfo currAnimation;
        private int currFrame;

        public void fromXML(ContentManager content, string path, Game1 game)
        {
            name = path.Split('\\')[path.Split('\\').Length - 1];
            string folderPath = path.Substring(0, path.Length - name.Length);
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(fs);

            XmlNodeList xmlnode = xmldoc.GetElementsByTagName("monster");
            for (int i = 0; i < xmlnode.Count; i++)
            {
                foreach (XmlNode monsterchild in xmlnode[i].ChildNodes)
                {
                    if (monsterchild.Name == "animations")
                    {
                        foreach (XmlNode node in monsterchild.ChildNodes)
                        {
                            AnimationInfo anim = new AnimationInfo();
                            foreach (XmlNode subnode in node.ChildNodes)
                                if (subnode.Name.Equals("name"))
                                    anim.name = subnode.FirstChild.Value;
                                else if (subnode.Name.Equals("start"))
                                    anim.start = int.Parse(subnode.FirstChild.Value);
                                else if (subnode.Name.Equals("end"))
                                    anim.end = int.Parse(subnode.FirstChild.Value);
                                else if (subnode.Name.Equals("keyframe"))
                                    anim.keyframe = int.Parse(subnode.FirstChild.Value);
                            animations.Add(anim);
                        }

                        int highestActiveFrame = 0;
                        foreach (XmlNode node in monsterchild.ChildNodes)
                            foreach (XmlNode subnode in node.ChildNodes)
                                if (subnode.Name.Equals("end"))
                                    if (int.Parse(subnode.FirstChild.Value) > highestActiveFrame)
                                        highestActiveFrame = int.Parse(subnode.FirstChild.Value);
                        for (int frameIndex = 1; frameIndex <= highestActiveFrame; ++frameIndex)
                        {
                            string frameIndexOffset = "";
                            if (frameIndex < 10) frameIndexOffset = "000";
                            else if (frameIndex < 100) frameIndexOffset = "00";
                            else if (frameIndex < 1000) frameIndexOffset = "0";
                            string framePath = folderPath + name.Substring(0,name.Length-4) + frameIndexOffset + frameIndex.ToString() + ".png";
                            Texture2D newFrame = null;//content.Load<Texture2D>(newFramePath);
                            using (Stream fileStream = new FileStream(framePath, FileMode.Open))
                            {
                                newFrame = Texture2D.FromStream(game.GraphicsDevice, fileStream);
                            }
                            getAlphaFromTex(ref newFrame);
                            frames.Add(newFrame);
                        }
                    }
                }
            }
            currAnimation = animations[0];
        }

        /// <summary>
        /// Replace magenta with transparent black (alphad)
        /// </summary>
        /// <param name="tex"></param>
        public static void getAlphaFromTex(ref Texture2D tex)
        {
            replaceColor(ref tex, Color.Magenta, Color.Transparent);
        }

        public static void replaceColor(ref Texture2D tex, Color src, Color dst)
        {
            Color[] pixels = new Color[tex.Width * tex.Height];
            tex.GetData<Color>(pixels);
            for (int i = 0; i < pixels.Length; i++)
                if (pixels[i] == src)
                    pixels[i] = dst;
            tex.SetData<Color>(pixels);
        }

        public AnimationInfo getAnimationInfo(string name)
        {
            foreach (AnimationInfo animInf in animations)
                if (animInf.name.Equals(name))
                    return animInf;
            return new AnimationInfo();
        }

        public void changeAnimation(string name)
        {
            if (currAnimation.name != name)
            {
                currAnimation = getAnimationInfo(name);
                currFrame = currAnimation.start;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (++currFrame >= currAnimation.end)
                currFrame = currAnimation.start;
            spriteBatch.Draw(frames[currFrame], Vector2.Zero, Color.White);
        }
    }
    public struct AnimationInfo
    {
        public string name;
        public int start, end, keyframe;
    }
}
