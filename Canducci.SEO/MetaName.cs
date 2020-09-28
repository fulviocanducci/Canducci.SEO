namespace Canducci.SEO
{
    public class MetaName: IMeta
    {
        public MetaName(string value, string content)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new System.ArgumentException($"'{nameof(value)}' cannot be null or empty", 
                    nameof(value));
            }

            if (string.IsNullOrEmpty(content))
            {
                throw new System.ArgumentException($"'{nameof(content)}' cannot be null or empty", nameof(content));
            }

            Value = value;
            Content = content;
        }
        public string TypeName => "name";
        public string Value { get; set; }
        public string Content { get; set; }

        public static implicit operator string(MetaName meta)
        {
            return $"<meta {meta.TypeName}=\"{meta.Value}\" content=\"{meta.Content}\" />";
        }
    }
}
