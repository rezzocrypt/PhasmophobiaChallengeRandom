using System.IO;
using System.Web.Script.Serialization;

namespace PhRandom
{
    public class PhParameters
    {
        private static JavaScriptSerializer _serializer = new JavaScriptSerializer();

        public string[] Difficulty = new string[0];
        public string[] Maps = new string[0];
        public string[] Challenge = new string[0];

        public static void Save(string path, PhParameters model)
        {
            var json = _serializer.Serialize(model);
            File.WriteAllText(path, json);
        }

        public static PhParameters Load(string path)
        {
            PhParameters result = null;
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                result = _serializer.Deserialize(json, typeof(PhParameters)) as PhParameters;
            }

            if (result == null)
            {
                result = new PhParameters
                {
                    Maps = new string[] {
                        "Tanglewood Street House",
                        "Edgefield Street House",
                        "Ridgeview Road House",
                        "Grafton Farmhouse",
                        "Bleasdale Farmhouse",
                        "Willow Street House",
                        "Camp Woodwind",
                        "Brownstone High School",
                        "Maple Lodge Campsite",
                        "Prison",
                        "Sunny Meadows"
                    },
                    Difficulty = new string[] {
                        "Любитель",
                        "Средняя",
                        "Профессионал",
                        "Кошмар"
                    },
                    Challenge = new string[] {
                        "Без фонарей",
                        "Без шавухи",
                        "Без шифта",
                        "Без таблеток",
                        "Не умереть",
                        "Не выходить из дома",
                        "Не выключать фонарь",
                        "Фото призрака",
                        "Базовый инвентарь",
                        "Петь песню при атаках"
                    }
                };
            }

            return result;
        }
    }
}