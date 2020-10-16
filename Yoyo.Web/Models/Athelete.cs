using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yoyo.Web.Models
{
    /// <summary>
    /// Model representing properties to an Athelete
    /// Note how it is inherited from BaseEntity with Id as int data type.
    /// </summary>
    public class Athelete : BaseEntity<int>
    {
        public string Name { get; set; }
    }


    /// <summary>
    /// Model having properties of Getting and Setting Athelete Status
    /// </summary>
    public class AtheleteStatus
    {
        //public int Id { get; set; }
        public int AtheleteId { get; set; }
        public string Status { get; set; }
        public string Score { get; set; }
    }
}
