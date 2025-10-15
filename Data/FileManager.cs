using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace campus_buddy.Data
{
    internal class FileManager
    {
        public static List<T> Load<T>(string filePath) where T : class, new()
        {
            var items = new List<T>();

            if (!File.Exists(filePath))
                return items;

            var lines = File.ReadAllLines(filePath);

            var headers = lines[0].Split(',').Select(h => h.Trim()).ToArray();
            var props = typeof(T).GetProperties();

            for (int i = 1; i < lines.Length; i++)
            {
                var parts = lines[i].Split(',');
                var obj = new T();

                for (int j = 0; j < headers.Length && j < parts.Length; j++)
                {
                    var header = headers[j];
                    var value = parts[j].Trim();

                    var prop = props.FirstOrDefault(p =>
                        string.Equals(p.Name, header, StringComparison.OrdinalIgnoreCase));
                    if (prop == null) continue;

                    try
                    {
                        if (prop.PropertyType == typeof(DateTime))
                            prop.SetValue(obj, DateTime.Parse(value, CultureInfo.InvariantCulture));
                        else if (prop.PropertyType == typeof(int))
                            prop.SetValue(obj, int.Parse(value));
                        else
                            prop.SetValue(obj, value);
                    }
                    catch
                    {
                    }
                }
                items.Add(obj);
            }
            return items;
        }

        public static void Save<T>(string filePath, IEnumerable<T> data)
        {
            var props = typeof(T).GetProperties();
            var lines = new List<string> { string.Join(",", props.Select(p => p.Name)) };

            foreach (var item in data)
            {
                var values = props.Select(p => Convert.ToString(p.GetValue(item)) ?? "");
                lines.Add(string.Join(",", values));
            }

            File.WriteAllLines(filePath, lines);
        }
    }
}
