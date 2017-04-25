using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace VisEx.Helpers
{
    public class Serializer
    {
        static string _stacksPath = "Stacks.txt";
        static string _pointsPath = "Points.txt";
        static string _selectedStackPath = "SelectedStack.txt";

        public static void SerializeStacks(List<PointStack> stacks)
        {
            string pathToExport = GetSettingsPath();
            string fullPath = Path.Combine(pathToExport, _stacksPath);

            XmlSerializer serializer = new XmlSerializer(stacks.GetType());

            using (StreamWriter streamWriter = new StreamWriter(fullPath, false))
            {
                serializer.Serialize(streamWriter, stacks);
            }
        }

        public static void SerializePoints(List<MyPoint> points)
        {
            string pathToExport = GetSettingsPath();
            string fullPath = Path.Combine(pathToExport, _pointsPath);

            XmlSerializer serializer = new XmlSerializer(points.GetType());

            using (StreamWriter streamWriter = new StreamWriter(fullPath, false))
            {
                serializer.Serialize(streamWriter, points);
            }
        }

        public static void SerializeSelectedStack(PointStack stack)
        {
            string pathToExport = GetSettingsPath();
            string fullPath = Path.Combine(pathToExport, _selectedStackPath);

            XmlSerializer serializer = new XmlSerializer(stack.GetType());

            using (StreamWriter streamWriter = new StreamWriter(fullPath, false))
            {
                serializer.Serialize(streamWriter, stack);
            }
        }

        public static List<PointStack> DeserializeStacks()
        {
            string pathToExport = GetSettingsPath();
            string fullPath = Path.Combine(pathToExport, _stacksPath);
            List<PointStack> stacks = null;
            if (!IsFileExists(fullPath))
            {
                stacks = new List<PointStack>();
            }
            else
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<PointStack>));
                StreamReader reader = new StreamReader(fullPath);
                stacks = (List<PointStack>)serializer.Deserialize(reader);
            }
            return stacks;
        }

        public static List<MyPoint> DeserializePoints()
        {
            string pathToExport = GetSettingsPath();
            string fullPath = Path.Combine(pathToExport, _pointsPath);
            List<MyPoint> points = null;
            if (!IsFileExists(fullPath))
            {
                points = new List<MyPoint>();
            }
            else
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<MyPoint>));
                StreamReader reader = new StreamReader(fullPath);
                points = (List<MyPoint>)serializer.Deserialize(reader);
            }
            return points;
        }

        public static PointStack DeserializeSelectedStack()
        {
            string pathToExport = GetSettingsPath();
            string fullPath = Path.Combine(pathToExport, _selectedStackPath);
            PointStack stack = null;
            if (!IsFileExists(fullPath))
            {
                stack = new PointStack();
            }
            else
            {
                XmlSerializer serializer = new XmlSerializer(typeof(PointStack));
                StreamReader reader = new StreamReader(fullPath);
                stack = (PointStack)serializer.Deserialize(reader);
            }
            return stack;
        }

        public static string GetSettingsPath()
        {
            string visExFolder = "VisEx";
            string environment = Serializer.GetRootPath();
            string fullPath = Path.Combine(environment, visExFolder);

            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }
            return fullPath;
        }

        private static string GetRootPath()
        {
            string environment = "";

            if (8 == IntPtr.Size
                || (!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"))))
            {
                return environment = Environment.GetEnvironmentVariable("ProgramFiles(x86)");
            }

            return environment = Environment.GetEnvironmentVariable("ProgramFiles");
        }

        private static bool IsFileExists(string fullPath)
        {
            if (File.Exists(fullPath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
