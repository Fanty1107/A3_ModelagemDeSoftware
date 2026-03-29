namespace A3_modelagem
{
    internal class Videos
    {
        //videos postados pelos editores
        public Editor Editor { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public int Views { get; set; }
        public Videos(Editor editor,string title, string description, string url, int views)
        {
            Editor = editor;
            Title = title;
            Description = description;
            Url = url;
            Views = views;
        }
    }
}
