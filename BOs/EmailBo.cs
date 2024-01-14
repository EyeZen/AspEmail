namespace EmailApp.DTOs
{
    public class EmailBo
    {
        /// <summary>
        /// Email subject
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Email body (HTML format)
        /// </summary>
        public string Body { get; set; }
    }
}
