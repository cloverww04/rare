﻿namespace rare.Models
{
    public class Posts
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string? title { get; set; }
        public DateTime PublicationDate { get; set; }
        public string? Content { get; set; }
        public bool Approved { get; set; }

        public List<Comments>? Comments { get; set; }
    }
}
