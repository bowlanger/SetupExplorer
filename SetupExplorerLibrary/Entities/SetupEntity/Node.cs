﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupExplorerLibrary.Entities.SetupEntity
{
    public class Node
    {
        
        public string Name { get; set; }

        public int Id { get; set; }
        public string Text { get; set; }

        public List<Property> Properties { get; set; } = new List<Property>();

        public Node(string name)
        {
            Name = name;
        }
    }
}