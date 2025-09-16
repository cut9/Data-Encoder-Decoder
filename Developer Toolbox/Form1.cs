using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Newtonsoft.Json;

namespace Developer_Toolbox
{
    public partial class Form1 : Form
    {
        public List<Option> options = new List<Option>
        {
            new Option("Base64 -> Text", originalText =>
            {
                if (string.IsNullOrWhiteSpace(originalText)) return string.Empty;
                return Encoding.UTF8.GetString(Convert.FromBase64String(originalText));
            }),
            new Option("Text -> Base64", originalText =>
            {
                if (string.IsNullOrWhiteSpace(originalText)) return string.Empty;
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(originalText));
            }),
            new Option("Binary -> Text", originalText =>
            {
                if (string.IsNullOrWhiteSpace(originalText)) return string.Empty;
                var parts = originalText.Split(new[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                var bytes = new byte[parts.Length];
                for (int i = 0; i < parts.Length; i++)
                {
                    bytes[i] = Convert.ToByte(parts[i], 2);
                }
                return Encoding.UTF8.GetString(bytes);
            }),
            new Option("Text -> Binary", originalText =>
            {
                if (string.IsNullOrWhiteSpace(originalText)) return string.Empty;
                var bytes = Encoding.UTF8.GetBytes(originalText);
                var sb = new StringBuilder();
                foreach (var b in bytes)
                {
                    sb.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
                    sb.Append(' ');
                }
                return sb.ToString().TrimEnd();
            }),
            new Option("Hex -> Text", originalText =>
            {
                if (string.IsNullOrWhiteSpace(originalText)) return string.Empty;
                originalText = Regex.Replace(originalText, @"\s+", ""); // удалить пробелы
                if (originalText.Length % 2 != 0) throw new FormatException("Hex string must have even length");
                var bytes = new byte[originalText.Length / 2];
                for (int i = 0; i < bytes.Length; i++)
                    bytes[i] = Convert.ToByte(originalText.Substring(i * 2, 2), 16);
                return Encoding.UTF8.GetString(bytes);
            }),
            new Option("Text -> Hex", originalText =>
            {
                if (string.IsNullOrWhiteSpace(originalText)) return string.Empty;
                var bytes = Encoding.UTF8.GetBytes(originalText);
                var sb = new StringBuilder(bytes.Length * 2);
                foreach (var b in bytes) sb.AppendFormat("{0:x2}", b);
                return sb.ToString();
            }),
            new Option("Unicode -> Text", originalText =>
            {
                if (string.IsNullOrWhiteSpace(originalText)) return string.Empty;
                return Regex.Replace(originalText, @"\\u([0-9a-fA-F]{4})", m =>
                {
                    int code = Convert.ToInt32(m.Groups[1].Value, 16);
                    return ((char)code).ToString();
                });
            }),
            new Option("Text -> Unicode", originalText =>
            {
                if (string.IsNullOrWhiteSpace(originalText)) return string.Empty;
                var sb = new StringBuilder();
                foreach (var ch in originalText)
                {
                    sb.AppendFormat("\\u{0:x4}", (int)ch);
                }
                return sb.ToString();
            }),
            new Option("Json -> Xml", originalText =>
            {                
                if (string.IsNullOrWhiteSpace(originalText)) return string.Empty;
                try
                {
                    return JsonConvert.DeserializeXNode(originalText, "rootName").ToString();
                }
                catch (Exception ex)
                {
                    return $"/* Error XML->JSON: {ex.Message} */";
                }
            }),
            new Option("Xml -> Json", originalText =>
            {
                if (string.IsNullOrWhiteSpace(originalText)) return string.Empty;
                try
                {
                    var doc = new XmlDocument();
                    doc.LoadXml(originalText);
                    return JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented, omitRootObject: false);
                }
                catch (Exception ex)
                {
                    return $"/* Error JSON->XML: {ex.Message} */";
                }
            }),
            new Option("URL -> Text", originalText =>
            {                
                if (string.IsNullOrWhiteSpace(originalText)) return string.Empty;
                return System.Web.HttpUtility.UrlDecode(originalText);
            }),
            new Option("Text -> URL", originalText =>
            {               
                if (string.IsNullOrWhiteSpace(originalText)) return string.Empty;
                return System.Web.HttpUtility.UrlEncode(originalText);
            }),
            new Option("GUID generator", originalText =>
            {
                return Guid.NewGuid().ToString();
            })
        };
        public Form1()
        {
            InitializeComponent();
            foreach (var option in options)
            {
                choseOptionComboBox.Items.Add(option.Name);
            }
        }
        private void Transform(object sender, EventArgs e)
        {
            var selectedOption = choseOptionComboBox.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedOption))
                return;
            foreach (var item in options)
            {
                if (item.Name == selectedOption)
                {
                    string result = item.Function(inRichTextBox.Text);
                    outRichTextBox.Text = result;
                    if (autoCopyCheckBox.Checked)
                    {
                        Clipboard.SetText(outRichTextBox.Text);
                    }
                    return;
                }
            }
        }
    }
    public class Option
    {
        public string Name { get; set; }
        public Func<string, string> Function { get; set; }
        public Option(string name, Func<string, string> function)
        {
            Name = name;
            Function = function;
        }
    }
}
