namespace Messages
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Post
    {
        public int Id { get; set; }

        public int Author_id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public virtual Author Author { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
