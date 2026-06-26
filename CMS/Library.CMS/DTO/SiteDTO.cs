using Library.CMS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.CMS.DTO
{
    public class SiteDTO
    {
        public string? Name { get; set; }
        private string? owner;

        public int Id { get; set; }
        public string? Owner
        {
            get
            {
                return owner;
            }
            set
            {
                if (owner != value)
                {
                    owner = value;
                }
            }
        }
        public List<string> Users { get; set; }
        public List<Page> Content { get; set; }

        public SiteDTO()
        {
            Users = new List<string>();
            Content = new List<Page>();
        }

        public override string ToString() => $"{Name}";

        public SiteDTO(Site s)
        {
            Name = s.Name;
            Owner = s.Owner;
            Id = s.Id;
            Content = s.Content;
            Users = s.Users;
        }
    }
}
