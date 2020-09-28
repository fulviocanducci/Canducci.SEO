namespace Canducci.SEO
{
    public class MetaProperty : IMeta
    {
        public MetaProperty(string value, string content)
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

        public string TypeName => "property";
        public string Value { get; set; }
        public string Content { get; set; }

        public static implicit operator string(MetaProperty meta)
        {
            return $"<meta {meta.TypeName}=\"{meta.Value}\" content=\"{meta.Content}\" />";
        }
    }
}
